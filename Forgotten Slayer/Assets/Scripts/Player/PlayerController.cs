using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Mira")]
    public GameObject HandDistance;
    public GameObject Axis;
    public GameObject Delay;
    public GameObject Hand;
    public GameObject Deb;
    public float Angle;
    public bool Flip;
    public Vector2 LookDir;
    public Rigidbody2D rig;
    public Animator anima;
    public TMPro.TMP_Text DebText;
    [Header("Movimentação")]
    public Vector2 playerInput;
    public float moveSpeed;
    public ParticleSystem dust;
    public HealthController playerHealth;



    void Update()
    {
        string DebTxt = "";

        DebTxt += transform.name + " rotation: " + transform.rotation.ToString() + "\n";

        DebTxt += transform.name + " position: " + transform.rotation.ToString() + "\n";

        DebTxt += Axis.name + " rotation: " + Axis.transform.rotation.ToString() + "\n";

        DebTxt += Axis.name + " position: " + Axis.transform.position.ToString() + "\n";

        DebTxt += "Angle: " + Angle.ToString() + "\n";

        DebTxt += "Flipped: " + Flip.ToString() + "\n";

        DebTxt += "PlayerInput: X: " + playerInput.x.ToString() + " Y:" + playerInput.y.ToString() + "\n";

        DebTxt += "ScreenToWorld-based Angle: " + Vector2.SignedAngle(Camera.main.ScreenToWorldPoint(Axis.transform.position), Camera.main.ScreenToWorldPoint(Input.mousePosition)).ToString() + "\n";

        DebTxt += "WorldToScreen-based Angle: " + Vector2.SignedAngle(Camera.main.WorldToScreenPoint(Axis.transform.position), Camera.main.ScreenToWorldPoint(Input.mousePosition)).ToString() + "\n";
        
        DebTxt += "LookDir: " + LookDir + "\n";
        
        DebText.text = DebTxt;

        if (Input.GetKeyDown(KeyCode.F8))
        {
            Deb.SetActive(!Deb.activeSelf);
        }
    }

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

        // Calcula a direção em que o jogador está olhando
        LookDir = MousePos - Axis.transform.position;

        // Calcula o ângulo da espada
        Angle = Vector2.SignedAngle(Axis.transform.localPosition, LookDir);
        //// Angle = Mathf.Atan2(LookDir.x, LookDir.y) * Mathf.Rad2Deg - 90f;
        
        // Vira alguns objetos baseado na rotação
        Axis.transform.localRotation = Quaternion.Euler(0, 0, Angle);
        
        // Nota: A condição aqui precisa ser "LookDir.x > 0" e não maior que "transform.position.x", pois o valor retornado é entre -1 e 1. 
        if (LookDir.x > 0)
        {
            Flip = false;
            // Axis.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(Angle, 0, 150));
            HandDistance.transform.localRotation = Quaternion.Euler(0, HandDistance.transform.localRotation.y, HandDistance.transform.localRotation.z);
        }
        else
        {
            Flip = true;
            // Axis.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(Angle, 0, -150));
            HandDistance.transform.localRotation = Quaternion.Euler(180, HandDistance.transform.localRotation.y, HandDistance.transform.localRotation.z);
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
            Debug.Log(playerHealth.currentHealth);
        }
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
            
        }
        
        if (playerInput.x < 0)
        {           
            
        }

        // Parado. Só isso.
        else if (playerInput.x == 0 || playerInput.y == 0 )
        {
            // Debug.Log("Parado");
        }

    }

    void TakeDamage(int damage)
    {
        playerHealth.currentHealth -= damage;
        if (playerHealth.currentHealth > 0)
        {
            //Player toma dano
        }else
        {
            //Player morre
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
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        Gizmos.DrawSphere(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Axis.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(HandDistance.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Delay.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(Hand.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }*/
    
}
