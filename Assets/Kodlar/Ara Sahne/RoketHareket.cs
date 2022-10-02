using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoketHareket : MonoBehaviour
{
    Rigidbody2D rb;
    public float hareketH�z�;
    public float maxX;
    public GameObject ���nObje;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(hareketH�z�, 0);
    }
    bool a;
    void Update()
    {
        if (!a)
        {
            if (rb.transform.position.x >= maxX)
            {
                a = true;
                StartCoroutine(naber());
            }
        }

    }
    IEnumerator naber()
    {
        rb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        ���nObje.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Y�ld�z Bilgi Yeri");
    }
}