using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İlkDiyalog : MonoBehaviour
{
    public Sprite[] resimler;
    public string[] isimler;
    public string[] yazılar;

    public string[] isimlerİngilizce;
    public string[] yazılarİngilizce;

    public List<diyalogClass> aktarılacakDiyaloglar = new List<diyalogClass>();
    public GameObject diyalogObje;
    Diyalog diyalog;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            isimler = isimlerİngilizce;
            yazılar = yazılarİngilizce;
        }
        diyalog = diyalogObje.GetComponent<Diyalog>();
        GameObject.Find("Karakter").GetComponent<Karakter>().hareketEdebilirmi = false;
        int seçilenYıldızNo = 0;
            switch (PlayerPrefs.GetString("senaryo"))
        {
            case "Beyaz Cüce":
                seçilenYıldızNo = 0;
                break;
            case "Nötron Yıldızı":
                seçilenYıldızNo = 1;
                break;
            case "Karadelik":
                seçilenYıldızNo = 2;
                break;
        }
        string seçilenYıldızİsim = "";
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            seçilenYıldızİsim = PlayerPrefs.GetString("senaryo");
        }
        else
        {
            switch (seçilenYıldızNo)
            {
                case 0:
                    seçilenYıldızİsim = "White Dwarf";
                    break;
                case 1:
                    seçilenYıldızİsim = "Neutron Star";
                    break;
                case 2:
                    seçilenYıldızİsim = "Black Hole";
                    break;
            }
        }
        for (int i = 0; i < yazılar.Length; i++)
        {

            isimler[i] = isimler[i].Replace("%a%", seçilenYıldızİsim);
            aktarılacakDiyaloglar.Add(new diyalogClass(isimler[i], yazılar[i], resimler[i]));
        }
        StartCoroutine(diyalogBekle());
    }
    IEnumerator diyalogBekle()
    {
        diyalog.diyalogBaşlat(aktarılacakDiyaloglar.ToArray());
        diyalog.diyalogBittimi = false;
        yield return new WaitUntil(() => diyalog.diyalogBittimi == true);
        GameObject.Find("Karakter").GetComponent<Karakter>().hareketEdebilirmi = true;
    }
}
