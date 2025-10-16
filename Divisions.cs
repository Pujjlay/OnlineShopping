using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping
{
    //Abteilungen
    internal class Divisions(string Factory, string Home, string Outside, string Event)
    {
        public string Factory { get; set; }

        public string Home { get; set; }

        public string Outside { get; set; }

        public string Event { get; set; }
    }
}