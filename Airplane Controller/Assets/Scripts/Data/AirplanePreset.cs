using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="LockDownStudio/Create Preset")]
public class AirplanePreset : ScriptableObject
{

    [Header("ControllerProperties")]
    public Vector3 Cogposition;
    public float AirplaneWeight;

    
    
    public float maxkph;
    public float LerpSpeed;
    
    public float Liftmaxpower;
    public AnimationCurve liftcurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    
    public float DragFactor;
    public float FlapDragFactor;

    
    public float Pitchspeed;
    public float RollSpeed;
    public float YawSpeed;
    public float BankingSpeed;

   

   

}
