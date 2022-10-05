using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class RigidBodyController : MonoBehaviour
{

    protected Rigidbody rb;
    protected AudioSource aSource;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
        if(aSource)
        {
            aSource.playOnAwake = false;
        }
    }

   
    void FixedUpdate()
    {
        if(rb)
        {
            HandlePhysics();
        }
    }

    protected virtual void HandlePhysics()
    {

    }
}
