using UnityEngine;
using UnityEditor;
using RogueLike.Combat;

[CustomEditor(typeof(DamageResistanceDataContainerSO))]
public class DamageResistanceContainerSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Edit"))
        {
            DamageResistanceContainerSOEditorWindow.Open((DamageResistanceDataContainerSO)target);
        }    
    }
}