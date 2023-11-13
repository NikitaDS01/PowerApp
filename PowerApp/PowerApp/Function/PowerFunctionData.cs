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
        public ValueY GetY(float valueX)
        {
            if (IsFloat(ValueA) && valueX <= 0)
                return new ValueY(-1, true);
            if(ValueA < 0 && valueX == 0)
                return new ValueY(-1, true);
            return new ValueY(
                (float)(ValueK * Math.Pow(valueX, ValueA))
                );
        }
        private bool IsFloat(float value)
        {
            int whole = (int)Math.Floor(Math.Abs(value));
            float fractional = Math.Abs(value) - whole;
            return fractional > 0 && fractional < 1;
        }
    }
}
