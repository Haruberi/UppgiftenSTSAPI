using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UppgiftenSTSAPI.Context;

namespace UppgiftenSTSAPI.Entities
{
    public class Dorm
    {
        public int id { set; get;  }
        public string name { get; set; }

        public IList<Student> students { get; set; }

    }
}
