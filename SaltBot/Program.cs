using DSharpPlus;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

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
            using (FileStream fs = File.OpenRead(@"..\..\..\token.json"))
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

            discord.MessageCreated += async e =>
            {
                if (e.Message.Content.ToLower().StartsWith("ping"))
                    await e.Message.RespondAsync("pong!");
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }

}
