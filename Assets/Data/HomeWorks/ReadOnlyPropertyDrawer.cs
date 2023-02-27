using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer//: MonoBehaviour
{
    public enum MyEnum
    {
        enemy1,
        enemy2,
        enemy3
    }
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        property.stringValue = "111111";
        var pos = position;

        EditorGUI.EnumPopup(pos, MyEnum.enemy1);

        pos.y += 30;
        EditorGUI.HelpBox(pos, "11 hdfhh", MessageType.Warning);

        pos.y += 30;
        EditorGUI.DropShadowLabel(pos, "222ghfuhj");

        pos.y += 30;
        EditorGUI.PropertyField(pos, property, label);

        GUI.enabled = true;
    }
}
public class ReadOnlyAttribute : PropertyAttribute
{

}

