using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Award))]
public class AwardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // Draw the type field
        var typeProperty = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProperty);

        var textFieldProperty = serializedObject.FindProperty("awardTextField");
        EditorGUILayout.PropertyField(textFieldProperty);

        var textProperty = serializedObject.FindProperty("awardText");
        EditorGUILayout.PropertyField(textProperty);



        // Draw the amount field if type is set to Add
        if (typeProperty.intValue == (int)Award.AwardType.Add)
        {
            var amountProperty = serializedObject.FindProperty("amount");
            EditorGUILayout.PropertyField(amountProperty, new GUIContent("Amount"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
