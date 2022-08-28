using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animator anima;

    public Transform attackPoint;
    public float attackRange;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public LayerMask enemyLayer;

    [Header("Slash")]
    public GameObject slash;

    private void Awake() {
        anima = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
                {
                    anima.SetTrigger("Attack");
                    //Detectando inimigos
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                    //Dando dano
                    foreach(Collider2D enemy in hitEnemies)
                    {
                        Debug.Log("Acertei " + enemy.name);
                    }
                    Instantiate(slash, attackPoint);
                    nextAttackTime = Time.time + 1f /attackRate;
                }
        }

    }

    private void OnDrawGizmosSelected() {

        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
