using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiyalogGirmeYeri : MonoBehaviour
{
    Diyalog diyalog;
    public Sprite[] diyalogResimler;
    public string[] diyalog�simler;
    public string[] diyalogYaz�lar;

    public string[] diyalog�simler�ngilizce;
    public string[] diyalogYaz�lar�ngilizce;
    List<diyalogClass> diyaloglar = new List<diyalogClass>();

    public GameObject sonPanel;
    void Awake()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            diyalogYaz�lar = diyalogYaz�lar�ngilizce;
            diyalog�simler = diyalog�simler�ngilizce;
        }

    }
    void Start()
    {
        int se�ilenY�ld�zNo = 0;
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
        string se�ilenY�ld�z�sim = "";
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            se�ilenY�ld�z�sim = PlayerPrefs.GetString("senaryo");
        }
        else
        {
            switch (se�ilenY�ld�zNo)
            {
                case 0:
                    se�ilenY�ld�z�sim = "White Dwarf";
                    break;
                case 1:
                    se�ilenY�ld�z�sim = "Neutron Star";
                    break;
                case 2:
                    se�ilenY�ld�z�sim = "Black Hole";
                    break;
            }
        }
        for (int i = 0; i < diyalogYaz�lar.Length; i++)
        {

            diyalogYaz�lar[i] = diyalogYaz�lar[i].Replace("%a%", se�ilenY�ld�z�sim);
            diyalogClass diyalogC = new diyalogClass(diyalog�simler[i], diyalogYaz�lar[i], diyalogResimler[i]);
            diyaloglar.Add(diyalogC);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Karakter")
        {
            StartCoroutine(bekle(collision.gameObject));
        }
    }
    IEnumerator bekle(GameObject karakter)
    {
        karakter.GetComponent<Karakter>().hareketEdebilirmi = false;
        diyalog = GameObject.Find("Diyalog Obje").GetComponent<Diyalog>();
        diyalog.diyalogBa�lat(diyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitUntil(() => diyalog.diyalogBittimi == true);
        for (float i = 0; i < 1f; i = i + 0.01f)
        {
            Color c = sonPanel.GetComponent<Image>().color;
            c.a = i;
            sonPanel.GetComponent<Image>().color = c;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("Uzay Gemisi");
    }
}
