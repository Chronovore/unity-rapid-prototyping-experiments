using Resources;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(ResourceSystemBehaviour))]
    public class ResourceSystemEditor : UnityEditor.Editor
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
}
