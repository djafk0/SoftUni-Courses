using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : HealerHero
    {
        private const int DefaultPower = 80;

        public Druid(string name)
            : base(name, DefaultPower)
        {
        }
    }
}
