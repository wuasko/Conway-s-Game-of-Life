using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_Buttons : MonoBehaviour {

    public GameObject MenuPanel;
    public GameObject LevelSelectPanel;
    public GameObject OptionsPanel;
    public InputField inputX;
    public InputField inputY;
    public Slider slider;
    // Use this for initialization
    void Start () {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        OptionsPanel.SetActive(false);
        inputX.text = StaticPass.SizeX.ToString();
        inputY.text = StaticPass.SizeY.ToString();
        slider.value = StaticPass.Speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowLevelPanel()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
        OptionsPanel.SetActive(false);
    }

    public void ShowMenuPanel()
    {
        MenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
        OptionsPanel.SetActive(false);
    }

    public void ShowOptionsPanel()
    {
        MenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }

    public void UpdateSizeX()
    {
        int j;
        if (System.Int32.TryParse(inputX.text, out j))
        {
            StaticPass.SizeX = j;
        }
        else
        {

        }
        //Debug.Log(StaticPass.SizeY);
    }

    public void UpdateSizeY()
    {
        int j;
        if (System.Int32.TryParse(inputY.text, out j))
        {
            StaticPass.SizeY = j;
        }
        else
        {

        }
        //Debug.Log(StaticPass.SizeY);
    }

    public void UpdateSlider()
    {
        StaticPass.Speed = (int) slider.value;
        //Debug.Log(StaticPass.Speed);
    }

    public void LoadLevelPulsar()
    {
        if (StaticPass.SizeX < 15)
        {
            StaticPass.SizeX = 15;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 15)
        {
            StaticPass.SizeY = 15;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 2;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }
    public void LoadLevelPentadecathlon()
    {
        if (StaticPass.SizeX < 16)
        {
            StaticPass.SizeX = 16;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 9)
        {
            StaticPass.SizeY = 9;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 3;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }
    public void LoadLevelGliderGun()
    {
        if (StaticPass.SizeX < 36)
        {
            StaticPass.SizeX = 36;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 15)
        {
            StaticPass.SizeY = 15;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 4;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelBrain()
    {
        if (StaticPass.SizeX < 17)
        {
            StaticPass.SizeX = 17;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 11)
        {
            StaticPass.SizeY = 11;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 6;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelFountain()
    {
        if (StaticPass.SizeX < 19)
        {
            StaticPass.SizeX = 19;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 15)
        {
            StaticPass.SizeY = 15;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 7;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelFox()
    {
        if (StaticPass.SizeX < 8)
        {
            StaticPass.SizeX = 8;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 7)
        {
            StaticPass.SizeY = 7;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 8;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelGerm()
    {
        if (StaticPass.SizeX < 10)
        {
            StaticPass.SizeX = 10;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 10)
        {
            StaticPass.SizeY = 10;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 9;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelSmiley()
    {
        if (StaticPass.SizeX < 7)
        {
            StaticPass.SizeX = 7;
            StaticPass.Stretched = true;
        }
        if (StaticPass.SizeY < 8)
        {
            StaticPass.SizeY = 8;
            StaticPass.Stretched = true;
        }
        StaticPass.Preset = 10;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }


    public void LoadLevelRandom()
    {
        StaticPass.Preset = 5;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }

    public void LoadLevelBlank()
    {
        StaticPass.Preset = 1;
        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        SceneManager.LoadScene(1);
    }


    public void Quit()
    {
        Application.Quit();
    }

    
}
