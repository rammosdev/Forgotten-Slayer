using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem dust;
    public Rigidbody2D rig;
    public Animator anima;
    public Vector2 playerInput;
    public float moveSpeed;

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate() {
        Movimento();
        Animation();
    }

    void Movimento()
    {
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rig.velocity = playerInput.normalized * moveSpeed;

        if (playerInput.x > 0 || playerInput.y > 0)
        {
            Debug.Log("Andando");
            transform.eulerAngles = new Vector3(0,0,0);
            CreateDust();
        }
        
        if (playerInput.x < 0)
        {
            Debug.Log("Andando");
            transform.eulerAngles = new Vector3(0,180,0);
            CreateDust();
        }

        else if (playerInput.x == 0 || playerInput.y == 0 )
        {
            Debug.Log("Parado");
        }

    }

    void Animation()
    {
        if (playerInput.x > 0 || playerInput.y > 0)
        {
            anima.SetInteger("Transition", 1);
        }
        else if (playerInput.x < 0 || playerInput.y < 0)
        {
            anima.SetInteger("Transition", 1);
        }
        else if (playerInput.x == 0 || playerInput.y == 0 )
        {
            anima.SetInteger("Transition", 0);
        }
    }

    void CreateDust()
    {
        //dust.Play();
    }
}
