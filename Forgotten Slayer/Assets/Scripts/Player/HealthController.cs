using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float currentHealth {get; private set;}
    [SerializeField] public float health;
    

    private void Awake() {
        currentHealth = health;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, health);
        currentHealth -= damage;

        if (currentHealth > 0)
        {
            //Dano contra o player
        }else
        {
            //Morte do player
        }
    }
}
