using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb;
    Vector3 initialScale,leftScale;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>())
            rb = GetComponent<Rigidbody2D>();
        else Debug.Log("No RigidBody attached to the character");
        rb.freezeRotation = true;
        initialScale = transform.localScale;
        leftScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) // right
        {
            rb.velocity = Vector2.right * speed;
            transform.localScale = initialScale;
            anim.SetBool("walk", true);

        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // left
        {
            rb.velocity = Vector2.left * speed;
            transform.localScale = leftScale;
            anim.SetBool("walk", true);
        }
        /*
        else if (Input.GetKey(KeyCode.W)) // up
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(KeyCode.S)) // down
        {
            rb.velocity = Vector2.down * speed;
        }
        */
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("walk", false);

        }

    }
}
