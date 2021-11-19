using System;
using System.Collections.Generic;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            /*
            var napis = "HelloWorld!Hell";
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            Console.WriteLine(colors.Length);
            //var randomColour = new Random();
            int kolor = 1;
            foreach (var znak in napis)
            {
                Console.ForegroundColor = colors[kolor];
                Console.Write(znak);
                Console.ResetColor();
                kolor++;
            }*/
            //Console.SetWindowSize(160, 40);
            //Console.SetBufferSize(160, 40);

            var plansza = new Board();
            int[] fleetTable = { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            Ship[] ships = new Ship[10];
            int[,] boardData = new int[30,30];
            for (var i = 0; i < fleetTable.Length; i++)
            {
                ships[i] = new Ship(fleetTable[i], plansza);
            }

            for (var i = 0; i < fleetTable.Length; i++)
            {
                var positions = ships[i].positionShip();
                foreach (var item in positions)
                {
                    plansza.UpdateBoard(item, true, fleetTable[i]);
                }
            }
            plansza.DrawBoard();
        }
    }
}