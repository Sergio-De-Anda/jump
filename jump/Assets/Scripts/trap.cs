using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private Rigidbody2D platform_rb;
    private Vector2 starting_pos;


    void Start()
    {
        platform_rb = GetComponent<Rigidbody2D>();
        starting_pos = transform.position;
    }


    void Update()
    {
        if (transform.position.y < 0 && (platform_rb.tag == "plummet_trap" || platform_rb.tag == "plummet_trap_delayed"))
        {
            platform_rb.bodyType = RigidbodyType2D.Static;
            platform_rb.gravityScale = 0.0f;
            transform.position = starting_pos;
        }
        if (gameObject.tag == "moving_platform_vertical")
        {
            if (transform.position.y < 2.0f)
            {
                platform_rb.gravityScale = -.75f;
            }
            else if (transform.position.y > 8.0f)
            {
                platform_rb.gravityScale = .75f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "plummet_trap_delayed")
            Invoke("change_gravity", 0.5f);
        else if (gameObject.tag == "plummet_trap")
            change_gravity();
    }

    void change_gravity()
    {
        //Rigidbody2D platform = Instantiate(platform_rb);
        platform_rb.bodyType = RigidbodyType2D.Dynamic;
        platform_rb.gravityScale = 1f;
    }
}
