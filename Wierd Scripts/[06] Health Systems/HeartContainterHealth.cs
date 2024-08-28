using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainterHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHearts;
    public Sprite EmptyHearts;

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHearts;
            }
            else
            {
                hearts[i].sprite = EmptyHearts;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

            if (health < 0)
            {

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            health = health - 1;
            Debug.Log("got hit");
        }
    }
}
