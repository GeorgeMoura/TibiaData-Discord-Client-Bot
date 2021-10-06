using System.Threading.Tasks;
using TibiaDataApiClient.Responses.GetCharacter;
using TibiaDataApiClient.Responses.GetSpecificWorld;

namespace TibiaDataApiClient.Services
{
    public interface IRestSharpClient
    {
        Task<GetCharacterResponse> GetCharacterAsync(string name);
        Task<GetSpecificWorldResponse> GetSpecificWorldAsync(string world);
    }
}