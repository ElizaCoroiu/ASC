using System;
using System.Text;

namespace ConvertorBaze
{
    class Program

    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static int pow(int baza, int exp)//functia putere
        {
            int nr = 1;
            for(int i=0; i<exp; i++)
            {
                nr = nr * baza;
            }
            return nr;
        }
        // functia transforma fiecare caracter al secventei date in cifra corespunzatoare in baza 10
        static int charValue(char x) 
        {
            if(Char.IsDigit(x))
            {
                return x - '0'; //x-'0'=x-48
            }
            else
            {
                return x - 'A' + 10;
            }
        }
        static char charOutput(int x)
        {
            char c;
            if (x < 10)
            {
                c = (char)('0' + x);
            }
            else
            {
                c = (char)('A' + (x - 10));
            }
            return c;
        }
        static int ConvertTo10(string str, int b1)
        {
            int nr = 0;
            for (int i = 0; i < str.Length; i++)
            {
                int valoare = charValue(str[i]);

                //nr = nr* b1+ valoare;
                nr += valoare * pow(b1, (str.Length - i - 1));
            }
            return nr;
        }
        static string ConvertTob2(int nr, int b2)
            {
            int r;
            char c;
            StringBuilder sb = new StringBuilder();
            while (nr != 0)
            {
                r = nr % b2;
                nr = nr / b2;
                c = charOutput(r);
                sb.Append(c);
            }
             return Reverse(sb.ToString());
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un sir de caractere");
            string str = Console.ReadLine();

            str= str.ToUpper();

            Console.WriteLine("Baza initiala=");
            int b1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Baza finala=");
            int b2 = int.Parse(Console.ReadLine());

            for (int i = 0; i < str.Length; i++)//verificam daca secventa data e in baza b1

            {
                int valoare = charValue(str[i]);

                if (valoare >= b1)
                {
                    Console.WriteLine("Nr. nu e in baza b1.");
                    return;
                }
            }
            

            //cauta pozitia virgulei in sir
            int PozitieVirgula = str.IndexOf(",");
            
            int precision;
            int precizie_b2;

            if (PozitieVirgula > 0)
            {
                Console.WriteLine("Virgula e la pozitia={0}", PozitieVirgula);
                
                //calculeaza nr de cifre dupa virgula
                precision = str.Length - PozitieVirgula - 1;
                
                Console.WriteLine("Introduceti nr. de zecimale dorite=");
                precizie_b2 = int.Parse(Console.ReadLine());
            }
            else
            {
                precision = 0;
                precizie_b2 = 0;
            }

            

            // elimina virgula rezultand partea intreaga si partea fractionara concatenate
            string str2 = str.Replace(",", "");
            
            int nr1=ConvertTo10(str2, b1); // converteste string-ul in int

            // transforma nr la precizia initiala
            float nr2 = nr1 / (float)Math.Pow(b1, precision); 

            // punem toate cifrele dorite in partea intreaga 
            nr2 = nr2 * (float)Math.Pow(b2, precizie_b2);
            int nr3 = (int)Math.Round(nr2);

            //converteste nr in baza b2
            string str3 = ConvertTob2(nr3, b2);

            if(precizie_b2 > 0)
            {
                // pune virgula la locul potrivit (cel initial)
                str3 = str3.Insert(str3.Length - precizie_b2, ",");
            }
            

            Console.WriteLine($"Numarul final in baza b2={str3}");

           



            Console.ReadKey();

            }
        }
}
