using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D MyRigidBody;
    private Animator myAnimator;
    private bool facingRight;

    public float jumpForce = 10f;
    public Vector2 jump = new Vector2(0.0f, 15.0f);
    public float movementSpeed;
    public Vector3 respawnPoint;

    bool grounded = true;
    public bool dead = false;


    //stats
    public int curHealth;
    public int maxHealth = 5;

    void Start()
    {
        respawnPoint = transform.position;
        facingRight = true;
        MyRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        curHealth = maxHealth;
    }

    void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);

        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            MyRigidBody.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            grounded = false;

        }
        if (transform.position.y < 0 || dead == true)
        {
            curHealth--;
            if (curHealth > 0)
            {
                transform.position = respawnPoint;
                dead = false;
            }
            else
            {
                dead = true;
            }
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "end")
            Debug.Log("End of Level");
        grounded = true;

        //collision involving platforms
        if (coll.transform.tag == "MovingPlatform")
        {
            transform.parent = coll.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

    private void HandleMovement(float horizontal)
    {
        MyRigidBody.velocity = new Vector2(horizontal * movementSpeed, MyRigidBody.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    private void Flip(float horizontal)
    {
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 LineScale = transform.localScale;
            LineScale.x *= -1;
            transform.localScale = LineScale;
        }
    }
}
