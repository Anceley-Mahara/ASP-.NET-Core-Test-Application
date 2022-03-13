using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Models
{
    public class PropertyModel
    {
        public int propertyID { get; set; }
        public string Name { get; set; }
        public string streetAddress { get; set; }
        public string City { get; set; }
        public string Market { get; set; }
        public string State { get; set; }
    }
}
