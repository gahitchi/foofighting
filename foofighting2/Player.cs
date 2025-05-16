using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foofighting2
{
    internal class Player
    {
        public string Name { get; private set; }
        public int HP { get; set; }
        public double DefenseChance { get; private set; }

        public Player(string name)
        {
            Name = name;
            var rand = new Random(Guid.NewGuid().GetHashCode());

            // Start with 200–500 HP
            HP = rand.Next(200, 501);

            // Defense chance between 0% and 100%
            DefenseChance = rand.Next(0, 101) / 100.0;
        }
    }
}
