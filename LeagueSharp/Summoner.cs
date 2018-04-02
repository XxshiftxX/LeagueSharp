using System.IO;
using System.Net;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace LeagueSharp
{
    class Summoner
    {
        #region Private Variables
        
        private int profileIconId;
        private string name;
        private long summonerLevel;
        private long revisionDate;
        private long id;
        private long accountId;
        #endregion

        #region Properties
        public int ProfileIconId { get => profileIconId; }
        public string Name { get => name; }
        public long SummonerLevel { get => summonerLevel; }
        public long RevisionDate { get => revisionDate; }
        public long Id { get => id; }
        public long AccountId { get => accountId; }
        #endregion

        private Summoner(int profileIconId, string name, long summonerLevel, long revisionDate, long id, long accountId)
        {
            this.profileIconId = profileIconId;
            this.name = name;
            this.summonerLevel = summonerLevel;
            this.revisionDate = revisionDate;
            this.id = id;
            this.accountId = accountId;
        }

        public static Summoner GetSummonerByName(string searchingName) => ExtractFromURL(LeagueSharp.urlPrefix + @"lol/summoner/v3/summoners/by-name/" + searchingName);

        public static Summoner GetSummonerByAccount(long SearchingId) => ExtractFromURL(LeagueSharp.urlPrefix + @"lol/summoner/v3/summoners/by-account/" + SearchingId);

        public static Summoner GetSummonerBySummonerID(long SearchingId) => ExtractFromURL(LeagueSharp.urlPrefix + @"lol/summoner/v3/summoners/" + SearchingId);

        private static Summoner ExtractFromURL(string requestURL)
        {
            string s = string.Empty;
            using (WebClient client = new WebClient())
            {
                client.QueryString.Add("api_key", LeagueSharp.API_KEY);
                client.Encoding = Encoding.UTF8;
                s = client.DownloadString(requestURL);
            }

            JObject jobject = JObject.Parse(s);

            int profileIconId = jobject["profileIconId"].Value<int>();
            string name = jobject["name"].Value<string>();
            long summonerLevel = jobject["summonerLevel"].Value<long>();
            long revisionDate = jobject["revisionDate"].Value<long>();
            long id = jobject["id"].Value<long>();
            long accountId = jobject["accountId"].Value<long>();

            return new Summoner(profileIconId, name, summonerLevel, revisionDate, id, accountId);
        }
    }
}
