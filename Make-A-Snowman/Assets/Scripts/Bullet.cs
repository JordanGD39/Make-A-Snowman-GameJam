using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 6;
    private GameObject player;
    Vector3 playerPos;
    private bool posReached;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        transform.right = playerPos - transform.position;
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInParent<PlayerMovement>().Die();
        }
        else if (collision.gameObject.CompareTag("SnowBall"))
        {
            collision.transform.localScale -= new Vector3(0.01f, 0.01f);
            collision.attachedRigidbody.mass -= 0.01f;
        }

        Destroy(gameObject);
    }
}
