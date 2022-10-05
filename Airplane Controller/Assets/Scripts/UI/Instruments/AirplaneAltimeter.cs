using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirplaneAltimeter : MonoBehaviour, AirplaneUI
{
    #region Variable
    [Header("Altimeter Propertiess")]
    public AirplaneController airplaneController;

    public RectTransform hundredPointer;
    public RectTransform thousandPointer; 

    #endregion

    #region BuildInRegion
    #endregion

    #region Interface Method
    public void HandleAirplaneUI()
    {
        if(airplaneController)
        {
            float currAlt = airplaneController.CurrMsl;
            float currThousand = currAlt / 1000;

            currThousand = Mathf.Clamp(currThousand, 0, 10);

            float currHundred = currAlt - (Mathf.Floor(currThousand) * 1000);
            currHundred = Mathf.Clamp(currHundred, 0, 1000);
            if(hundredPointer)
            {
                float normalizedHundred= Mathf.InverseLerp(0, 1000 , currHundred);
                
                float hunRot = 360 * normalizedHundred;
                hundredPointer.rotation = Quaternion.Euler(0, 0, -hunRot);
            }
            if(thousandPointer)
            {
                float normalizedThousand = Mathf.InverseLerp(0, 10, currThousand);
                
                float ThousRot = 360 * normalizedThousand;
                thousandPointer.rotation = Quaternion.Euler(0, 0, -ThousRot);
            }
        }
    }
    #endregion
}



