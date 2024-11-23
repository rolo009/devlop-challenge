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
        // SortedDictionary to store numbers where key is index and value is the number
        private SortedDictionary<int, int> numbers;

        // Constructor to initialize the NumberContainers object with an empty SortedDictionary
        public NumberContainers()
        {
            numbers = new SortedDictionary<int, int>();
        }

        // Method to add or update a number at a specific index in the container
        public void Change(int index, int number)
        {
            numbers[index] = number;
        }

        // Method to find the index of a number in the container
        public int Find(int num)
        {
            // Check if the number exists in the container
            if (numbers.ContainsValue(num))
            {
                // Loop through the dictionary to find the key (index) associated with the number
                foreach (var number in numbers)
                {
                    if (number.Value == num) return number.Key;
                }
            }

            // Return -1 if the number is not found in the container
            return -1;
        }
    }
}
