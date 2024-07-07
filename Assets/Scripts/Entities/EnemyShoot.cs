using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    int life;
    int dir;
    public int range = 12;
    float attackTime;
    public float cooldown;
    bool canAttack;
    public GameObject target;   
    public Proyectile sphere;
    public ProyectileInverse sphereInv;   
    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _sr;
    BoxCollider2D _bc;
    Player _p;

    void Start ()
    {       
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _p = FindObjectOfType<Player>();

        target = GameObject.Find("Player");        
        life = 1;
    }
	
	void Update ()
    {
        if (life <= 0)
            Destroy(this.gameObject);

        attackTime += Time.deltaTime * 1;

        if (target != null)
        {
            if (attackTime > cooldown)
            {
                float distance = Vector3.Distance(transform.position, target.transform.position);

                if (range > distance)
                {
                    Shoot();
                }
            }
        }

        
           
    }

    void Shoot()
    {
        if (_sr.flipX == false)
        {
            Proyectile bulletTemp = Instantiate(sphere);
            bulletTemp.transform.position = transform.position - Vector3.right + Vector3.up*0.37f;
        }
        else if (_sr.flipX == true)
        {
            ProyectileInverse bulletTemp = Instantiate(sphereInv);
            bulletTemp.transform.position = transform.position + Vector3.right*0.65f + Vector3.up*0.37f;
        }
        attackTime = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
            Destroy(this.gameObject);

        if (collision.gameObject.GetComponent<Player>())
        {
            if (_p.isDamaged == false)
            {
                collision.gameObject.GetComponent<Player>().Knockback(-5, 1f);
                _p.life -= 1;              
            }                        
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            Destroy(this.gameObject);
    }
}
