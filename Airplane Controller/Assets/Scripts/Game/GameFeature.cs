using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFeature : MonoBehaviour
{

    public EngineFuel fuel;
    public AudioSource sound;
    public GameObject Can;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print(other.gameObject.name);
        if (other.gameObject.tag =="Player")
        {
            //print("das");
            sound.Play();
            score.UpdateScore();
            Can.SetActive(false);
            fuel.AddFuel(1);
        }
    }
    
}
