using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DoraLux
{
    //Basic class
    internal abstract class User(string name) // Divisions to User and to class abstract changed because no logic was with Divions beginnen
    {
        public string Name { get; set; } = name;

        public abstract void DisplayMenu();

    }
}