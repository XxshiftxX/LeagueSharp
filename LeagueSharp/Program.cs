using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Summoner s = Summoner.GetSummonerByName(Console.ReadLine());

            Console.WriteLine($"Lv. {s.SummonerLevel}) {s.Name} (유저 ID : {s.Id})");

            Summoner sCopy = Summoner.GetSummonerByAccount(s.AccountId);

            Console.WriteLine($"Lv. {sCopy.SummonerLevel}) {sCopy.Name} (유저 ID : {sCopy.Id})");

            sCopy = Summoner.GetSummonerBySummonerID(s.Id);

            Console.WriteLine($"Lv. {sCopy.SummonerLevel}) {sCopy.Name} (유저 ID : {sCopy.Id})");
        }
    }
}
