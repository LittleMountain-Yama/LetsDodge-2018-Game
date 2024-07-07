using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int life;
    int distance;
    int currentP;
    float speed;
    float range;
    float cooldown;
    float shotTimer;
    float hurtTimer;
    float hurtTime;
    bool cooldownHurt;
    public GameObject target;
    public GameObject up;
    public GameObject down;
    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _sr;
    Player _p;
    public Proyectile proyectileA;
    public ProyectileInverse proyectileB;
    public ProyectileUp proyectileC;
    public ProyectileDown proyectileD;
    public NEProyectile proyectileE;
    public NOProyectile proyectileF;
    public SEProyectile proyectileG;
    public SOProyectile proyectileH;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        _p = FindObjectOfType<Player>();

        _sr.color = Color.red;

        target = GameObject.Find("Player");

        range = 0.5f;
        speed = 3f;
        life = 5;
        cooldown = 1;
        hurtTime = 2;
    }

    void Update()
    {
        if (life == 0)
            SceneManager.LoadScene("Win");

        hurtTimer += 1 * Time.deltaTime;
        if(hurtTimer > hurtTime)
        {
            cooldownHurt = false;
            _sr.color = Color.red;
        }

        shotTimer += 1 * Time.deltaTime;
        if (shotTimer > cooldown)
            Shoot();

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

    void Shoot()
    {
        shotTimer = 0;
        currentP = Random.Range(0,7);

        if(currentP == 0)
        {
            Proyectile bulletTemp = Instantiate(proyectileA);
            bulletTemp.transform.position = down.transform.position - Vector3.right*2;
        }
        else if (currentP == 1)
        {
            ProyectileInverse bulletTemp = Instantiate(proyectileB);
            bulletTemp.transform.position = up.transform.position + Vector3.right * 2;
        }
        else if (currentP == 2)
        {
            ProyectileUp bulletTemp = Instantiate(proyectileC);
            bulletTemp.transform.position = up.transform.position + Vector3.up * 2;
        }
        else if (currentP == 3)
        {
            ProyectileDown bulletTemp = Instantiate(proyectileD);
            bulletTemp.transform.position = down.transform.position - Vector3.up * 2;
        }
        else if (currentP == 4)
        {
            NEProyectile bulletTemp = Instantiate(proyectileE);
            bulletTemp.transform.position = up.transform.position + Vector3.right * 2 + Vector3.up * 2;
        }
        else if (currentP == 5)
        {
            NOProyectile bulletTemp = Instantiate(proyectileF);
            bulletTemp.transform.position = up.transform.position - Vector3.right * 2 + Vector3.up * 2;
        }
        else if (currentP == 6)
        {
            SEProyectile bulletTemp = Instantiate(proyectileG);
            bulletTemp.transform.position = down.transform.position + Vector3.right * 2 - Vector3.up * 2;
        }
        else
        {
            SOProyectile bulletTemp = Instantiate(proyectileH);
            bulletTemp.transform.position = down.transform.position - Vector3.right * 2 - Vector3.up * 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (_p.isDamaged == false)
            {
                collision.gameObject.GetComponent<Player>().Knockback(-1, 1f);
                _p.life -= 1;
            }            
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cooldownHurt == false)
        {
            if (collision.gameObject.layer == 14)
            {
                life -= 1;
                hurtTimer = 0;
                cooldownHurt = true;
                _sr.color = Color.blue;
            }
        }
    }
}

