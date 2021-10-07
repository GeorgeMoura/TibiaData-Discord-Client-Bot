using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TibiaDataApiClient.Responses.GetCharacter;
using TibiaDataApiClient.Responses.GetSpecificWorld;
using TibiaDataApiClient.Services;
using TibiaDiscordBot.Common.Utils;
using TibiaDiscordBot.Services;

namespace TutorialBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {

        private TibiaDataService tibiaDataService;
        private readonly string ErrorMessage = "Não foi possível completar a consulta.";

        public Commands(TibiaDataService tibiaDataService)
        {
            this.tibiaDataService = tibiaDataService;
        }

        [Command("character")]
        public async Task GetCharacter([Remainder] string characterName)
        {
            GetCharacterResponse response = await tibiaDataService.GetCharacter(characterName);

            await discordReplyAsync(CheckSuccessAndReturnResponse(response));
        }

        [Command("world")]
        public async Task GetSpecificWorld([Remainder] string worldName)
        {
            GetSpecificWorldResponse response = await tibiaDataService.GetSpecificWorld(worldName);

            await discordReplyAsync(CheckSuccessAndReturnResponse(response));
        }

        [Command("meanlevel")]
        public async Task GetMeanLevelOfPlayersOnline([Remainder] string worldName)
        {
            string reply = await tibiaDataService.GetMeanLevelOfPlayersOnline(worldName);

            await ReplyAsync(reply);
        }

        [Command("findparty")]
        public async Task GetShareablePlayersToParty([Remainder] string playersName)
        {
            string reply = await tibiaDataService.GetShareablePlayersToParty(playersName);

            await discordReplyAsync(reply);
        }

        private string CheckSuccessAndReturnResponse<T>(T obj)
        {
            string botReply;

            if (obj != null)
            {
                botReply = Serializer.Serialize(obj);
            }
            else
            {
                botReply = ErrorMessage;
            }

            return botReply;
        }

        private async Task discordReplyAsync(string response)
        {
            if (response.Length >= 2000)
            {
                await replyBuffer(response);
            }
            else
            {
                await ReplyAsync(response);
            }
        }

        private async Task replyBuffer(string response)
        {
            string responseString;
            int charactersLeft = response.Length;
            int startIndex = 0;

            while (charactersLeft > 0)
            {
                responseString = response.TruncateLongString(startIndex, 2000);
                charactersLeft -= responseString.Length;
                startIndex += 2000;
                await ReplyAsync(responseString);
            }
        }
    }
}