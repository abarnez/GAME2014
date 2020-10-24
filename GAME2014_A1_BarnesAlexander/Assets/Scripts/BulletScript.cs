/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 bullet script
 used to control the player bullets, the fire toward the sky, if they collide when enemies they do damage
 LAST MODIFIED 10/24/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
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
        checkBounds();
    }
    private void Move()
    {
        transform.position += new Vector3(0.0f, speed);
    }

    private void checkBounds()
    {
        if (transform.position.y > 5.2)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

}
