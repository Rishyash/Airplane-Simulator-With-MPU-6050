using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunwayLight : MonoBehaviour
{

    #region Variable
    public List<GameObject> Light = new List<GameObject>();
   int time;
    int lastTime;
    public Color color;
    #endregion

    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(ExampleCoroutine());
        lastTime = 0;
        time = 0;

    }
    
    

    IEnumerator ExampleCoroutine()
    {
        if(time>Light.Count-1)
        {
            time = 0;
        }
        Light[time].GetComponentInChildren<Light>().color = color;
        time++;
        lastTime = time - 1;
        
        yield return new WaitForSeconds(.1f);
        Light[lastTime].GetComponentInChildren<Light>().color = Color.white;
        StartCoroutine(ExampleCoroutine());
    }

    #region CustomMethod
    
    #endregion

}
