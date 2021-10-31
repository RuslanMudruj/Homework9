using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;


namespace homework_1
{

    delegate void AddLogs(Product Prod, string messege);
    delegate void AddCorrectProduct(Storage tmp);
    delegate void FindSpoiledProduct(Storage stor);

    static class StorageEvents
    {

        public static void Addproudct_again(Storage stor)
        {
            string p_name, p_date;
            double p_price = 0;
            int p_weight = 0;
            bool check = true;
            Product tmp = new Product();
            Console.WriteLine($"Enter products Name\n");

            p_name = Console.ReadLine();
            tmp.Name = p_name;




            Console.WriteLine($"Enter products Price\n");
            try
            {
                p_price = double.Parse(Console.ReadLine());


            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                check = false;
            }

            tmp.Price = p_price;
            Console.WriteLine($"Enter products Weight\n");


            try
            {
                p_weight = int.Parse(Console.ReadLine());


            }
            catch (FormatException ex)
            {
                check = false;
                Console.WriteLine(ex.Message);
            }
            if (check)
            {
                stor.many_product.Add(tmp);
            }
            else
            {
                Console.WriteLine("Your date is incorrect");
            }


        }


        static int get_all_days(string date)
        {
            int years_days = int.Parse(date.Split('.')[2]);
            bool check = true;
            if (int.Parse(date.Split('.')[2]) % 4 == 0)
            {
                years_days *= 366;
                check = false;
            }
            else
            {
                years_days *= 365;
            }
            int mounth_days = int.Parse(date.Split('.')[1]);
            switch (mounth_days)
            {
                case 1:
                    mounth_days *= 31;
                    break;
                case 2:
                    if (check)
                        mounth_days *= 28;
                    else
                        mounth_days *= 29;
                    break;
                case 3:
                    mounth_days *= 31;
                    break;
                case 4:
                    mounth_days *= 30;
                    break;
                case 5:
                    mounth_days *= 31;
                    break;
                case 6:
                    mounth_days *= 30;
                    break;
                case 7:
                    mounth_days *= 31;
                    break;
                case 8:
                    mounth_days *= 31;
                    break;
                case 9:
                    mounth_days *= 30;
                    break;
                case 10:
                    mounth_days *= 31;
                    break;
                case 11:
                    mounth_days *= 30;
                    break;
                case 12:
                    mounth_days *= 31;
                    break;
                default:
                    break;
            }
            int days = int.Parse(date.Split('.')[0]);
            Console.WriteLine(days + mounth_days + years_days);
            return days + mounth_days + years_days;


        }
    



        public static void expired_product(Storage stor)
        {
           
            List<Product> Spoiled_product = new List<Product>();
            //int all_now_days = int.Parse(DateTime.Now.Year.ToString()) * 365 + int.Parse(DateTime.Now.Month.ToShortDateString());

            foreach (var prod in stor.many_product)
            {
                if (get_all_days(DateTime.Now.ToShortDateString()) - get_all_days(prod.Date) < prod.Days)
                {
                    Spoiled_product.Add(prod);
                    Console.WriteLine(prod.ToString());
                }

            }

            
        }



           
           
        



        public static void StorageLogs(Product Prod, string messege)
        {
            using (StreamWriter file = new StreamWriter(@"C:\Users\Ruslanchik\source\repos\Homework8.1\Logs.txt"))
            {
                file.WriteLine($"{messege} in:\n{Prod.ToString()}");
                file.WriteLine($"{DateTime.Now.ToShortDateString()}|{DateTime.Now.ToLongTimeString()}\n");
            }
        }
    }
}

       
