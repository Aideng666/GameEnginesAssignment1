using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveForce;
    [SerializeField] float jumpForce;

    Rigidbody2D body;

    bool levelComplete;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.right * moveForce, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.left * moveForce, ForceMode2D.Force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            GetComponent<Animator>().SetTrigger("Jump");
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            body.drag = 1;
        }
        else
        {
            body.drag = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Final")
        {
            levelComplete = true;
        }

        if (collision.gameObject.tag == "Ground")
        {  
            if (collision.contacts[0].normal.y > 0.5)
            {
                isGrounded = true;
            }
        }
    }

    public bool GetLevelComplete()
    {
        return levelComplete;
    }
}
