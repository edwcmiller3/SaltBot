using Newtonsoft.Json;

namespace SaltBot
{
    public struct ConfigJSON
    {
        [JsonProperty("Token")]
        public string Token { get; private set; }

        [JsonProperty("Prefix")]
        public string Prefix { get; private set; }
    }
}