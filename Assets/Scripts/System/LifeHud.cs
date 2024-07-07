using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHud : MonoBehaviour
{
    Player _p;
    public GameObject hA;
    public GameObject hB;
    public GameObject hC;
    public GameObject hD;
    public GameObject hE;

    private void Awake()
    {
       _p = FindObjectOfType<Player>();        
    }

    void Update ()
    {
        if (_p.life >= 5)
        {
            hA.SetActive(true);
            hB.SetActive(true);
            hC.SetActive(true);
            hD.SetActive(true);
            hE.SetActive(true);
        }

        if (_p.life == 4)
        {
            hA.SetActive(false);
            hB.SetActive(true);
            hC.SetActive(true);
            hD.SetActive(true);
            hE.SetActive(true);
        }

        if (_p.life == 3)
        {
            hA.SetActive(false);
            hB.SetActive(false);
            hC.SetActive(true);
            hD.SetActive(true);
            hE.SetActive(true);
        }

        if (_p.life == 2)
        {
            hA.SetActive(false);
            hB.SetActive(false);
            hC.SetActive(false);
            hD.SetActive(true);
            hE.SetActive(true);
        }

        if (_p.life == 1)
        {
            hA.SetActive(false);
            hB.SetActive(false);
            hC.SetActive(false);
            hD.SetActive(false);
            hE.SetActive(true);
        }

        if (_p.life < 1)
        {
            hA.SetActive(false);
            hB.SetActive(false);
            hC.SetActive(false);
            hD.SetActive(false);
            hE.SetActive(false);
        }

    }
}
