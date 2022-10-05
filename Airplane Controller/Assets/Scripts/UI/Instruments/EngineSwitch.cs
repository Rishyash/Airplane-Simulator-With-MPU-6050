using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EngineSwitch : MonoBehaviour , AirplaneUI
{
    #region Variable
    [Header("AirSpeed Properties")]
    public AirplaneEngine engine;
    public Image Switch;
    

    
    #endregion

    #region BuildInregion

    #endregion

    #region CustomMethod
    public void HandleAirplaneUI()
    {
        if(!engine.isShutOff)
        {
            Switch.color = new Color32(255,0,0,255);
        }
        else
        {
            Switch.color = new Color32(164, 0, 0, 255);
        }

    }
    #endregion
}
