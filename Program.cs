using Restorano_sistema;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestoranoSistema
{
    public class Program
    {
        static void Main(string[] args)
        {
            var manager = new OrderManager("food.txt", "drinks.txt");
            // Parodyti maisto meniu
            Console.WriteLine("Maisto meniu:");
            var foodMenu = manager.GetFoodMenu();
            for (int i = 0; i < foodMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {foodMenu[i].Name} - {foodMenu[i].Price:C}");
            }

            // Parodyti gėrimų meniu
            Console.WriteLine("\nGėrimų meniu:");
            var drinkMenu = manager.GetDrinkMenu();
            for (int i = 0; i < drinkMenu.Count; i++)
            {
                Console.WriteLine($"{i + 1 + foodMenu.Count}. {drinkMenu[i].Name} - {drinkMenu[i].Price:C}");
            }

            // Kliento prekių pasirinkimas
            Console.WriteLine("\nPasirinkite prekes iš meniu (įveskite prekių numerius, atskirtus kableliais):");
            var selection = Console.ReadLine();
            var selectedItems = new List<Item>();

            // Apdoroti pasirinkimą
            var selectedNumbers = selection.Split(',')
                                            .Select(num => int.Parse(num.Trim()) - 1)
                                            .ToList();

            foreach (var number in selectedNumbers)
            {
                if (number >= 0 && number < foodMenu.Count)
                {
                    selectedItems.Add(foodMenu[number]);
                }
                else if (number >= foodMenu.Count && number < foodMenu.Count + drinkMenu.Count)
                {
                    selectedItems.Add(drinkMenu[number - foodMenu.Count]);
                }
                else
                {
                    Console.WriteLine($"Netinkamas pasirinkimas: {number + 1}");
                }
            }

            // Rinktis staliuką
            manager.ShowTables();
            Console.WriteLine("\nPasirinkite staliuko numerį: ");
            int tableNumber = int.Parse(Console.ReadLine());

            // Sukurti užsakymą
            manager.CreateOrder(tableNumber, selectedItems, printClientReceipt: true, clientEmail: "klientas@example.com");

            // Pažymėti staliuką kaip laisvą
            manager.MarkTableAsAvailable(tableNumber);
            manager.ShowTables();
           
        }
    }
}
