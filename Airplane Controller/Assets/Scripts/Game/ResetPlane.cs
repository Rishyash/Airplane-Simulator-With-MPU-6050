using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour
{

    public Transform RespwanPos;
    public Transform PlanePos;
    public Transform RespwanPosCam;
    public Transform PlanePosCam;
    public Rigidbody rb;
    public AirplaneInputs airplaneInputs;
    public EngineFuel fuel;
    public Score score;
    public GameObject[] Cans;
    public GameObject ScorePannel;

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(2);
    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            airplaneInputs.Respawn();
            rb.velocity = Vector3.zero;
            fuel.AddFuel(1);
            score.ScoreUI.text = "Score : 0";
            ExampleCoroutine();
            PlanePos.position = RespwanPos.position;
            PlanePos.rotation = RespwanPos.rotation;
            PlanePosCam.position = RespwanPosCam.position;
            PlanePosCam.rotation = RespwanPosCam.rotation;
            foreach(GameObject x in Cans)
            {
                x.SetActive(true);
            }

        }
    }

    public void Respawn()
    {
        ScorePannel.SetActive(false);
        airplaneInputs.Respawn();
        rb.velocity = Vector3.zero;
        fuel.AddFuel(1);
        score.ScoreUI.text = "Score : 0";
        ExampleCoroutine();
        PlanePos.position = RespwanPos.position;
        PlanePos.rotation = RespwanPos.rotation;
        PlanePosCam.position = RespwanPosCam.position;
        PlanePosCam.rotation = RespwanPosCam.rotation;
        foreach (GameObject x in Cans)
        {
            x.SetActive(true);
        }
    }

}
