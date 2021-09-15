using System;
using System.Collections.Generic;
using System.Text;

namespace almacen_golosinas
{
    public class Menu : IMenu
    {
        Almacen g = new Golosinas();
        public void golosinas()
        {
            var des = "";
            var value = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Sale of candies");
                if (g.getProduct("").Count.Equals(0))
                {
                    Console.WriteLine("there are not candies");
                    Console.WriteLine("Do you want to add candies? y/n");
                    des = Console.ReadLine();
                    if (des.Equals("y"))
                    {
                        Console.WriteLine("How many candies do you want to add?");
                        int cant = Convert.ToInt16(Console.ReadLine());
                        for (int i = 0; i < cant; i++)
                        {
                            Console.WriteLine("New Candy");
                            Console.WriteLine("Add the ID");
                            var id = Console.ReadLine();
                            Console.WriteLine("Add the name");
                            var name = Console.ReadLine();
                            Console.WriteLine("Add the price");
                            var price = Convert.ToDouble(Console.ReadLine());
                            g.addProduct(new Producto { 
                                ID = id,
                                Name = name,
                                Price = price
                            });
                        }
                        Console.WriteLine("Do you want to go to the beginning? y/n");
                        des = Console.ReadLine();
                        if (des.Equals("y"))
                        {
                            value = true;
                        }
                        else
                        {
                            value = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Do you want to go to the beginning? y/n");
                        des = Console.ReadLine();
                        if (des.Equals("s"))
                        {
                            Console.Clear();
                            Console.WriteLine("Sale of candies");
                        }
                        else
                        {
                            value = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("List of Candies");
                    foreach (var item in g.getProduct(""))
                    {
                        Console.WriteLine($"ID: {item.ID} " +
                            $"Golosina: {item.Name} " +
                            $"Price: {item.Price} ");
                    }
                    Console.WriteLine("Do you want to sale any candy? y/n");
                    des = Console.ReadLine();
                    if (des.Equals("y"))
                    {
                        sales();
                    }
                    else
                    {
                        value = false;
                    }

                }
            } while (value);
        }

        public double requiringPayment()
        {
            bool correctPayment = false;
            double res = 0;
            while (!correctPayment)
            {
                Console.WriteLine("How would you like to pay? 100/50");
                res = double.Parse(Console.ReadLine());
                if (res != 100 && res != 50)
                {
                    Console.WriteLine("incorrect payment");
                }
                else
                {
                    correctPayment = true;

                }
            }
            return res;
        }

        public void sales()
        {
            double total = 0;
            string des = "";
            do
            {
                Console.WriteLine("Add the product");
                string product = Console.ReadLine();
                var products = g.getProduct(product);
                while (products.Count.Equals(0))
                {
                    Console.WriteLine("Candy not available, please chose another product");
                    product = Console.ReadLine();
                    products = g.getProduct(product);
                }
                Console.WriteLine($"The amount to be paid is: {products[0].Price}$");
                double payment = requiringPayment();
                while (payment < products[0].Price)
                {
                    Console.WriteLine($"{(products[0].Price - payment)}$ short of the total amount to be paid");
                    payment += requiringPayment();
                }
                Console.WriteLine($"Your change is: {(payment - products[0].Price)}$");
                total += products[0].Price;
                Console.WriteLine($"Your payment was: {total}$");
                Console.WriteLine("Would you like to make another purchase? y/n");
                des = Console.ReadLine();
            } while (des.Equals("s"));
        }
    }
}
