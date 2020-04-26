using System;

namespace StringBroadSenseCompare
{
    class Program
    {
        //Iphone 7 black and black iphone 7
        //Red black green   and green red black
        public bool CompareStrings(string s1, string s2)
        {


            //---------------------------------------------------------

            string[] tempS2 = s1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var length = s1.Length;
            int i=0,j=0;

            for( i=0; i< tempS2.Length; i++)
            {
                string temp = tempS2[i];

                if(s2.Contains(tempS2[i]))
                {
                    j++;
                    Console.WriteLine("\nString 1 is: ", temp);

                }
                
            }

            if (i == j)
            {
                return true;
            }

            //--------------------------------------------------------

            else
            {
                return false;
            }





            //string[] tempS1 = s1.Split(' ', StringSplitOptions.RemoveEmptyEntries);


            //if(s2.Contains(tempS1[0]) && s2.Contains(tempS1[1]) && s2.Contains(tempS1[2]))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}





        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String 1 ");
            string s1;
            s1 = Console.ReadLine();

            Console.WriteLine("\nEnter the String 2 ");
            string s2;
            s2 = Console.ReadLine();

            Program obj = new Program();
            var boolVar = obj.CompareStrings(s1,s2);

            if(boolVar)
            {
                Console.WriteLine("Strings are equal");
            }
            else
            {
                Console.WriteLine("Strings are not equal");
            }

            Console.ReadKey();
        }
    }
}
