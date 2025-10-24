using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Division(string name)
    {
        public string Name { get; set; } = name;
        public List<Item> Items { get; set; } = [];
    }
}
