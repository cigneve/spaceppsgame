using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiyalogGirScript : MonoBehaviour
{
    public GameObject büyükResimObje;
    public GameObject diyalogObje;
    public Diyalog diyalog;
    public List<diyalogClass> gönderilecekDiyaloglar = new List<diyalogClass>();

    public Sprite[] anaBüyükResimlerBaþlangýç;
    public Sprite[] anaResimlerBaþlangýç;
    public string[] anaÝsimlerBaþlangýç;
    public string[] anaÝsimlerBaþlangýçÝngilizce;
    public string[] anaYazýlarBaþlangýç;
    public string[] anaYazýlarBaþlangýçÝngilizce;

    public Sprite[] yýldýzNo1Resimler;
    public string[] yýldýzNo1Ýsimler;
    public string[] yýldýzNo1ÝsimlerÝngilizce;
    public string[] yýldýzNo1;
    public string[] yýldýzNo1Ýngilizce;
    public Sprite[] yýldýzNo1BüyükResimler;

    public Sprite[] yýldýzNo2Resimler;
    public string[] yýldýzNo2Ýsimler;
    public string[] yýldýzNo2ÝsimlerÝngilizce;
    public string[] yýldýzNo2;
    public string[] yýldýzNo2Ýngilizce;
    public Sprite[] yýldýzNo2BüyükResimler;

    public Sprite[] yýldýzNo3Resimler;
    public string[] yýldýzNo3Ýsimler;
    public string[] yýldýzNo3ÝsimlerÝngilizce;
    public string[] yýldýzNo3;
    public string[] yýldýzNo3Ýngilizce;
    public Sprite[] yýldýzNo3BüyükResimler;

    public string[] anaYazýlarSon;
    public string[] anaYazýlarSonÝngilizce;
    public Sprite[] anaResimlerSon;
    public string[] anaÝsimlerSon;
    public string[] anaÝsimlerSonÝngilizce;
    public Sprite[] anaBüyükResimlerSon;

    public Sprite[] tümResimler;
    public string[] resimÝsimler;
    public string[] resimÝngilizceÝsimler;

    public Text isimGösterge;

    public int seçilenYýldýzNo;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            anaÝsimlerBaþlangýç = anaÝsimlerBaþlangýçÝngilizce;
            anaYazýlarBaþlangýç = anaYazýlarBaþlangýçÝngilizce;

            yýldýzNo1Ýsimler = yýldýzNo1ÝsimlerÝngilizce;
            yýldýzNo1 = yýldýzNo1Ýngilizce;

            yýldýzNo2Ýsimler = yýldýzNo2ÝsimlerÝngilizce;
            yýldýzNo2 = yýldýzNo2Ýngilizce;

            yýldýzNo3Ýsimler = yýldýzNo3ÝsimlerÝngilizce;
            yýldýzNo3 = yýldýzNo3Ýngilizce;

            anaÝsimlerSon = anaÝsimlerSonÝngilizce;
            anaYazýlarSon = anaYazýlarSonÝngilizce;
        }
        switch (PlayerPrefs.GetString("senaryo"))
        {
            case "Beyaz Cüce":
                seçilenYýldýzNo = 0;
                break;
            case "Nötron Yýldýzý":
                seçilenYýldýzNo = 1;
                break;
            case "Karadelik":
                seçilenYýldýzNo = 2;
                break;
        }
        StartCoroutine(baþla());
    }
    public void yýldýzýBul(Sprite yýldýz)
    {
        int a = 0;
        for (int i = 0; i < tümResimler.Length; i++)
        {
            if (yýldýz == tümResimler[i])
            {
                a = i;
                break;
            }
        }
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            isimGösterge.text = resimÝsimler[a];
        }
        else if (PlayerPrefs.GetInt("dil") == 1)
        {
            isimGösterge.text = resimÝngilizceÝsimler[a];
        }
    }
    IEnumerator baþla()
    {
        diyalog = diyalogObje.GetComponent<Diyalog>();
        for (int i = 0; i < anaYazýlarBaþlangýç.Length; i++)
        {
            diyalogClass dc = new diyalogClass(anaÝsimlerBaþlangýç[i], anaYazýlarBaþlangýç[i], anaResimlerBaþlangýç[i], anaBüyükResimlerBaþlangýç[i]);
            gönderilecekDiyaloglar.Add(dc);
        }
        diyalog.diyalogBaþlat(gönderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        gönderilecekDiyaloglar.Clear();
        if (seçilenYýldýzNo == 0)
        {
            for (int i = 0; i < yýldýzNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(yýldýzNo1Ýsimler[i], yýldýzNo1[i], yýldýzNo1Resimler[i], yýldýzNo1BüyükResimler[i]);
                gönderilecekDiyaloglar.Add(dc);
            }
        }
        else if (seçilenYýldýzNo == 1)
        {
            for (int i = 0; i < yýldýzNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(yýldýzNo2Ýsimler[i], yýldýzNo2[i], yýldýzNo2Resimler[i], yýldýzNo2BüyükResimler[i]);
                gönderilecekDiyaloglar.Add(dc);
            }
        }
        else if (seçilenYýldýzNo == 2)
        {
            for (int i = 0; i < yýldýzNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(yýldýzNo3Ýsimler[i], yýldýzNo3[i], yýldýzNo3Resimler[i], yýldýzNo3BüyükResimler[i]);
                gönderilecekDiyaloglar.Add(dc);
            }
        }
        diyalog.diyalogBaþlat(gönderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        gönderilecekDiyaloglar.Clear();
        for (int i = 0; i < anaYazýlarSon.Length; i++)
        {
            diyalogClass dc = new diyalogClass(anaÝsimlerSon[i], anaYazýlarSon[i], anaResimlerSon[i], anaBüyükResimlerSon[i]);
            gönderilecekDiyaloglar.Add(dc);
        }
        diyalog.diyalogBaþlat(gönderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        SceneManager.LoadScene("Quiz");
    }
}
