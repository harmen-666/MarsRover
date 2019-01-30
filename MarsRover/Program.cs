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
            GenerateWater Water = new GenerateWater();
            int[] CoWaX = Water.GenerateX();
            int[] CoWaY = Water.GenerateY();
            rover.ToonInSight();
            mars.toonMars();
            station.toonBasis();

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
                    }
                    Console.Clear();
                    rover.ToonInSight();
                    mars.toonMars();
                    station.toonBasis();
                    rover.fuel();

                }
            }
        }
    }

    class InSight
    {
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
        //change is goood 
        public void ToonInSight()
        {
            if (posX >= 0 && posY >= 0)
            {
                Console.ForegroundColor = kleur;
                Console.SetCursorPosition(posX, posY);
                Console.Write(symbool);
            }
        }
        public void fuel()
        {
            F.huidigefuel();
        }

    }

    class Energie
    {
        private int fuel = 50;
        public int verbruik(int F)
        {
            fuel = fuel - F;
            return fuel;
        }
        //GNOMED     
        public int huidigverbruik()
        {
            return fuel;
        }
        public void opladen()
        {
            fuel = 50;
        }
        public void huidigefuel()
        {
            Console.SetCursorPosition(45, 0); //test
            Console.Write("Fuel : " + fuel);
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
