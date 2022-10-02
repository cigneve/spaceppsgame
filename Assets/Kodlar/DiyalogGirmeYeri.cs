using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiyalogGirmeYeri : MonoBehaviour
{
    Diyalog diyalog;
    public Sprite[] diyalogResimler;
    public string[] diyalogÝsimler;
    public string[] diyalogYazýlar;

    public string[] diyalogÝsimlerÝngilizce;
    public string[] diyalogYazýlarÝngilizce;
    List<diyalogClass> diyaloglar = new List<diyalogClass>();

    public GameObject sonPanel;
    void Awake()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            diyalogYazýlar = diyalogYazýlarÝngilizce;
            diyalogÝsimler = diyalogÝsimlerÝngilizce;
        }

    }
    void Start()
    {
        int seçilenYýldýzNo = 0;
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
        string seçilenYýldýzÝsim = "";
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            seçilenYýldýzÝsim = PlayerPrefs.GetString("senaryo");
        }
        else
        {
            switch (seçilenYýldýzNo)
            {
                case 0:
                    seçilenYýldýzÝsim = "White Dwarf";
                    break;
                case 1:
                    seçilenYýldýzÝsim = "Neutron Star";
                    break;
                case 2:
                    seçilenYýldýzÝsim = "Black Hole";
                    break;
            }
        }
        for (int i = 0; i < diyalogYazýlar.Length; i++)
        {

            diyalogYazýlar[i] = diyalogYazýlar[i].Replace("%a%", seçilenYýldýzÝsim);
            diyalogClass diyalogC = new diyalogClass(diyalogÝsimler[i], diyalogYazýlar[i], diyalogResimler[i]);
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
        diyalog.diyalogBaþlat(diyaloglar.ToArray());
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
