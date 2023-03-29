using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int nextSceneLoad;
    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            SceneManager.LoadScene(nextSceneLoad);
            if(nextSceneLoad> PlayerPrefs.GetInt("LevelAt"))
            {
                PlayerPrefs.SetInt("LevelAt", nextSceneLoad);
            }

        }
    }
    
}
