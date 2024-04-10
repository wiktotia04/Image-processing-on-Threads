using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3._2
{
    internal class BlackWhite

    {
        public static void Apply(Bitmap img)
        {
            //filtr picture with only black end white pixels
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    var pixel = img.GetPixel(i, j);
                    var avg = (pixel.R + pixel.G + pixel.B) / 3;
                    if (avg > 127)
                    {
                        img.SetPixel(i, j, System.Drawing.Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        img.SetPixel(i, j, System.Drawing.Color.FromArgb(0, 0, 0));
                    }
                }
            }
        }
    }
}
