using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using SaltBot.Commands;

namespace SaltBot
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            string json = "";
            using (FileStream fs = File.OpenRead(@"..\..\..\config.json"))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            ConfigJSON configJSON = JsonConvert.DeserializeObject<ConfigJSON>(json);

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = configJSON.Token,
                TokenType = TokenType.Bot
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefix = configJSON.Prefix
            });

            commands.RegisterCommands<Command1>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

}
