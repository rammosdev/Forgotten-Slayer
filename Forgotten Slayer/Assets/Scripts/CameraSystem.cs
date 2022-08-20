using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private Transform Player;

    public float Speed;

    void Start()
    {
        // Pega os componentes necessários
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        // Movimenta a camera
        transform.position = new Vector2(Mathf.Lerp(transform.position.x, Player.position.x, Speed * Time.deltaTime), Mathf.Lerp(transform.position.y, Player.position.y, Speed * Time.deltaTime));

        // Vou deixar aqui pra se você ainda quiser usar :)
        // Pooorém, o código de cima eu acho um pouco melhor e mais "macio"
        /*transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
        Player.GetComponent<Transform>().position.x - minX, 
        Player.GetComponent<Transform>().position.x + minX),

        Mathf.Clamp(transform.position.y, 
        Player.GetComponent<Transform>().position.y - minY, 
        Player.GetComponent<Transform>().position.y + minY));*/
    }
}
