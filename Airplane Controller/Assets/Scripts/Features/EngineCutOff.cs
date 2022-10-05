using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngineCutOff : MonoBehaviour
{
    #region Variable
    [Header("Engine Cutoff")]
    public KeyCode engineCutoffKey = KeyCode.O;
    public AirplaneEngine engine;
    //public UnityEvent onenginecutOff = new UnityEvent();
    #endregion

    #region BuildInregion
    void Start()
    {

    }


    void Update()
    {
        if(Input.GetKeyDown(engineCutoffKey))
        {
            HandleEngineCutoff();
        }
    }
    #endregion

    #region CustomMethod
    void HandleEngineCutoff()
    {
        if(engine.isShutOff)
        {
            engine.isShutOff = !engine.isShutOff;
        }
        else
        {
            engine.isShutOff = !engine.isShutOff;
        }
    }
    #endregion
}
