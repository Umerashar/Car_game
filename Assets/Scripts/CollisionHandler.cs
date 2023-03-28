using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
    }

    private void StartDeathSequence()
    {
      //  SendMessage("OnPlayerDeath");
    }
}
