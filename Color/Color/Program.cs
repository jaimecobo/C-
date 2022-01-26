using System;
namespace Exercise
{

    class Color
    {

        int _red;
        int _green;
        int _blue;
        int _opacity;

        // Red property
        public int Red { get; set; }

        // Green property
        public int Green { get; set; }

        // Blue property
        public int Blue { get; set; }

        // Opacity property
        public int Opacity { get; set; }




        // default ctor 
        Color()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Opacity = 255;
        }

        // ctor accepting 1 integer

        public Color(int Red)
        {
            this.Red = Red;
            Green = Red;
            Blue = Red;
            Opacity = 255;
        }

        // ctor accepting 3 integers
        public Color(int Red, int Green, int Blue)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
            Opacity = 255;
        }

        // ctor accepting 4 integers
        public Color(int Red, int Green, int Blue, int Opacity)
        {
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
            this.Opacity = Opacity;
        }

    }

}