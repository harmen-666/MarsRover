using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Program
    {
 
        public static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkRed; // mars :-)
            Console.Clear();
            Console.CursorVisible = false; // cursor weg

            Mars mars = new Mars();
            Basisstation station = new Basisstation();
            InSight rover = new InSight();
            GenerateWater water = new GenerateWater(mars.grootteX, mars.grootteY);
            rover.ToonInSight();
            mars.toonMars();
            station.toonBasis();
            water.Plaats();

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var command = Console.ReadKey().Key;

                    switch (command)
                    {
                        case ConsoleKey.DownArrow: //naar benedenbewegen
                            rover.moveDown();
                            break;
                        case ConsoleKey.UpArrow:
                            rover.moveUp();
                            break;
                        case ConsoleKey.LeftArrow:
                            rover.moveLeft();
                            break;
                        case ConsoleKey.RightArrow:
                            rover.moveRight();
                            break;
                        case ConsoleKey.T:
                            water.WaterZien();
                            break;
                        case ConsoleKey.Y:
                            water.WaterNietZien();
                            break;
                        case ConsoleKey.Enter:
                            rover.boor();
                            break;
                    }
                    Console.Clear();
                    rover.ToonInSight();
                    mars.toonMars();
                    station.toonBasis();
                }
            }
        }
    }
   

    class InSight
    {
        //hey kids
        char symbool = '#';
        ConsoleColor kleur = ConsoleColor.Yellow;
        int posX = 1;
        int posY = 1;
        Energie F;
        //verbreuk per verplaatsing
        public int vpv = 1;

        public InSight()
        {
             F = new Energie();
        }

        public InSight(char symbool, ConsoleColor kleur)
        {
            this.symbool = symbool;
            this.kleur = kleur;
        }

        public void moveUp()
        {
            if (posY > 0 && F.huidigverbruik() > 0)
            {
                posY--;
                F.verbruik(vpv);
            }
        }

        public void moveDown()
        {
            if (F.huidigverbruik() > 0)
            {
            posY++;
            F.verbruik(vpv);
                }
        }

        public void moveLeft()
        {
            if (posX > 0 && F.huidigverbruik() > 0)
            {
                posX--;
                F.verbruik(vpv);
            }
        }

        public void moveRight()
        {
            if (F.huidigverbruik() > 0)
            {
            posX++;
            F.verbruik(vpv);
                }
        }
        

        public void ToonInSight()
        {
            if (posX >= 0 && posY >= 0) 
            {
                Console.ForegroundColor = kleur;
                Console.SetCursorPosition(posX, posY);
                Console.Write(symbool);
            }
        }
        //boren
        bool succes = false;
        char waterplas = '〰';
        
        ConsoleColor water = ConsoleColor.Blue;
        public void boor()
        {
            for (int i =0; i < .length; i++)
            {

            }
        }
        public void toonwater(bool succes)
        {
            if (succes == true)
            {
                Console.SetCursorPosition(posX, posY);
                Console.ForegroundColor = water;
                Console.Write(waterplas);
            }
            else
            {

            }
        }

    }

    class Energie
    {
        private int fuel = 50;
        public int verbruik(int F) {
            fuel = fuel - F;
            return fuel;
        }
        public int huidigverbruik(int groote)
        {
            return fuel;
        }
        public void opladen()
        {
            fuel = 50;
        }
    }

    class Basisstation
    {
        char symbool = '▀';
        ConsoleColor basis = ConsoleColor.Green;
        int posX = 5;
        int posY = 3;

        public void toonBasis()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(symbool);
        }


        private void Laadstation()
        {
            if (posX == 50 && posY == 30)
            {
                Opladen();
            }
        }

        private void Opladen()
        {
            //energie = energie++;
        }

}

}
