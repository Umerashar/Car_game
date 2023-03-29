using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int Level = 0;
    public List<Button> LevelButtons = new();

    private void Start()
    {
        int LevelAt = PlayerPrefs.GetInt("LevelAt", 1);

        for (int i = 0; i < LevelButtons.Count; i++)
        {
            if (i+1 > LevelAt)
            {
                LevelButtons[i].interactable = false;
            }
        }
       //// PlayerPrefs.DeleteKey("LevelCleared");
       // if (PlayerPrefs.HasKey("LevelCleared"))
       // {
       //     UpdateLevel(PlayerPrefs.GetInt("LevelCleared"));

       // }
       // else
       // {
       //     UpdateLevel(Level);
       //     PlayerPrefs.SetInt("LevelCleared", Level);
       // }
        
    }
    //public void UpdateLevel(int numlevel)
    //{
    //    for (int i = 0; i < LevelButtons.Count; i++)
    //    {
    //        if(i<=numlevel)
    //        {
    //            LevelButtons[i].interactable = true;
    //        }
    //        else
    //        {
    //            LevelButtons[i].interactable = false;
    //        }
    //    }
    //}
    //public void LevelCleared(int nextLevel)
    //{
    //    int LevelPassed = PlayerPrefs.GetInt("LevelCleared");
    //    if (LevelPassed <= nextLevel)
    //    {
    //        PlayerPrefs.SetInt("LevelCleared", nextLevel);
    //        LevelPassed = nextLevel;
    //    }
    //    UpdateLevel(LevelPassed);
    //}
}
