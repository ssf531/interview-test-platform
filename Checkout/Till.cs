using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {
        // the dictionary contains item quantities
        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0},
            {'D', 0}
        };
        // the dictionary contains item prices
        private Dictionary<char, int> _itemPrice = new Dictionary<char, int>{
            {'A', 50},
            {'B', 30},
            {'C', 20},
            {'D', 15}
        };
        // the dictionary contains quantity limit for items
        private Dictionary<char, int> _itemsMaxAmount = new Dictionary<char, int>{
            {'C', 6}
        };
        // the dictionary contains special conditions
        private Dictionary<char, Tuple<int, int>> _specialSets = new Dictionary<char, Tuple<int, int>>{
            {'A', Tuple.Create(3,130)},
            {'B', Tuple.Create(2,45)}
        };

          public double Total() 
        { 
            double total = 0;
            foreach(var item in _items)
            {   
                // Variables of price and quantity
                var itemPrice = _itemPrice[item.Key];
                var itemNum = item.Value;
                // When the item has special condition and the quantity reaches the minimum requirement, caculate the special cost
                if(_specialSets.ContainsKey(item.Key) && item.Value >= _specialSets[item.Key].Item1){  
                    // The tuple of the special condition for the item 
                    var specialSet = _specialSets[item.Key] ;
                    // Call the fuction to add cost for items with special
                    total += ItemCostInSpecial(itemNum, itemPrice, specialSet);
                }else {
                    // Add cost for items with no special
                    total += itemPrice * itemNum;             
                };    
            }  
           return total;
        
        }
        //Caculate item cost with special condition
        private static double ItemCostInSpecial(int itemNum,int itemPrice,  Tuple<int, int> special)
        {   
            //caculate the number of discounted items 
            var numberInSpecial =  itemNum / special.Item1;
            var numberNotInSpecial =  itemNum % special.Item1; 
            var specialSetPrice = special.Item2;

            var cost = specialSetPrice * numberInSpecial + itemPrice * numberNotInSpecial;   
            return cost;
        }
      
        //Add item number exceed warn
        public void Scan(string items)
        {
            //Upper the lower cases
            items = items.ToUpper();
            foreach(var item in items)
            {
                _items[item]++;  
                // Warn if an item exceeds max number
                if(_itemsMaxAmount.ContainsKey(item) && _items[item] > _itemsMaxAmount[item]) Console.WriteLine("{0} exceeds the maximum", item);              
            }
        }
    }
}