using System;

namespace Operatii_Aritmetice
{
    class Program
    {
        static int[] Addition(int[] x, int[] y)
        {
            int c = 0;
            int max = Math.Max(x.Length, y.Length);
            int min = Math.Min(x.Length, y.Length);
            int[] v = new int[max + 1];
            for (int i = 0; i < min; i++)
            {
                v[i] = x[i] + y[i] + c;

                if (v[i] >= 10)
                {
                    c = 1;
                    v[i] -= 10;
                }
                else
                {
                    c = 0;
                }
            }
            int[] z;

            if (x.Length > y.Length)
            {
                z = x;
            }
            else
            {
                z = y;
            }

            for (int i = min; i < max; i++)
            {
                v[i] = z[i] + c;

                if (v[i] >= 10)
                {
                    c = 1;
                    v[i] -= 10;
                }
                else
                {
                    c = 0;
                }
            }
            if (c == 1)
            {
                v[max] = c;
            }
            return v;

        }
        static void WriteHugeNumber(int[] x)
        {
            for (int i = x.Length - 1; i >= 0; i--)
            {
                Console.Write(x[i] + " ");

            }
            Console.WriteLine();
        }

        static int[] HugeNumber()
        {
            string a = Console.ReadLine();
            int[] v = new int[a.Length];

            for (int i = a.Length - 1; i >= 0; i--)
            {
                v[a.Length - 1 - i] = int.Parse(a[i].ToString());
            }
            return v;
        }
        static bool isSmaller(int[] x, int[] y)
        {

            int n1 = x.Length, n2 = y.Length;

            if (n1 < n2)
                return true;
            if (n2 < n1)
                return false;

            for (int i = n1 - 1; i >= 0; i--)
            {
                if (x[i] < y[i])
                    return true;
                else if (x[i] > y[i])
                    return false;
            }
            return false;
        }

        static bool isEqual(int[] x, int[] y)
        {
            int n1 = x.Length;
            int n2 = y.Length;

            if (n1 != n2)
            {
                return false;

            }
            for (int i = 0; i < n1; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }
        static bool isSmallerOrEqual(int[] x, int[] y)
        {
            return isSmaller(x, y) || isEqual(x, y);

        }

        static int[] RemoveZeros(int[] x)
        {
            int last_pos = -1;
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                if (last_pos < 0)
                {
                    last_pos = i;
                }
                } else
                {
                    last_pos = -1;
                }
            }
            if (last_pos > 0)
            {
                int[] rez = new int[last_pos];
                for (int i = 0; i< rez.Length; i++)
                {
                    rez[i] = x[i];
                }
                return rez;
            }
            return x;
        }
        static int[] Subtraction(int[] x, int[] y)
        {

            int max = Math.Max(x.Length, y.Length);
            int min = Math.Min(x.Length, y.Length);
            int c = 0;

            int[] v = new int[max];
            bool ok = false;

            if (isSmaller(x,y))
            {
                int[] z;
                z = x;
                x = y;
                y = z;
                ok = true;
            }

            for (int i=0; i<min; i++)
            { 
                v[i] = x[i] - y[i] - c;
                if (v[i] < 0)
                {
                    v[i] += 10;
                    c = 1;
                }
                else
                {
                    c = 0;
                }
               
            }

            

            for (int i=min; i<max; i++)
            {

                v[i] = x[i] - c;
                if (v[i] < 0)
                {
                    c = 1;
                }
                else
                {
                    c = 0;
                }
            }

            if(ok)
            {
                v[v.Length - 1] *= -1;
            }
            return RemoveZeros(v);
        }
        static int[] Multiplication(int[] x, int[] y)
        {
            int[] v = new int[x.Length + y.Length];
            

            int[][] intermediar= new int[y.Length][];

            for(int i=0; i < y.Length; i++)
            {
                int[] z = new int[x.Length+y.Length];
                int produs, rest, cat = 0;

                for (int j = 0; j < x.Length; j++)
                {
                    
                    produs = y[i] * x[j]+cat;
                    rest = produs % 10;
                    cat = produs / 10;

                    z[j+i] = rest;
                   
                }
                if (cat > 0)
                {
                    z[x.Length + i] = cat;
                }
                intermediar[i] = z;

                    
            }
            for(int i=0; i<intermediar.Length; i++)
            {
                v= Addition(intermediar[i], v);
            }
            return RemoveZeros(v);
        }
        static int Division(int[] x, int[] y)
        {
            
            int nr = 0;
            
            
            
                do
                {
                
                x = Subtraction(x, y);
                nr++;
                } while (isSmallerOrEqual(y, x));
            return nr;
        }
        static void Main(string[] args)
        {
            int[] v1 = HugeNumber();
            int[] v2 = HugeNumber();

            WriteHugeNumber(v1);
            WriteHugeNumber(v2);

            // adunarea

            int[] addition = Addition(v1, v2);

            WriteHugeNumber(addition);

            // scaderea

            int[] subtraction = Subtraction(v1, v2);

            WriteHugeNumber(subtraction);

            //inmultirea

            int[] multiplication = Multiplication(v1, v2);

            WriteHugeNumber(multiplication);

            // impartirea

            int division = Division(v1, v2);

            Console.WriteLine(division);
        }
    }
}
