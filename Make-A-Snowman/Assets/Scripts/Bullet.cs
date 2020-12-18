using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed = 3;
    private GameObject player;
    Vector3 playerPos;
    private bool posReached;

    private void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        transform.right = playerPos - transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * speed * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        Destroy(gameObject);
    }
}
