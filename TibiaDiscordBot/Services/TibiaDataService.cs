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
            catch (Exception ex)
            {
                Console.WriteLine("Error on GetCharacter call: " + ex.Message + " - name: " + characterName);
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
            Player maxPlayer = new Player();
            Player minPlayer = new Player();
            maxPlayer.level = 0;
            minPlayer.level = int.MaxValue;

            try
            {
                foreach (Player player in world.world.players_online)
                {
                    maxPlayer = player.level > maxPlayer.level ? player : maxPlayer;
                    minPlayer = player.level < minPlayer.level ? player : minPlayer;
                    levelSum += player.level;
                }
            }catch(NullReferenceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return "Ops!";
            }

            decimal meanLevel = decimal.Round(levelSum / world.world.players_online.Count);

            string botReply = @"A quantidade de players online em " + world.world.world_information.name + " é " + world.world.players_online.Count.ToString() + "\n" +
                               "O jogador de maior level é " + maxPlayer.name + " - level " + maxPlayer.level.ToString() + " - " + maxPlayer.vocation + "\n" +
                               "O jogador de menor level é " + minPlayer.name + " - level " + minPlayer.level.ToString() + " - " + minPlayer.vocation + "\n" +
                               "A média online de level do servidor é " + meanLevel.ToString();

            return botReply;
        }

        public async Task<string> GetShareablePlayersToParty(string playersString)
        {
            StringBuilder sb = new StringBuilder();
            List<string> playerNames = playersString.Split("-p").Select(name => name.Trim()).ToList();
            playerNames.RemoveAll(str => str == string.Empty);

            int minLevelParty = 0;
            int maxLevelParty = int.MaxValue;
            string world = string.Empty;
            List<string> vocationsLeft = new List<string>() { "Master Sorcerer", "Elder Druid", "Elite Knight", "Royal Paladin" };

            foreach(string player in playerNames)
            {
                var getCharacterResponse = await GetCharacter(player);

                if (getCharacterResponse == null) return "Error on character search";
                if (getCharacterResponse.characters.error != null)
                {
                    sb.AppendLine("Character \"" + player + "\" não localizado, continuando análise de party sem ele(a). \n");
                    continue;
                }
                if (world == string.Empty) world = getCharacterResponse.characters.data.world;

                vocationsLeft.Remove(getCharacterResponse.characters.data.vocation);

                var levelRange = GetSharedLevelRange(getCharacterResponse.characters.data.level);
                minLevelParty = levelRange.Item1 > minLevelParty ? levelRange.Item1 : minLevelParty;
                maxLevelParty = levelRange.Item2 < maxLevelParty ? levelRange.Item2 : maxLevelParty;
            }

            if(minLevelParty > maxLevelParty)
            {
                return "Sua party não pode sharear.";
            }

            var worldInformation = await GetSpecificWorld(world);
            
            sb.AppendLine("Lista de vocações faltantes online que estão no range de level da sua party: \n");

            foreach(string vocation in vocationsLeft)
            {
                var avaliableVocation = worldInformation.world.players_online.Where(player => player.vocation == vocation && 
                                                                                    player.level >= minLevelParty && 
                                                                                    player.level <= maxLevelParty)
                                                                                    .OrderByDescending(player => player.level);

                sb.AppendLine("Online " + vocation + "'s: \n");

                foreach(Player player in avaliableVocation)
                {
                    sb.AppendLine(player.name + " - " + player.vocation + " - " + player.level);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private Tuple<int, int> GetSharedLevelRange(int level)
        {
            int minRange = decimal.ToInt32(decimal.Round(level * 2 / 3));
            int maxRange = decimal.ToInt32(decimal.Round(level * 3 / 2));

            return new Tuple<int, int>(minRange, maxRange);
        }

        private string adjustCharactername(string characterName)
        {
            string[] splittedString = characterName.Split();

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
