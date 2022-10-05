using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(EngineFuel))]
public class AirplaneEngine : MonoBehaviour
{
    #region Variable
    [Header("Engine Properties")]
    public float maxForce = 200f;
    public float maxRPM = 2550f;

    public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Header("Propellor")]
    public Propeller propeller;
    #endregion
    private float currentRPM;
    public float CurrentRPM
    {
        get { return currentRPM; }
    }

    private float lastThrottleValue;
    [SerializeField]
    public  bool isShutOff = false;
    private float FinalshutoffthrottlwValue;
    public float ShutOffspeed = 2f;

    public EngineFuel fuel;



    #region BuildInRegion
    private void Start()
    {
        if(!fuel)
        {
            fuel = GetComponent<EngineFuel>();
            if(fuel)
            {
                
            }
        }
        fuel.InitFuel();
    }
    #endregion

    #region CustomMethod
    public Vector3 CalculateForce(float throttle)
    {
        float finalThrottle = Mathf.Clamp01(throttle);

        if(!isShutOff)
        {
            finalThrottle = powerCurve.Evaluate(finalThrottle);
            lastThrottleValue = finalThrottle;
        }
        else
        {
            lastThrottleValue -= Time.deltaTime * ShutOffspeed;
            lastThrottleValue = Mathf.Clamp01(lastThrottleValue);
            FinalshutoffthrottlwValue = powerCurve.Evaluate(lastThrottleValue) ;
            finalThrottle = FinalshutoffthrottlwValue;
            //FinalshutoffthrottlwValue -= 1000f;
        }
        

         currentRPM = finalThrottle * maxRPM;
        if(propeller)
        {
            propeller.HandleRPM(currentRPM);
        }
        HandleFuel(finalThrottle);


        float finalPower = finalThrottle * maxForce;
        Vector3 finalForce = transform.forward * finalPower;
        return finalForce;
    }

    private void HandleFuel(float throtlle)
    {
        if(fuel)
        {
                fuel.UpdateFuel(throtlle);
            
                //print("dsa");
                if(fuel.currFuel<=0)
                {
                    isShutOff = true;
                }
            
        }
    }
    #endregion
}
