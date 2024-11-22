using Exercise1_OOP.Classes;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        //Variables
        NumberContainers nc = null;
        string[] operationsArray = [];
        int[][] valuesArray = [];

        List<int?> output = [];

        //Operations Input method to handle user input for the list of operations,
        //ensuring they are valid and meet the specified constraints:
        //- At most 105 calls will be made in total to change and find
        //- All operations are correctly called (NumberContainers, find, change)
        operationsArray = OperationsInput();


        //Values Input method to handle user input for the list of values,
        //ensuring they are valid and meet the specified constraints:
        //- 1 <= index, number <= 109
        valuesArray = ValuesInput();
        
        for (int i = 0; i < operationsArray.Length; i++)
        {
            switch (operationsArray[i].ToString())
            {
                case "NumberContainers":
                    nc = new NumberContainers();
                    output.Add(null);
                    break;
                case "find":
                    if (nc != null)
                    {
                        output.Add(nc.Find(valuesArray[i][0]));
                    }
                    break;
                case "change":
                    if (nc != null)
                    {
                        nc.Change(valuesArray[i][0], valuesArray[i][1]);
                        output.Add(null);
                    }
                    break;
                default:
                    Console.WriteLine($"Invalid Operation: {operationsArray[i]}");
                    break;
            }
        }

        Console.WriteLine(JsonConvert.SerializeObject(output));
    }

    public static string[] OperationsInput()
    {
        string operations = "";
        string[] operationsArray = [];

        do
        {
            Console.WriteLine("Operations Input (NumberContainers, find, change)");

            // Read the input string from the console
            operations = Console.ReadLine();

            // Deserialize the input JSON string into a string array
            operationsArray = JsonConvert.DeserializeObject<string[]>(operations);

        } while (operationsArray.Any(op => op != "NumberContainers" && op != "find" && op != "change") ||
        operationsArray.Where(op => op == "find" || op == "change").ToList().Count() >= 105);

        return operationsArray;
    }

    public static int[][] ValuesInput()
    {
        string values = "";
        int[][] valuesArray = [];

        do
        {
            Console.WriteLine("Values Input");

            // Read the input string from the console
            values = Console.ReadLine();

            // Deserialize the input JSON string into a string array
            valuesArray = JsonConvert.DeserializeObject<int[][]>(values);

        } while (valuesArray.Where(v => v.Length == 1).ToList().Any(v => v[0] < 1 || v[0] >= 109) ||
        valuesArray.Where(v => v.Length == 2).ToList().Any(v => v[0] < 1 || v[0] >= 109 || v[1] < 1 || v[1] >= 109));

        return valuesArray;
    }
}