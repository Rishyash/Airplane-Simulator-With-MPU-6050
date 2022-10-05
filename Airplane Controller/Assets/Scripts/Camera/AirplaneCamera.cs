using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneCamera : BasicFollowCamera
{
    #region Variable
    [Header("Airpalne Camera Propertties")]
    public float minHeightFromGround = 3f;
    #endregion

    #region Bildin Method
    private void Start()
    {

    }

    
    #endregion

    #region Custom Method
   public override void HandleCamera()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit))
        {
             if(hit.distance<minHeightFromGround && hit.transform.tag == "Ground")
            {
                float wantedHeight = origHeight + minHeightFromGround -  hit.distance;
                height = wantedHeight;
            }
        }
        base.HandleCamera();

    }
    #endregion
}
