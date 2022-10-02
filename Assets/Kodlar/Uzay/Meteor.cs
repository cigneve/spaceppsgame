using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float enFazlaGidilebilirX;
    public float hareketHýzý;
    Rigidbody2D rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(hareketHýzý, 0);
    }
    void Update()
    {
        if (transform.position.x < enFazlaGidilebilirX)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Roket")
        {
            UzayAnaKod uzayAnaKod = GameObject.Find("Uzay Ana Obje").GetComponent<UzayAnaKod>();
            if (uzayAnaKod.kalpGidebilirmi)
                Destroy(gameObject);
            uzayAnaKod.kalpGötür();
        }
    }
}
