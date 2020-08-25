using System;

namespace TelCo.ColorCoder
{

    class ColorCode
    {
        /****************************Genertes Color from Pair number******************************/
        public static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            // The function supports only 1 based index. Pair numbers valid are from 1 to 25
            int minorSize = ColorCodeConstant.colorMapMinor.Length;
            int majorSize = ColorCodeConstant.colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            // Find index of major and minor color from pair number
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;



            // Construct the return val from the arrays
            ColorPair pair = new ColorPair()
            {
                majorColor = ColorCodeConstant.colorMapMajor[majorIndex],
                minorColor = ColorCodeConstant.colorMapMinor[minorIndex]
            };

            // return the value
            return pair;
        }

        /****************************Genertes corresponding no. from color******************************/

        public static int GetPairNumberFromColor(ColorPair pair)
        {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int i = 0; i < ColorCodeConstant.colorMapMajor.Length; i++)
            {
                if (ColorCodeConstant.colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }



            // Find the minor color in the array and get the index
            int minorIndex = -1;
            for (int i = 0; i < ColorCodeConstant.colorMapMinor.Length; i++)
            {
                if (ColorCodeConstant.colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            // If colors can not be found throw an exception
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }



            // Compute pair number and Return  
            // (Note: +1 in compute is because pair number is 1 based, not zero)
            return (majorIndex * ColorCodeConstant.colorMapMinor.Length) + (minorIndex + 1);
        }
    }
}
