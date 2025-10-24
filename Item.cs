using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoraLux
{
    internal class Item(string name, double price)
    {
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
    }
}
