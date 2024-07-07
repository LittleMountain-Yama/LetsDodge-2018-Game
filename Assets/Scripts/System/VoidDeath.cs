using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDeath : MonoBehaviour
{
    Player _p;
    EnemyMove _m;
    

    private void Start()
    {
        _p = FindObjectOfType<Player>();
        _m = FindObjectOfType<EnemyMove>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            _p.life = 0;

        if (collision.gameObject.GetComponent<EnemyMove>())
            _m.life = 0;
    }

}
