using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public class PowerFunctionData
    {
        public float ValueA { get; set; }
        public float ValueK { get; set; }
        public int Scale { get;set; }
        public PowerFunctionData(float valueA, float valueK, int scale)
        {
            ValueA = valueA;
            ValueK = valueK;
            Scale = scale;
        }
        public double GetY(float valueX)
        {
            if (valueX < 0)
                return float.MinValue;
            double newX = Math.Exp(ValueA * Math.Log(valueX, Math.E));
            return ValueK * newX;
        }
        public double GetY(int valueX)
        {
            return ValueK * Math.Pow(valueX, ValueA);
        }
    }
}
