using UnityEngine;
using XNode;

public class NumberSliderNode : Node
{
    [SerializeField, Tooltip("The numeric value output by the slider")]
    public float numericValue = 1f;

    [SerializeField, Tooltip("The number of digits to display after the decimal point")]
    public int digits = 2;

    [SerializeField, Tooltip("The minimum allowed value")]
    public float min = 0f;

    [SerializeField, Tooltip("The maximum allowed value")]
    public float max = 10f;

    // The output port named "Number"
    [Output(ShowBackingValue.Never)] public float Number;

    // This method is called by XNode when a port value is requested
    public override object GetValue(NodePort port)
    {
        if (port.fieldName == "Number")
        {
            // Clamp and round the value before outputting
            float clamped = Mathf.Clamp(numericValue, min, max);
            return (float)System.Math.Round(clamped, digits);
        }
        return null;
    }
}
