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
                if (!ilk�al��t�rma)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, rb.velocity.y);
                    animator.SetBool("y�r�yormu", false);
                }
                else
                {
                    ilk�al��t�rma = false;
                }
            }
        }
    }
    bool ilk�al��t�rma = true;
    private bool _hareketEdebilirmi;
    Rigidbody2D rb;
    Animator animator;
    public float y�r�meH�z�, z�plamaG�c�;
    public bool z�playabilirmi;
    public bool kameraTakipEdecekmi = true;

    public bool hareketEdebilirmiBa�lang��;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hareketEdebilirmi = hareketEdebilirmiBa�lang��;
    }
    void Update()
    {
        if (kameraTakipEdecekmi)
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 1, -20);
        if (hareketEdebilirmi)
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(y�r�meH�z�, rb.velocity.y);
                animator.SetBool("y�r�yormu", true);

                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 0;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-y�r�meH�z�, rb.velocity.y);
                animator.SetBool("y�r�yormu", true);

                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = 180;
                transform.rotation = Quaternion.Euler(rotationVector);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetBool("y�r�yormu", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                if (z�playabilirmi)
                {
                    rb.velocity = new Vector2(rb.velocity.x, z�plamaG�c�);
                    z�playabilirmi = false;
                    animator.SetBool("z�pl�yormu", true);
                }
            }
        }
    }
}
