using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int numOfHearts;
    public PlayerController player;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    

    private void Awake() {
        player = GetComponent<PlayerController>();
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("-1");

        if (currentHealth > 0)
        {
            //Player toma dano
            currentHealth -= damage;
        }
        if (currentHealth == 0)
        {
            //Player morre
            GetComponent<PlayerController>().moveSpeed = 0;
            Debug.Log("Morri");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth > numOfHearts)
        {
            currentHealth = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }else
            {
                hearts[i].enabled = false;
            }
        }
    }


}
