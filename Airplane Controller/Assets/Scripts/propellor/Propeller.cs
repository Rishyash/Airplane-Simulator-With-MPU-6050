using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    #region Variable
    [Header("Propeller Properties")]
     public float QUADminRpm = 300f;
    public float minTextureSwap = 600f;
    public GameObject mainProp;
    public GameObject BlurProp;
    public float MinPropRotation = 1100f;

    [Header("Meterial Properties")]

    public Material BlurPropMat;
    public Texture2D Blur1,Blur2;

    #endregion

    #region BuildIn method
    private void Start()
    {
        if (mainProp && BlurProp)
        {
            HandleSwaping(0f);
        }
    }
    #endregion

    #region CustomMethod
    public void HandleRPM(float currRPM)
    {
        // degree per sec
        float dps = ((currRPM * 360) / 60) * Time.deltaTime;
        if(dps <10)
        {
            dps = 10f;
        }
        dps = Mathf.Clamp(dps, 0f, MinPropRotation);
        transform.Rotate(Vector3.forward, dps);
        //Debug.Log(dps);
        if(mainProp && BlurProp)
        {
            HandleSwaping(currRPM);
        }
        
    }

    public void HandleSwaping(float currRPM)
    {
        if(currRPM > QUADminRpm)
        {
            BlurProp.gameObject.SetActive(true);
            mainProp.gameObject.SetActive(false);

            if(BlurPropMat  && Blur1 && Blur2)
            {   
                if (currRPM > minTextureSwap)
                {
                    BlurPropMat.SetTexture("_MainTex", Blur2);
                }
                else
                {
                    BlurPropMat.SetTexture("_MainTex", Blur1);
                }
                
            }
            
        }
        else
        {
            BlurProp.gameObject.SetActive(false);
            mainProp.gameObject.SetActive(true);
        }
    }
    #endregion
}
