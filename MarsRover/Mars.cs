using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Mars
    {

       public int grootteX = 40;
       public int grootteY = 20;


        //Maakt een omgeving waarin je kan bewegen (in de console)
        public void toonMars()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
            Console.Write("╔");
            for (int i = 1; i < grootteX; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("═");
            }
            //hello me old chum
            Console.Write("╗");
            for (int i = 1; i < grootteY; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
            }
            //im gnot a gnelf
            Console.SetCursorPosition(0, grootteY);
            Console.Write("╚");
            for (int i = 1; i < grootteY; i++)
            {
                Console.SetCursorPosition(grootteX, i);
                Console.Write("║");
            }
            //im gnot a gnoblin
            Console.SetCursorPosition(grootteX, grootteY);
            Console.Write("╝");
            for (int i = 1; i < grootteX; i++)
            {
                Console.SetCursorPosition(i, grootteY);
                Console.Write("═");
            }
        }

    class GenerateWater
    {
        int Xmax;
        int Ymax;
        int kans;
        bool[,] waterplaatsen;
        Random Generate = new Random();

        public GenerateWater(int x, int y)
        {

            waterplaatsen = new bool[x,y];
             Xmax = x;
             Ymax = y;
        }

        public void Plaats()
        {
            for (int i = 1; i < Xmax-1; i++)
            {
                for (int j = 1; j < Ymax-1; j++)
                {
                    kans = Generate.Next(0, 10);
                    if(kans == 1)
                    {
                        waterplaatsen[i, j] = true;
                    }
                    else { waterplaatsen[i, j] = false; }
                }
            }
        }
        public void WaterZien()
        {
            for (int i = 1; i < Xmax - 1; i++)
            {
                for (int j = 1; j < Ymax - 1; j++)
                {
                    if (waterplaatsen[i,j] == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.SetCursorPosition(i, j);
                        Console.Write("%");
                    }

                }
            }
        }
        public void WaterNietZien()
        {
            for (int i = 1; i < Xmax - 1; i++)
            {
                for (int j = 1; j < Ymax - 1; j++)
                {
                    if (waterplaatsen[i, j] == true)
                    {
                        Console.Write(" ");
                    }

                }
            }
        }
    }
}
