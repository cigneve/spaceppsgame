using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoketHareket : MonoBehaviour
{
    Rigidbody2D rb;
    public float hareketHýzý;
    public float maxX;
    public GameObject ýþýnObje;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(hareketHýzý, 0);
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
        ýþýnObje.SetActive(true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Yýldýz Bilgi Yeri");
    }
}