using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01_nkoirala1
{
    public class ImageReducer : BaseBitmapManip
    {
        public ImageReducer(Bitmap bm, Action<string> error) : base(bm, error)
        {
        }

        public override Bitmap ReduceImage(int Threshold)
        {
            Bitmap result = BitmapOriginal;
            var colorTable = BuildColourTable();

            Dictionary<Color, Color> colorChanged = new Dictionary<Color, Color>();


            while (colorTable.Count > 0)
            {
                List<Color> similarColors = new List<Color>();
                var popularColor = colorTable.OrderByDescending(kv => kv.Value).First().Key;

                foreach (var color in colorTable.Keys.ToList())
                {
                    if (GetColourDifference(popularColor, color) <= Threshold)
                    {
                        similarColors.Add(color);
                        colorChanged[color] = popularColor;
                    }
                }

                foreach (var color in similarColors)
                {
                    colorTable.Remove(color);
                }
            }


            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color current = result.GetPixel(x, y);
                    if (colorChanged.ContainsKey(current))
                        result.SetPixel(x, y, colorChanged[current]);
                }
            }


            return result;
        }
    }
}
