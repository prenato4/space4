using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N11 : MonoBehaviour
{
    public int Health;
    public int damage;
    
    public float speed;

    public float Timer;
    public float Wtimer;

    public bool Walk;

    private Animator An;
    private Rigidbody2D Rig;


    public Transform Spawn1;
    public Transform Spawn2;

    public GameObject Fire1;

    // Start is called before the first frame update
    void Start()
    {
        An = GetComponent<Animator>();
        Rig = GetComponent<Rigidbody2D>();
        Invoke("StartFire", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if (Timer >= Wtimer)
        {
            Walk = !Walk;
            Timer = 0f;
            
        }

        if (Walk)
        {
            Rig.velocity = Vector2.left * speed;
        }
        else
        {
            Rig.velocity = Vector2.right * speed;
        }
    }

    public void Damage(int D)
    {
        An.SetBool("Ishit1", true);
        Health -= D;
        Invoke("RH", 0.3f);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void RH()
    {
        An.SetBool("Ishit1", false);
    }


    void StartFire()
    {
        InvokeRepeating("IFire", 0f, 5f);
    }
    
    
    void IFire()
    {
        Instantiate(Fire1, Spawn1.position, Spawn1.rotation);
        Instantiate(Fire1, Spawn2.position, Spawn2.rotation);
    }
}
