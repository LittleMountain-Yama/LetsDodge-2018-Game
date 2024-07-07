using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEProyectile : MonoBehaviour
{
    float speed = 9;
    float timer;
    float bulletTime = 6;
    Player _p;
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    BoxCollider2D _bc;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _bc = GetComponent<BoxCollider2D>();
        _p = FindObjectOfType<Player>();
    }

    void Update()
    {
        timer += Time.deltaTime * 1;

        transform.position += transform.right * speed * Time.deltaTime;
        transform.position += transform.up * speed * Time.deltaTime;

        if (timer > bulletTime)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 11)
            Destroy(this.gameObject);

        if (collision.gameObject.GetComponent<Player>())
        {
            if (_p.isDamaged == false)
            {
                collision.gameObject.GetComponent<Player>().Knockback(-1, 1.5f);
                _p.life -= 1;
            }
        }
    }
}
