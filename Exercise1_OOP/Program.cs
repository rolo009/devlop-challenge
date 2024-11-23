using Exercise1_OOP.Classes;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        //Variables
        NumberContainers? nc = null;

        string[] operationsArray;
        int[][] valuesArray;

        List<int?> output = [];

        // Calls the method to handle operations input, ensuring they meet constraints
        operationsArray = OperationsInput();

        // Calls the method to handle values input, ensuring they meet constraints
        valuesArray = ValuesInput();

        // Loop through all operations and execute them
        for (int i = 0; i < operationsArray.Length; i++)
        {
            // Switch based on the operation type
            switch (operationsArray[i].ToString())
            {
                case "NumberContainers":
                    // Create a new instance of 'NumberContainers'
                    nc = new NumberContainers();
                    output.Add(null);
                    break;
                case "find":
                    // Perform 'find' operation
                    if (nc != null)
                    {
                        output.Add(nc.Find(valuesArray[i][0]));
                    }
                    break;
                case "change":
                    // Perform 'change' operation
                    if (nc != null)
                    {
                        nc.Change(valuesArray[i][0], valuesArray[i][1]);
                        output.Add(null);
                    }
                    break;
                default:
                    // If the operation is not valid, print an error message
                    Console.WriteLine($"Invalid Operation: {operationsArray[i]}");
                    break;
            }
        }

        // Output the final result as a JSON array
        Console.WriteLine(JsonConvert.SerializeObject(output));
    }

    // Method to handle the input of operations, validating constraints
    public static string[] OperationsInput()
    {
        string operations = "";
        string[] operationsArray = [];
        bool isConstraintsValid = true;

        do
        {
            isConstraintsValid = true;

            Console.WriteLine("Operations Input (NumberContainers, find, change)");

            // Read the input string from the console
            operations = Console.ReadLine();

            // Deserialize the input JSON string into a string array
            operationsArray = JsonConvert.DeserializeObject<string[]>(operations);

            // Check if any operation is invalid or if there are too many 'find' or 'change' operations
            if (operationsArray!.Any(op => op != "NumberContainers" && op != "find" && op != "change") ||
        operationsArray!.Where(op => op == "find" || op == "change").ToList().Count() >= 105)
            {
                isConstraintsValid = false;
                Console.WriteLine("Something went wrong: ensure all operations are 'NumberContainers', 'find', or 'change', " +
                    "and the number of 'find' or 'change' operations does not exceed 104.");
            }

        } while (!isConstraintsValid);

        // Method to handle the input of values, ensuring constraints are met
        return operationsArray!;
    }

    // Method to handle the input of values, ensuring constraints are met
    public static int[][] ValuesInput()
    {
        string values = "";
        int[][] valuesArray = [];
        bool isConstraintsValid = true;

        do
        {
            isConstraintsValid = true;

            Console.WriteLine("Values Input");

            // Read the input string from the console
            values = Console.ReadLine();

            // Deserialize the input JSON string into a string array
            valuesArray = JsonConvert.DeserializeObject<int[][]>(values);

            // Check if any values are out of the valid range(1 to 109)
            if (valuesArray!.Where(v => v.Length == 1).ToList().Any(v => v[0] < 1 || v[0] >= 109) ||
        valuesArray!.Where(v => v.Length == 2).ToList().Any(v => v[0] < 1 || v[0] >= 109 || v[1] < 1 || v[1] >= 109))
            {
                isConstraintsValid = false;
                Console.WriteLine("Something went wrong: ensure all values are between 1 and 109.");
            }

        } while (!isConstraintsValid); // Loop until the input meets the constraints

        // Return the valid values array
        return valuesArray!;
    }
}