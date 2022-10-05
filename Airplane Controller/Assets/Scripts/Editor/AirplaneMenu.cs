using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class AirplaneMenu
{
    [MenuItem("Airplane Tools/Create New Airplane")]
    public static void CreatenewAirplane()
    {
        //SetupTools.CreateDefaultPlane("Airplane");
        AirplaneSetupWindow.LaunchSetupWindow();
    }
}
