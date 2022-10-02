using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiyalogGirScript : MonoBehaviour
{
    public GameObject b�y�kResimObje;
    public GameObject diyalogObje;
    public Diyalog diyalog;
    public List<diyalogClass> g�nderilecekDiyaloglar = new List<diyalogClass>();

    public Sprite[] anaB�y�kResimlerBa�lang��;
    public Sprite[] anaResimlerBa�lang��;
    public string[] ana�simlerBa�lang��;
    public string[] ana�simlerBa�lang���ngilizce;
    public string[] anaYaz�larBa�lang��;
    public string[] anaYaz�larBa�lang���ngilizce;

    public Sprite[] y�ld�zNo1Resimler;
    public string[] y�ld�zNo1�simler;
    public string[] y�ld�zNo1�simler�ngilizce;
    public string[] y�ld�zNo1;
    public string[] y�ld�zNo1�ngilizce;
    public Sprite[] y�ld�zNo1B�y�kResimler;

    public Sprite[] y�ld�zNo2Resimler;
    public string[] y�ld�zNo2�simler;
    public string[] y�ld�zNo2�simler�ngilizce;
    public string[] y�ld�zNo2;
    public string[] y�ld�zNo2�ngilizce;
    public Sprite[] y�ld�zNo2B�y�kResimler;

    public Sprite[] y�ld�zNo3Resimler;
    public string[] y�ld�zNo3�simler;
    public string[] y�ld�zNo3�simler�ngilizce;
    public string[] y�ld�zNo3;
    public string[] y�ld�zNo3�ngilizce;
    public Sprite[] y�ld�zNo3B�y�kResimler;

    public string[] anaYaz�larSon;
    public string[] anaYaz�larSon�ngilizce;
    public Sprite[] anaResimlerSon;
    public string[] ana�simlerSon;
    public string[] ana�simlerSon�ngilizce;
    public Sprite[] anaB�y�kResimlerSon;

    public Sprite[] t�mResimler;
    public string[] resim�simler;
    public string[] resim�ngilizce�simler;

    public Text isimG�sterge;

    public int se�ilenY�ld�zNo;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            ana�simlerBa�lang�� = ana�simlerBa�lang���ngilizce;
            anaYaz�larBa�lang�� = anaYaz�larBa�lang���ngilizce;

            y�ld�zNo1�simler = y�ld�zNo1�simler�ngilizce;
            y�ld�zNo1 = y�ld�zNo1�ngilizce;

            y�ld�zNo2�simler = y�ld�zNo2�simler�ngilizce;
            y�ld�zNo2 = y�ld�zNo2�ngilizce;

            y�ld�zNo3�simler = y�ld�zNo3�simler�ngilizce;
            y�ld�zNo3 = y�ld�zNo3�ngilizce;

            ana�simlerSon = ana�simlerSon�ngilizce;
            anaYaz�larSon = anaYaz�larSon�ngilizce;
        }
        switch (PlayerPrefs.GetString("senaryo"))
        {
            case "Beyaz C�ce":
                se�ilenY�ld�zNo = 0;
                break;
            case "N�tron Y�ld�z�":
                se�ilenY�ld�zNo = 1;
                break;
            case "Karadelik":
                se�ilenY�ld�zNo = 2;
                break;
        }
        StartCoroutine(ba�la());
    }
    public void y�ld�z�Bul(Sprite y�ld�z)
    {
        int a = 0;
        for (int i = 0; i < t�mResimler.Length; i++)
        {
            if (y�ld�z == t�mResimler[i])
            {
                a = i;
                break;
            }
        }
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            isimG�sterge.text = resim�simler[a];
        }
        else if (PlayerPrefs.GetInt("dil") == 1)
        {
            isimG�sterge.text = resim�ngilizce�simler[a];
        }
    }
    IEnumerator ba�la()
    {
        diyalog = diyalogObje.GetComponent<Diyalog>();
        for (int i = 0; i < anaYaz�larBa�lang��.Length; i++)
        {
            diyalogClass dc = new diyalogClass(ana�simlerBa�lang��[i], anaYaz�larBa�lang��[i], anaResimlerBa�lang��[i], anaB�y�kResimlerBa�lang��[i]);
            g�nderilecekDiyaloglar.Add(dc);
        }
        diyalog.diyalogBa�lat(g�nderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        g�nderilecekDiyaloglar.Clear();
        if (se�ilenY�ld�zNo == 0)
        {
            for (int i = 0; i < y�ld�zNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(y�ld�zNo1�simler[i], y�ld�zNo1[i], y�ld�zNo1Resimler[i], y�ld�zNo1B�y�kResimler[i]);
                g�nderilecekDiyaloglar.Add(dc);
            }
        }
        else if (se�ilenY�ld�zNo == 1)
        {
            for (int i = 0; i < y�ld�zNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(y�ld�zNo2�simler[i], y�ld�zNo2[i], y�ld�zNo2Resimler[i], y�ld�zNo2B�y�kResimler[i]);
                g�nderilecekDiyaloglar.Add(dc);
            }
        }
        else if (se�ilenY�ld�zNo == 2)
        {
            for (int i = 0; i < y�ld�zNo1.Length; i++)
            {
                diyalogClass dc = new diyalogClass(y�ld�zNo3�simler[i], y�ld�zNo3[i], y�ld�zNo3Resimler[i], y�ld�zNo3B�y�kResimler[i]);
                g�nderilecekDiyaloglar.Add(dc);
            }
        }
        diyalog.diyalogBa�lat(g�nderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        g�nderilecekDiyaloglar.Clear();
        for (int i = 0; i < anaYaz�larSon.Length; i++)
        {
            diyalogClass dc = new diyalogClass(ana�simlerSon[i], anaYaz�larSon[i], anaResimlerSon[i], anaB�y�kResimlerSon[i]);
            g�nderilecekDiyaloglar.Add(dc);
        }
        diyalog.diyalogBa�lat(g�nderilecekDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitWhile(() => diyalog.diyalogBittimi == false);
        SceneManager.LoadScene("Quiz");
    }
}
