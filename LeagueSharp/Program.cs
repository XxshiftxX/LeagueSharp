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
            Summoner me = Summoner.GetSummonerByName(Console.ReadLine());

            Console.WriteLine($"Lv.{me.SummonerLevel}) {me.Name} ({me.Id})");
        }
    }
}
