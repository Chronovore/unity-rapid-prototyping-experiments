using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ResourceSystemBehaviour))]
public class ResourceSystemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Save"))
        {
            ((ResourceSystemBehaviour) target).UpdateResources();
        }
    }
}
