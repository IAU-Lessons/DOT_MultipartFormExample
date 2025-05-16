using System;
using UnityEngine;

/// <summary>
/// Vector3 variable reference object.
/// </summary>
[Serializable]
public class Vector3Reference
{
    public bool useConstant;
    public Vector3 ConstantValue;
    public Vector3Variable Variable;

    public Vector3 Value
    {
        get
        {
            return useConstant ? ConstantValue : Variable.value;
        }
    }
}