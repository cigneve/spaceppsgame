using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public string[] yaz�lar;
    public string[] yaz�lar�ngilizce;

    public Image resimG�sterge;
    public Text yaz�G�sterge;

    public string y�klenecekSahne;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            yaz�lar = yaz�lar�ngilizce;
        }
        StartCoroutine(d�ng�());
    }
    IEnumerator d�ng�()
    {
        for (int i = 0; i < yaz�lar.Length; i++)
        {
            yaz�Bittimi = false;
            StartCoroutine(yaz�Yaz(yaz�lar[i]));
            yield return new WaitWhile(() => yaz�Bittimi == false);
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(y�klenecekSahne);
    }
    bool yaz�Bittimi;
    IEnumerator yaz�Yaz(string yaz�)
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
        yaz� = yaz�.Replace("%a%", se�ilenY�ld�z�sim);
        yaz�G�sterge.text = "";
        foreach(char karakter in yaz�)
        {
            yaz�G�sterge.text = yaz�G�sterge.text + karakter;
            yield return new WaitForSeconds(0.02f);
        }
        yaz�Bittimi = true;
    }
}
