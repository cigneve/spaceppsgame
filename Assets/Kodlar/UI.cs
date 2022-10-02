using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public GameObject[] buttonlar;
    bool buttonlaraTýklanabilirmi;
    public string yüklenecekSahne;
    public Text isimGösterge;
    int müzik, ses, dil;
    public GameObject[] senaryoButtonlar;
    public Text müzikButtonText;
    public Text sesButtonText;
    public Text dilButtonText;

    public GameObject oynaButton;

    string açýk;
    string kapalý;
    void Start()
    {
        foreach (GameObject senaryoButton in senaryoButtonlar)
        {
            senaryoButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        }
        müzik = PlayerPrefs.GetInt("müzik");
        ses = PlayerPrefs.GetInt("ses");
        dil = PlayerPrefs.GetInt("dil");
        if (dil == 0)
        {
            açýk = "Açýk";
            kapalý = "Kapalý";
        }
        else
        {
            açýk = "Yes";
            kapalý = "No";
        }
        if (müzik == 0)
        {
            müzikButtonText.text = açýk;
        }
        else
        {
            müzikButtonText.text = kapalý;
        }
        if (ses == 0)
        {
            sesButtonText.text = açýk;

        }
        else if (ses == 1)
        {
            sesButtonText.text = kapalý;
        }
        if (dil == 0)
        {
            dilButtonText.text = "TR";
        }
        else if (dil == 1)
        {
            dilButtonText.text = "EN";
        }
        anaMenü.SetActive(true);
        ayarlarMenü.SetActive(false);
        oyunMenü.SetActive(false);
        þuankiMenü = anaMenü;
        isimGösterge.text = Application.productName;
        þuankiMenü = anaMenü;
        StartCoroutine(baþlangýç());
    }
    public void oynaButton1()
    {
        menüDeðiþtir(oyunMenü);

    }
    public void senaryoButton()
    {
        foreach(GameObject senaryoButton in senaryoButtonlar)
        {
            senaryoButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        }
        GameObject sb = EventSystem.current.currentSelectedGameObject;
        PlayerPrefs.SetString("senaryo", sb.name);
        sb.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.green;
        oynaButton.SetActive(true);
    }
    public void oynaButton2()
    {
        SceneManager.LoadScene(yüklenecekSahne);
    }
    public void dilButton()
    {
        if (dil == 0)
        {
            PlayerPrefs.SetInt("dil", 1);
            dil = 1;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "EN";
        }
        else
        {
            PlayerPrefs.SetInt("dil", 0);
            dil = 0;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "TR";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void müzikButton()
    {
        if (müzik == 0)
        {
            PlayerPrefs.SetInt("müzik", 1);
            müzik = 1;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = kapalý;
        }
        else
        {
            PlayerPrefs.SetInt("müzik", 0);
            müzik = 0;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = açýk;
        }
    }
    public void sesButton()
    {
        if (ses == 0)
        {
            PlayerPrefs.SetInt("ses", 1);
            ses = 1;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = kapalý;
        }
        else
        {
            PlayerPrefs.SetInt("ses", 0);
            ses = 0;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = açýk;
        }
    }
    public GameObject anaMenü;
    public GameObject ayarlarMenü;
    public GameObject oyunMenü;
    public void ayarlarButton()
    {
        menüDeðiþtir(ayarlarMenü);
    }
    public void geriButton()
    {
        menüDeðiþtir(anaMenü);
    }
    public GameObject þuankiMenü;
    public void menüDeðiþtir(GameObject açýlacakMenü)
    {
        þuankiMenü.SetActive(false);
        açýlacakMenü.SetActive(true);
        þuankiMenü = açýlacakMenü;
    }
    IEnumerator baþlangýç()
    {
        foreach (GameObject button in buttonlar)
        {
            button.SetActive(false);
        }
        foreach (GameObject button in buttonlar)
        {
            animasyonBittimi = false;
            button.transform.GetChild(0).gameObject.SetActive(false);
            button.GetComponent<RectTransform>().offsetMin = new Vector2(194f, 34f);
            button.GetComponent<RectTransform>().offsetMax = new Vector2(-194f, -34f);
            StartCoroutine(buttonAnimasyon(button));
            yield return new WaitWhile(() => animasyonBittimi == false);
        }
        buttonlaraTýklanabilirmi = true;
        yield return new WaitForSeconds(1f);
    }
    bool animasyonBittimi;

    IEnumerator buttonAnimasyon(GameObject button)
    {
        RectTransform rt = button.GetComponent<RectTransform>();
        button.SetActive(true);
        for (float i = 194f; i  > 0; i = i - 2f)
        {
            rt.offsetMin = new Vector2(i, rt.offsetMin.y);
            rt.offsetMax = new Vector2(-i, rt.offsetMax.y);
            yield return new WaitForSeconds(0.01f);
        }
        for (float i = 34f; i > 0; i = i - 2f)
        {
            rt.offsetMin = new Vector2(rt.offsetMin.x, i);
            rt.offsetMax = new Vector2(rt.offsetMax.x, -i);
            yield return new WaitForSeconds(0.01f);
        }
        button.transform.GetChild(0).gameObject.SetActive(true);
        animasyonBittimi = true;
    }
    public void çýkýþButton()
    {
        Application.Quit();
    }
}