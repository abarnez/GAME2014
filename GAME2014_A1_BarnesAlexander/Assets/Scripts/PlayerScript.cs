/* 
 Alexander Barnes 101086806
 GAME2014_A1_BARNES_ALEXANDER
 PLAYER_SCRIPT
 Used to control the player Via touch inputs, also controls the players health and death, as well as plays the sounds and set score values for the tmp on the canvas
 LAST MODIFIED 10/24/2020
 VERSION 1.0.1
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerScript : MonoBehaviour
{

    public float Boundry;
    public float Speed;
    public float maxSpeed;
    public float Health;
    public GameObject bullet;
    private Rigidbody2D rigidBody;
    private Vector3 touchesEnd;
    public GameObject firePoint;
    public AudioSource firesound;
    public TMP_Text healthUI;
    public TMP_Text scoreUI;
    
    public float Score;
    

    void Start()
    {
       
        touchesEnd = new Vector3();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = "Lives: " + Health;
        scoreUI.text = "Score: " + Score;
        

        Move();
        CheckBounds();
    }
    private void Move()
    {
        float direction = 0.0f;

        //touch imput



        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.x)
            {
                direction = 1.0f;
                Fire();
            }

            if (worldTouch.x < transform.position.x)
            {
                direction = -1.0f;
                Fire();
            }

            touchesEnd = worldTouch;
        }
        if (Input.GetAxis("Horizontal") >= 0.1f)
        {
            direction = 1.0f;
           
        }

        if (Input.GetAxis("Horizontal") <= -0.1f)
        {
            direction = -1.0f;
            

        }

        Vector2 newVeloicty = rigidBody.velocity + new Vector2(direction * Speed, 0.0f);
        rigidBody.velocity = Vector2.ClampMagnitude(newVeloicty, maxSpeed);
        rigidBody.velocity *= 0.99f;

        if (touchesEnd.x != 0.0f)
        {
            transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchesEnd.x, 0.01f), transform.position.y);
        }
    }

    private void CheckBounds()
    {
        if (transform.position.x >= Boundry)
        {
            transform.position = new Vector3(Boundry, transform.position.y, 0.0f);
        }

        if (transform.position.x <= -Boundry)
        {
            transform.position = new Vector3(-Boundry, transform.position.y, 0.0f);
        }
    }

    private void Fire()
    {
        if (Time.frameCount % 250.0f == 0)
        {
            firesound.Play();
            Instantiate(bullet, firePoint.transform.position, transform.rotation);
        }
       
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyBullet")
        {
            Health--;
        }
        if (Health == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
       
    }


}
