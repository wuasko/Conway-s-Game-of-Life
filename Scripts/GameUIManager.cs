using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    public GameObject MainPanel;
    public GameObject OptionsPanel;
    public GameObject ConfirmPanel;
    public Text welcomeText;
    public GameManager gameManager;
    public GameObject Camera;
    public Slider slider;
    // Use this for initialization
    void Start() {
        ShowMainPanel();
        ScaleScreen();
        slider.value = StaticPass.Speed;
        welcomeText.text = "You are now playing: ";
        switch (StaticPass.Preset)
        {
            case 1:
                welcomeText.text += "Blank";
                break;
            case 2:
                welcomeText.text += "Pulsar";
                break;
            case 3:
                welcomeText.text += "Pentadecathlon";
                break;
            case 4:
                welcomeText.text += "Gospel Glider Gun";
                break;
            case 5:
                welcomeText.text += "Random";
                break;
            case 6:
                welcomeText.text += "Brain";
                break;
            case 7:
                welcomeText.text += "Fountain";
                break;
            case 8:
                welcomeText.text += "Fox";
                break;
            case 9:
                welcomeText.text += "Germ";
                break;
            case 10:
                welcomeText.text += "Smiley";
                break;
        }
        welcomeText.text += "\n Press ESC for more options";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!OptionsPanel.activeSelf)
            {
                ShowOptionsPanel();
            }
            else
            {
                Resume();
            }
        }
    }

    public void ScaleScreen()
    {
        Vector3 center;
        float width, height, proportions, centerX, centerY;
        if (StaticPass.SizeX % 2 == 0)
        {
            //even
            centerX = StaticPass.SizeX / 2 - 0.5f;
        }
        else
        {
            centerX = StaticPass.SizeX / 2;
        }
        if (StaticPass.SizeY % 2 == 0)
        {
            //even
            centerY = StaticPass.SizeY / 2 - 0.5f;
        }
        else
        {
            centerY = StaticPass.SizeY / 2;
        }
        center = new Vector3(centerX, centerY, -10);
        Camera.transform.position = center;

        
        proportions = (float)Screen.height / (float)Screen.width;
        height = (float)StaticPass.SizeY * 0.5f;
        width = (float)StaticPass.SizeX * proportions * 0.5f;
        //Debug.Log("Screen size: "+Screen.height+"x"+Screen.width+", grid size: "+StaticPass.SizeY+"x"+StaticPass.SizeX+" ");

        if (proportions > (float)StaticPass.SizeY / (float)StaticPass.SizeX)
        {
            Camera.GetComponent<Camera>().orthographicSize = width;
            //Debug.Log("It's wider, set to scale" + width);
        }
        else
        {
            Camera.GetComponent<Camera>().orthographicSize = height;
            //Debug.Log("It's taller, set to scale" + height);
        }

        //.main.orthograpthicSize = widthToBeSeen * Screen.height / Screen.width * 0.5;
        
    }

    public void UpdateSlider()
    {
        StaticPass.Speed = (int)slider.value;
    }

    public void ShowMainPanel()
    {
        MainPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        ConfirmPanel.SetActive(false);
        gameManager.Pause(true);
        gameManager.isEditable = false;
    }

    public void ShowOptionsPanel()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(true);
        ConfirmPanel.SetActive(false);
        gameManager.Pause(true);
        gameManager.isEditable = false;
    }

    public void Resume()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        gameManager.Pause(false);
        ConfirmPanel.SetActive(false);
        gameManager.isEditable = false;
    }
    public void Edit()
    {
        MainPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        gameManager.Pause(true);
        ConfirmPanel.SetActive(false);
        gameManager.isEditable = true;
    }
    public void LeaveToMenu()
    {
        ConfirmPanel.SetActive(true);
    }
    public void ConfirmedLeave()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
