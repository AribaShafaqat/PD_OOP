using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PD1
{
    internal class Program
    {
    
            static void Main(string[] args)
            {

                string[] plant = new string[10];
                int[] price = new int[10];
                int[] quantity = new int[10];
                int Count = 0;


                string inventoryPath = "C:\\Users\\dell\\Documents\\OOP\\week\\Week1\\Week1\\data.txt.txt";


                readPlanttData(inventoryPath, plant, price, ref Count);
                char option;
                do
                {

                    option = Owner_menu();
                if(option=='1')
                {
                    viewPlants(plant, price, Count);
                }
                    if (option == '2')
                    {
                        Console.WriteLine("Enter Plant Name: ");
                        string newPlant = Console.ReadLine();
                        Console.WriteLine("Enter Price: ");
                        int newPrice = int.Parse(Console.ReadLine());

                        addItem(newPlant, newPrice, plant, price, ref Count);
                    }
                    if (option == '3')
                    {
                        viewPlants(plant, price, Count);
                        Console.WriteLine("Enter Plant Name you want to Update: ");
                        string newPlant = Console.ReadLine();
                        updatePlant(newPlant, plant, price, ref Count);
                    }
                    if (option == '4')
                    {
                        viewPlants(plant, price, Count);
                        Console.WriteLine("Enter Plant Name you want to Delete: ");
                        string newPlant = Console.ReadLine();
                        deletePlant(newPlant, plant, price, ref Count);
                    }
                    savePlantData(inventoryPath, plant, price, Count);
                } while (option != '5');


            }
            static char Owner_menu()
            {
                Console.Clear();
                char option;
                Console.WriteLine("Press 1 to View Stock:");
                Console.WriteLine("Press 2 to Add a New Plant:");
                Console.WriteLine("Press 3 to Update an Exisitng Plant: ");
                Console.WriteLine("Press 4 to Delete a Plant:");
                Console.WriteLine("Press 5 to Exit: ");
                Console.WriteLine("Enter Option: ");
                option = char.Parse(Console.ReadLine());
                return option;
            }
            static void addItem(string newPlant, int newPrice, string[] plant, int[] price, ref int Count)
            {
                if (Count <= 9)
                {
                    plant[Count] = newPlant;
                    price[Count] = newPrice;
                    Count++;
                }
            }
            static void viewPlants(string[] plant, int[] price, int Count)
            {
                Console.WriteLine("Plant\tPrice");
                for (int x = 0; x < Count; x++)
                {
                    Console.WriteLine(plant[x] + "\t" + price[x]);
                }
            }
            static int findPlant(string newPlant, string[] plant, int Count)
            {
                for (int x = 0; x < Count; x++)
                {
                    if (newPlant == plant[x])
                    {
                        return x;
                    }
                }
                return -1;
            }
            static void clearScreen()
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            static void updatePlant(string newPlant, string[] plant, int[] price, ref int Count)
            {
                int idx = findPlant(newPlant, plant, Count);
                if (idx >= 0 && idx <= 9)
                {
                    Console.WriteLine("Plant Found");
                    Console.WriteLine("Enter the Updated price");
                    int newPrice = int.Parse(Console.ReadLine());
                    price[idx] = newPrice;

                }
                else
                {
                    clearScreen();
                    Console.WriteLine("Plant Does Not Exists.");
                }
            }
            static void deletePlant(string newPlant, string[] plant, int[] price, ref int Count)
            {
                int idx = findPlant(newPlant, plant, Count);
                if (idx >= 0 && idx <= 9)
                {
                    Console.WriteLine("Plant Found");
                    for (int x = idx; x <Count - 1; x++)
                    {
                        plant[x] = plant[x + 1];
                        price[x] = price[x + 1];

                    }
                    Count++;
                }
            }
            static void savePlantData(string inventoryPath, string[] plant, int[] price, int Count)
            {
                StreamWriter f1 = new StreamWriter(inventoryPath, false);
                for (int x = 0; x < Count; x++)
                {
                    f1.WriteLine(plant[x] + "," + price[x]);
                }
                f1.Flush();
                f1.Close();
            }
            static string parseData(string record, int field)
            {
                int comma = 1;
                string item = "";
                for (int x = 0; x < record.Length; x++)
                {
                    if (record[x] == ',')
                    {
                        comma++;
                    }
                    else if (comma == field)
                    {
                        item = item + record[x];
                    }
                }
                return item;
            }
            static void readPlanttData(string inventoryPath, string[] plant, int[] price, ref int Count)
            {
                StreamReader fp = new StreamReader(inventoryPath);
                string record;
                while ((record = fp.ReadLine()) != null)
                {
                    if (Count > 9)
                    {
                        break;
                    }
                    plant[Count] = parseData(record, 1);
                    price[Count] = int.Parse(parseData(record, 2));
                    Count++;
                }
                fp.Close();
            }

        }
    }




