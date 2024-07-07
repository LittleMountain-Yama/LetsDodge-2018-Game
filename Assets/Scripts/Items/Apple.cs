using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    GameObject _p;

    private void Awake()
    {
        _p = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (_p.transform.GetComponent<Player>().life <= 3)
            {                
                _p.transform.GetComponent<Player>().life += 2;
                Destroy(this.gameObject);
            }
            else if(_p.transform.GetComponent<Player>().life == 4)
            {
                _p.transform.GetComponent<Player>().life += 1;
                Destroy(this.gameObject);
            }

        }
    }
}
