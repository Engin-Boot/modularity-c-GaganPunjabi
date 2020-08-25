using System.Drawing;



namespace TelCo.ColorCoder
{
    public static class ColorCodeConstant
    {
        public static readonly Color[] colorMapMajor;
        public static readonly Color[] colorMapMinor;
        static ColorCodeConstant()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
    }
}