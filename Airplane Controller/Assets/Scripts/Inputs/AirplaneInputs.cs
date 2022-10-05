using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneInputs : MonoBehaviour
{
    #region Variable
    public float pitch = 0f;
    public float roll = 0f;
    public float yaw = 0f;
    public float throttle = 0f;

    public KeyCode BrakeKey = KeyCode.Space;
    public KeyCode CameraKey = KeyCode.C;
    protected bool CameraSwitch = false;
    protected float brake = 0f;
    public int maxFlapIncrement = 2;
    protected int flaps = 0;

    public float throttleSpeed = 0.1f;
    private float stikyThrotle;
    
    #endregion

    #region Properties
    public float Pitch
    {
        get { return pitch; }
    }
    public float Roll
    {
        get { return roll; }
    }
    public float Yaw
    {
        get { return yaw; }
    }
    public float Throttle
    {
        get { return throttle; }
    }

    public int Flaps
    {
        get { return flaps; }
    }

    public float Break
    {
        get { return brake; }
    }

    public float StikyThrottle
    {
        get{ return stikyThrotle; }
    }

    public bool cameraSwitch
    {
        get { return CameraSwitch; }
    }

    private float normalizeFlap;

    public float NornalizedFlap
    {
        get { return (float)flaps / maxFlapIncrement; }
    }
    


    #endregion


    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
    }

    void StikyThrottleControl()
    {
        stikyThrotle = stikyThrotle + (throttle * throttleSpeed * Time.deltaTime);
        stikyThrotle = Mathf.Clamp01(stikyThrotle);
       // Debug.Log(stikyThrotle);
    }

    public void Respawn()
    {
        stikyThrotle = 0;
    }
    void HandleInput()
    {
        //pitch = Input.GetAxis("Vertical");
        //roll = Input.GetAxis("Horizontal");
        //yaw = Input.GetAxis("Yaw");
        //throttle = Input.GetAxis("Throttle");
        // if (Input.GetKey(KeyCode.W))
        // {
        //     pitch = 1;
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     pitch = -1;
        // }
        // else
        // {
        //     pitch = 0;
        // }
        // if (Input.GetKey(KeyCode.D))
        // {
        //     roll = 1;
        // }
        // else if (Input.GetKey(KeyCode.A))
        // {
        //     roll = -1;
        // }
        // else
        // {
        //     roll = 0;
        // }
        // if (Input.GetKey(KeyCode.RightArrow))
        // {
        //     yaw = 1;
        // }
        // else if (Input.GetKey(KeyCode.LeftArrow))
        // {
        //     yaw = -1;
        // }
        // else
        // {
        //     yaw = 0;
        // }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            throttle = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            throttle = -1;
        }
        else
        {
            throttle = 0;
        }
        StikyThrottleControl();
        brake = Input.GetKey(BrakeKey)? 1f : 0f;
        if(Input.GetKeyDown(KeyCode.F))
        {
            flaps += 1;
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            flaps -= 1;
        }

        flaps = Mathf.Clamp(flaps, 0, maxFlapIncrement);

        CameraSwitch = Input.GetKeyDown(CameraKey);
    }
}
