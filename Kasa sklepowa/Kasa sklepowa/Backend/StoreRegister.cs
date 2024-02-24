using Kasa_sklepowa.Frontend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Kasa_sklepowa.Backend
{
    public class StoreRegister
    {
        public  StoreRegister()
        {
            CreateProductsList();
        }

        public static List<Product> Products { get; set; }


        public static void CreateProductsList()
        {
            Products = ProductsListCreator.GetProducts();
        }
        public static void ShowAllProducts()
        {   
            Console.Clear();
            Console.WriteLine( "KOD KRESKOWY | NAZWA" );
            foreach (Product product in Products)
            {
                Console.Write(product.Id + " | ");
                Console.WriteLine(product.Produkt);
            }
        }
        public static void Purchase()
        {
            bool test=false;
            float CenaVat;
            float vat = 1.23F;
            Console.Clear();
            float price = 0;
            string scan = "a";
            var basket = new InBasketProducts();
            while (scan != "P"){
                Console.Write("KOD KRESKOWY LUB WYDRUK PARAGONU(P) : ");
                scan = Console.ReadLine();
                if (scan == "P") break;
                Convert.ToInt32(scan);
                foreach (Product product in Products)
                {
                    if (scan == product.Id)
                    {
                        test = true;
                        Console.Clear();
                        Console.WriteLine(product.Produkt);
                        price += product.Cena*vat;
                        Math.Round(price, 2);
                        Console.WriteLine("CENA ŁĄCZNA: " + price.ToString("N2") +" zł");
                        basket.InBasketProduct.Add(product);
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NIEPOPRAWNY KOD KRESKOWY", Console.ForegroundColor);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            Console.Clear() ;
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine( "PARAGON");
            Console.WriteLine( "DATA ZAKUPU : "+ DateTime.Now);
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (Product product in basket.InBasketProduct)
            {
                CenaVat = product.Cena * 1.23F;
                Console.WriteLine(product.Produkt + " | " + CenaVat.ToString("N2") + " zł");
            }
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("DO ZAPŁATY:"+price.ToString("N2"));
            float VatOnly = price * 0.23F;
            Console.WriteLine("W TYM VAT: " + VatOnly.ToString("N2"));
            Console.WriteLine("---------------------------------------------------------------------");
                
            

        }
        public static void MainMenu()
        {
            switch (Display.DisplayWelcome())
            {
                case 1:
                    ShowAllProducts();
                    MainMenu();
                    break;
                case 2:
                    Console.Write("KOD KRESKOWY LUB WYDRUK PARAGONU(P) :");
                    Purchase();
                    break;
                case 3:
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wybrałeś niepoprawną opcję !!!",Console.ForegroundColor);
                    Console.ForegroundColor = ConsoleColor.White;
                    MainMenu();
                    break;
            }

        }
        

    }
}
