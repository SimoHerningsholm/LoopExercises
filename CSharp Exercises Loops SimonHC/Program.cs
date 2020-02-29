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
            Console.WriteLine("Opgave01");
            MultiplicationTable();
            //Opgave02
            Console.WriteLine("Opgave02");
            Console.WriteLine(TheBiggestNumber(new int[] { 190, 291, 145, 209, 280, 300 }));
            Console.WriteLine(TheBiggestNumber(new int[] { -9, -2, -7, -8, -4 }));
            //Opgave03
            Console.WriteLine("Opgave03");
            Console.WriteLine(TwoSevensNextToEachOther(new int[] { 8, 2, 5, 7, 9, 0, 7, 7, 3, 1 }));
            Console.WriteLine(TwoSevensNextToEachOther(new int[] { 9, 4, 5, 3, 7, 7, 7, 3, 2, 5, 7, 7}));
            //Opgave04
            Console.WriteLine("Opgave04");
            Console.WriteLine(ThreeIncreasingAdjacent(new int[] { 45, 23, 44, 68, 65, 70, 80, 81, 82 }));
            Console.WriteLine(ThreeIncreasingAdjacent(new int[] { 7, 3, 5, 8, 9, 3, 1, 4 }));
            //Opgave05
            Console.WriteLine("Opgave05");
            SieveOfEratosthenes(30);
            //Opgave06
            Console.WriteLine("Opgave06");
            Console.WriteLine(ExtractString("##abc##def"));
            Console.WriteLine(ExtractString("12####78"));
            Console.WriteLine(ExtractString("gar##d#en"));
            Console.WriteLine(ExtractString("++##--##++"));
            //Opgave07
            Console.WriteLine(FullSequenceOfLetters("ds"));
            Console.WriteLine(FullSequenceOfLetters("or"));
            //Opgave08
            Console.WriteLine("Opgave07");
            Console.WriteLine(SumAndAverage(11, 66));
            Console.WriteLine(SumAndAverage(-10, 0));
            //Opgave09
            Console.WriteLine("Opgave08");
            DrawTriangle();
            //Opgave10
            Console.WriteLine("Opgave09");
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
            //Der laves et loop på 10 iterationer så trekanten får en højde på 10 stjerner.
            for (int i = 0; i < 10; i++)
            {
                //Der foretages indskubninger op til værdien af startspace
                for (int j = 0; j <= startspace; j++)
                {
                    Console.Write(" ");
                }
                //Efter indskubninger printes der antal stjerner der skal printes for hver iteration. Hver stjerne efterfulgt af et mellem.
                for (int j = 0; j < AfterStartSpaceWrites; j++)
                {
                    
                    Console.Write("*");
                    Console.Write(" ");
                }
                //der laves en ny linje så der er klar til næste iteration
                Console.WriteLine("");
                //for hver iteration formindskes antal indskubninger fra venstre med 1 og antal stjerner der skal udskrives stiger med 1.
                startspace -= 1;
                AfterStartSpaceWrites += 1;
            }
            //Anden udgave (den første jeg kom op med)
            int iteration = 0;
            int margin = 0;
            //Der laves et while løkke med 10 iterationer med henblik på at lave en stjerne med en højde på 10 stjerner
            while(iteration < 10)
            {   
                //Tæller man antal tegn hver række der udgør en række i stjernen vil det svare til en iteration der går op til 19.
                for (int i = 1; i <= 19; i++)
                {
                    //margin øges med 1 for hver while løkke iteration. Der skal laves mellemrum på hver side af stjerner der genereres
                    //for hver iteration. Antal mellemrum på hver side af antal stjerner forminskes med 1 på hver side for hver iteration.
                    //antal stjerner øges med 2. Dette opnåes med nedenstående betingelse hvor 
                    //mellem udskrives såfremt iterationsnummeret er mindre end 10 minus marginenen eller iterationsnummeret er større end 10 plus marginen
                    //Er dette ikke tilfældet skal der printes stjerner.
                     if(i < 10 - margin || i > 10 + margin)
                     {
                         Console.Write("-");
                     }
                     else
                     {
                         Console.Write("*");
                     }
                }
                //For hver række af stjerner og mellemrum laves en ny linje og iteration samt margin øges med 1.
                Console.WriteLine("");
                iteration++;
                margin++;
            }
        }
        static string SumAndAverage(double n, double m)
        {
            //der instancieres variabler til sum og gennemsnit og nævneren i brøken der udregner gennemsnit
            double sum = 0;
            double avg = 0;
            double avgDenominator = 0;
            //først valideres der på om n og m indeholder gyldige værdier, hvis dette ikke er tilfældet udskrives en fejlmeddelelse
            if(n <= m)
            {
                //der loopes igennem tallene fra n til m
                for (double i = n; i <= m; i++)
                {
                    //hver tal mellem n og m lægges i summen. og for hvert tal der lægges i summen øges avgDenominator med 1 da det vil give antal tal der er lagt til summen
                    sum += i;
                    avgDenominator += 1;//man skulle tro man bare skulle finde differensen mellem m og n som avg denominator men nøøøouuoo det er ikke godt nok for c#
                } //                      eller også har min logik bare fejlet et eller andet sted..
                //Gennemsnittet udregnes og summen og gennemsnittet returneres.
                avg = sum / avgDenominator; 
                return "sum: " + sum.ToString() + " avg: " + avg.ToString();
            }
            else
            {
                return "The first integer is not less than or equal to the second integer";
            }
        }
        static string FullSequenceOfLetters(string a)
        {
            //alfabetet nedskrives med henblik på at kunne identificere karaktere i a som en del af alfabetet
            string alphabet = "abcdefghijklmnopqrstuvwxyzæøå";
            //strengen der skal concatineres samt integers for start og slut index i alfabetet.
            string concatContainer = string.Empty;
            int startLetterIndex = 0;
            int endLetterIndex = 0;
            //Der loopes igennem alfabetet
            for (int i = 0; i < alphabet.Length; i++)
            {
                //Når det første bogstav er identificeret sættes startindex
                if(a[0] == alphabet[i])
                {
                    startLetterIndex = i;
                }
                //Når det andet bogstav er identificeret sættes slutidenx
                if(a[1] == alphabet[i])
                {
                    endLetterIndex = i;
                }
            }
            //Det er et krav at slutbogstav skal have et større index end startbogstav
            if(endLetterIndex > startLetterIndex)
            {
                //concatcontaineren modtager karaktere mellem start og slut index
                for (int i = startLetterIndex; i <= endLetterIndex; i++)
                {
                    concatContainer += alphabet[i];
                }
                return concatContainer;
            }
            else
            {
                return "Bogstaverne forekom i forkert rækkefølge.";
            }
        }
        static string ExtractString(string a)
        {
            //Der loades variabler der skal anvendes til at finde indexes samt til at concatinere streng.
            int firstStringIndex = 0;
            int TwoHashendingCounter = 0;
            string stringConcat = string.Empty;
            // der loopes igennem a indtil første forekomst af 2 hashtags
            for (int i = 0; i < a.Length-1; i++)
            {
                //såfremt nuværende position samt næste position indeholder et hashtag er indexet på begyndelse af streng efter to hashtags fundet.
                //og der kan brydes ud af loopet med henblik på at concatinere en streng
                if(a[i] == '#'  && a[i+1] == '#')
                {
                    firstStringIndex = i + 2;
                    break;
                }
            }
            //der loopes igennem a fra indexet hvor den indre streng starter
            for (int i = firstStringIndex; i < a.Length-1; i++)
            {
                //hvis den når til en iteration hvor værdien af iterationen er hashtag og værdien af næste iteration er hashtag, betyder det at hele strengen er fundet
                // og der kan brydes ud af loopet. Ellers fortsætter den med at concatinere strengen
                if(a[i] == '#' && a[i+1] == '#')
                {
                    break;
                }
                else
                {
                    stringConcat += a[i];
                }
            }
            //der loopes igennem a fra første index for at være sikker på der faktisk har været 2 hashtags til at afslutte ovenstående loop.
            for (int i = firstStringIndex; i < a.Length; i++)
            {
                if(a[i] == '#')
                {
                    TwoHashendingCounter++;
                }
            }
            //Såfremt der har været 2 hashtags returneres strengen der er blevet concatineret. Ellers returneres en tom streng da der i givet tilfælde
            //ikke har været en streng mellem 2 hashtags i hver siden ende af strengen
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
            //Der føres omvendt bevisførelse. Det skal bevises at et tal der genereres ikke er et primtal. 
            //Det første primtal er 2 og sættes som det første potentielle primtal.
            int potentialPrime = 2;
            List<int> primeList = new List<int>() {2};
            //Så længe det potentielle primtal er mindre end det tal man vil regne primtal op til skal der findes primtal.
            while(potentialPrime < n)
            {
                //For hver start på en ny iteration øges tallet der potentielt kan være et primtal med 1 med henblik på ny validering af et nyt potentielt primtal
                potentialPrime++;
                //der loopes igennem værdien fra første primtil til værdien af det nuværende potentielle primtal
                for (int i = 2; i < potentialPrime; i++)
                {
                    //såfremt der eksistere et tal der går op i det nuværende potentielle primtal kan der ikke være tale om at det nuværende 
                    //potentielle primtal er et primtal. Derfor brydes der ud af forloopet med henblik på generering af et nyt potentielt primtal.
                    if(potentialPrime % i == 0)
                    {
                        break;
                    }
                    //Hvis vi befinder os på sidste iteration og ingen genererede tal har gået op i primtallet, må det nuværende tal i while løkken være
                    //et primtal og kan sættes i listen over primtal.
                    if(i == potentialPrime - 1)
                    {
                        primeList.Add(potentialPrime);
                    }
                }
            }
            //listen over primtal op til n printes.
            for (int i = 0; i < primeList.Count; i++)
            {
                Console.WriteLine(primeList[i]);
            }
        }
        static bool ThreeIncreasingAdjacent(int[] a)
        {
            //der loopes igennem alle tal
            for (int i = 0; i < a.Length-2; i++)
            {
                //såfremt værdien af næste punkt i iterationen er lig værdien af nuværende iteration plus 1 og at værdien af iterationen efter 
                //næste iterationen er 1 mere værdien i næste iteration, så vil betingelsen være opfyldt.
                if(a[i+1] == a[i] +1 && a[i+2] == a[i+1] + 1)
                {
                    return true;
                }
            }
            return false;
        }
        static int TwoSevensNextToEachOther(int[] a)
        {
            //der sættes en counter til at tælle antal gange to 7 er ved siden af hinanden
            int counter = 0;
            //der loopes igennem alle tal.
            for (int i = 0; i < a.Length-1; i++)
            {
                //såfremt værdien af nuværende position i iterationen er 7 og værdien af næste position i iterationen er 7, øges counteren med 1.
                if(a[i] == 7 && a[i+1] == 7)
                {
                    counter++;
                }
            }
            return counter;
        }
        static int TheBiggestNumber(int[] a)
        {
            //Det første tal i arrayet sættes som udgangspunkt for at potentielt være det største tal.
            int udgangsPunkt = a[0];
            // der loopes igennem alle tal
            for (int i = 0; i < a.Length; i++)
            {
                //hvis værdien af nuværende sted i iterationen er større end udgangspunktet, overskrives udgangspunktet med denne værdi
                if(a[i] > udgangsPunkt)
                {
                    udgangsPunkt = a[i];
                }
            }
            return udgangsPunkt;
        }
        static void MultiplicationTable()
        {
            //Der skal loopes 10 iterationer med tallene fra 1 til 10
            for (int i = 1; i <= 10; i++)
            {
                //For hver iteration af tallene fra 1 til 10, skal der loopes 10 iterationer af tallene fra 1 til 10
                //Dvs for hvert tal i det ydre loop kan dette tal ganges med tallene fra 1 til 10 genereret  i det indre loop
                for (int j = 1; j <= 10; j++)
                {
                    //Hvis produktet af tallet fra det ydre og indre loop er mindre end 10 skal der laves ekstra mellemrum når produktet af tallet er udskrevet
                    //dette med henblik på at skabe et bedre visuelt overblik
                    if(i*j < 10)
                    {
                        //produktet af tallet i det ydre loop ganget med tallet fra det indre udskrives med 2 mellemrum
                        Console.Write(i * j + "  ");
                        //Når værdien af tallet i det indre loop er 10 skal der laves ny linje
                        if(j == 10)
                        {
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        //produktet af tallet i det ydre loop ganget med tallet fra det indre udskrives med 1 mellemrum
                        Console.Write(i * j + " ");
                        //Når værdien af tallet i det indre loop er 10 skal der laves ny linje
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
