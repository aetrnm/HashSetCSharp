using System;

namespace HashSetCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSettt hs = new HashSettt();

            hs.Add("123");
            hs.Add("1233");
            hs.Add("1233");
            hs.Add("12333");
            hs.Add("123333");
            hs.Add("1233333");
            hs.Add("12333333");
            hs.Add("123333333");
            
            Console.WriteLine(hs.Find("12333333333"));
        }
    }
}