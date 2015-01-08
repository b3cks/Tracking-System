using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gMapForNet
{

    /// <summary>
    /// Meta data for a log file
    /// </summary>
    class Metadata
    {
        // metadata fields and default values
        public string name = "";
        public string starting = "";
        public string destination = "";

        public Metadata(string n, string s, string d)
        {
            this.name = n;
            this.starting = s;
            this.destination = d;
        }

        public override string ToString()
        {
            string info = "";
            info += "INFOMATION\n";
            info += "Route name: " + this.name + "\n";
            info += "Starting from: " + this.starting + "\n";
            info += "Destination: " + this.destination + "\n";
            return info;
        }
    }
}
