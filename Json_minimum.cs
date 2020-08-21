using System;
using Newtonsoft.Json;
using System.IO;

namespace json_playground
{
    class Product
    {
        public string name = "Apple";
        public DateTime date = new DateTime(2020, 12, 02);
        public String[] sizes = new string[] {"Small", "big"};

        static void Main(string[] args)
        {
            var myApple = new Product();
            var output = JsonConvert.SerializeObject(myApple);
            Console.WriteLine(output);

            var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + "hello.txt";
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(output);
            }
        }
    }
}
