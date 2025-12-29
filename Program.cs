//Táborosi Ákos GASQ56
//Település valamikor minimális hőmérséklettel
using System;
using System.Collections.Generic;

namespace KomplexBead
{
class Program
{
    static void Main(string[] args)
    {
        // változók létrehozása
        int telepulesSzam = 0;
        int napokSzam = 0;
        List<int> indexek = new List<int>();
        int db = 0;
        List<int> joIndexek = new List<int>();
        
        //Beolvasás
        BeolvasBiro();
            int[,] elorejelzes = new int[telepulesSzam, napokSzam];
            

            for (int i = 0; i < telepulesSzam; i++)
            {
                string[] sor = Console.ReadLine().Split(' ');
                
                for (int j = 0; j < napokSzam; j++)
                {
                    int.TryParse(sor[j], out elorejelzes[i, j]); 
                }
            }
            
            //Minimum keresés
            for (int i = 0; i < napokSzam; i++)
            {
                indexek.Add(Minimum(i,  elorejelzes));
            }

            //Indexek kiválogatása
            for (int i = 0; i < napokSzam; i++)
            {
                if (!Eldont(i, indexek))
                {
                    joIndexek.Add(indexek[i]);
                    db++;
                }
            }
            //Rendezés
            joIndexek.Sort();
            
            //Kiíratás
            Console.Write(db + " ");
            for (int i = 0; i < joIndexek.Count; i++)
            {
                Console.Write(joIndexek[i] + " ");
            }
        

        void BeolvasBiro()
        {
            string szamok = Console.ReadLine();
            string[] l =  szamok.Split(' ');
            int.TryParse(l[0], out telepulesSzam);
            int.TryParse(l[1], out napokSzam);
            
        }
        //Tesztelés miatt nincs meghívva
        void Beolvas()
        {
            Console.Write("Add meg a települések számát: ");
            while (!int.TryParse(Console.ReadLine(), out telepulesSzam))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Természetes szám kell");
                Console.ResetColor();
                Console.Write("Add meg a települések számát: ");
            }
            
            Console.Write("Add meg a napok számát: ");
            while (!int.TryParse(Console.ReadLine(), out napokSzam))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Természetes szám kell");
                Console.ResetColor();
                Console.Write("Add meg a napok számát: ");
            }
            
            
        }

        int Minimum(int sor, int[,] m)
        {
            int minertek = int.MaxValue;
            int minindex = -1;
            for (int i = 0; i < telepulesSzam; i++)
            {
                if (m[i, sor] < minertek)   
                {
                    minertek = m[i, sor];
                    minindex = i;
                }
            }
            return minindex+1;
        }

        bool Eldont(int j, List<int> lista)
        {
            bool van = false;
            for (int i = 0; i < j; i++)
            {
                if (lista[j] == lista[i])
                {
                    van = true;
                }
                
            }
            return van;
        }
    }
}
}