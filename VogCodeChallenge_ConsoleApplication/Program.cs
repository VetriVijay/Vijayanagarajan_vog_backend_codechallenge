using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VogCodeChallenge_ConsoleApplication
{
  class Program
  {
    static void Main(string[] args)
    {

      //Without using loop,one way of iterating the NameList using lamda expression
      QuestionClass.NamesList.ForEach(i => Console.WriteLine("Name: "+ i));

      //One more way to iterate the NameList without using For/Foreach loop.
      string names = string.Join(Environment.NewLine, QuestionClass.NamesList);

      Console.WriteLine(names);

      Console.WriteLine("Please enter the value:");
      object value = Console.ReadLine();
      string resp = TESTModule(value);
      Console.WriteLine("TestModule method result: "+ resp);
    }

    public static string TESTModule(object value)
    {
      string result = "";
      int num;
      float floatValue;
      bool isNumeric = int.TryParse(Convert.ToString(value), out num);
      switch (value)
      {
        case var expression when int.TryParse(Convert.ToString(value), out num) == true:
          if (num >= 1 && num <= 4)
          {
            Console.WriteLine($"Value is integer and within 1,2,3,4:");
            result = Convert.ToString(num * 2);
          }
          else if (num > 4)
          {
            Console.WriteLine($"Value is integer and greater than 4:");
            result = Convert.ToString(num * 3);
          }
          else if (num < 1)
          {
            Console.WriteLine($"Value is integer and less than 1:");
            throw new Exception("Value is zero or negative");
          }
          break;
        case var expression when float.TryParse(Convert.ToString(value), out floatValue):
          if (floatValue == 1.0 || floatValue == 2.0) 
          {
            Console.WriteLine($"Value is float");
            result = Convert.ToString(3.0f);
          }
          break;
        case var expression when Regex.IsMatch(Convert.ToString(value), @"^[a-zA-Z]+$"):
            Console.WriteLine($"Value is string");
            result = Convert.ToString(value).ToUpper();
          break;
        default:
          Console.WriteLine($"Value is not string or integer or float");
          result = Convert.ToString(value);
          break;

      }
      return result;

    }

    public bool IsNumeric(string str)
    {
      int num;
      bool isNumeric = int.TryParse(str, out num);
      return isNumeric;
    }
  
  }
}
