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

            Product[] products = new Product[10];
            
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
                        products[x] = new Product(name, price, quantity);
                        x++;
                    }
                }

                foreach(Product product in products)
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
