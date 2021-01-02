
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TerrainPaint))]
public class TerrainPaintButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TerrainPaint myScript = (TerrainPaint)target;
 
        if (GUILayout.Button("Paint"))
        {
            myScript.Paint();
        }
    }
}