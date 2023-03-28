using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int Hit = 10;
    public ScoreBoard scoreboard;
    public ParticleSystem ps;
        // Start is called before the first frame update
    void Start()
    {
        scoreboard = FindObjectOfType<ScoreBoard>();

    }
    

    // Update is called once per frame
    
     void OnParticleCollision(GameObject other)
    {

        scoreboard.Scorehit(scorePerHit);
        Hit = Hit - 1;
        if(Hit <=1)
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            KillPlayer();
            
        }
    }

    private void KillPlayer()
    {
        
        Destroy(gameObject);
    }
}
