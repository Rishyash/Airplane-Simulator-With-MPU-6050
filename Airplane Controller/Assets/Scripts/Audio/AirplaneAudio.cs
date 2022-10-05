using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneAudio : MonoBehaviour
{
    #region Variable
    public AirplaneInputs input;
    [Header("AudioPropertir=es")]
    public AudioSource Idle;
    public AudioSource FullThrottle;
    public float MaxPitchVAlue = 1.2f;
    private float FinalPitchVAlue;
    public AirplaneEngine engine;


    private float FinalVolValue;
    #endregion

    #region BulidIn
    private void Start()
    {
        if(FullThrottle)
        {
            FullThrottle.volume = 0f;
        }
    }
    public void Update()
    {
        if(input)
        {
            HandleAudio();
        }
    }
    #endregion

    #region CustomMethod
    void HandleAudio()
    {
        FinalVolValue = Mathf.Lerp(0f, 1f, input.StikyThrottle);
        FinalPitchVAlue = Mathf.Lerp(0f, MaxPitchVAlue, input.StikyThrottle);
        if(FullThrottle && !engine.isShutOff)
        {
            FullThrottle.volume = FinalVolValue;
        }
        if(FullThrottle && engine.isShutOff)
        {
            FullThrottle.volume -= .01f; 
        }
        
    }
    #endregion


}
