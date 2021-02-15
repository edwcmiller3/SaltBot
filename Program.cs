using DSharpPlus;
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

        public class AppToken
        {
            public string Token { get; set; }
        }
        static async Task MainAsync()
        {
            string token = File.ReadAllText(@"..\..\..\token.txt");

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
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
