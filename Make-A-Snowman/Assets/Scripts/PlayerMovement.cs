using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private bool grounded = false;
    private Rigidbody2D rb;
    private Animator anim;
    private float horiInput;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 500;
    [SerializeField] private float groundedOffset = 0.5f;
    [SerializeField] private float groundedRadius = 2;
    [SerializeField] private float deathY = -10;
    [SerializeField] private float winX = 20;
    [SerializeField] private Transform sprite;
    [SerializeField] private Transform snowBallSprite;
    [SerializeField] private LayerMask layerMask;
    private bool jumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horiInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(horiInput));
        
        if (horiInput != 0)
        {
            Vector3 scale = sprite.transform.localScale;
            scale.x = horiInput > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

            sprite.transform.localScale = scale;
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jumpPressed = true;
        }

        grounded = Physics2D.OverlapCircle(transform.position + Vector3.down * groundedOffset, groundedRadius, layerMask);
        anim.SetBool("Grounded", grounded);

        if (transform.position.y < deathY)
        {
            Die();   
        }

        if (transform.position.x > winX && snowBallSprite.localScale.x >= 0.12f)
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            rb.AddForce(transform.up * jumpForce);
            jumpPressed = false;
        }

        if (Mathf.Abs(horiInput) < 0.3f)
        {
            horiInput = 0;
        }
        
        rb.velocity = new Vector2(horiInput * speed, rb.velocity.y);       
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.down * groundedOffset, groundedRadius);
    }
}
