using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireb2 : MonoBehaviour
{
    public float Speed;
   
    public int damage;

    public Rigidbody2D Rig;
   

    
    
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Rig.velocity = Vector2.down* Speed;
        Destroy(gameObject, 6f);

    }

    private void OnTriggerEnter2D(Collider2D CO )
    {
        if (CO.gameObject.tag == "Player")
        {
            CO.GetComponent<Player>().damage(damage);
            Destroy(gameObject);
        }
        
    }
}
