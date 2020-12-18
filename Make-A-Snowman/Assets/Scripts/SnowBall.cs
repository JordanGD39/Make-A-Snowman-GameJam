using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBall : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool grounded = false;
    [SerializeField] private Transform sprite;
    [SerializeField] private float growSpeed;
    [SerializeField] private float maxGrowth = 0.5f;
    [SerializeField] private float minSpeed = 1;
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float groundedOffset = 0.5f;
    [SerializeField] private float groundedRadius = 0.5f;
    [SerializeField] private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(transform.position + Vector3.down * groundedOffset, groundedRadius, layerMask);

        if (grounded && rb.velocity.x > minSpeed && sprite.transform.localScale.x < maxGrowth)
        {
            float speed = growSpeed * (rb.velocity.x / maxSpeed);
            Vector3 scale = Vector3.one;
            scale *= speed * Time.deltaTime;
            scale.z = 0;
            sprite.transform.localScale += scale;

            rb.mass += speed;
        }        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + Vector3.down * groundedOffset, groundedRadius);
    }
}
