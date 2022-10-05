using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGuage : MonoBehaviour ,AirplaneUI
{
    #region Variable
    [Header("Fuel Properties")]
    public EngineFuel fuel;
    public RectTransform pointer;
    public Vector2 minMaxRot = new Vector2(-90, 90);
    #endregion

    

    #region CustomMethod
    public void HandleAirplaneUI()
    {
        if(fuel  &&  pointer)
        {
            float wantedrot = Mathf.Lerp(minMaxRot.x, minMaxRot.y, fuel.NornalizeFuel);
            pointer.rotation = Quaternion.Euler(0, 0, -wantedrot);
            
        }
    }
    #endregion
}
