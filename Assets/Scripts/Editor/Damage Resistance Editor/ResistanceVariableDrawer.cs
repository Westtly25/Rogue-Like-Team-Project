using UnityEngine;
using UnityEditor;
using RogueLike.Combat;

[CustomPropertyDrawer(typeof(ResistanceVariable))]
public class ResistanceVariableDrawer: PropertyDrawer
{
    private float height = 20f;
    private float spacing = 5f;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 3 + 6;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty( position, label, property );

        Rect titleRect = new Rect(position.x, position.y, position.width, height);
        Rect boolValueRect = new Rect(position.x, position.y + height + spacing, 100f, height);
        Rect value = new Rect(position.x + boolValueRect.width + spacing, position.y + height + spacing, 100f, height);
        Rect labelPercentage = new Rect(position.x + boolValueRect.width + value.width + spacing, position.y + height + spacing, 15, height);

        property.FindPropertyRelative("damageType").objectReferenceValue = (DamageType)EditorGUI.ObjectField(titleRect, property.FindPropertyRelative("damageType").objectReferenceValue , typeof(DamageType), true);

        property.FindPropertyRelative("isInvulnerable").boolValue = EditorGUI.ToggleLeft(boolValueRect, "Invulnerable", property.FindPropertyRelative("isInvulnerable").boolValue);

        if(property.FindPropertyRelative("isInvulnerable").boolValue == false)
        {
            property.FindPropertyRelative("resistancePercentage").floatValue = EditorGUI.FloatField(value, property.FindPropertyRelative("resistancePercentage").floatValue);
            EditorGUI.LabelField(labelPercentage, "%");
        }
        else property.FindPropertyRelative("resistancePercentage").floatValue = 100f;
        EditorGUI.EndProperty();
    }
}