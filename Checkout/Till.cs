using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {

        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0},
            {'D', 0}
        };

        public double Total() 
        { 
            double total = 0;
            foreach(var item in _items)
            {
                if(item.Value == 0) continue;
                else {
                    switch (item.Key)
                    {
                        case 'A':
                            total = AddItemA(total, item);
                            continue;
                        case 'B':
                            total = AddItemB(total, item);
                            continue;
                        case 'C':
                            total = AddItemC(total, item);
                            continue;
                        case 'D':
                            total = AddItemD(total, item);
                            continue;
                        default:
                            Console.WriteLine("invalid item");
                            break;
                    }
                }
            }   
           return total;
        }
        private static double AddItemA(double total, KeyValuePair<char, int> item)
        {   
            //Use two int variables to determine the number of discounted items and the items with the original price
            var numberInSpecial =  item.Value / 3;
            var numberNotInSpecial =  item.Value % 3; 
            total += 130 * numberInSpecial + 50 * numberNotInSpecial;     
            return total;
        }

        private static double AddItemB(double total, KeyValuePair<char, int> item)
        {
            var numberInSpecial =  item.Value / 2;
            var numberNotInSpecial =  item.Value % 2;
            total += 45 * numberInSpecial + 30 * numberNotInSpecial;  
            return total;
        }

        private static double AddItemC(double total, KeyValuePair<char, int> item)
        {
            //Warn when c items exceeds the maximum
            if (item.Value > 6) Console.WriteLine("Exceeds the maximum");
            total += 20 * item.Value; 
            return total;          
        }

        private static double AddItemD(double total, KeyValuePair<char, int> item)
        {
            total += 15 * item.Value;
            return total;
        }

        public void Scan(string items)
        {
            //Upper the lower cases
            items = items.ToUpper();
            foreach(var item in items)
            {
                _items[item]++;  
            }
        }
    }
}