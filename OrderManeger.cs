using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorano_sistema
{
    public class OrderManager
    {
        private List<Table> tables = new List<Table>();
        private List<Item> foodMenu;
        private List<Item> drinkMenu;

        public OrderManager(string foodFilePath, string drinksFilePath)
        {
            foodMenu = LoadItemsFromFile(foodFilePath);
            drinkMenu = LoadItemsFromFile(drinksFilePath);
            InitializeTables();
        }

        private List<Item> LoadItemsFromFile(string filePath)
        {
            return File.ReadAllLines(filePath)
                       .Select(line =>
                       {
                           var parts = line.Split(',');
                           return new Item { Name = parts[0], Price = decimal.Parse(parts[1]) };
                       }).ToList();
        }

        private void InitializeTables()
        {
            tables = new List<Table>
            {
            new Table { TableNumber = 1, Seats = 4 },
            new Table { TableNumber = 2, Seats = 2 },
            new Table { TableNumber = 3, Seats = 6 }
            };
        }

        public void CreateOrder(int tableNumber, List<Item> items, bool printClientReceipt, string clientEmail = null)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber && !t.IsOccupied);

            if (table == null)
            {
                Console.WriteLine("Staliukas nerastas arba uzimtas!");
                return;
            }

            table.MarkOccupied();
            var order = new Order { Table = table, Items = items };

            // Generuoti cekius
            var restaurantReceipt = new RestaurantReceiptImpl();
            var clientReceipt = new CLientReceiptImpl();

            restaurantReceipt.Print(order);
            if (printClientReceipt)
            {
                clientReceipt.Print(order);
                if (!string.IsNullOrEmpty(clientEmail))
                    clientReceipt.SendByEmail(order, clientEmail);
            }
        }

        public void MarkTableAsAvailable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table != null) table.MarkAvailable();
        }

        public void ShowTables()
        {
            tables.ForEach(t => Console.WriteLine(t));
        }

        public List<Item> GetFoodMenu() => foodMenu;
        public List<Item> GetDrinkMenu() => drinkMenu;

        public bool? MarkTableAsAvailable()
        {
            throw new NotImplementedException();
        }

        public object GetTables()
        {
            throw new NotImplementedException();
        }
    }

}
