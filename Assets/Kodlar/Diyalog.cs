using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Diyalog : MonoBehaviour
{
    public GameObject diyalogPanel;
    public Image diyalogResimGösterge;
    public Text diyalogYazýGösterge;
    public Text diyalogÝsimGösterge;

    public Image büyükResimGösterge;

    public GameObject devamButton;

    public diyalogClass[] diyaloglar;

    public bool diyalogBittimi;
    void Awake()
    {
        diyalogPanel.SetActive(false);
        devamButton.SetActive(false);
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            devamButton.transform.GetComponentInChildren<Text>().text = "Continue";
        }
    }
    public void diyalogBaþlat(diyalogClass[] gelenDiyaloglar)
    {
        diyalogBittimi = false;
        diyaloglar = gelenDiyaloglar;
        diyalogPanel.SetActive(true);
        StartCoroutine(diyalogDöngü(diyaloglar));

    }
    IEnumerator diyalogDöngü(diyalogClass[] gelenDiyaloglar)
    {
        foreach (diyalogClass diyalog in diyaloglar)
        {
            yazýBitti = false;
            devam = false;
            diyalogGir(diyalog.isim, diyalog.yazý, diyalog.resim, diyalog.büyükResim);
            yield return new WaitWhile(() => devam == false);
        }
        diyalogBittimi = true;
        diyalogPanel.SetActive(false);
    }
    public GameObject büyükÝsimGösterge;
    void diyalogGir(string isim, string yazý, Sprite resim, Sprite büyükResim)
    {
        if (resim != null)
            diyalogResimGösterge.sprite = resim;
        if (büyükResim != null)
        {
            büyükResimGösterge.sprite = büyükResim;
            GameObject.Find("Yýldýz Bilgi Diyalog").GetComponent<DiyalogGirScript>().yýldýzýBul(büyükResim);
        }
        diyalogÝsimGösterge.text = isim;
        diyalogYazýGösterge.text = "";
        StartCoroutine(diyalogYazýAnimasyon(yazý));
    }
    bool yazýBitti;
    IEnumerator diyalogYazýAnimasyon(string yazý)
    {
        foreach (char karakter in yazý)
        {
            diyalogYazýGösterge.text = diyalogYazýGösterge.text + karakter;
            yield return new WaitForSeconds(0.01f);
        }
        yazýBitti = true;
        devamButton.SetActive(true);
    }
    bool devam;
    public void diyalogDevamButton()
    {
        if (yazýBitti)
        {
            devamButton.SetActive(false);
            devam = true;
        }
    }
}
public class diyalogClass{
    public string isim { get; set; }
    public string yazý { get; set; }
    public Sprite resim { get; set; }
    public Sprite büyükResim { get; set; }

    public diyalogClass(string isim, string yazý, Sprite resim, Sprite büyükResim = null)
    {
        this.isim = isim;
        this.yazý = yazý;
        this.resim = resim;
        this.büyükResim = büyükResim;
    }
}