using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(TerrainLoader))]
public class TerrainLoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TerrainLoader target = (TerrainLoader)base.target;

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Activate \"Activate\""))
        {
            ActivateAllRenderers(target.activate);
        }
        if (GUILayout.Button("Deactivate \"Activate\""))
        {
            DeactivateAllRenderers(target.activate);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Activate \"Deactivate\""))
        {
            ActivateAllRenderers(target.deactivate);
        }
        if (GUILayout.Button("Deactivate \"Deactivate\""))
        {
            DeactivateAllRenderers(target.deactivate);
        }
        GUILayout.EndHorizontal();

    }

    public void ActivateAllRenderers(GameObject go)
    {
        if(go == null)
        {
            return;
        }

        foreach(MeshRenderer r in go.GetComponentsInChildren<MeshRenderer>(true))
        {
            r.enabled = true;
        }
    }

    public void DeactivateAllRenderers(GameObject go)
    {

        if(go == null)
        {
            return;
        }

        foreach (MeshRenderer r in go.GetComponentsInChildren<MeshRenderer>(true))
        {
            r.enabled = false;
        }
    }
}
