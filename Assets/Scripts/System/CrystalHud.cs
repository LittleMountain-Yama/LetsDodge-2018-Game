using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrystalHud : MonoBehaviour
{    
    public Text crystalText;
    public GameObject Image;
    Player _p;

    private void Awake()
    {
        _p = FindObjectOfType<Player>();
    }

    void Update ()
    {
        if (_p.crystals == 0)
        {
            Image.SetActive(false);
            crystalText.text = "";
        }
        else if (_p.crystals > 0)
        {
            Image.SetActive(true);
            crystalText.text = "" + _p.crystals;
        }                   
    }
}
