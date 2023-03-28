using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject GameOverMenu;

    private void OnEnable()
    {
        HealthScript.OnPlayerDie += EnableGameOverMenu;
    }
    private void OnDisable()
    {
        HealthScript.OnPlayerDie -= EnableGameOverMenu;
    }
    

    public void EnableGameOverMenu()
    {
        GameOverMenu.SetActive(true);
    }
}
