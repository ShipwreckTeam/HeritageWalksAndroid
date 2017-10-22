using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace HeritageWalks
{
    public class DataAPI
    {
        HttpClient client = new HttpClient();

        public async Task<List<Stop>> GetStopsAsync()
        {
            client.BaseAddress = new Uri("http://heritagetrailsapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Stop> stopList = new List<Stop>();

            try
            {
                var response = await client.GetAsync("api/Stops");

                var result = await response.Content.ReadAsStringAsync();
                var stopsJson = JsonConvert.DeserializeObject<List<Stop>>(result);

                foreach (Stop stop in stopsJson)
                {
                    stopList.Add(stop);
                }
                return stopList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return stopList;
        }

        public async Task<List<Trail>> GetTrailsAsync()
        {
            client.BaseAddress = new Uri("http://heritagetrailsapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<Trail> trailList = new List<Trail>();

            try
            {
                var response = await client.GetAsync("api/Trails");

                var result = await response.Content.ReadAsStringAsync();
                var trailsJson = JsonConvert.DeserializeObject<List<Trail>>(result);

                foreach (Trail trail in trailsJson)
                {
                    trailList.Add(trail);
                }
                return trailList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return trailList;
        }

        public async Task<List<DetailStop>> GetDetailStopsAsync()
        {
            client.BaseAddress = new Uri("http://heritagetrailsapi.azurewebsites.net");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            List<DetailStop> detailStopList = new List<DetailStop>();

            try
            {
                var response = await client.GetAsync("api/DetailStops");

                var result = await response.Content.ReadAsStringAsync();
                var detailStopsJson = JsonConvert.DeserializeObject<List<DetailStop>>(result);

                foreach (DetailStop detailStop in detailStopsJson)
                {
                    detailStopList.Add(detailStop);
                }
                return detailStopList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return detailStopList;
        }
    }
}