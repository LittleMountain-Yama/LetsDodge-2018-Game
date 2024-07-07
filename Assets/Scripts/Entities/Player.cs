using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int life;   
    public int crystals;
    float speed;
    float jumpSpeed;
    float stunTime;
    public float timerStun;
    float dir;
    float currentDir;
    bool canJumpA;
    bool canJumpB;
    string sceneName;
    public bool isCrouching;
    public bool isJumping;
    public bool isDashing;
    public bool isDamaged;    
    public bool isDefault;
    Rigidbody2D _rb;
    Animator _anim;
    SpriteRenderer _sr;
    public BoxCollider2D bcStand;
    public BoxCollider2D bcCrouch;
    Brain _brain;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();    
        _anim = GetComponent<Animator>();
        _brain = new Brain(this);

        canJumpB = false;
        bcCrouch.enabled = false;

        life = 5;
        speed = 6.8f;
        jumpSpeed = 325;
        stunTime = 0.75f;

        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    void Update()
    {
        if (life <= 0)
        {
            if (sceneName == "Level 1")
            {
                SceneManager.LoadScene("Death1");
            }

            if (sceneName == "Boss")
            {
                SceneManager.LoadScene("Death2");
            }
        }

        _brain.ListenerKey();

        float axisX = Input.GetAxis("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(axisX));

        if (isJumping != true && isDefault != true)
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                isCrouching = true;
                canJumpA = false;
                bcStand.enabled = false;
                bcCrouch.enabled = true;
            }
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                isCrouching = false;
                canJumpA = true;
                bcStand.enabled = true;
                bcCrouch.enabled = false;
            }
        }
        _anim.SetBool("isJumping", isJumping);

        timerStun += 1 * Time.deltaTime;              

        if (timerStun > stunTime)
        {
            isDamaged = false;
            _sr.color = Color.white;
        }

        _anim.SetBool("isDamaged", isDamaged);
        _anim.SetBool("isCrouching", isCrouching);
        _anim.SetBool("isDashing", isDashing);
    }

    public void Move(float dir)
    {
        if (isCrouching != true)
        {
            float velY = _rb.velocity.y;
            _rb.velocity = new Vector2(dir * speed, velY);

            if (dir > 0)
            {
                _sr.flipX = false;
                currentDir = 1;
            }
            else
            {
                currentDir = -1;
                _sr.flipX = true;
            }
        }
    }

    public void Jump()
    {
        if (canJumpA == true)
        {
            _rb.AddForce(Vector2.up * jumpSpeed);
            canJumpA = false;
            canJumpB = true;
        }
        else if (canJumpB == true)
        {
            _rb.AddForce(Vector2.up * jumpSpeed / 2.3f);

            float velY = _rb.velocity.y;
            _rb.velocity = new Vector2(0, velY);

            if (_sr.flipX == false)
                _rb.AddForce(Vector2.right * jumpSpeed/50, ForceMode2D.Impulse);
            else
                _rb.AddForce(-Vector2.right * jumpSpeed/50, ForceMode2D.Impulse);

            canJumpB = false;
            isDashing = true;
            isJumping = false;
        }        
    }

    public void Knockback(int dir, float force)
    {
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector2(0, 0);
        _rb.AddForce(new Vector2(1 * dir, 2f) * force, ForceMode2D.Impulse);
        _sr.color = new Color(0.95f, 0.5f, 0.5f, 0.8f);
        timerStun = 0;
        isDamaged = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 12 || collision.gameObject.layer == 14)
        {
            canJumpA = true;
            canJumpB = false;
            isJumping = false;
            isDashing = false;            
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 16 && crystals == 5)
        {
            SceneManager.LoadScene("Boss");
        }
    }
}
