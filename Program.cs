using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;

namespace homework_1
{
    class Program
    {
        public static void add(List<int> bla) 
        {
            bla.Add(2);
            Console.WriteLine(bla);
        }



        static void Main()
        {


            /*
            check_del buble_check = Product.buble_check_by_days;
            List<Product> Produts_lt = new List<Product>();         
            Product temp1 = new Product("Milk", 35.90, 150, "25", "13.07.2021");
            Produts_lt.Add(temp1);
            Product temp2 = new Product("Meat", 35.90, 150, "3", "15.07.2021");
            Produts_lt.Add(temp2);
            Product temp3 = new Product("Bread", 35.90, 150, "30", "15.07.2021");
            Produts_lt.Add(temp3);
            Product[] Products_arr = new Product[Produts_lt.Count];


            for (int i = 0; i < Products_arr.Length; i++)
            {
                Console.WriteLine(i);
                Products_arr[i] = Produts_lt[i];
            }
            Sort_class.Sort(Products_arr, buble_check);

            for (int i = 0; i < Products_arr.Length; i++)
                Console.WriteLine(Products_arr[i].ToString());


            check_del buble_check_weight = Product.buble_check_by_weight;
            Sort_class.Sort(Products_arr, buble_check);

            for (int i = 0; i < Products_arr.Length; i++)
                Console.WriteLine(Products_arr[i].ToString());



            List<Product> Produts_lt = new List<Product>();
            Product temp1 = new Product("Milk", 35.90, 150, "25", "13.07.2021");
            Produts_lt.Add(temp1);
            Product temp2 = new Product("Meat", 35.90, 150, "3", "15.07.2021");
            Produts_lt.Add(temp2);
            Product temp3 = new Product("Bread", 35.90, 150, "30", "15.07.2021");
            Produts_lt.Add(temp3);
            
            
            Storage Storage_1 = new Storage(Produts_lt);
            

    */

             List<Product> Produts_lt2 = new List<Product>();
             Product temp1_1 = new Product("Milk", 35.90, 150, "25", "13.07.2021");
             Produts_lt2.Add(temp1_1);
             Product temp2_2 = new Product("Chips", 35.90, 150, "30", "15.10.2021");
             Produts_lt2.Add(temp2_2);
             Product temp3_3 = new Product("Water", 35.90, 150, "30", "15.07.2021");
             Produts_lt2.Add(temp3_3);

             Storage Storage_2 = new Storage(Produts_lt2);


             Storage.AddLogsEvent += StorageEvents.StorageLogs;
            Storage.AddProductEvent += StorageEvents.Addproudct_again;
            Storage.FindSpoiledProductEvent += StorageEvents.expired_product;
            //Storage Mutual_Storage = Storage.different_products(Storage_1, Storage_2);


            Storage_2.spoile_prouct();

             //Storage_2.delete_items("Chips");
             //Storage_2.search_product("150", "Weight");
            
               

           
            





        }
    }
}
