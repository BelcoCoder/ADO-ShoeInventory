using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ShoeId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public byte No { get; set; }
    }
}
