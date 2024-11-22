using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercise1_OOP.Classes
{
    public class NumberContainers
    {
        //List<int> numbers;
        private SortedDictionary<int, int> numbers;
        public NumberContainers()
        {
            numbers = new SortedDictionary<int, int>();
        }

        public void Change(int index, int number)
        {
            numbers[index] = number;
        }

        public int Find(int num)
        {

            if (numbers.ContainsValue(num))
            {
                foreach (var number in numbers)
                {
                    if (number.Value == num) return number.Key;
                }
            }
            
            return -1;
        }
    }
}
