using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3._2
{
    internal class Blurr
    {
        public static void Apply(Bitmap img)
        {
            if (img != null)
            {
                int width = img.Width;
                int height = img.Height;

                // Tworzymy nowy obraz do przechowania przefiltrowanych pikseli
                Bitmap blurredImg = new Bitmap(width, height);

                // Stosujemy filtr rozmycia na każdym pikselu obrazu
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Color avgColor = CalculateAverageColor(img, x, y);
                        blurredImg.SetPixel(x, y, avgColor);
                    }
                }

                // Kopiujemy przefiltrowany obraz do oryginalnego obrazu
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        img.SetPixel(x, y, blurredImg.GetPixel(x, y));
                    }
                }
            }
        }

        // Funkcja do obliczania średniego koloru pikseli w sąsiedztwie
        private static Color CalculateAverageColor(Bitmap img, int x, int y)
        {
            int radius = 3; 
            int count = 0;
            int totalR = 0, totalG = 0, totalB = 0;

            for (int i = x - radius; i <= x + radius; i++)
            {
                for (int j = y - radius; j <= y + radius; j++)
                {
                    if (i >= 0 && i < img.Width && j >= 0 && j < img.Height)
                    {
                        Color pixelColor = img.GetPixel(i, j);
                        totalR += pixelColor.R;
                        totalG += pixelColor.G;
                        totalB += pixelColor.B;
                        count++;
                    }
                }
            }

            // Obliczamy średni kolor pikseli w sąsiedztwie
            int avgR = totalR / count;
            int avgG = totalG / count;
            int avgB = totalB / count;

            return Color.FromArgb(avgR, avgG, avgB);
        }
    }
}
