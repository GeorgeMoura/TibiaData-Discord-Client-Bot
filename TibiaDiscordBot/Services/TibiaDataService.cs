using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TibiaDataApiClient.Responses.GetCharacter;
using TibiaDataApiClient.Responses.GetSpecificWorld;
using TibiaDataApiClient.Services;

namespace TibiaDiscordBot.Services
{
    public class TibiaDataService
    {
        private readonly IRestSharpClient tibiaApiClient;

        public TibiaDataService(IRestSharpClient tibiaApiClient)
        {
            this.tibiaApiClient = tibiaApiClient;
        }

        public async Task<GetCharacterResponse> GetCharacter(string characterName)
        {
            try
            {
                return await tibiaApiClient.GetCharacterAsync(adjustCharactername(characterName));
            }
            catch (Exception)
            {
                Console.WriteLine("Error on GetCharacter call");
                return null;
            }
        }

        public async Task<GetSpecificWorldResponse> GetSpecificWorld(string worldName)
        {
            try
            {
                return await tibiaApiClient.GetSpecificWorldAsync(worldName);
            }
            catch (Exception)
            {
                Console.WriteLine("Error on GetSpecificWorld call");
                return null;
            }
        }

        public async Task<string> GetMeanLevelOfPlayersOnline(string worldName)
        {
            GetSpecificWorldResponse world = await GetSpecificWorld(worldName);

            int levelSum = 0;
            int maxLevel = 0;
            int minLevel = int.MaxValue;
            string maxLevelName = string.Empty;
            string maxLevelVoc = string.Empty;
            string minLevelName = string.Empty;
            string minLevelvoc = string.Empty;

            try
            {
                foreach (Player player in world.world.players_online)
                {

                    if (player.level > maxLevel)
                    {
                        maxLevel = player.level;
                        maxLevelName = player.name;
                        maxLevelVoc = player.vocation;
                    }

                    if (player.level < minLevel)
                    {
                        minLevel = player.level;
                        minLevelName = player.name;
                        minLevelvoc = player.vocation;
                    }

                    levelSum += player.level;
                }
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return "Ops!";
            }
            decimal meanLevel = decimal.Round(levelSum / world.world.players_online.Count);

            string botReply = @"O jogador de maior level é " + maxLevelName + " - level " + maxLevel.ToString() + " - " + maxLevelVoc + "\n" +
                               "O jogador de menor level é " + minLevelName + " - level " + minLevel.ToString() + " - " + minLevelvoc + "\n" +
                               "A média de level do servidor é " + meanLevel.ToString();

            return botReply;
        }

        private string adjustCharactername(string characterName)
        {
            string[] splittedString = characterName.Split(' ');

            if (splittedString.Length > 1)
                return string.Join("+", splittedString);

            return characterName;
        }

        private string formatResponse(string response)
        {
            JToken jt = JToken.Parse(response);
            return jt.ToString(Formatting.Indented);
        }

    }
}
