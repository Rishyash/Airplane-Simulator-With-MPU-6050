using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollowCamera : MonoBehaviour
{
    #region Variable
    [Header("Bacis CAmeraProperty")]
    public Transform target;
    public float distance = 5f;
    public float height = 2f;
    private Vector3 smoothVelocity;
    public float SmoothTime = .5f;
    protected float origHeight;
    #endregion

    #region Bildin Method
    private void Start()
    {
        origHeight = height;
    }

    private void FixedUpdate()
    { 
        if(target)
        {
            HandleCamera();
        }
        
    }
    #endregion

    #region Custom Method
    public virtual void HandleCamera()
    {
        Vector3 WantedPos = target.position + (-target.forward * distance) + (Vector3.up * height);
        transform.position = Vector3.SmoothDamp(transform.position,WantedPos,ref smoothVelocity,SmoothTime);
        transform.LookAt(target);
    }
    #endregion

}
