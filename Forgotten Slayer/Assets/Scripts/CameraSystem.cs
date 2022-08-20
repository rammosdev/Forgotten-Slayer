using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private GameObject Player;

    public float minX, minY, speed;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, 
        Player.GetComponent<Transform>().position.x - minX, 
        Player.GetComponent<Transform>().position.x + minX),

        Mathf.Clamp(transform.position.y, 
        Player.GetComponent<Transform>().position.y - minY, 
        Player.GetComponent<Transform>().position.y + minY));
    }
}
