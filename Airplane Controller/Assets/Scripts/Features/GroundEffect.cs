using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEffect : MonoBehaviour
{
    #region Variable
    private Rigidbody rb;
    public float MaxGroundDistance = 3f;
    public float LiftForce = 100f;
    public float maxSpeed = 15f;
    #endregion


    #region BulidInMethod
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(rb)
        {
            HandleGroundEffect();
        }
    }
    #endregion

    #region CustomMethod
    protected virtual void HandleGroundEffect()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            if(hit.transform.tag == "Ground" && hit.distance < MaxGroundDistance)
            {
                float currvelocity = rb.velocity.magnitude;
                float normalizedSpeed = currvelocity / maxSpeed;
                normalizedSpeed = Mathf.Clamp01(normalizedSpeed);
                float distance = MaxGroundDistance - hit.distance;
                float FinalForce = LiftForce * distance * normalizedSpeed;
                rb.AddForce(Vector3.up * FinalForce);
            }
        }
    }
    #endregion
}
