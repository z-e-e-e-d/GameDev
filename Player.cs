using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed = 2f;
    [SerializeField]
    float jumpForce = 1f;
    Transform trns;
    SpriteRenderer spr;
    Rigidbody2D myBody;

    bool isGrounded = true;

    void Start()
    {
        trns = GetComponent<Transform>();
        spr = GetComponent<SpriteRenderer>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        running();
        jumping();
    }

    private void running()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            trns.Translate(new Vector2(-1 * speed, 0f) * Time.deltaTime);
            spr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            trns.Translate(new Vector2(speed, 0f) * Time.deltaTime);
            spr.flipX = false;
        }

    }

    private void jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            myBody.AddForce(new Vector2(0f, jumpForce),ForceMode2D.Impulse);
            isGrounded = false;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }
}
