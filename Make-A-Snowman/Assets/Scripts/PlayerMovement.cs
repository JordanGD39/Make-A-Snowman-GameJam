using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horiInput;
    [SerializeField] private float speed = 5;
    [SerializeField] private Transform sprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horiInput = Input.GetAxis("Horizontal");

        
        if (horiInput != 0)
        {
            Vector3 scale = sprite.transform.localScale;
            scale.x = horiInput > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);

            sprite.transform.localScale = scale;
        }        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horiInput * speed, rb.velocity.y);
    }
}
