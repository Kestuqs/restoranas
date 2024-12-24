using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public class Table
    {
        public int TableNumber { get; set; }
        public int Seats { get; set; }
        public bool IsOccupied { get; set; } = false;

        public void MarkOccupied() => IsOccupied = true;
        public  void MarkAvailable() => IsOccupied = false;

        public override string ToString() => $"Staliukas {TableNumber} ({Seats} vietu) - {(IsOccupied ? "Uzimtas" : "Laisvas")}";
       
        
    }
}
