using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UzayAnaKod : MonoBehaviour
{
    public int kalanKalp;
    public GameObject kalpPanel;
    public GameObject[] kalpler;

    public Sprite doluKalp;
    public Sprite boþKalp;

    public int kalanSüre;

    public Text baþlangýçBeklemeGösterge;
    void Start()
    {
        kalanKalp = 3;
        kalanSüre = 3;
        for (int i = 0; i < kalpler.Length; i++)
        {
            kalpler[i].GetComponent<Image>().sprite = doluKalp;
        }
        baþlangýçBeklemeGösterge.gameObject.SetActive(true);
        kalpPanel.SetActive(false);
        baþlangýçBeklemeGösterge.text = kalanSüre.ToString();
        geriSayýmKalanSüre = 15;
        geriSayýmGösterge.gameObject.SetActive(false);
        StartCoroutine(baþlangýçBekleme());
    }
    public bool kalpGidebilirmi;
    public void kalpGötür()
    {
        if (kalpGidebilirmi)
        {
            kalpGidebilirmi = false;
            kalanKalp--;
            if (kalanKalp == 2)
            {
                kalpler[2].GetComponent<Image>().sprite = boþKalp;
                kalpler[1].GetComponent<Image>().sprite = doluKalp;
                kalpler[0].GetComponent<Image>().sprite = doluKalp;
            }
            else if (kalanKalp == 1)
            {
                kalpler[2].GetComponent<Image>().sprite = boþKalp;
                kalpler[1].GetComponent<Image>().sprite = boþKalp;
                kalpler[0].GetComponent<Image>().sprite = doluKalp;
            }
            else if (kalanKalp == 0)
            {
                kalpler[2].GetComponent<Image>().sprite = boþKalp;
                kalpler[1].GetComponent<Image>().sprite = boþKalp;
                kalpler[0].GetComponent<Image>().sprite = boþKalp;
                oyunDurum = false;
                oyunKaybedildi();
            }
            StartCoroutine(damageAnimasyon());
        }
    }
    public GameObject meteorPrefab;
    Meteor meteor;
    IEnumerator damageAnimasyon()
    {
        GameObject roket = GameObject.Find("Roket");
        for (int i = 0; i < 4; i++)
        {
            roket.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            roket.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        kalpGidebilirmi = true;
    }
    IEnumerator meteorOluþturmaBekleme()
    {
        if (oyunDurum)
        {
            meteorOluþtur();
            yield return new WaitForSeconds(3f);
            StartCoroutine(meteorOluþturmaBekleme());
        }
        else
        {
            foreach (GameObject klon in GameObject.FindGameObjectsWithTag("Meteor"))
                Destroy(klon);
        }
    }
    public void meteorOluþtur()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject klon = Instantiate(meteorPrefab);
            meteor = klon.GetComponent<Meteor>();
            meteor.hareketHýzý = Random.Range(-50, -24);
            meteor.transform.position = new Vector2(70, Random.Range(-13, 19));
        }
    }
    public bool oyunDurum;
    IEnumerator baþlangýçBekleme()
    {
        yield return new WaitForSeconds(1f);
        kalanSüre--;
        if (kalanSüre == 0)
        {
            if (PlayerPrefs.GetInt("dil") == 1)
            {
                baþlangýçBeklemeGösterge.text = "Go!";
            }
            else
            {
                baþlangýçBeklemeGösterge.text = "Baþla!";
            }
            yield return new WaitForSeconds(1f);
            baþlangýçBeklemeGösterge.gameObject.SetActive(false);
            kalpPanel.SetActive(true);
            oyunDurum = true;
            kalpGidebilirmi = true;
            geriSayýmGösterge.gameObject.SetActive(true);
            StartCoroutine(meteorOluþturmaBekleme());
            StartCoroutine(geriSay());
        }
        else
        {
            baþlangýçBeklemeGösterge.text = kalanSüre.ToString();
            StartCoroutine(baþlangýçBekleme());
        }
    }
    public Text geriSayýmGösterge;
    public int geriSayýmKalanSüre;
    IEnumerator geriSay()
    {
        if (oyunDurum)
        {
            geriSayýmGösterge.text = geriSayýmKalanSüre.ToString();
            yield return new WaitForSeconds(1f);
            geriSayýmKalanSüre--;
            if (geriSayýmKalanSüre == 0)
            {
                oyunBitti();
                oyunDurum = false;
            }
            else
            {
                StartCoroutine(geriSay());
            }
        }
        else
        {
            geriSayýmGösterge.text = "";
        }
    }

    public GameObject tekrarOynaPanel;
    void oyunKaybedildi()
    {
        tekrarOynaPanel.SetActive(true);
    }
    public void tekrarBaþlat()
    {
        SceneManager.LoadScene("Uzay Gemisi Sürme");
    }
    void oyunBitti()
    {
        SceneManager.LoadScene("Ara Sahne");
    }
}