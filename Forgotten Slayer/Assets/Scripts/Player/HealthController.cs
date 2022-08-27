using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (maxHealth > numOfHearts)
        {
            maxHealth = numOfHearts;
        }

        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
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
