using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HealthScript : MonoBehaviour
{
    public static event Action OnPlayerDie;

    public float mexHealth = 100;
     public float CurrentHealth;
    public GameObject explosionPrefab;
    
    public TextMeshProUGUI PlayerHealth;
       

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = mexHealth;

        
        UpdateHealthText();
            

    }

   

    

    public void TakeDamage(float amount )
    {
     
        
        CurrentHealth -= amount;
        UpdateHealthText();




        if (CurrentHealth <= 0)
        {




            CurrentHealth = mexHealth;
            OnPlayerDie?.Invoke(); 
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.Log("The player dai");
               


        }
    }
    void UpdateHealthText()
    {
        PlayerHealth.text = CurrentHealth.ToString();
    }
    

}
