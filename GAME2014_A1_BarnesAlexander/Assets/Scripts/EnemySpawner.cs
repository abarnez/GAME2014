/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 Enemy Spawner
 Used to spawn the bonus enemy, every 25 seconds a random number between 1 and 10 is generated if it equals 5 the bonus enemy will spawn
 LAST MODIFIED 10/24/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject BonusEnemy;
    private float chance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        if (Time.frameCount % 2500.0f == 0)
        {
            chance = Random.Range(1, 10);
            
            if (chance ==5 )
            {
                Instantiate(BonusEnemy, transform.position, transform.rotation);
            }
        }


    }
}
