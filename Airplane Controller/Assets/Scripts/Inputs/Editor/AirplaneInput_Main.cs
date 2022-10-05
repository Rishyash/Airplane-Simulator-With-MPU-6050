using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AirplaneInputs))]
public class AirplaneInput_Main : Editor
{
    #region Variable
    private AirplaneInputs targetInput;
    #endregion



    private void OnEnable()
    {
        targetInput = (AirplaneInputs)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        string debugInfo = "";
        debugInfo += "Pitch = " + targetInput.Pitch + "\n";
        debugInfo += "Roll = " + targetInput.Roll + "\n";
        debugInfo += "Yaw = " + targetInput.Yaw + "\n";
        debugInfo += "Throttle = " + targetInput.Throttle + "\n";
        debugInfo += "Brake = " + targetInput.Break + "\n";
        debugInfo += "Flaps = " + targetInput.Flaps + "\n";



        GUILayout.Space(10);
        EditorGUILayout.TextArea(debugInfo,GUILayout.Height(100));
        GUILayout.Space(10);
        Repaint();
    }
}
