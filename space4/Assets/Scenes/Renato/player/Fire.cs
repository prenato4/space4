using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    public float Speed;
    public int damage;

    public Rigidbody2D Rig;
    public Animator A;

    
    
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        A = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Rig.velocity = transform.up * Speed;
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D CO )
    {
        if (CO.gameObject.tag == "enemy")
        {
            CO.GetComponent<ini>().Damage(damage);
            A.SetBool("Ibo", true);
            Destroy(gameObject,0.1f);
        }
        if (CO.gameObject.tag == "N1")
        {
            CO.GetComponent<N1>().Damage(damage);
            A.SetBool("Ibo", true);
            Destroy(gameObject,0.1f);
        }
        if (CO.gameObject.tag == "N11")
        {
            CO.GetComponent<N11>().Damage(damage);
            A.SetBool("Ibo", true);
            Destroy(gameObject,0.1f);
        }
        if (CO.gameObject.tag == "N111")
        {
            CO.GetComponent<N111>().Damage(damage);
            A.SetBool("Ibo", true);
            Destroy(gameObject,0.1f);
        }
        if (CO.gameObject.tag == "N1111")
        {
            CO.GetComponent<N1111>().Damage(damage);
            A.SetBool("Ibo", true);
            Destroy(gameObject,0.1f);
        }
        
        
    }
}
