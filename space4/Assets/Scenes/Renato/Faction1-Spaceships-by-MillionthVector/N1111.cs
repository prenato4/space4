using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1111 : MonoBehaviour
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
    public Transform Spawn3;
    public Transform Spawn4;

    public GameObject Fire1;
    public GameObject Fire2;
    public GameObject Fire3;
    public GameObject Fire4;
    

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
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            Rig.velocity = Vector2.right * speed;
            transform.eulerAngles = new Vector3(180, 0, -90);
        }
    }

    public void Damage(int D)
    {
        An.SetBool("Ishit3", true);
        Health -= D;
        Invoke("RH", 0.3f);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    void RH()
    {
        An.SetBool("Ishit3", false);
    }


    void StartFire()
    {
        InvokeRepeating("IFire", 1f, 1f);
        InvokeRepeating("IIfire", 2f, 2f);
    }


    void IFire()
    {
        Instantiate(Fire1, Spawn1.position, Spawn1.rotation);
        //Instantiate(Fire2, Spawn2.position, Spawn2.rotation);
        
        //Instantiate(Fire2, Spawn4.position, Spawn4.rotation);
    }

    void IIfire()
    {
       Instantiate(Fire1, Spawn3.position, Spawn3.rotation);
        //Instantiate(Fire2, Spawn4.position, Spawn4.rotation);
    }

}
