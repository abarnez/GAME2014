/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 Enemy Script
 Controls the enemies, makes them fire at an random interval set between 9,20 seconds, as well as giving a 1 in 5 chance to drop a health pack on death for the player, if it gets hit 3 times it will die
 LAST MODIFIED 10/24/2020
 VERSION 1.0.0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public Collider2D EnemyCheck;
    //public PolygonCollider2D Body;
    public GameObject bullet;
   // public GameObject Enemybullet;
    public GameObject ally;
    public GameObject FirePoint;
    public GameObject healthpickup;
    public int Health;
    public Vector3 shift;
    private float chance;
    private float chance2;
    public int delay;
    public AudioSource fire_weapon_sound;
   
    public AudioClip deathsound;



    // Start is called before the first frame update
    void Start()
    {
        chance = Random.Range(900, 2000);
        chance2 = Random.Range(1, 5);
       






    }

    // Update is called once per frame
    void Update()
    {
       Move();
        if(ally == null)
        {
            Fire();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet") {
            Health--;
            GameObject thePlayer = GameObject.Find("Player");

            PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();

            if (Health == 0)
            {
                if (chance2 == 3)
                {
                    Instantiate(healthpickup, transform.position, transform.rotation);
                }
                
                playerScript.Score += 10.0f;
                AudioSource.PlayClipAtPoint(deathsound, transform.position);

                Destroy(gameObject);

            }
        }     
    }
    private void Fire()
    {
        if (Time.frameCount % chance == 0)
        {
            if(FirePoint == null)
            {
                Destroy(gameObject);
            }
            Instantiate(bullet, FirePoint.transform.position, transform.rotation);
            fire_weapon_sound.Play();
        }

    }

    public void Move()
    {
        if (transform.position.y > shift.y)
        {
           // transform.Translate(Vector3.down * -Time.deltaTime / 2);
        }
     
    }

 





}
