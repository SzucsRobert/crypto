using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace cesar
{
    public class cesar
    {
        public string text = System.IO.File.ReadAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\readme.txt");
        public int n;
        public cesar(int n)
        {
            this.n = n;
        }
        public void Coding()
        {
            string lines=" ";
            foreach(char x in text)
            {
                char t = Convert.ToChar(Convert.ToInt32(x) + n);
                if (Convert.ToInt32(t) > 122)
                    t = Convert.ToChar(Convert.ToInt32(t) - 26);

                lines = lines+t;
            }
            System.IO.File.WriteAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText.txt", lines);

        }
        public void Decoding()
        {
            string text2 = System.IO.File.ReadAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText.txt");
           string lines = " ";
            foreach (char x in text2)
            {
                char t = Convert.ToChar(Convert.ToInt32(x) - n);
                if (Convert.ToInt32(t) < 97)
                    t = Convert.ToChar(Convert.ToInt32(t) + 26);

                lines = lines + t;
            }
            System.IO.File.WriteAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText2.txt", lines);

        }

    }
    public class substitutie
    {
        public static Random r = new Random();
        public int x = r.Next(50, 100);
        public int[] v = new int[27];
        public substitutie()
        {
            for(int i=1;i<=26;i++)
            {
                v[i] = i;
            }
            for (int i = 1; i < x; i++)
            {
                int q = r.Next(1, 26);
                int l = r.Next(1, 26);
                int aux = v[q];
                v[q] = v[l];
                v[l] = aux;
            }


        }
        public void Cod()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\readme.txt");
            string lines = " ";
            foreach (char x in text)
            {
                int y = Convert.ToInt32(x) - 96;
                char t = ' ';
                if (x != ' ')
                {
                int u = v[y] + 96;
                
               
                    t = Convert.ToChar(u);
                }
                    
                lines = lines + t;

            }
            System.IO.File.WriteAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText3.txt", lines);

            
        }
        public void decod()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText3.txt");
            string lines = " ";
            foreach (char x in text)
            {
                char t = ' ';
                if(x!= ' ')
                {
                    for(int i=1;i<=26;i++)
                    {
                        if(Convert.ToInt32(x)-96==v[i])
                        {
                            t = Convert.ToChar(i + 96);
                        }
                    }
                }
                lines = lines + t;

            }
            System.IO.File.WriteAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText4.txt", lines);


        }

    }
    public class Propozitie
    {
        
        public int n = 5;
        public char[,] m=new char[6,6];
        public Propozitie()
        {

            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                    m[i, j] = ' ';
                

            using (StreamReader sr = new StreamReader(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\readme2.txt")) 
            {
                        while (sr.Peek() >= 0)
                        {
                            char t =(char)sr.Read();
                    if (t == 'j')
                        t = 'i';
                            if(t!= ' ')
                            {
                                for (int i = 1; i < 6; i++)
                                    for (int j = 1; j < 6; j++)
                                    {
                                        if(m[i,j]==' ' && nuafostutilizat(t))
                                         {
                                            m[i, j] = t;

                                         }

                                    }
                            }

                        }
            }
            int y = 96;
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                {
                    if (m[i, j] == ' ')
                    {
                        while(m[i,j]==' ')
                        {
                            if (nuafostutilizat(Convert.ToChar(y)))
                            {
                                m[i, j] = Convert.ToChar(y);
                            }
                            else
                                y++;
                        }
                    }
                }
            
        }
        public void cod()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\readme.txt"))
            {
                while (sr.Peek() >= 0)
                {
                    char t = (char)sr.Read();
                    char k=' ';
                    if(sr.Peek()>=0)
                        k = (char)sr.Read();

                    int ki=1;
                    int kj=1;
                    int ti=1;
                    int tj=1;
                    for (int i = 1; i < 6; i++)
                        for (int j = 1; j < 6; j++)
                        {
                            if(m[i,j]==k)
                            {
                                ki = i;
                                kj = j;

                            }
                            if(m[i,j]==j)
                            {
                                ti = i;
                                tj = j;
                            }

                        }
                    string lines=" ";
                    if (k!= ' ')
                    {
                        t = m[ti, kj];
                        k = m[ki, ti];
                        lines = lines + t + k;
                    }
                    else
                    {
                        lines = lines + t;
                    }
                    System.IO.File.WriteAllText(@"C:\Users\Robi\Desktop\cripto\cesar\cesar\bin\Debug\WriteText5.txt", lines);

                }

            }

         }

            private bool nuafostutilizat(char t)
        {
            for (int i = 1; i < 6; i++)
                for (int j = 1; j < 6; j++)
                {
                    if (m[i, j] == t&& t=='j')
                        return false;
                }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            cesar a = new cesar(12);
            a.Coding();
            a.Decoding();

            substitutie b = new substitutie();
            b.Cod();
            b.decod();
            Propozitie c = new Propozitie();
            c.cod();
        }
    }
}
