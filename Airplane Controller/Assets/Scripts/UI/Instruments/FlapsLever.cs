using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlapsLever : MonoBehaviour , AirplaneUI
{
    #region Variable
    [Header("Flap Level")]
    public AirplaneInputs input;
    public RectTransform Parent;
    public RectTransform lever;
    public float Handhlespeed = 2;
    #endregion

    #region BuildInregion
    void Start()
    {

    }


    void Update()
    {

    }
    #endregion

    #region CustomMethod
    public void HandleAirplaneUI()
    {
        if (input && Parent && lever)
        {
            float height = Parent.rect.height;
            Vector2 wantedhandlepos = new Vector2(0, -height * input.NornalizedFlap);
            lever.anchoredPosition = Vector2.Lerp(lever.anchoredPosition, wantedhandlepos, Time.deltaTime * Handhlespeed);
        }

    }
    #endregion
}
