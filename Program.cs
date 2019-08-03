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
            Console.Write("Enter the file full path: ");
            string sourceFilePath = Console.ReadLine();

            List<Product> products = new List<Product>();

            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\file2.csv";

                Directory.CreateDirectory(targetFolderPath);

                int x = 0;
                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    int quantity = int.Parse(fields[2]);

                    products.Add(new Product(name, price, quantity));
                    x++;
                }

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (Product product in products)
                    {
                        sw.WriteLine(product);
                        Console.WriteLine(product);
                    }
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
