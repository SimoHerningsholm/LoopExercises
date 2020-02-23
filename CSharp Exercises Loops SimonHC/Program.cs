using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Exercises_Loops_SimonHC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Opgave01
            //   MultiplicationTable();
            //Opgave02
            /* Console.WriteLine(TheBiggestNumber(new int[] { 190, 291, 145, 209, 280, 300 }));
             Console.WriteLine(TheBiggestNumber(new int[] { -9, -2, -7, -8, -4 }));*/
            //Opgave03
            /*  Console.WriteLine(TwoSevensNextToEachOther(new int[] { 8, 2, 5, 7, 9, 0, 7, 7, 3, 1 }));
              Console.WriteLine(TwoSevensNextToEachOther(new int[] { 9, 4, 5, 3, 7, 7, 7, 3, 2, 5, 7, 7}));*/
            //Opgave04
            /*  Console.WriteLine(ThreeIncreasingAdjacent(new int[] { 45, 23, 44, 68, 65, 70, 80, 81, 82 }));
              Console.WriteLine(ThreeIncreasingAdjacent(new int[] { 7, 3, 5, 8, 9, 3, 1, 4 }));*/
            //Opgave05
            // SieveOfEratosthenes(30);
            //Opgave06
            /*  Console.WriteLine(ExtractString("##abc##def"));
              Console.WriteLine(ExtractString("12####78"));
              Console.WriteLine(ExtractString("gar##d#en"));
              Console.WriteLine(ExtractString("++##--##++"));*/
            //Opgave08
            /* Console.WriteLine(SumAndAverage(11, 66));
             Console.WriteLine(SumAndAverage(-10, 0));*/
            //Opgave09
            // DrawTriangle();
            //Opgave10
            Console.WriteLine(ToThePowerOf(-2, 3));
            Console.WriteLine(ToThePowerOf(5, 5));
            Console.ReadLine();
        }
        static int ToThePowerOf(int a, int b)
        {
            //Eksempel:
            //a = 2
            //b = 3
            //i: 0 -> 1 -> 2 (3 iterationer)
            //i0: 1 = 1 * 2 --> 2
            //i1: 2 = 2 * 2 --> 4
            //i2: 4 = 4 * 2 --> 8 
            //Efter 3 iterationer: 1 --> 8
            int Power = 1;
            for (int i = 0; i < b; i++)
            {
                Power *= a;
            }
            return Power;
        }
        static void DrawTriangle()
        {
            //Følgende opgave løses på 2 forskellige måder hvor den første er tættest på trekanten i opgaven.
            //Første udgave løses ud fra følgende analyse:
            /*
             Følgende viser hvordan trekanten kan laves hvor mellemrum er udbyttet med bindestreg
             ----*
             ---*-*
             --*-*-*
             -*-*-*-*
             *-*-*-*-*
             Analyse:
             skal man lave ovenstående figur startes der med en indskubning fra højre på 4 mellemrum. 
             For hver iteration formindskes denne indskubning med 1.
             For hver iteration øges antal tegn til højre for indskubning med 2.
             Det er altid stjerne efterfulgt af mellemrum til højre for indskubning
             På figuren ovenover vil det svare til der sættes en bindestreg efter den sidste stjerne i hver iteration.
             Dette kan dog ikke ses når bindestregen erstattes af et mellemrum. Derfor får man stadig et skærmbillede
             der ser nogenlunde ud som trekanten i opgaven.
             */
             //Første udgave
            int startspace = 8;
            int AfterStartSpaceWrites = 1;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j <= startspace; j++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < AfterStartSpaceWrites; j++)
                {
                    Console.Write("*");
                    Console.Write(" ");
                }
                Console.WriteLine("");
                startspace -= 1;
                AfterStartSpaceWrites += 1;
            }
            //Anden udgave (den første jeg kom op med)
            int iteration = 0;
            int margin = 0;
            while(iteration < 10)
            {            
                for (int i = 1; i <= 19; i++)
                {
                     if(i < 10 - margin || i > 10 + margin)
                     {
                         Console.Write(" ");
                     }
                     else
                     {
                         Console.Write("*");
                     }
                }
                Console.WriteLine("");
                iteration++;
                margin++;
            }
        }
        static string SumAndAverage(double n, double m)
        {
            double sum = 0;
            double avg = 0;
            double avgDenominator = 0;
            if(n <= m)
            {
                for (double i = n; i <= m; i++)
                {
                    sum += i;
                    avgDenominator += 1;//man skulle tro man bare skulle finde differensen mellem m og n som avg denominator men nøøøouuoo det er ikke godt nok for c#
                } //                      eller også har min logik bare fejlet et eller andet sted..
                avg = sum / avgDenominator; 
                return "sum: " + sum.ToString() + " avg: " + avg.ToString();
            }
            else
            {
                return "The first integer is not less than or equal to the second integer";
            }
        }
        static string ExtractString(string a)
        {
            int firstStringIndex = 0;
            int TwoHashendingCounter = 0;
            string stringConcat = string.Empty;
            for (int i = 0; i < a.Length-1; i++)
            {
                if(a[i] == '#'  && a[i+1] == '#')
                {
                    firstStringIndex = i + 2;
                    break;
                }
            }
            for (int i = firstStringIndex; i < a.Length-1; i++)
            {
                if(a[i] == '#' && a[i+1] == '#')
                {
                    break;
                }
                else
                {
                    stringConcat += a[i];
                }
            }
            for (int i = firstStringIndex; i < a.Length; i++)
            {
                if(a[i] == '#')
                {
                    TwoHashendingCounter++;
                }
            }
            if(TwoHashendingCounter == 2)
            {
                return stringConcat;
            }
            else
            {
                return "";
            }

        }
        static void SieveOfEratosthenes(int n)
        {
            int potentialPrime = 2;
            List<int> primeList = new List<int>() {2};
            while(potentialPrime < n)
            {
                potentialPrime++;
                for (int i = 2; i < potentialPrime; i++)
                {
                    if(potentialPrime % i == 0)
                    {
                        break;
                    }

                    if(i == potentialPrime - 1)
                    {
                        primeList.Add(potentialPrime);
                    }
                }
            }
            for (int i = 0; i < primeList.Count; i++)
            {
                Console.WriteLine(primeList[i]);
            }
        }
        static bool ThreeIncreasingAdjacent(int[] a)
        {
            for (int i = 0; i < a.Length-2; i++)
            {
                if(a[i+1] == a[i] +1 && a[i+2] == a[i+1] + 1)
                {
                    return true;
                }
            }
            return false;
        }
        static int TwoSevensNextToEachOther(int[] a)
        {
            int counter = 0;
            for (int i = 0; i < a.Length-1; i++)
            {
                if(a[i] == 7 && a[i+1] == 7)
                {
                    counter++;
                }
            }
            return counter;
        }
        static int TheBiggestNumber(int[] a)
        {
            int udgangsPunkt = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] > udgangsPunkt)
                {
                    udgangsPunkt = a[i];
                }
            }
            return udgangsPunkt;
        }
        static void MultiplicationTable()
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    if(i*j < 10)
                    {
                        Console.Write(i * j + "  ");
                        if(j == 10)
                        {
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.Write(i * j + " ");
                        if (j == 10)
                        {
                            Console.WriteLine("");
                        }
                    }
                }
            }
        }
    }
}
