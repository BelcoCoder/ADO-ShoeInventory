using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum InventoryMovementType
    {
        Out,
        In
    }
    public class InventoryMovement
    {
        public int ShoeId { get; set; }
        public int Count { get; set; }
        public byte No { get; set; }
        public InventoryMovementType Type { get; set; }
    }
}
