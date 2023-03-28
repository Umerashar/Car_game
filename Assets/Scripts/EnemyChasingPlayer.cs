using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingPlayer : MonoBehaviour
{
    public float MovementSpeed = 3f;
    public float TurningSpeed = 3f;
    GameObject player;
    public float KOTime;
    public float Damage = 20 ;
    
    public HealthScript healthS;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        SetRotation(rotation);
        SetPosition();
    }

    private void SetPosition()
    {
        transform.position += transform.forward * Time.deltaTime * MovementSpeed;
    }

    private void SetRotation(Quaternion rotation)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * TurningSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag ("Player"))
        {

            healthS.TakeDamage(Damage);
            
            //Destroy(gameObject);
            Debug.Log("Enemy Hit");

        }
    }


    
}

