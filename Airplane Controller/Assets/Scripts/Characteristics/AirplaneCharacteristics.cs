  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneCharacteristics : MonoBehaviour
{
    #region Variable
    [Header("ENGINE Information")]
    public float forwardVelocity;
    
    public float mph;
    public float maxkph = 250f;
    public float LerpSpeed;
    [Header("Lift Properties")]
    public float Liftmaxpower = 800f;
    public AnimationCurve liftcurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    public float FlapLift = 100f;

    [Header("Drag Properties")]
    public float DragFactor = 0.01f;
    public float maxmps;
    public float FlapDragFactor;

    [Header("Contrpl Properties")]
    public float Pitchspeed;
    public float RollSpeed;
    public float YawSpeed;
    public float BankingSpeed;
    public AnimationCurve controlsurfaces = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private AirplaneInputs input;
    Rigidbody rb;
    private float startdrag;
    private float AngularDrag;
    
    private float normalizedMPH;

    private float AngleofAttack;
    private float PitchAngle;
    private float RollAngle;
    private float csEffeciencyValue;
   
    #endregion

    #region CustomMethods
    public void InitializeCharacteristis(Rigidbody currrb,AirplaneInputs currinputs)
    {
        input = currinputs;
        rb = currrb;
        startdrag = rb.drag;
        AngularDrag = rb.angularDrag;
        maxmps = maxkph / 2.2f;
    }

    public void UpdateCharacteristics()
    {   
        if(rb)
        {
            calculateDrag();
            CalculateForwardSpeed();
            CalculateLift();
            HandlePitch();
            handleRoll();
            HandleYaw();
            Handlecontrolsurfaces();
            HandleBanking();
            HandleRigidBody();
        }
        
    }
    public void HandleRigidBody()
    {
        if(rb.velocity.magnitude>1f)
        {
            Vector3 UpdatedVelocity = Vector3.Lerp(rb.velocity, transform.forward * forwardVelocity, forwardVelocity * AngleofAttack * Time.deltaTime );
            rb.velocity = UpdatedVelocity;
            // rotate plane
            Quaternion UpdateRotaion = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity.normalized, transform.up),Time.deltaTime);
            rb.MoveRotation(UpdateRotaion);
        }
    }
    public void CalculateForwardSpeed()
    {
        Vector3 localvelocity = transform.InverseTransformDirection(rb.velocity);
        forwardVelocity = Mathf.Max(0f ,localvelocity.z);
        forwardVelocity = Mathf.Clamp(forwardVelocity, 0f, maxmps);
        mph = forwardVelocity * 2.2f;
       // mph = Mathf.Clamp(mph, 0f, maxkph);

        normalizedMPH = Mathf.InverseLerp(0f, maxkph, mph);
        
    }

    void CalculateLift()
    {

        // anglr of attack
        AngleofAttack = Vector3.Dot(rb.velocity.normalized, transform.forward);
        AngleofAttack *= AngleofAttack;
        //Debug.Log(AngleofAttack);
        //Calculate Lift
        Vector3 LiftDir = transform.up;
        float LiftPower = liftcurve.Evaluate(normalizedMPH) * Liftmaxpower;

        // flap lift
        //float finalLiftPower = LiftPower * input.NornalizedFlap;    


        Vector3 FinalLiftForce = LiftDir * (LiftPower) * AngleofAttack ;
        //Debug.Log(LiftPower);
        rb.AddForce(FinalLiftForce);
    }
    void calculateDrag()
    {
        float speedDrag = forwardVelocity * DragFactor;

        float flapdrag = input.Flaps * FlapDragFactor;


        float finalDrag = startdrag + speedDrag + flapdrag;

        rb.drag = finalDrag;
        rb.angularDrag = AngularDrag * forwardVelocity;
    }
    void Handlecontrolsurfaces()
    {
        csEffeciencyValue = controlsurfaces.Evaluate(normalizedMPH);
    }

    void HandlePitch()
    {
        Vector3 flatforward = transform.forward;
        flatforward.y = 0f;
        flatforward = flatforward.normalized;
        PitchAngle = Vector3.Angle(transform.forward, flatforward);
        //Debug.Log(PitchAngle);

        Vector3 PitchTouqe = input.Pitch * Pitchspeed * transform.right * csEffeciencyValue;
        rb.AddTorque(PitchTouqe);


    }
    void handleRoll()
    {
        Vector3 FlatRight = transform.right;
        FlatRight.y = 0f;
        FlatRight = FlatRight.normalized;
        RollAngle = Vector3.SignedAngle(transform.right, FlatRight,transform.forward);

        Vector3 rolltoque = -input.Roll * RollSpeed * transform.forward * csEffeciencyValue;
        rb.AddTorque(rolltoque);

    }
    void HandleYaw()
    {
        Vector3 YawTorque = input.Yaw * YawSpeed * transform.up * csEffeciencyValue;
        rb.AddTorque(YawTorque);
    }
    void HandleBanking()
    {
        float bankside = Mathf.InverseLerp(-90f, 90f, RollAngle);
        float BankAmount = Mathf.Lerp(-1f, 1f, bankside);
        Vector3 bankTorque = BankAmount * BankingSpeed * transform.up ;
        rb.AddTorque(bankTorque);
    }
    #endregion
}
