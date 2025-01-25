using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Docker.Domain.Models
{
    public class Demo
    {
        public int DemoID { get; set; }
        public string? DemoName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Comments { get; set; }
    }
}
