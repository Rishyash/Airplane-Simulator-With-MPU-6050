using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region Variable
    [Header("Camera Properties")]
    public AirplaneInputs input;
    public List<Camera> listofcamera = new List<Camera>();
    public int StartCam = 0;
    private int camIndex = 0;
    #endregion

    #region BuiltIn
    // Start is called before the first frame update
    void Start()
    {
        DisableAllcam();
        listofcamera[StartCam].enabled = true;
        listofcamera[StartCam].GetComponent<AudioListener>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(input.cameraSwitch)
        {
            SwitchCamera();
            
        }
    }
    #endregion

    #region CustomMethod

    public virtual void SwitchCamera()
    {
        if(listofcamera.Count>0)
        {
            DisableAllcam();
            camIndex++;
            if(camIndex>=listofcamera.Count)
            {
                camIndex = 0;   
            }
            listofcamera[camIndex].enabled = true;
            listofcamera[camIndex].GetComponent<AudioListener>().enabled = true;
        }
    }

    void DisableAllcam()
    {
        if(listofcamera.Count>0)
        {
            foreach(Camera cam in listofcamera)
            {
                cam.enabled = false;
                cam.GetComponent<AudioListener>().enabled = false;
            }
        }
    }
    #endregion

}
