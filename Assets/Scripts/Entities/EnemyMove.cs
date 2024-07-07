using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int life;
    public int distance;
    float speed;
    float range;
    public GameObject target;
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
        range = 0.5f;        
        speed = 4.1f;
        life = 1;
    }
	
	void Update ()
    {
        if (life == 0)
            Destroy(this.gameObject);

        if (transform.position.x < target.transform.position.x)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }

        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if (range < distance)
            {
                Vector3 direction = target.transform.position - transform.position;
                transform.position += direction.normalized * speed * Time.deltaTime;
            }
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (_p.isDamaged == false)
            {
                collision.gameObject.GetComponent<Player>().Knockback(-1, 1f);                
                _p.life -= 2;
            }
            Destroy(this.gameObject);          
        }

        if(collision.gameObject.layer == 14)
            Destroy(this.gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
            Destroy(this.gameObject);
    }
}
