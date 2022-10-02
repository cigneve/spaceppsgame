using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SonDiyalog : MonoBehaviour
{
    public string[] baþlangýçYazýlar;
    public string[] baþlangýçYazýlarÝngilizce;
    public Text yazýGösterge;
    public GameObject diyalogPanel;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            baþlangýçYazýlar = baþlangýçYazýlarÝngilizce;
        }
        diyalogPanel.SetActive(true);
        sonPanel.gameObject.SetActive(false);
        StartCoroutine(yazmaDöngüsü());
    }
    IEnumerator yazmaDöngüsü()
    {
        foreach(string yazý in baþlangýçYazýlar)
        {
            yazmaTamamlandýmý = false;
            StartCoroutine(yaz(yazý));
            yield return new WaitUntil(() => yazmaTamamlandýmý == true);
        }
        yield return new WaitForSeconds(1f);
        diyalogPanel.SetActive(false);
        sonPanel.gameObject.SetActive(true);
        StartCoroutine(sonBitiþ());
    }
    bool yazmaTamamlandýmý;
    IEnumerator yaz(string yazý)
    {
        yazýGösterge.text = "";
        foreach (char karakter in yazý)
        {
            yazýGösterge.text = yazýGösterge.text + karakter;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(2f);
        yazmaTamamlandýmý = true;
    }

    public Image sonPanel;
    public Image resim;
    public Text yazý;
    IEnumerator sonBitiþ()
    {
        //adamim oyuncu :*
        for (float i = 0; i < 1; i = i + 0.01f)
        {
            Color c1 = sonPanel.color;
            Color c2 = resim.color;
            Color c3 = yazý.color;

            c1.a = i;
            c2.a = i;
            c3.a = i;

            sonPanel.color = c1;
            resim.color = c2;
            yazý.color = c3;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(3f);
    }
}
