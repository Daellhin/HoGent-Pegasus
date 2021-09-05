using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pegasus.Models.Domain {
    public class Registration {
        public int Id { get; private set; }
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }

        public Registration() {
        }

        public Registration(string name) {
            Name = name;
            TimeStamp = DateTime.Now;
        }

        public override string ToString() {
            return $"{Name} {TimeStamp} ";
        }
    }
}
