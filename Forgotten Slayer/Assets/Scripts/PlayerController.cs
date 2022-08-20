using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject HandDistance;
    public GameObject Axis;
    public ParticleSystem dust;
    public Rigidbody2D rig;
    public Animator anima;
    public Vector2 playerInput;
    public float moveSpeed;

    public bool Flip;

    private void Awake()
    {
        // Pega os componentes necessários.
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
    }

    private void MouseLook()
    {
        // Calcula a rotação da espada do jogador baseado na posição do mouse
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDir = MousePos - Axis.transform.position;
        float Angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg - 90f;
        Axis.GetComponent<Rigidbody2D>().rotation = Angle;
        
        // Vira alguns objetos baseado na rotação
        if (LookDir.x > 0)
        {
            Flip = false;
            HandDistance.transform.localRotation = Quaternion.Euler(0, HandDistance.transform.rotation.y, HandDistance.transform.rotation.z);
        }
        else
        {
            Flip = true;
            HandDistance.transform.localRotation = Quaternion.Euler(180, HandDistance.transform.rotation.y, HandDistance.transform.rotation.z);
        }
    }

    private void FixedUpdate()
    {
        // Chama as funções depois do cálculo das físicas do jogo.
        MouseLook();
        Movimento();
        Animation();

        // Vira o jogador horizontalmente baseado em certas circunstâncias
        GetComponent<SpriteRenderer>().flipX = Flip;
    }

    // Movimento
    void Movimento()
    {
        // Define a direção de movimento baseado nas teclas pressionadas.
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        // Adiciona velocidade ao jogador baseado na direção.
        rig.velocity = playerInput.normalized * moveSpeed;

        // Muda a direção do player baseado em sua velocidade
        if (playerInput.x > 0 || playerInput.y > 0)
        {
            Debug.Log("Andando Direita");
            Flip = false;
            CreateDust();
        }
        
        if (playerInput.x < 0)
        {
            Debug.Log("Andando Esquerda");
            
            Flip = true;
            CreateDust();
        }

        // Parado. Só isso.
        else if (playerInput.x == 0 || playerInput.y == 0 )
        {
            Debug.Log("Parado");
        }

    }

    // Animação
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
