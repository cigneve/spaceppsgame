using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Amca : MonoBehaviour
{
    public Vector2 ilkKonum;
    public Vector2 sonKonum;
    public string y�klenecekSahne;
    public GameObject panel;
    void Start()
    {
        StartCoroutine(y�r�me());
    }
    IEnumerator y�r�me()
    {
        transform.position = ilkKonum;
        yield return new WaitForSeconds(3f);
        for(float i = 0; i < 1f; i = i + 0.01f)
        {
            Color c = panel.GetComponent<Image>().color;
            c.a = i;
            panel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.01f);
        }
        transform.position = sonKonum;
        for (float i = 1f; i > 0; i = i - 0.01f)
        {
            Color c = panel.GetComponent<Image>().color;
            c.a = i;
            panel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(y�klenecekSahne);
    }
}