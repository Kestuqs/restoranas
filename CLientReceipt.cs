using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public class CLientReceiptImpl : IReceipt
    {
        public void Print(Order order)
        {
            Console.WriteLine("\n--- Kliento cekis ---");
            Console.WriteLine($"Staliukas: {order.Table.TableNumber}");
            Console.WriteLine($"Uzsakyta:\n{string.Join("\n", order.Items.Select(i => i.ToString()))}");
            Console.WriteLine($"Bendra suma: {order.TotalAmount:C}");
        }
        public void SendByEmail(Order order, string email)
        {
            Console.WriteLine($"[Klientui skirtas cekis issiustas el. pastu: {email}]");
        }

    }
}
