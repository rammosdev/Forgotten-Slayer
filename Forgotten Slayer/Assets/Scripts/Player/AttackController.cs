    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class AttackController : MonoBehaviour
    {
        public Animator anima;

        public Transform attackPoint;
        public float attackRange;
        public float attackRate = 1f;
        float nextAttackTime = 0f;
        public LayerMask enemyLayer;
        public GameObject slash;
        public Transform handDistance;
        public PlayerController playerController;
        public bool Flip;
        public static bool left = false;
        private void Awake() {
            anima = GetComponent<Animator>();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        private void FixedUpdate() {
            FlipFunction();
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
                if (Input.GetButtonDown("Fire1") && handDistance.transform.rotation.x == 0)
                    {          
                        {
                            
                            anima.SetTrigger("Attack"); //Animação de ataque
                            
                            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); //Detectando inimigos
                            
                            foreach(Collider2D enemy in hitEnemies)
                                {
                                    Debug.Log("Acertei " + enemy.name); //Causando dano
                                }

                            Instantiate(slash, attackPoint.position, attackPoint.rotation); //Instantiando o slash.

                            nextAttackTime = Time.time + 0.5f /attackRate; //Delay do ataque

                            handDistance.transform.rotation = Quaternion.Euler(new Vector3(-180, handDistance.transform.rotation.y, handDistance.transform.rotation.z));
                        }
                    }
                    else
                    {
                        
                    }
            }   
        }

        public void FlipFunction()
        {
            if (Input.GetButton("Fire1"))
            {
                if (handDistance.transform.rotation.x == 0)
                {
                    Debug.Log("Igual a 0");
                }

                if (handDistance.transform.rotation.x < 0)
                {
                    Debug.Log("Igual a -180");
                }
            }
        }


        private void OnDrawGizmosSelected() {

            if (attackPoint == null)
                return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
