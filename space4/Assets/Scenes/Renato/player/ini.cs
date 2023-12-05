using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ini : MonoBehaviour
{
    public int health;
    public int Daamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int D)
    {
        health -= D;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D CO)
    {
        if (CO.gameObject.tag == "Player")
        {
            CO.gameObject.GetComponent<Player>().damage(Daamage);
        }
    }
}
