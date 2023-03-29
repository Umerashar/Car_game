using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsScenesChange : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void SceneOne()
    {
        SceneManager.LoadScene("Track");
    }
    public void SceneTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
