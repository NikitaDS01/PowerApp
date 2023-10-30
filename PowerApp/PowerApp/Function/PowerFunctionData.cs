using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public class PowerFunctionData
    {
        public float ValueA { get; set; }
        public float ValueB { get; set; }
        public float ValueK { get; set; }
        public int Scale { get;set; }
        public PowerFunctionData(float valueA, float valueB, float valueK, int scale)
        {
            ValueA = valueA;
            ValueB = valueB;
            ValueK = valueK;
            Scale = scale;
        }
        public double? GetYFloat(float valueX)
        {
            if (valueX < 0)
                return null;
            double newX = Math.Exp(ValueA * Math.Log(valueX, Math.E));
            return (ValueK * newX) + ValueB;
        }
        public double GetYInt(int valueX)
        {
            return (ValueK * Math.Pow(valueX, ValueA)) + ValueB;
        }
    }
}
