using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ChunkGroup))]
public class ChunkGroupEditor : Editor
{

    private ChunkGroup targetCG;
    void OnEnable()
    {
        targetCG = target as ChunkGroup;
    }

    public override void OnInspectorGUI()
    {
        ListManager();
        DisplayChunk();
    }

    private void ListManager()
    {
        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("+"))
        {
            targetCG.AddOneElements();
        }
        if (GUILayout.Button("-"))
        {
            targetCG.RemoveOneElements();
        }

        EditorGUILayout.EndHorizontal();
    }

    private void DisplayChunk ()
    {
        if(targetCG.typeOfObstacle != null)
        for (int i = 0; i < targetCG.typeOfObstacle.Count; i++)
        {
            EditorGUILayout.BeginVertical("box");

            targetCG.typeOfObstacle[i] = (TypeOfObstacle)EditorGUILayout.EnumPopup("TypeOfObstacle " + i.ToString(), targetCG.typeOfObstacle[i]);

            targetCG.speed[i] = EditorGUILayout.FloatField("Chunk Speed", targetCG.speed[i]);

            targetCG.timeBeforeNext[i] = EditorGUILayout.FloatField("Time Befor Next Chunk", targetCG.timeBeforeNext[i]);

            EditorGUILayout.EndVertical();
        }
    }
}
