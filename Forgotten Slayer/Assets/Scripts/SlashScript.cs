using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    [Header("Slash")]
    [SerializeField] private float slashSpeed;
    [SerializeField] private float lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Slash();
    }

    public void Slash()
    {
        transform.Translate(Vector2.right * slashSpeed * Time.deltaTime);
                    
    }
}
