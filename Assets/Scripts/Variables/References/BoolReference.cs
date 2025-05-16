using System;

/// <summary>
/// Bool variable reference object.
/// </summary>
[Serializable]
public class BoolReference
{
    public bool useConstant;
    public bool ConstantValue;
    public BoolVariable Variable;

    public bool Value
    {
        get
        {
            return useConstant ? ConstantValue : Variable.value;
        }
    }
}