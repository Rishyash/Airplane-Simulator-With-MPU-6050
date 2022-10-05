using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AirplaneStates
{
    LANDED,
    GROUNDED,
    FLYING,
    CRASHED
}
[RequireComponent(typeof(AirplaneCharacteristics))]
public class AirplaneController : RigidBodyController
{
    public AirplanePreset airplanePreset;
    [Header("Input")]
    public AirplaneInputs inputs;
    [Tooltip("Weight is in Kg")]
    public float AirPlaneweight = 800;

    public Transform centerofgravity;

    [Header("Engine")]
    public List<AirplaneEngine> engines = new List<AirplaneEngine>();

    [Header("Wheels")]
    public List<AirplaneWheel> wheels = new List<AirplaneWheel>();

    [Header("AirplaneCharacteristics")]

    public AirplaneCharacteristics characteristics;

    [Header("ControlSurfaces")]
    public List<Controlsurfaces> cSurfaces = new List<Controlsurfaces>();

    [SerializeField] public AirplaneStates airplaneStates = AirplaneStates.LANDED;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isLanded = false;
    [SerializeField] private bool isFlying = false;

    const float metretoFeets = 3.28084f;

    private float currMsl;
    public float CurrMsl
    {
        get { return currMsl; }
    }

    private float currAGL;

    public float CurrAGL
    {
        get { return currAGL; }
    }
    public override void Start()
    {
        GetPresetInfo();
        base.Start();
        if(rb)
        {
            rb.mass = AirPlaneweight;
            if(centerofgravity)
            {
                rb.centerOfMass = centerofgravity.localPosition;
            }
            characteristics = GetComponent<AirplaneCharacteristics>();
            if (characteristics)
            {
                characteristics.InitializeCharacteristis(rb,inputs);
            }
        }
        
        if(wheels!=null)
        {
            if(wheels.Count>0)
            {
                foreach(AirplaneWheel wheel in wheels)
                {
                    wheel.TorqeWheel();
                }
            }
        }
        InvokeRepeating("CheckGrounded", 2f, 1f);

        
    }
    protected override void HandlePhysics()
    {   
        if(inputs)
        {
            HandleEngine();
            HandleAerodynamics();
            HandleControlsurfaces();
            HandleWheel();
            HandleAltitude();
        }
        
    }

    void HandleEngine()
    {
        if(engines != null)
        {
            if(engines.Count>0)
            {
                foreach(AirplaneEngine engine in engines)
                {
                    rb.AddForce( engine.CalculateForce(inputs.StikyThrottle));
                }
            }
        }
         
    }
    void HandleAerodynamics()
    {
        if(characteristics)
        {
            characteristics.UpdateCharacteristics();
        }
    }

    
    void HandleAltitude()
    {
        currMsl = transform.position.y * metretoFeets;

        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit))
        {
            currAGL = (transform.position.y - hit.transform.position.y) * metretoFeets;
           // Debug.Log(currAGL);
        }
        
    }

    void HandleControlsurfaces()
    {
        if(cSurfaces.Count>0)
        {
            foreach(Controlsurfaces controlsurfaces in cSurfaces)
            {
                controlsurfaces.HandleControlsurfaces(inputs);
            }
        }
    }
    void HandleWheel()
    {
        if(wheels.Count>0)
        {
            foreach(AirplaneWheel wheel in wheels)
            {
                wheel.HandleWheel(inputs);
            }
        }
    }
    void GetPresetInfo()
    {
        if(airplanePreset)
        {
            AirPlaneweight = airplanePreset.AirplaneWeight;
            centerofgravity.localPosition = airplanePreset.Cogposition;

            characteristics.DragFactor = airplanePreset.DragFactor;
            characteristics.FlapDragFactor = airplanePreset.FlapDragFactor ;
            characteristics.liftcurve = airplanePreset.liftcurve;
            characteristics.Liftmaxpower = airplanePreset.Liftmaxpower;
            characteristics.BankingSpeed = airplanePreset.BankingSpeed;
            characteristics.RollSpeed = airplanePreset.RollSpeed;
            characteristics.YawSpeed = airplanePreset.YawSpeed;
            characteristics.Pitchspeed = airplanePreset.Pitchspeed;
            characteristics.maxkph = airplanePreset.maxkph;
            characteristics.LerpSpeed = airplanePreset.LerpSpeed;
        }
    }

    void CheckGrounded()
    {
        if(wheels.Count > 0)
        {
            int groundedcount = 0;
            foreach(AirplaneWheel wheel in wheels)
            {
                if (wheel.IsGrounded)
                    groundedcount++;
            }
            
            if(groundedcount == wheels.Count)
            {
                isGrounded = true;
                isFlying = false;

                if(rb.velocity.magnitude < 1f)
                {
                    isLanded = true;
                    airplaneStates = AirplaneStates.LANDED;
                }
                else
                {
                    airplaneStates = AirplaneStates.GROUNDED;
                    isLanded = false;
                }
            }
            else
            {
                airplaneStates = AirplaneStates.FLYING;
                isGrounded = false;
                //if(isLanded == false)
                    isFlying = true;
            }
        }
    }
}
