using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;
    public float Boundry;
    public float Speed;
    public float maxSpeed;

    private Rigidbody2D rigidBody;
    private Vector3 touchesEnd;
    // Start is called before the first frame update
    void Start()
    {
      touchesEnd = new Vector3();
        rigidBody = GetComponent<Rigidbody2D>();
        
    }

    private void FireBullet()
    {
       
        
        bulletManager.GetBullet(transform.position);
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();

        if (Time.frameCount % 40.0f == 0) {
            FireBullet();
        }
    }



    private void Move()
    {
        float direction = 0.0f;

        //touch imput

        

        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if(worldTouch.x > transform.position.x)
            {
                direction = 1.0f;

            }

            if (worldTouch.x < transform.position.x)
            {
                direction = -1.0f;

            }

            touchesEnd = worldTouch;
        }


        
        
 
        //if touch is to the right
      

        if(Input.GetAxis("Horizontal") >= 0.1f)
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
        if(transform.position.x >= Boundry)
        {
            transform.position = new Vector3(Boundry, transform.position.y, 0.0f);
        }

        if (transform.position.x <= -Boundry)
        {
            transform.position = new Vector3(-Boundry, transform.position.y, 0.0f);
        }
    }
}