using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] LevelButtons;


    private void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 2);
        for (int i = 0; i < LevelButtons.Length; i++)
        {
            if (i + 2 > currentLevel)
                LevelButtons[i].interactable = false;
        }    
    }
    public void ResetLevel()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ChangeLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
    }

    
}
