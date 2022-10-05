using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI ScoreUI;
    public TextMeshProUGUI IDUI;
    public int score = 0;
    public GameObject GameOverPannel;
    public TextMeshProUGUI GameOverScore;
    public GameObject ControlPannel;
    int flag = 0;
    public AirplaneController airplaneController;
    void Start()
    {
        ScoreUI.text = "Score : 0";
        IDUI.text = SystemInfo.deviceUniqueIdentifier;
    }

    private void Update()
    {
        if(airplaneController.airplaneStates == AirplaneStates.FLYING || airplaneController.airplaneStates == AirplaneStates.GROUNDED)
        {
            flag = 1;
        }
        else
        {
            if (flag == 1 && airplaneController.airplaneStates == AirplaneStates.LANDED)
            {
                print("win");
                GameOverScore.text = "Score : " + score.ToString();
                GameOverPannel.SetActive(true);
                flag = 0;
            }
            flag = 0;
        }
        
    }
    public void UpdateScore()
    {
        score++;
        ScoreUI.text = "Score : " + score.ToString();
    }

    public void CloseControlPannel()
    {
        ControlPannel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OpenControlPannel()
    {
        ControlPannel.SetActive(true);
        Time.timeScale = 0;
    }


}
