using System;
using UnityEngine;
using Calamity.Math;

namespace Calamity.Primitives
{
    [Serializable]
    public abstract class VariableReference
    {
        [SerializeField] bool useConstant = true;
        [SerializeField] bool useFormula = false;

        /*public bool IsGlobal
        {
            get
            { return _usingGlobal; }
            set
            {
                if (_usingGlobal != value)
                {
                    _usingGlobal = value;
                }
            }
        }*/

        public bool UseConstant
        {
            get
            {
                return useConstant;
            }
            set
            {
                if (useConstant != value)
                {
                    useConstant = value;
                }
            }
        }

        public bool UseFormula
        {
            get
            {
                return useFormula;
            }
            set
            {
                if (useFormula != value)
                {
                    useFormula = value;
                }
            }
        }

        public abstract GlobalVariable UntypedGlobalVariable { get; }

        public abstract bool IsValid { get; }
    }

    [Serializable]
    public class VariableReference<VariableType, GlobalVariableType> : VariableReference//, ISerializationCallbackReceiver
        where GlobalVariableType : GlobalVariable<VariableType>
    {
        [SerializeField] GlobalVariableType _globalVariable;
        [SerializeField] MathFormula<VariableType> formula;
        [SerializeField] VariableType constantValue;

        //public VariableReference() {}

        /*public VariableReference(VariableType initValue)
        {
            _localValue = initValue;
            UseConstant = true;
        }

        public VariableReference(GlobalVariableType initVariable)
        {
            _globalVariable = initVariable;
            IsGlobal = true;
        }*/

        /// <summary>
        /// Since VariableReference is not a UnityEngine.Object type, we will not receive the OnEnable() event.
        /// By implementing ISeralizationCallbackReceiver, we can use OnAfterDeserialize() as an initialization 
        /// method where we subscribe to the referenced GlobalVariable (should there be one).
        /// </summary>
        /*public void OnAfterDeserialize()
        {
            //SubscribeToGlobal();
        }

        public void OnBeforeSerialize()
        { }*/

        public virtual VariableType Value
        {
            get
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot return value on VariableReference in global state when globalReference is null!");
                }

                //return IsGlobal ? GlobalVariable : LocalValue;
                return UseConstant ? LocalValue : UseFormula ? formula.Value : GlobalVariable;
            }
            set
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot assign value to VariableReference in global state when globalReference is null!");
                }

                if (UseConstant)
                {
                    LocalValue = value;

                }
                else if (UseFormula)
                {

                }
                else
                {
                    GlobalVariable.Value = value;
                }
            }
        }

        public GlobalVariableType GlobalVariable
        {
            get
            {
                return _globalVariable;
            }
            set
            {
                if (value.Equals(_globalVariable))
                {
                    return;
                }

                // Unsubscribe from currently reference GlobalVariable
                //UnsubscribeFromGlobal();

                // Set the reference to the new GlobalVariable and subscribe to it's ChangeEvents
                _globalVariable = value;
                //SubscribeToGlobal();

                // Update all subscribers of this VariableReference
                //RaiseChangeEvent();
            }
        }

        public VariableType LocalValue
        {
            get { return constantValue; }
            set
            {
                if (value.Equals(constantValue))
                {
                    return;
                }

                constantValue = value;
                //RaiseChangeEvent();
            }
        }

        public override GlobalVariable UntypedGlobalVariable
        {
            get
            {
                return _globalVariable;
            }
        }

        /// <summary>
        /// IsValid checks if this VariableReference is in a valid state. Meaning, if it can return a meaningful
        /// value.
        /// 
        /// If the VariableReference is pointing to the globalVariable but globalVariable has not been set yet,
        /// we are in an invalid state. We cannot return null as a sentinel value, as we do not know the type of 
        /// VariableType (e.g. it could be an int).
        /// </summary>
        public override bool IsValid
        {
            get
            {
                return UseConstant || UseFormula || _globalVariable != null;
            }
        }

        public static implicit operator VariableType(VariableReference<VariableType, GlobalVariableType> variableReference)
        {
            return variableReference.Value;
        }
    }
}