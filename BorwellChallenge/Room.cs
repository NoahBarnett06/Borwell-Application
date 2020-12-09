using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorwellChallenge
{
    public class Room
    {
        // Publicly declares the variables used in the this class, and also sets their datatypes
        public decimal Width;
        public decimal Length;
        public decimal Height;
        public decimal OpeningHeight;
        public decimal OpeningWidth;
        public int OpeningCount;
        public decimal Total;

        // Calculates the area of the walls
        public decimal Wall1
        {
            get { return Length * Height; }
        }
        public decimal Wall2
        {
            get { return Width * Height; }
        }
        public decimal WallTotal
        {
            get { return 2 * (Wall1 + Wall2); }
        }

        // Calculates the volume of the room
        public decimal Volume
        {
            get { return Width * Length * Height; }
        }
        
        // Calculate the area of the floor
        public decimal FloorArea
        {
            get { return Width * Length; }
        }

        // Caclulates the area of the opening (door/window) and rounds it to two decimal places
        public decimal Opening
        {
            get { return Math.Round(OpeningHeight * OpeningWidth, 2); }
        }

        // Counts the number of openings added
        public int OpeningNumber
        {
            get { return OpeningCount += 1; }               
        }

        // Calculates the total area of all the openings
        public decimal OpeningTotal
        {
            get
            {
                Total += Opening;
                return Total;
            }
        }

        // Calculates how many litres of paint are needed to cover the area of the walls using a ratio of 10:1 for area of the walls(m²) to litres of paint
        public decimal Paint
        {
            get
            {
                var Walls = (WallTotal - OpeningTotal) / 10;
                if (Walls < 1)
                {
                    return 1;
                }
                if (Walls > Math.Round(Walls))
                {
                    Walls = Math.Round(Walls);
                    var x = Walls + 1;
                    return x;
                }
                else
                {
                    Walls = Math.Round(Walls);
                    var x = Walls;
                    return x;
                }
            }
        }
        
    }
}
