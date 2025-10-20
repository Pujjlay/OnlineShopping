using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Division
    {
        public string Name { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public Division(string name)
        {
            Name = name;
        }

    }
}
