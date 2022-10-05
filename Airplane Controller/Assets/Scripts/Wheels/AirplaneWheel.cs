using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof( WheelCollider))]
public class AirplaneWheel : MonoBehaviour
{
    #region Variable
    [Header("WheelProperties")]
    public Transform WheelGraphics;
    private WheelCollider wheelcol;
    public bool isBreaking = false;
    public float breakPower = 5f;
    private Vector3 worrlPos;
    private Quaternion worldRot;
    private float FinalBreakForce;
    public bool isStearing = false;
    public float StearingAngle = 20f;
    private float FInalStearAngle;
    public float smoothStearSpeed = 8f;
    #endregion

    private bool isGrounded = false;
    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    #region BuildInRegion
    private void Start()
    {
        wheelcol = GetComponent<WheelCollider>();

    }
    #endregion

    #region CustomMethod
    public void TorqeWheel()
    {   
        if(wheelcol)
        {
            wheelcol.motorTorque = 0.000000001f;
        }
        
    }

    public void HandleWheel(AirplaneInputs input)
    {   
        if(wheelcol)
        {
            wheelcol.GetWorldPose(out worrlPos, out worldRot);
            if (WheelGraphics)
            {
                WheelGraphics.position = worrlPos;
                WheelGraphics.rotation = worldRot;
                
            }
            if (isBreaking)
            {
                
                if (input.Break > 0.1f)
                {
                    FinalBreakForce = Mathf.Lerp(FinalBreakForce, input.Break * breakPower, Time.deltaTime);
                    wheelcol.brakeTorque = FinalBreakForce;
                }
                else
                {
                    FinalBreakForce = 0f;
                    wheelcol.brakeTorque = 0f;
                    wheelcol.motorTorque = 0.000000001f;
                }
            }
            if(isStearing)
            {
                FInalStearAngle = Mathf.Lerp(FInalStearAngle, input.Yaw * StearingAngle, Time.deltaTime * smoothStearSpeed);
                wheelcol.steerAngle = FInalStearAngle ;
            }

            isGrounded = wheelcol.isGrounded;
            
        }
    }
    #endregion
}
