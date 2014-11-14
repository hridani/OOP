namespace StringDisperser
{
    using System;
    using System.Collections.Generic;

    class StringDisperserTest
    {
        static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            StringDisperser clonestringDisperser = (StringDisperser)stringDisperser.Clone();

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine("\n");
            clonestringDisperser.Chars.RemoveAt(4);
            Console.WriteLine(clonestringDisperser.ToString());
            Console.WriteLine(stringDisperser.CompareTo(clonestringDisperser) == 0 ?
                                "Two StringDispersers are equal" :
                                "Two StringDispersers are not equal"
                            );
        }
    }
}
