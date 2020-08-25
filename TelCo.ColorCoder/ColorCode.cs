using System;
namespace TelCo.ColorCoder
{
    class ColorCode
    {
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = ColorCodeConstant.colorMapMinor.Length;
            int majorSize = ColorCodeConstant.colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;
            ColorPair pair = new ColorPair()
            {
                majorColor = ColorCodeConstant.colorMapMajor[majorIndex],
                minorColor = ColorCodeConstant.colorMapMinor[minorIndex]
            };
            return pair;
        }
        public static int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = -1;
            for (int i = 0; i < ColorCodeConstant.colorMapMajor.Length; i++)
            {
                if (ColorCodeConstant.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            int minorIndex = -1;
            for (int i = 0; i < ColorCodeConstant.colorMapMinor.Length; i++)
            {
                if (ColorCodeConstant.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            return (majorIndex * ColorCodeConstant.colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
