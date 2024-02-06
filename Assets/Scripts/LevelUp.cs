using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelUp : MonoBehaviour
{
    public GameObject LevelUPCanvas;
    public GameObject Player;
    public bool LevelUpDone = false;
    public Slider slider;

    private int level = 0; //This variable control whole levels of game
    private int XP; //Curent XP increasing per time
    public TextMeshProUGUI levelNumber;

    //New code by BaoHQ - 06/02/2024
    private int nextLvlTargetScore;  //This function is temporary which contain new target xp milestone for next level
    //End of new code
    
    void Start()
    {
        PlayerPrefs.SetInt("XP",0);
        slider.maxValue = 20;
        levelNumber.text = "LV 0";

        SettingStart();
    }
    void Update()
    {
        XP = PlayerPrefs.GetInt("XP");
        sliderValueChanger();
        if(XP == 20 && LevelUpDone == false)
        {
            Time.timeScale = 0;
            LevelUPCanvas.SetActive(true);
            LevelUpDone = true;
            slider.maxValue = 50;
            level = 1;
            levelNumber.text = "LV 1";
        }
        if(XP == 21)
        {
            LevelUpDone = false;
        }
        if(XP == 50 && LevelUpDone == false)
        {
            Time.timeScale = 0;
            LevelUPCanvas.SetActive(true);
            LevelUpDone = true;
            level = 2;
            levelNumber.text = "LV 2";
        }
        if(XP == 51)
        {
            LevelUpDone = false;
        }
        if(XP == 100 && LevelUpDone == false)
        {
            Time.timeScale = 0;
            LevelUPCanvas.SetActive(true);
            LevelUpDone = true;
            level = 3;
            levelNumber.text = "LV 3";
        }
        if(XP == 101)
        {
            LevelUpDone = false;
        }
        if(XP == 200 && LevelUpDone == false)
        {
            Time.timeScale = 0;
            LevelUPCanvas.SetActive(true);
            LevelUpDone = true;
            level = 4;
            levelNumber.text = "LV 4";
        }
    }

    #region Handle upgrade player activities
    public void IncreaseHealthClicked()
    {
        //Attacht to increase health upgrade button
        Player.GetComponent<playerhealth>().SetHealthMax();
        Time.timeScale = 1;
        LevelUPCanvas.SetActive(false);
    }
    public void IncreaseDamgeClicked()
    {
        //Attacht to increase health upgrade button
        Player.transform.GetChild(0).GetChild(0).GetComponent<SowrdAttac>().SetDamageLevelUP();
        Time.timeScale = 1;
        LevelUPCanvas.SetActive(false);
    }
    #endregion
    public void sliderValueChanger()
    {
        if(level == 0)
        {
            slider.value = XP;
        }
        if(level == 1)
        {
            slider.value = XP - 20;
        }
        if(level == 2)
        {
            slider.value = XP - 50;
        }
        if(level == 3)
        {
            slider.value = XP - 100;
        }
        if(level == 4)
        {
            slider.value = XP -200;
        }
    }


    //New code by BaoHQ - 06/02/2024
    private void SettingStart()
    {
        nextLvlTargetScore = 50;
    }
    private void sliderValueChange()
    {

    }
    private void DecideNextLevelPropeties()
    {
        //This function will be call everytime player reach new level

    }
}
