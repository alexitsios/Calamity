using System;
using Calamity.Math;

namespace Calamity.Primitives
{
    [Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float ConstantValue;
        public bool UseFormula = false;
        public MathFormula<float> Formula;
        public FloatVariable Variable;

        public FloatReference()
        { }

        public FloatReference(float value)
        {
            UseConstant = true;
            UseFormula = false;
            ConstantValue = value;
        }

        public float Value
        {
            get { return UseConstant ? ConstantValue : UseFormula ? Formula.Value : (Variable as FloatVariable).Value; }
            set { if (UseConstant) ConstantValue = value; else (Variable as FloatVariable).SetValue(value); }
        }

        public static implicit operator float(FloatReference reference)
        {
            return reference.Value;
        }
    }
}