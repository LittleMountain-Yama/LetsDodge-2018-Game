using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
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
            Destroy(this.gameObject);
            _p.transform.GetComponent<Player>().crystals += 1;
        }
    }
}
