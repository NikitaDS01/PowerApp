using System;
using System.Collections.Generic;
using System.Text;

namespace PowerApp.Function
{
    public struct ValueY
    {
        public bool IsEmpty { get; private set; }
        public float Value { get; private set; }

        public ValueY(float value, bool isNotEmpty =false)
        {
            IsEmpty = isNotEmpty;
            Value = value;
        }
    }
}
