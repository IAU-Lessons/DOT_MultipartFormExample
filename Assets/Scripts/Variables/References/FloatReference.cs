using System;
using UnityEngine;

/// <summary>
/// Float variable reference object.
/// </summary>
[Serializable]
public class FloatReference
{
    [SerializeField] private bool useConstant;
    [SerializeField] private float ConstantValue;
    [SerializeField] private FloatVariable Variable;

    public float Value
    {
        get
        {
            return useConstant ? ConstantValue : Variable.value;
        }
    }
}