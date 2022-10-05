using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airplanetachometre : MonoBehaviour, AirplaneUI
{
    #region Variable
    [Header("TachoMetre Propertiess")]
    public AirplaneController airplaneController;
    public AirplaneEngine engine;
    public RectTransform pointer;
    public float maxRPM = 3500f;
    public float MAxRotation = 312;
    private float finalRot = 0f;
    public float PointerSpeed = 2f;

    #endregion

    #region BuildInRegion
    #endregion

    #region Interface Method
    public void HandleAirplaneUI()
    {
        if(engine&&pointer)
        {
            float normalizedRPM = Mathf.InverseLerp(0, maxRPM, engine.CurrentRPM);
            float wantedRot = normalizedRPM * -MAxRotation;
            finalRot = Mathf.Lerp(finalRot, wantedRot, Time.deltaTime * PointerSpeed);
            
            pointer.rotation = Quaternion.Euler(0, 0, wantedRot);
            
        }
    }
    #endregion
}
