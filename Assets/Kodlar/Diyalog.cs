using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Diyalog : MonoBehaviour
{
    public GameObject diyalogPanel;
    public Image diyalogResimG�sterge;
    public Text diyalogYaz�G�sterge;
    public Text diyalog�simG�sterge;

    public Image b�y�kResimG�sterge;

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
    public void diyalogBa�lat(diyalogClass[] gelenDiyaloglar)
    {
        diyalogBittimi = false;
        diyaloglar = gelenDiyaloglar;
        diyalogPanel.SetActive(true);
        StartCoroutine(diyalogD�ng�(diyaloglar));

    }
    IEnumerator diyalogD�ng�(diyalogClass[] gelenDiyaloglar)
    {
        foreach (diyalogClass diyalog in diyaloglar)
        {
            yaz�Bitti = false;
            devam = false;
            diyalogGir(diyalog.isim, diyalog.yaz�, diyalog.resim, diyalog.b�y�kResim);
            yield return new WaitWhile(() => devam == false);
        }
        diyalogBittimi = true;
        diyalogPanel.SetActive(false);
    }
    public GameObject b�y�k�simG�sterge;
    void diyalogGir(string isim, string yaz�, Sprite resim, Sprite b�y�kResim)
    {
        if (resim != null)
            diyalogResimG�sterge.sprite = resim;
        if (b�y�kResim != null)
        {
            b�y�kResimG�sterge.sprite = b�y�kResim;
            GameObject.Find("Y�ld�z Bilgi Diyalog").GetComponent<DiyalogGirScript>().y�ld�z�Bul(b�y�kResim);
        }
        diyalog�simG�sterge.text = isim;
        diyalogYaz�G�sterge.text = "";
        StartCoroutine(diyalogYaz�Animasyon(yaz�));
    }
    bool yaz�Bitti;
    IEnumerator diyalogYaz�Animasyon(string yaz�)
    {
        foreach (char karakter in yaz�)
        {
            diyalogYaz�G�sterge.text = diyalogYaz�G�sterge.text + karakter;
            yield return new WaitForSeconds(0.01f);
        }
        yaz�Bitti = true;
        devamButton.SetActive(true);
    }
    bool devam;
    public void diyalogDevamButton()
    {
        if (yaz�Bitti)
        {
            devamButton.SetActive(false);
            devam = true;
        }
    }
}
public class diyalogClass{
    public string isim { get; set; }
    public string yaz� { get; set; }
    public Sprite resim { get; set; }
    public Sprite b�y�kResim { get; set; }

    public diyalogClass(string isim, string yaz�, Sprite resim, Sprite b�y�kResim = null)
    {
        this.isim = isim;
        this.yaz� = yaz�;
        this.resim = resim;
        this.b�y�kResim = b�y�kResim;
    }
}