using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Length cannot be zero or negative.");
                }

                length = value;
            }

        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Width cannot be zero or negative.");
                }

                width = value;
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Height cannot be zero or negative.");
                }

                height = value;
            }
        }

        public double SurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            return 2 * length * width + 2 * length * height + 2 * width * height;
        }

        public double LateralSurfaceArea()
        {
            return 2 * height * (length + width);
        }

        public double Volume()
        {
            return length * width * height;
        }

    }
}
