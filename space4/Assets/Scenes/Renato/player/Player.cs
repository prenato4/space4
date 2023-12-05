using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int Health;

    public float Speed;
    public float RSpeed;

    public bool BP;

    public GameObject Fire1;

    public Transform SpawnU;
    public Transform SpawnU1;
    private Rigidbody2D rig;
    private BoxCollider2D box;
    private Animator An;


    private Quaternion UR;
    private Vector3 UP;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        An = GetComponent<Animator>();
        UR = transform.rotation;
        UP = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //Movimentação na Vertical e Horizontal;
        /*float MH = Input.GetAxis("Horizontal");
        float MV = Input.GetAxis("Vertical");
        Vector3 M = new Vector3(MH, MV, 0);
        transform.position += M.normalized * Speed * Time.deltaTime;


        Vector3 MP = Input.mousePosition;
        MP = Camera.main.ScreenToWorldPoint(MP);
.
        Vector2 D = new Vector2(MP.x - transform.position.x, MP.y - transform.position.y);
        transform.up = D.normalized;
        //tentaiva de Fazer a rotação, mas usarei para os Inimigos
        /*float R = Input.GetAxis("Mouse X") * SR;
        transform.Rotate(0, SR, 0);*/

        //float R = Input.GetAxis("Vertical");
        //transform.Rotate(Vector3.forward, -R * RSpeed * Time.deltaTime);

        //Vector2 P = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //rig.velocity = P * Speed;
        
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized;

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(-horizontalInput, verticalInput) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            UR = transform.rotation;
            UP = transform.position;
        }
        else
        {
            rig.velocity = Vector2.zero;
            transform.rotation = UR;
            transform.position = UP;

        }

        rig.velocity = direction * Speed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }

    }

    public void damage(int DM)
    {
        An.SetBool("Ishit", true);
        Health -= DM;
        Invoke("RH", 0.3f);
        
    }

    void RH()
    {
       An.SetBool("Ishit", false);
    }

    void Fire()
    {
        Instantiate(Fire1, SpawnU.position, SpawnU.rotation);
        Instantiate(Fire1, SpawnU1.position, SpawnU1.rotation);
    }
}
