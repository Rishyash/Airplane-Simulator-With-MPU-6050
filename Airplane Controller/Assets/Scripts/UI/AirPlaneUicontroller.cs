using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AirPlaneUicontroller : MonoBehaviour
{
    #region Variable
    public List<AirplaneUI> instruments = new List<AirplaneUI>();
    #endregion

    #region BuildInregion
    void Start()
    {
        instruments = transform.GetComponentsInChildren<AirplaneUI>().ToList<AirplaneUI>();
    }


    void Update()
    {
        if(instruments.Count>0)
        {
            foreach(AirplaneUI instrument in instruments)
            {
                instrument.HandleAirplaneUI();
            }
        }
    }
    #endregion

    #region CustomMethod
    #endregion

}
