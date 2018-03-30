using UnityEditor;
using UnityEngine;

// Deactiveert het editen van de variabele in de Inspector.
public class ShowOnlyAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
public class ShowOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
		// Bereken de weergegeven waarde
		string valueStr;

        switch (prop.propertyType)
        {
            case SerializedPropertyType.Integer:
                valueStr = prop.intValue.ToString();
                break;
            case SerializedPropertyType.Boolean:
                valueStr = prop.boolValue.ToString();
                break;
            case SerializedPropertyType.Float:
                valueStr = prop.floatValue.ToString("0.00000");
                break;
            case SerializedPropertyType.String:
                valueStr = prop.stringValue;
                break;
            default:
                valueStr = "(not supported)";
                break;
        }
		// Teken de weergegeven waarde in de Inspector
        EditorGUI.LabelField(position, label.text, valueStr);
    }
}
