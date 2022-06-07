using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigi;
    SpriteRenderer spriteRenderer;

    public string state;

    [SerializeField] float jumpForce = 300;

    [SerializeField] GameObject canva;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        state = "on air";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (state == "land")
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        state = "on air";
        rigi.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            state = "land";
            Debug.Log(state);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Hit");
            canva.GetComponent<ScoreControl>().EndGame();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            state = "on air";
            Debug.Log(state);
        }
    }
}
