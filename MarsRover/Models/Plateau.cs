using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Plateau
    {
        private int width;

        private int height;

        public int Getwidth()
        {
            return width;
        }

        public void Setwidth(int value)
        {
            width = value;
        }

        public int Getheight()
        {
            return height;
        }

        public void Setheight(int value)
        {
            height = value;
        }

    }
}
