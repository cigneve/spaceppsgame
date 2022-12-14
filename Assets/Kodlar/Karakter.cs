using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karakter : MonoBehaviour
{
    public bool hareketEdebilirmi
    {
        get
        {
            return _hareketEdebilirmi;
        }
        set
        {
            _hareketEdebilirmi = value;
            if (!value)
            {
                if (!ilkÇalıştırma)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("yürüyormu", false);
                }
                else
                {
                    ilkÇalıştırma = false;
                }
            }
        }
    }
    bool ilkÇalıştırma = true;
    private bool _hareketEdebilirmi;
    Rigidbody2D rb;
    Animator animator;
    public float yürümeHızı, zıplamaGücü;
    public bool zıplayabilirmi;
    public bool kameraTakipEdecekmi = true;

    public bool hareketEdebilirmiBaşlangıç;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hareketEdebilirmi = hareketEdebilirmiBaşlangıç;
    }
    void Update()
    {
        if (kameraTakipEdecekmi)
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 1, -20);
        if (hareketEdebilirmi)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(yürümeHızı, rb.velocity.y);
                animator.SetBool("yürüyormu", true);

                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 0;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-yürümeHızı, rb.velocity.y);
                animator.SetBool("yürüyormu", true);

                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetBool("yürüyormu", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (zıplayabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, zıplamaGücü);
                    zıplayabilirmi = false;
                    animator.SetBool("zıplıyormu", true);
                }
            }
        }
    }
}
