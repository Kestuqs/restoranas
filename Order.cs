using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public class Order
    {
        public Table Table { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public DateTime OrderTime { get; set; } = DateTime.Now;

        public decimal TotalAmount => Items.Sum(item => item.Price);

        public override string ToString()
        {
            var itemsDescription = string.Join("\n", Items.Select(i => i.ToString()));
            return $"Staliukas: {Table.TableNumber}\nLaikas: {OrderTime}\nUžsakymai:\n{itemsDescription}\nBendra suma: {TotalAmount:C}";
        }
    }
}
