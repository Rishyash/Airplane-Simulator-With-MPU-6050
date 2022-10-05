using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum controlSurfacesType
{
    Rudder,
    Elevator,
    Flaps,
    Aileron
}
public class Controlsurfaces : MonoBehaviour
{
    #region Variable
    [Header("ControlSurfaces Properties")]
    public controlSurfacesType type = controlSurfacesType.Rudder;
    public float maxAngle = 30f;
    private float WantedAngle;
    public Vector3 Axis = Vector3.right;
    public float SmoothSpeed = 2f; 
    public Transform ControlSurfaceGraphiics;


    #endregion

    #region BuildInregion
    private void Update()
    {
        if(ControlSurfaceGraphiics)
        {
            Vector3 FinalAngle = Axis * WantedAngle;
            ControlSurfaceGraphiics.localRotation = Quaternion.Slerp(ControlSurfaceGraphiics.localRotation, Quaternion.Euler( FinalAngle),Time.deltaTime * SmoothSpeed);
        }
    }
    #endregion


    #region CustomMethod

    public void HandleControlsurfaces(AirplaneInputs input)
    {
        float inputValue = 0f;
        switch(type)
        {
            case controlSurfacesType.Rudder:
                inputValue = input.Yaw;
                break;

            case controlSurfacesType.Elevator:
                inputValue = input.Pitch;
                break;
            case controlSurfacesType.Flaps:
                inputValue = input.Flaps;
                break;
            case controlSurfacesType.Aileron:
                inputValue = input.Roll;
                break;

            default:
                break;
        }

        WantedAngle = inputValue * maxAngle;
    }
    #endregion
}
