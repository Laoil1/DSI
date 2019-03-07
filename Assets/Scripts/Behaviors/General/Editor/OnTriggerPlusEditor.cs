using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OnTriggerPlus))]
public class OnTriggerPlusEditor : Editor
{
    private OnTriggerPlus targetOTP;
    
    private void OnEnable()
    {
        targetOTP = target as OnTriggerPlus;
    }

    public override void OnInspectorGUI()
    {
        targetOTP.IsTag = EditorGUILayout.Toggle("Use Tag ?", targetOTP.IsTag);
        if(targetOTP.IsTag)
        {
            EditorGUILayout.LabelField("Test if the tag is the same as the triggered object");
            targetOTP.UseSameTag = EditorGUILayout.Toggle(targetOTP.UseSameTag);

            if(!targetOTP.UseSameTag)
            {
                targetOTP.EnteredTag = EditorGUILayout.TextField("Tag",targetOTP.EnteredTag);
            }

        }
        EditorUtility.SetDirty(target); 
        DrawDefaultInspector();
    }

}
