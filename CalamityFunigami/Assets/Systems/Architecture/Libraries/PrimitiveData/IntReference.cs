using System;
using Calamity.Math;

namespace Calamity.Primitives
{
    [Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        public int ConstantValue;
        public bool UseFormula = false;
        public MathFormula<int> Formula;
        public IntVariable Variable;

        /*public IntReference()
        { }

        public IntReference(int value)
        {
            UseConstant = true;
            UseFormula = false;
            ConstantValue = value;
        }*/

        //public IntReference(int initialValue) : base(initialValue)
        //{ }

        public int Value
        {
            get { return UseConstant ? ConstantValue : UseFormula ? Formula.Value : (Variable as IntVariable).Value; }
            set { if (UseConstant) ConstantValue = value; else (Variable as IntVariable).SetValue(value); }
        }

        public static implicit operator int(IntReference reference)
        {
            return reference.Value;
        }
    }
}
