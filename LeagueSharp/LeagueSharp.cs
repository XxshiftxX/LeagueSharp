using System.IO;

namespace LeagueSharp
{
    class LeagueSharp
    {
        public static readonly string urlPrefix = "https://kr.api.riotgames.com/";
        public static readonly string API_KEY = File.ReadAllText(@"D:\Test\key.txt");
    }
}
