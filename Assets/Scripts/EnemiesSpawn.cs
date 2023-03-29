using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 50; i > 0; i--)
        {
            Spawn();
        }
    }

    // Update is called once per frame
   void Spawn()
    {
        Instantiate(enemy, new Vector3(Random.Range(-5f, 13f), Random.Range(0.641f, 0.642f), Random.Range(50f, 600f)), Quaternion.identity);
    }
}
