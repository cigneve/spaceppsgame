using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OluşturulmuşYıldız : MonoBehaviour
{
    public float yaşamSüresi;
    void Start()
    {
        StartCoroutine(yaşamSayaç());
    }
    IEnumerator yaşamSayaç()
    {
        yield return new WaitForSeconds(yaşamSüresi);
        GameObject.Find("Yıldız Oluşturucu Obje").GetComponent<YıldızOluşturucu>().ölümVar();
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Karadelik")
        {
            Destroy(gameObject);
            GameObject.Find("Yıldız Oluşturucu Obje").GetComponent<YıldızOluşturucu>().ölümVar();
        }
    }
}
