using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeminAlgılayıcı : MonoBehaviour
{
    GameObject karakter;
    Karakter karakterScript;
    Animator karakterAnimator;
    void Start()
    {
        karakter = gameObject.transform.parent.gameObject;
        karakterScript = karakter.GetComponent<Karakter>();
        karakterAnimator = karakter.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Zemin")
        {
            karakterScript.zıplayabilirmi = true;
            karakterAnimator.SetBool("zıplıyormu", false);
        }
    }
}
