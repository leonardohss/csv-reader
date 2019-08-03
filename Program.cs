using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using CsvReader.Entities;

namespace CsvReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathSource = @"c:\temp\file1.csv";
            string targetPath = @"c:\temp\file2.csv";

            List<Product> products = new List<Product>();
            
            try
            {
                using (StreamReader sr = File.OpenText(pathSource))
                {
                    int x = 0; 
                    while (!sr.EndOfStream)
                    {
                        string[] line = (sr.ReadLine().Split(','));
                        string name = line[0];
                        double price = double.Parse(line[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(line[2]);
                        products.Add(new Product(name, price, quantity));
                        x++;
                    }
                    using (StreamWriter sw = File.AppendText(targetPath))
                    {
                        foreach (Product product in products)
                        {
                            sw.WriteLine(product);
                        }
                    }
                }

                foreach (Product product in products)
                {
                    Console.WriteLine(product); 
                }  
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
