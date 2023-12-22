using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day3
{
    public static class Day3
    {
        public static int GetPartsSum()
        {
            TransformFile transform = new TransformFile(@"..\..\..\Day3\Input.txt");
            DetectPartNumber detect = new DetectPartNumber(transform.ToTwoDimensionCharTab());
            return detect.GetParts().Sum();
        }

        public static int GetRatioSum()
        {
            TransformFile transform = new TransformFile(@"..\..\..\Day3\Input.txt");
            DetectGear detectGear = new DetectGear(transform.ToTwoDimensionCharTab());
            return detectGear.GetSum();
        }
    }
}
