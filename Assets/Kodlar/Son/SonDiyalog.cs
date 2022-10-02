using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SonDiyalog : MonoBehaviour
{
    public string[] ba�lang��Yaz�lar;
    public string[] ba�lang��Yaz�lar�ngilizce;
    public Text yaz�G�sterge;
    public GameObject diyalogPanel;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            ba�lang��Yaz�lar = ba�lang��Yaz�lar�ngilizce;
        }
        diyalogPanel.SetActive(true);
        sonPanel.gameObject.SetActive(false);
        StartCoroutine(yazmaD�ng�s�());
    }
    IEnumerator yazmaD�ng�s�()
    {
        foreach(string yaz� in ba�lang��Yaz�lar)
        {
            yazmaTamamland�m� = false;
            StartCoroutine(yaz(yaz�));
            yield return new WaitUntil(() => yazmaTamamland�m� == true);
        }
        yield return new WaitForSeconds(1f);
        diyalogPanel.SetActive(false);
        sonPanel.gameObject.SetActive(true);
        StartCoroutine(sonBiti�());
    }
    bool yazmaTamamland�m�;
    IEnumerator yaz(string yaz�)
    {
        yaz�G�sterge.text = "";
        foreach (char karakter in yaz�)
        {
            yaz�G�sterge.text = yaz�G�sterge.text + karakter;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        yazmaTamamland�m� = true;
    }

    public Image sonPanel;
    public Image resim;
    public Text yaz�;
    IEnumerator sonBiti�()
    {
        //adamim oyuncu :*
        for (float i = 0; i < 1; i = i + 0.01f)
        {
            Color c1 = sonPanel.color;
            Color c2 = resim.color;
            Color c3 = yaz�.color;

            c1.a = i;
            c2.a = i;
            c3.a = i;

            sonPanel.color = c1;
            resim.color = c2;
            yaz�.color = c3;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
    }
}
