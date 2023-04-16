using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Program
    {
        class Owner
        {
            public string plant;
            public int price;
        }
        static void Main(string[] args)
        {
            List<Owner> data = new List<Owner>();
            

            string inventoryPath = "C:\\Users\\dell\\Documents\\OOP\\week\\Week1\\.vs\\file.txt.txt";
            readplantData(inventoryPath, data);
            char option;
            do
            {

                option = ownerMenu();
                if (option =='1')
                {
                    viewstock(data);
                    Console.ReadKey();
                }
                if (option == '2')
                {
                    Console.WriteLine("Enter plant Name: ");
                    string newplant = Console.ReadLine();
                    Console.WriteLine("Enter Price: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    add(newplant, newPrice, data);
                }
                if (option == '3')
                {
                    viewstock(data);
                    Console.WriteLine("Enter Plant Name you want to Delete: ");
                    string newplant = Console.ReadLine();
                    deleteplant(newplant, data);

                }
                if (option == '4')
                {
                    viewstock(data);
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newplant = Console.ReadLine();
                    update(newplant, data);
                }
                saveplantData(inventoryPath, data);
            }
            while (option!=5);
        }



        static char ownerMenu()
        {
            Console.Clear();
            char option;
            Console.WriteLine("1. View Stock ");
            Console.WriteLine("2. Add a plant ");
            Console.WriteLine("3. Delete a plant ");
            Console.WriteLine("4. Update Price");
            option=Char.Parse(Console.ReadLine());
            return option;

        }
        static void viewstock(List<Owner> data)
        {
            Owner info = new Owner();
            Console.WriteLine("Plant\t Price");
            for (int x = 0; x < data.Count; x++)
            {
                Console.WriteLine(info.plant + "\t" + info.price);
            }
        }
        static void add(string newplant, int newprice, List<Owner> data)
        {
            Owner info = new Owner();
 
                info.plant=newplant;
                info.price=newprice;
                data.Add(info);
            
        }
        static int findplant(string newplant, List<Owner> data)
        {
            Owner info = new Owner();
            for (int x = 0; x < data.Count; x++)
            {
                if (newplant == info.plant)
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
        static void deleteplant(string newplant, List<Owner> data)
        {
            Owner info = new Owner();
            int idx = findplant(newplant, data);
            if (idx >= 0 && idx <= 9)
            {
                Console.WriteLine("Plant Found");
                data.RemoveAt(idx);
            }
        }
        static void update(string newplant, List<Owner> data)
        {
            Owner info = new Owner();
            int idx = findplant(newplant, data);
            if (idx >= 0 && idx <= 9)
            {
                Console.WriteLine("Plant Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                info.price = newPrice;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Plant Does Not Exists.");
            }
        }

    

        
        static void saveplantData(string inventoryPath, List<Owner> data)
        {
            StreamWriter f1 = new StreamWriter(inventoryPath, false);
            Owner info = new Owner();
            for (int x = 0; x < data.Count; x++)
            {
                f1.WriteLine(info.plant + "," + info.price + ",");
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
        static void readplantData(string inventoryPath, List<Owner> data)
        {
            StreamReader fp = new StreamReader(inventoryPath);
            string record;
            while ((record = fp.ReadLine()) != null)
            {
                
                Owner info = new Owner();
                info.plant = parseData(record, 1);
                info.price = int.Parse(parseData(record, 2));
                data.Add(info);
            }
            fp.Close();
        }
    }
}
