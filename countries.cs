using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace watherstack
{
        public class country
        {
            public bool error { get; set; }
            public string msg { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string country { get; set; }
            public string[] cities { get; set; }
        }

    }

