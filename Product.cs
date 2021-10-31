using System;
using System.Collections.Generic;
using System.Text;

namespace homework_1
{
    class Product: IEquatable<Product>
    {
        protected string name;
        public string Name
        {
            set
            {
                name = value;

            }
            get
            {
                return name;
            }
        }



        protected string type;
        public string Type
        {
            set
            {
                type = value;

            }
            get
            {
                return type;
            }

        }

        protected double price;
        public double Price
        {
            set
            {
                try
                {
                    if (value > 0)
                    {
                        price = value;
                    }
                    else
                        throw new Exception("price is incorrect");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get
            {
                return price;
            }
        }

        protected int weight;
        public int Weight
        {
            set
            {
                try { 
                if (value > 0)
                {
                    weight = value;
                }
                else
                    throw new Exception("weight is incorrect");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

}
            get
            {
                return weight;
            }
        }

        protected int days;
        public int Days
        {
            set

            {
                try
                {
                    if (value > 31 || value < 1)
                        throw new Exception("Days is wrong");
                    else
                        days = value;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            get
            {
                return days;
            }

        }
        protected string date;
        public string Date
        {
            set
            {
                try
                {
                    if (value.Split('.').Length != 3)
                    {
                        throw new FormatException("Wrong date Format");
                    }

                    else
                    {
                        this.date = value;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                date = value;

            }
            get
            {
                return date;
            }

        }




        public Product()
        {
               
        }

        public Product(string in_name, double in_price, int in_weight,string in_days,string in_date)
        {
            this.name = in_name;
            if (in_price > 1)
            {
                this.price = in_price;
            
            }
            else
                throw new Exception("price is incorrect");

            if (in_weight > 1)
            {
                this.weight = in_weight;
            }
            else
                throw new Exception("weight is incorrect");
            
            if ((int.Parse(in_days) > 1) && (int.Parse(in_days) < 31)) 
            {
                this.days = int.Parse(in_days);
            }
            else
                throw new Exception("wa is incorrect");




            try
            {
                if (in_date.Split('.').Length != 3)
                {   
                 
                    throw new FormatException("Wrong date Format");
                }
               

                else
                {
                    
                    this.date = in_date;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public Product(string in_name, double in_price, int in_weight, string in_date)
        {
            this.name = in_name;
            if (in_price > 1)
            {
                this.price = in_price;

            }
            else
                throw new Exception("price is incorrect");

            if (in_weight > 1)
            {
                this.weight = in_weight;
            }
            else
                throw new Exception("weight is incorrect");




            try
            {
                if (this.date.Split('.').Length != 3)
                {
                    throw new FormatException("Wrong date Format");



                }

                else
                {
                    this.date = in_date;
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        



        public static int buble_check_by_days(Product a, Product b)
        {
            if (a.Days > b.Days)
                return 1;
            else
                return 0;
        }


        public static int buble_check_by_weight(Product a, Product b)
        {
            if (a.Weight > b.Weight)
                return 1;
            else
                return 0;
        }

    public virtual void change_price(double d_percents) 
        {
            
            this.price = this.price * (d_percents / 100);
        }
        public override string ToString()// перевантаження  метода ToString
        {
            return $"Name: {this.Name}\nPrice: {this.Price}\nWeight: {this.Weight}\nDays: {this.Days}\n" ;

        }


        public bool Equals(Product other)
        {
            return Name.Equals(other.Name)
                && Price.Equals(other.Price) && Date.Equals(other.Date) && Days.Equals(other.Days) && Weight.Equals(other.Weight);
        }






    }
}
