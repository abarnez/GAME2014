/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 enemy bullet script
 used to control bullets that the enemies fire, they fall down towards the player if they collide wtih them they take damage
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript1 : MonoBehaviour
{

    public float speed;
    public GameObject Player;
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
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Destroy(gameObject);
        }
    }

}
