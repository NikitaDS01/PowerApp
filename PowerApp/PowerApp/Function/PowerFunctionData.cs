using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public class PowerFunctionData
    {
        public float ValueA { get; set; }
        public float ValueK { get; set; }
        public PowerFunctionData(float valueA, float valueK)
        {
            ValueA = valueA;
            ValueK = valueK;
        }
        public float GetY(float valueX)
        {
            return ValueK * (float)Math.Pow(ValueA, 2);
        }
    }
}
