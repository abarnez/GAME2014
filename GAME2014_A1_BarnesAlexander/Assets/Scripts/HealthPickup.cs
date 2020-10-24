/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 Health pickup
 Used to control the health pickup that is spawned on chance by enemies, it just falls towards the player, if the player picks it up they get a health, if theyre at max health which is 3 it will remain at 3
 LAST MODIFIED 10/24/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void checkBounds()
    {
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        GameObject thePlayer = GameObject.Find("Player");
        
        PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();

        if (other.tag == "Player")
        {

            if (playerScript.Health < 3)
            {
                playerScript.Health += 1.0f;
            }
            Destroy(gameObject);
        }

    }

    private void Move()
    {
        transform.position += new Vector3(0.0f, speed);
    }
}
