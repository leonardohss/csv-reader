﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CsvReader.Entities
{
    class Product
    {
        public string name { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }

        public Product() { }

        public Product(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public double Total()
        {
            return price * quantity;
        }

        public override string ToString()
        {
            return name + "," + Total().ToString("F2"); 
        }
    }
}
