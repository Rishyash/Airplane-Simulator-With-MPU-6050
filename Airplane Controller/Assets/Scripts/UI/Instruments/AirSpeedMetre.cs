using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSpeedMetre : MonoBehaviour , AirplaneUI
{
    #region Variable
    [Header("AirSpeed Properties")]
    public AirplaneCharacteristics airplaneCharacteristics;
    public RectTransform pointer;
    public float MaxIndicator = 160;
    
    public float Handhlespeed = 2;
    #endregion

    #region BuildInregion
    
    #endregion

    #region CustomMethod
    public void HandleAirplaneUI()
    {
        if(airplaneCharacteristics && pointer)
        {
            float currKnot = airplaneCharacteristics.mph * .8689f;
            float normalizedKnot = Mathf.InverseLerp(0, MaxIndicator, currKnot);
            float wanteddrot = 360 * normalizedKnot;
            pointer.rotation = Quaternion.Euler(0, 0, -wanteddrot);
        }

    }
    #endregion
}
