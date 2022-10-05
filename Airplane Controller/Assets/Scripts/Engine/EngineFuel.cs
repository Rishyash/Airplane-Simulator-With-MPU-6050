using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngineFuel : MonoBehaviour
{
    #region Variable
    [Header("FuelProperties")]
    [Tooltip("In gallons")]
    public float FuelQuantity = 26f;
    [Tooltip("Avg burn rate per Hour ")]
    public float FuelBurnRate = 6.1f;
    [Header("Events")]
    public UnityEvent onFuel = new UnityEvent();
    #endregion

    #region Properties
    private float CurrFuel;
    public float currFuel
    {
        get { return CurrFuel; }
    }

    private float normalizeFuel;
    public float NornalizeFuel
    {
        get { return normalizeFuel; }
    }
    #endregion


    #region BuildInregion
    private void Start()
    {
       
    }

    #endregion

    #region CustomMethod

    public void InitFuel()
    {
        CurrFuel = FuelQuantity;
    }

    public void AddFuel(float quan)
    {
        CurrFuel += quan;
        CurrFuel = Mathf.Clamp(CurrFuel, 0, FuelQuantity);
        if (currFuel >= FuelQuantity )
        {
            if(onFuel != null)
            {
                onFuel.Invoke();
            }
        }
    }

    public void ResetFuel()
    {
        CurrFuel = FuelQuantity;
    }
    public void UpdateFuel(float aPercentage)
    {
        float currBurn = ((FuelBurnRate * aPercentage)/3600)*Time.deltaTime;
        
        CurrFuel -= currBurn;
        //print(currFuel);
        CurrFuel = Mathf.Clamp(CurrFuel, 0, FuelQuantity);
        normalizeFuel = currFuel / FuelQuantity;
        



    }
    #endregion
}
