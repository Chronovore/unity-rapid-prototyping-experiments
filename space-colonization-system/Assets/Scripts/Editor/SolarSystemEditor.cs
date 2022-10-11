using CelestialBodies;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SolarSystemBehaviour))]
    public class SolarSystemEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            if (GUILayout.Button("Save"))
            {
                ((SolarSystemBehaviour) target).UpdateSolarSystem();
            }
        }
    }
}
