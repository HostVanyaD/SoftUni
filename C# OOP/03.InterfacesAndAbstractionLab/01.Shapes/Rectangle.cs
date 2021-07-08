using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public void Draw()
        {
            DrawLine(width, '*', '*');

            for (int i = 1; i < height - 1; ++i)
            {
                DrawLine(width, '*', ' ');                
            }
            DrawLine(width, '*', '*');
        }

        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);

            for (int i = 1; i < width - 1; ++i)
            {
                Console.Write(mid);                
            }
            Console.WriteLine(end);
        }
    }
}
