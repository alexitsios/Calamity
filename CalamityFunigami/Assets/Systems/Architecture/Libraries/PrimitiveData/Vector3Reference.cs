using System;
using UnityEngine;

namespace Calamity.Primitives
{
    [Serializable]
    public class Vector3Reference
    {
        public bool UseConstant = true;
        public Vector3 ConstantValue;
        public bool UseComposite = false;

        public CompositeVector3Reference CompositeVector3;

        public Vector3Variable Variable;

        public Vector3Reference()
        { }

        public Vector3Reference(Vector3 value)
        {
            UseConstant = true;
            UseComposite = false;
            ConstantValue = value;
        }

        public Vector3 Value
        {
            get { return UseConstant ? ConstantValue : UseComposite ? CompositeVector3.Value : Variable.Value; }
            set { if (UseConstant) ConstantValue = value; else Variable.SetValue(value); }
        }

        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }
    }
}