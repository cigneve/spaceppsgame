using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string[] yazýlar;
    public string[] yazýlarÝngilizce;

    public Image resimGösterge;
    public Text yazýGösterge;

    public string yüklenecekSahne;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            yazýlar = yazýlarÝngilizce;
        }
        StartCoroutine(döngü());
    }
    IEnumerator döngü()
    {
        for (int i = 0; i < yazýlar.Length; i++)
        {
            yazýBittimi = false;
            StartCoroutine(yazýYaz(yazýlar[i]));
            yield return new WaitWhile(() => yazýBittimi == false);
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(yüklenecekSahne);
    }
    bool yazýBittimi;
    IEnumerator yazýYaz(string yazý)
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
        yazý = yazý.Replace("%a%", seçilenYýldýzÝsim);
        yazýGösterge.text = "";
        foreach(char karakter in yazý)
        {
            yazýGösterge.text = yazýGösterge.text + karakter;
            yield return new WaitForSeconds(0.02f);
        }
        yazýBittimi = true;
    }
}
