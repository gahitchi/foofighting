using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace foofighting2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>
            {
                //icarus,
                //baba,
                //ppanther,
                //clone,
                //emperor
            };
            for (int i = 1; i <= 10; i++)
            {
                players.Add(new Player($"player {i}"));
            }

            Console.WriteLine("START");
            Console.WriteLine($"total players: {players.Count}\n");

            Random rand = new Random();

            while (players.Count > 1)
            {
                // 2a) Pick two different random players
                int index1 = rand.Next(players.Count);
                int index2;
                do
                {
                    index2 = rand.Next(players.Count);
                } while (index2 == index1);

                Player p1 = players[index1];
                Player p2 = players[index2];

                Console.WriteLine($"next fight: {p1.Name} vs {p2.Name}");

                Player attacker = p1;
                Player defender = p2;

                while (attacker.HP > 0 && defender.HP > 0)
                {
                    int damage = rand.Next(1, 101);
                    Console.WriteLine($"{attacker.Name} attacks {defender.Name} with {damage} damage");
                    Thread.Sleep(500);

                    bool blockSuccess = rand.NextDouble() < defender.DefenseChance;
                    if (blockSuccess)
                    {
                        double blockPct = 0.5 + rand.NextDouble() * 0.5;
                        int blocked = (int)(damage * blockPct);
                        damage -= blocked;
                        Console.WriteLine($"{defender.Name} blocks {blocked} damage! damage inflicted: {damage}");
                        Thread.Sleep(500);
                    }

                    defender.HP -= damage;
                    Console.WriteLine($"{defender.Name} HP remaining: {Math.Max(defender.HP, 0)}\n");
                    Thread.Sleep(500);

                    if (defender.HP <= 0)
                        break;

                    Player temp = attacker;
                    attacker = defender;
                    defender = temp;
                }

                Player winner = attacker.HP > 0 ? attacker : defender;
                Player loser = attacker.HP > 0 ? defender : attacker;

                Console.WriteLine($"{winner.Name} wins! {loser.Name} is eliminated\n");
                Thread.Sleep(500);

                players.Remove(loser);
                Console.WriteLine($"fighters left: {players.Count}\n");
                Thread.Sleep(500);
            }

            if (players.Count == 1)
            {
                Console.WriteLine($"the winnner is {players[0].Name}");
                Thread.Sleep(500);
            }
            else
            {
                Console.WriteLine("all fighters died in combat");
                Thread.Sleep(500);
            }
        }
    }
}