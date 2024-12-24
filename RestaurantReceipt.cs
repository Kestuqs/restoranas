using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public class RestaurantReceiptImpl : IReceipt
    {
        public void Print(Order order)
        {
            Console.WriteLine("\n--- Restorano cekis ---");
            Console.WriteLine(order.ToString());

            // Irasymas i faila
            File.AppendAllText("restaurant_receiptc.txt", $"{order}\n\n");
        }

        public void SendByEmail(Order order, string email)
        {
            Console.WriteLine($"[Restoranui skirtas cekis issiustas el. pastu: {email}]");
        }
    }

}
