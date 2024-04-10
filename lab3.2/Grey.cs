using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3._2
{
    internal class Grey
    {
        public static void Apply(Bitmap img)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    var pixel = img.GetPixel(i, j);
                    var avg = (pixel.R + pixel.G + pixel.B) / 3;
                    img.SetPixel(i, j, System.Drawing.Color.FromArgb(avg, avg, avg));
                }
            }
        }
    }
}
