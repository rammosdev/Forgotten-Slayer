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

    public float Angle;

    public bool Flip;

    public TMPro.TMP_Text DebText;

    public GameObject Deb;

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
        Vector2 LookDir = MousePos - Axis.transform.position;

        // Calcula o ângulo da espada
        Angle = Vector2.SignedAngle(Axis.transform.position, MousePos);
        
        Axis.transform.rotation = Quaternion.Euler(0, 0, Angle);
        // Vira alguns objetos baseado na rotação
        
        // Nota: A condição aqui precisa ser "LookDir.x > 0" e não maior que "transform.position.x", pois o valor retornado é entre -1 e 1. 
        if (LookDir.x > 0)
        {
            Flip = false;
            // Axis.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(Angle, 0, 150));
            HandDistance.transform.localRotation = Quaternion.Euler(0, HandDistance.transform.rotation.y, HandDistance.transform.rotation.z);
        }
        else
        {
            Flip = true;
            // Axis.transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(Angle, 0, -150));
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
            CreateDust();
        }
        
        if (playerInput.x < 0)
        {           
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
