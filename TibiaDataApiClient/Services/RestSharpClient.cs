using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaDataApiClient.Responses.GetCharacter;
using TibiaDataApiClient.Responses.GetSpecificWorld;

namespace TibiaDataApiClient.Services
{
    public class RestSharpClient : IRestSharpClient
    {
        private RestClient client;

        public RestSharpClient()
        {
            this.client = new RestClient("https://api.tibiadata.com/v2");
        }

        public async Task<GetCharacterResponse> GetCharacterAsync(string name)
        {
            var request = new RestRequest($"characters/{name}.json", DataFormat.Json);

            GetCharacterResponse response = await this.client.GetAsync<GetCharacterResponse>(request);

            return response;
        }

        public async Task<GetSpecificWorldResponse> GetSpecificWorldAsync(string world)
        {
            var request = new RestRequest($"world/{world}.json", DataFormat.Json);

            var response = await this.client.GetAsync<GetSpecificWorldResponse>(request);

            return response;
        }

    }
}
