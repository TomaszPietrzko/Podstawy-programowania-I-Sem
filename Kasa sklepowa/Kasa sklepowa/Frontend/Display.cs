using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa_sklepowa.Frontend
{
    public class Display
    {
        public static int DisplayWelcome()
        {
            Console.WriteLine("WYBIERZ OPCJĘ: ");
            Console.WriteLine("1 => LISTA WSZYSTKICH PRODUKTÓW");
            Console.WriteLine("2 => ZAKUPY");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.Write("WYBIERZ 1, 2 LUB 3:");
            int choice = Convert.ToInt32(Console.ReadLine());    
            
            return choice;
         }
    }
}
