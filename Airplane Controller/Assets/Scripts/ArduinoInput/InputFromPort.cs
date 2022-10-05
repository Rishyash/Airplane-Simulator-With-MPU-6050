using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Ports;
public class InputFromPort : MonoBehaviour
{   

    public AirplaneInputs airplaneInputs;
    SerialPort seri = new SerialPort("COM3",9600);
    // Start is called before the first frame update
    void Awake()
    {
        seri.Open();
        StartCoroutine(ReadData());
    }

    IEnumerator ReadData()
    {   
        while(true){
        string[] values = seri.ReadLine().Split(',');
            print(values[0] + " , " + values[1] + " , " + values[2] + " , ");
        if(values.Length >2)
        {   
            airplaneInputs.pitch = float.Parse(values[0]) * -1;
            airplaneInputs.roll = int.Parse(values[1]) * -1;
            airplaneInputs.yaw = int.Parse(values[2]) * -1;
            //airplaneInputs.throttle = int.Parse(values[3]) / 10;
        }
        yield return new WaitForSeconds(.05f);}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
