using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public Joystick joystick;
    public float JoystickHorizontalSensitivity;
    public float JoystickVerticalSensitivity;
    public float horizontalFroce;
    public float verticalForce;
    public bool isGrounded;
    public Transform spawnpoint;

    private Rigidbody2D m_Rigidbody2D;
    private SpriteRenderer m_spriteRenderer;
    private Animator m_anitmator;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_anitmator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (isGrounded)
        {

            if (joystick.Horizontal > JoystickHorizontalSensitivity)
            {
                m_Rigidbody2D.AddForce(Vector2.right * horizontalFroce * Time.deltaTime);
                m_spriteRenderer.flipX = false;
                m_anitmator.SetInteger("AnimState", 1);
                // move right
            }
            else if (joystick.Horizontal < -JoystickHorizontalSensitivity)
            {
                m_Rigidbody2D.AddForce(Vector2.left * horizontalFroce * Time.deltaTime);
                m_spriteRenderer.flipX = true;
                m_anitmator.SetInteger("AnimState", 1);
                //move left
            }
            else if (joystick.Vertical > JoystickVerticalSensitivity)
            {
                m_Rigidbody2D.AddForce(Vector2.up * verticalForce * Time.deltaTime);
                m_anitmator.SetInteger("AnimState", 2);
            }
            else
            {
                m_anitmator.SetInteger("AnimState", 0);
                // idle
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //  respawn
        if(other.tag == "DeathPlane")
        transform.position = spawnpoint.position;
    }
}
