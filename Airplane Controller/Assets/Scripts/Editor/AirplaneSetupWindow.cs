using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AirplaneSetupWindow : EditorWindow
{
    #region Variable
    private string Airplanename = null;
    private Object model;
    #endregion

    #region buildinRegion
    public static void LaunchSetupWindow()
    {
        AirplaneSetupWindow.GetWindow(typeof(AirplaneSetupWindow), true, "AirplaneSetup").Show();
    }

    private void OnGUI()
    {
        Airplanename = EditorGUILayout.TextField("AirPlane Name", Airplanename);
        model = EditorGUILayout.ObjectField("Prefab",model,typeof(Object),true); 
        if(GUILayout.Button("Create Airplane"))
        {
            SetupTools.CreateDefaultPlane(Airplanename,model);
            AirplaneSetupWindow.GetWindow(typeof(AirplaneSetupWindow), true, "AirplaneSetup").Close();
        }
       
        }
    }
    #endregion

