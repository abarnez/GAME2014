/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 Bonus Enemy Script
 When enemy is spawned, it will fly across the screen, if the player hits it once theyll kill it and get extra points
 LAST MODIFIED 10/24/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemyScript : MonoBehaviour
{


    public float speed;
    public float chance;
    public int Health;
    public AudioSource BE_S;
    
    void Start()
    {

        BE_S.Play();
}
    void Update()
    {
        
        Move();
        checkBounds();
    }

    private void Move()
    {
        transform.position += new Vector3(speed, 0.0f);
    }

    private void checkBounds()
    {
        if (transform.position.x > 2.2)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Health--;
            GameObject thePlayer = GameObject.Find("Player");

            PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();

            if (Health == 0)
            {
              
                playerScript.Score += 50.0f;
                

                Destroy(gameObject);

            }
        }
    }


}
