using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltitudeMetre : MonoBehaviour, AirplaneUI
{
    #region Variable
    [Header("Altitude Properties")]
    public AirplaneController airplaneController;
    public RectTransform bg;
    public RectTransform pointer;
    #endregion

    #region BuildInregion
    
    #endregion

    #region CustomMethod
    public void HandleAirplaneUI()
    {
        if (airplaneController)
        {
            float BankAngle = Vector3.Dot(airplaneController.transform.right, Vector3.up) * Mathf.Rad2Deg;
            float PitchAngle = Vector3.Dot(airplaneController.transform.forward, Vector3.up) * Mathf.Rad2Deg;
            Quaternion Bankrot = Quaternion.Euler(0, 0, BankAngle);
            bg.transform.rotation = Bankrot;

            Vector3 wantedRot = new Vector3(0, -PitchAngle, 0);
            bg.anchoredPosition = wantedRot;

            pointer.transform.rotation = Bankrot;
        }

    }
    #endregion
}
