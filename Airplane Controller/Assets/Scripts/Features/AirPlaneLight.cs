using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneLight : MonoBehaviour
{

    #region Variable
    public GameObject Arlight;
    int time;
    int lastTime;
    public Color color;
    public bool light;
    #endregion

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
        lastTime = 0;
        time = 0;
        light = true;

    }



    IEnumerator ExampleCoroutine()
    {
        /*if (time > Light.Count - 1)
        {
            time = 0;
        }
        Light[time].GetComponentInChildren<Light>().color = color;
        time++;
        lastTime = time - 1;

        yield return new WaitForSeconds(.1f);
        Light[lastTime].GetComponentInChildren<Light>().color = Color.white;*/
        if(light)
        {
            this.GetComponentInChildren<Light>().color = color;
        }
        else
        {
            this.GetComponentInChildren<Light>().color = Color.white;
        }
        yield return new WaitForSeconds(.1f);
        light = !light;

        StartCoroutine(ExampleCoroutine());
    }

    #region CustomMethod

    #endregion

}
