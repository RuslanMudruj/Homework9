using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace homework_1
{
    class Storage
    {
        public static event AddLogs AddLogsEvent;
        public static event AddCorrectProduct AddProductEvent;
        public static event FindSpoiledProduct FindSpoiledProductEvent;

        int n;
        public List<Product> many_product;
        public Product this[int index]
        {
            set
            {
                many_product[index] = value;
            }
            get
            {
                if (index < many_product.Count)
                    return many_product[index];
                else
                    throw new Exception("index is begger than many product's lenght");
            }

        }


        public Storage()
        {
            this.many_product = new List<Product>();
        }
        public Storage(List<Product> el)
        {
            this.many_product  = new List<Product>();
            this.many_product.AddRange(el);
        }




        public void date_delete()
        {
            DateTime dt = DateTime.Now;
            string[] date = dt.ToString("d").Split('.');
            
            for(int i = 0;i< many_product.Count; i++)
            {
                if (many_product[i].Type == "Milk")
                {
                    string[] product_date = many_product[i].Date.Split('.');
                }
            }
        }

        public void out_file()
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Ruslanchik\source\repos\Homework_№3\out.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < many_product.Count; i++)
                {
                    sw.WriteLine(String.Format("Product {0}\tPrice {1}\tType {2}\tDate {3} \n", many_product[i].Name, many_product[i].Price, many_product[i].Type));
                }


            }
        }
        public void in_file()
        {

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Ruslanchik\source\repos\Homework_№3\out.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < many_product.Count; i++)
                {
                    sw.WriteLine(String.Format("Product {0}\tPrice {1}\tType {2}\tDate {3} \n", many_product[i].Name, many_product[i].Price, many_product[i].Type));


                }
            }
        }








        // Methods------------------------------------------------------------

    

        public void dialog_method()
        {
            for (int i = 0; i < 3; i++)
            {
                string namee = Console.ReadLine();
                many_product[i].Name = namee;
                Console.WriteLine("Pleas enter a price");
                int pric = int.Parse(Console.ReadLine());
                many_product[i].Price = pric;
                Console.WriteLine("Pleas enter a weight");
                int weig = int.Parse(Console.ReadLine());
                many_product[i].Weight = weig;
            }

        }


        public void init_method()
        {
            many_product[0].Name = "Meat";
            many_product[0].Price = 50;
            many_product[0].Weight = 100;

            many_product[1].Name = "Milk";
            many_product[1].Price = 30;
            many_product[1].Weight = 1;


            many_product[2].Name = "Eggs";
            many_product[2].Price = 10;
            many_product[2].Weight = 30;

        }





        public void druk_product()
        {
            for (int i = 0; i < 3; i++)
                Console.WriteLine("Information about Product: " + '\n' + "Name: " + many_product[i].Name + '\n' + "Price: " + many_product[i].Price + "\n Weight: " + many_product[i].Weight);

        }






        public void meat_check()
        {
           
            for (int i = 0; i < 3; i++)
            {
                if (many_product[i].Name == "Meat")
                {
                    Console.WriteLine("Information about Meat Product: " + '\n' + "Name: " + many_product[i].Name + '\n' + "Price: " + many_product[i].Price + "\n Weight: " + many_product[i].Weight);


                }
            }
        }

        public void store_changeprice(int persent)
        {
            for (int i = 0; i < 3; i++)
            {
                many_product[i].change_price(persent);
            }

        }


        //Methods for TASK 8.2

        public static Storage mutual_products(Storage a, Storage b)
        {
            Storage mutal_products = new Storage();
            foreach (var prod in a.many_product)
                if (b.many_product.Contains(prod))// return false, but in list is a mutual product
                {
                    mutal_products.many_product.Add(prod);
                }
            return mutal_products;
        }
        public static Storage different_first_storage_products(Storage a, Storage b)
        {
            Storage mutal_products = new Storage();
            foreach(var prod in a.many_product)
                if (!b.many_product.Contains(prod))
                {
                    mutal_products.many_product.Add(prod);
                }
            return mutal_products;
        }
        protected static List<Product> Check_prod(List<Product> a, List<Product> b)
        {
            List<Product> product_list = new List<Product>();
            foreach(var prod in b)
                if (!a.Contains(prod))
                {
                    product_list.Add(prod);
                }
            return product_list;
        }

        public static Storage different_products(Storage a, Storage b)
        {
            Storage mutal_products = new Storage();
            mutal_products.many_product.AddRange(Check_prod(a.many_product, b.many_product));
            mutal_products.many_product.AddRange(Check_prod(b.many_product, a.many_product));

            return mutal_products;
        }




        //Methods for TASK 9

        private List<Product> search_by_name(string product_name)
        {
            List<Product> finded_product = new List<Product>();
            foreach (var prod in many_product)
            {
                if (prod.Name.Equals(product_name))
                {
                    finded_product.Add(prod);
                }
                
            }
            return finded_product;
        }
        public void add(Product el)
        {
            many_product.Add(el);
        }


        public void delete_items(string product_name)
        {

            for(int i = 0;i < many_product.Count;i++)
            {
                if (search_by_name(product_name).Contains(many_product[i]))
                {
                    many_product.Remove(many_product[i]);
                    i -= 1;
                }
            }
        }
        public void add_item()
        {
            
            
        
            bool check = true;
            Product tmp = new Product();
            Console.WriteLine($"Enter products Name\n");
            
           string p_name = Console.ReadLine();
            tmp.Name = p_name;    




            Console.WriteLine($"Enter products Price\n");
            try
            {
                double p_price = double.Parse(Console.ReadLine());
                tmp.Price = p_price;

            }
            catch(FormatException ex)
            {
                AddLogsEvent(tmp, ex.Message);
                check = false;
            }
            
            
            Console.WriteLine($"Enter products Weight\n");
            
            
            try
            {
                int p_weight = int.Parse(Console.ReadLine());
                tmp.Weight = p_weight;

            }
            catch (FormatException ex)
            {
                AddLogsEvent(tmp, ex.Message);
                check = false;
            }
            


           



            Console.WriteLine($"Enter products Days\n");


            try
            {
                int p_days = int.Parse(Console.ReadLine());
                tmp.Days = p_days ;
                    
            }
            catch (FormatException ex)
            {
                AddLogsEvent(tmp, ex.Message);
                check = false;
            }



            

            Console.WriteLine($"Enter products Date \n");
            try
            {
                string p_date = Console.ReadLine();
                if (p_date.Split('.').Length != 3)
                {

                    throw new FormatException("Wrong date");
                }
                else
                {
                    tmp.Date = p_date;
                }
            }
            catch(FormatException ex)
            {
                AddLogsEvent(tmp, ex.Message);
                check = false;
                Console.WriteLine("incorerect date");
            }
            
           
            
               
            

            if (check)
            {
                many_product.Add(tmp);
            }
            else
            {
                AddProductEvent(this);
            }
        }


        //protected int get_all_days(string date)
        //{
        //    int years_days = int.Parse(date.Split('.')[2]);
        //    bool check = true;
        //    if (int.Parse(date.Split('.')[2]) % 4 == 0)
        //    {
        //        years_days *= 366;
        //        check = false;
        //    }
        //    else
        //    {
        //        years_days *= 365;
        //    }
        //    int mounth_days = int.Parse(date.Split('.')[1]);
        //    switch (mounth_days)
        //    {
        //        case 1:
        //            mounth_days *= 31;
        //            break;
        //        case 2:
        //            if (check)
        //                mounth_days *= 28;
        //            else
        //                mounth_days *= 29;
        //            break;
        //        case 3:
        //            mounth_days *= 31;
        //            break;
        //        case 4:
        //            mounth_days *= 30;
        //            break;
        //        case 5:
        //            mounth_days *= 31;
        //            break;
        //        case 6:
        //            mounth_days *= 30;
        //            break;
        //        case 7:
        //            mounth_days *= 31;
        //            break;
        //        case 8:
        //            mounth_days *= 31;
        //            break;
        //        case 9:
        //            mounth_days *= 30;
        //            break;
        //        case 10:
        //            mounth_days *= 31;
        //            break;
        //        case 11:
        //            mounth_days *= 30;
        //            break;
        //        case 12:
        //            mounth_days *= 31;
        //            break;
        //        default:
        //            break;
        //    }
        //    int days = int.Parse(date.Split('.')[0]);
        //    Console.WriteLine(days + mounth_days + years_days);
        //    return days + mounth_days + years_days;


        //}
        //public  void expired_prodcut( )
        //{
        //    List<Product> Spoiled_product = new List<Product>();
        //    //int all_now_days = int.Parse(DateTime.Now.Year.ToString()) * 365 + int.Parse(DateTime.Now.Month.ToShortDateString());

        //    foreach (var prod in this.many_product)
        //    {
        //        if (get_all_days(DateTime.Now.ToShortDateString()) - get_all_days(prod.Date) < prod.Days)
        //        {
        //            Spoiled_product.Add(prod);
        //        }

        //    }
        //    FindSpoiledProductEvent()
        //    //return Spoiled_product;
        //}

    

        public void search_product(string word, string atr)
        {
            foreach (var prod in many_product) 
            {
                
                switch (atr)
                {
                    
                    case "Name":
                        if (prod.Name == word) 
                        {
                            Console.WriteLine(prod.ToString());
                            
                        }
                        break;
                    case "Price":
                        if (prod.Price == double.Parse(word))
                        {
                            Console.WriteLine(prod.ToString());
                        }
                        break;
                    case "Weight":
                        if (prod.Weight == int.Parse(word))
                        {
                            Console.WriteLine(prod.ToString());
                        }
                        break;
                    case "Days":
                        if (prod.Days == int.Parse(word))
                        {
                            Console.WriteLine(prod.ToString());
                        }
                        break;
                    case "Date":
                        if (prod.Date == word)
                        {
                            Console.WriteLine(prod.ToString());
                        }
                        break;

                }

            }

        }

        public void spoile_prouct()
        {
            FindSpoiledProductEvent(this);
        }
        

    }
}


