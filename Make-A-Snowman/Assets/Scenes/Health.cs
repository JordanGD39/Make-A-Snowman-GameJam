using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int playerHealth;

    public int maxHealth;

    public Image[] Hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;

    void Update()
    {

        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                Hearts[i].sprite = fullHeart;
            }
            else
            {
                Hearts[i].sprite = halfHeart;
            }

            if (i < maxHealth)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }
    }
}
