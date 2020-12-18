using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject enemy;
    private GameObject player;
    [SerializeField]
    private float throwTimer;
    [SerializeField]
    private float throwDistance;
    private float distanceToPlayer;
    [SerializeField]
    private GameObject fireball;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("angry snowman");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        Throw();
    }

    void CheckDistance()
    {
       distanceToPlayer = player.transform.position.x - enemy.transform.position.x;
    }

    void Throw()
    {
        if (distanceToPlayer <= throwDistance)
        {
            throwTimer -= Time.deltaTime;

            if (throwTimer <= 0)
            {
                Debug.Log(throwTimer);
                Debug.Log("throwing");
                Instantiate(fireball, enemy.transform.position, Quaternion.identity);
                throwTimer = 5;
            }
        }
    }
}
