using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicEnemy : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float throwTimer;
    [SerializeField] private float reloadTime = 1;
    [SerializeField]
    private float throwDistance;
    private float distanceToPlayer;
    [SerializeField]
    private GameObject fireball;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        throwTimer = reloadTime;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        Throw();
    }

    void CheckDistance()
    {
       distanceToPlayer = Mathf.Abs(player.position.x - transform.position.x);
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
                Instantiate(fireball, transform.position, Quaternion.identity);
                throwTimer = reloadTime;
            }
        }
        else
        {
            throwTimer = reloadTime;
        }
    }
}
