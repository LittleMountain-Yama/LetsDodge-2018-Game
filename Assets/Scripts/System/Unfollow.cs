using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unfollow : MonoBehaviour
{
    public CameraToFollow _c;
    Player _p;

	void Start ()
    {
        _c = FindObjectOfType<CameraToFollow>();
        _p = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _p.isDefault = true;
            _c.follow = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
            if (_p.life != 0)
            {
                _p.isDefault = false;
                _c.follow = true;
            }
    }
}
