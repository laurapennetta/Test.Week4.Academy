using Acquisti.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Acquisti.Client.API
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("ORDINI");
            HttpClient client = new HttpClient();
            Console.ReadKey();

            #region POST

            HttpRequestMessage postRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:5001/api/Ordini")
            };

            OrdineContract newOrd = new OrdineContract
            {
                CodiceOrdine ="or-43875",
                CodiceProdotto="pr-6524t98p0",
                DataOrdine = DateTime.Today,
                Importo = 23.5
            };

            string newOrdJson = JsonConvert.SerializeObject(newOrd);
            postRequest.Content = new StringContent(
                newOrdJson,
                Encoding.UTF8,
                "application/json"
            );

            var postResponse = await client.SendAsync(postRequest);

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = await postResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrdineContract>(data);

                Console.WriteLine($"Ordine added with ID = {result.ID}");
            }

            #endregion

            #region GET

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:5001/api/Ordini")
            };

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<OrdineContract>>(data);

                foreach (var item in result)
                {
                    Console.WriteLine($"[{item.ID}] " +
                        $"{item.DataOrdine} - {item.CodiceOrdine} - {item.CodiceProdotto} - {item.Importo}");
                }
            }

            #endregion

            #region GET BY ID

            Console.Write("ID (GET): ");

            string idGet = Console.ReadLine();
            HttpRequestMessage getByIDRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:5001/api/Ordini/{idGet}")
            };

            HttpResponseMessage getByIDResponse = await client.SendAsync(getByIDRequest);

            if (getByIDResponse.IsSuccessStatusCode)
            {
                string data = await getByIDResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrdineContract>(data);

                Console.WriteLine($"[{result.ID}] " +
                        $"{result.DataOrdine} - {result.CodiceOrdine} - {result.CodiceProdotto} - {result.Importo}");
            }

            #endregion

            #region PUT

            Console.Write("ID (PUT): ");
            string id = Console.ReadLine();

            HttpRequestMessage putRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:5001/api/Ordini/{id}")
            };

            int.TryParse(id, out int idVal);
            OrdineContract updatedOrd = new OrdineContract
            {
                ID = idVal,
                CodiceOrdine = "or-43875",
                CodiceProdotto = "pr-6524t98p0",
                DataOrdine = DateTime.Today,
                Importo = 27.5
            };

            string updatedOrdJson = JsonConvert.SerializeObject(updatedOrd);
            putRequest.Content = new StringContent(
                updatedOrdJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage putResponse = await client.SendAsync(putRequest);

            
            if (putResponse.IsSuccessStatusCode)
            {
                string data = await putResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrdineContract>(data);

                Console.WriteLine($"[{result.ID}] " +
                        $"{result.DataOrdine} - {result.CodiceOrdine} - {result.CodiceProdotto} - {result.Importo}");
            }

            #endregion

            #region DELETE

            Console.Write("ID (DELETE): ");
            string idDel = Console.ReadLine();

            HttpRequestMessage deleteRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"https://localhost:5001/api/Ordini/{idDel}")
            };

            HttpResponseMessage deleteResponse = await client.SendAsync(deleteRequest);

            
            if (deleteResponse.IsSuccessStatusCode)
            {
                Console.WriteLine($"Loan Successfully deleted.");
            }

            #endregion
        }
    }
}
