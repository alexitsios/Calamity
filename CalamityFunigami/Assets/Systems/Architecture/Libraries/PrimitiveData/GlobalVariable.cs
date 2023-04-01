using System;
using UnityEngine;

namespace Calamity.Primitives
{
    [Serializable]
    public abstract class GlobalVariable : ScriptableObject
    {
        public abstract object UntypedValue { get; }
    }

    [Serializable]
    public abstract class GlobalVariable<T> : GlobalVariable
    {
        [SerializeField] T _value;

        public override object UntypedValue { get { return _value; } }

        public virtual T Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value))
                    return;

                _value = value;
            }
        }

        public static implicit operator T(GlobalVariable<T> variableOfT)
        {
            return variableOfT.Value;
        }

        /*public T CopyVariable()
        {
            if (typeof(T).IsValueType)
            {
                return Value;
            }
            else
            {
                // Calling Instantiate ensures we get an actual copy of the object, rather than a 
                // reference. Unless T is a UnityEngine.Object, in which case it is also just a 
                // reference.
                // This creates and destroys a ScriptableObject.
                var globalCopy = Instantiate(this);
                T variableCopy = globalCopy.Value;
                DestroyImmediate(globalCopy);

                return variableCopy;
            }
        }*/
    }
}