using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour
{
    public GameObject[] buttonlar;
    bool buttonlaraT�klanabilirmi;
    public string y�klenecekSahne;
    public Text isimG�sterge;
    int m�zik, ses, dil;
    public GameObject[] senaryoButtonlar;
    public Text m�zikButtonText;
    public Text sesButtonText;
    public Text dilButtonText;

    public GameObject oynaButton;

    string a��k;
    string kapal�;
    void Start()
    {
        foreach (GameObject senaryoButton in senaryoButtonlar)
        {
            senaryoButton.transform.GetChild(0).gameObject.GetComponent<Text>().color = Color.black;
        }
        m�zik = PlayerPrefs.GetInt("m�zik");
        ses = PlayerPrefs.GetInt("ses");
        dil = PlayerPrefs.GetInt("dil");
        if (dil == 0)
        {
            a��k = "A��k";
            kapal� = "Kapal�";
        }
        else
        {
            a��k = "Yes";
            kapal� = "No";
        }
        if (m�zik == 0)
        {
            m�zikButtonText.text = a��k;
        }
        else
        {
            m�zikButtonText.text = kapal�;
        }
        if (ses == 0)
        {
            sesButtonText.text = a��k;

        }
        else if (ses == 1)
        {
            sesButtonText.text = kapal�;
        }
        if (dil == 0)
        {
            dilButtonText.text = "TR";
        }
        else if (dil == 1)
        {
            dilButtonText.text = "EN";
        }
        anaMen�.SetActive(true);
        ayarlarMen�.SetActive(false);
        oyunMen�.SetActive(false);
        �uankiMen� = anaMen�;
        isimG�sterge.text = Application.productName;
        �uankiMen� = anaMen�;
        StartCoroutine(ba�lang��());
    }
    public void oynaButton1()
    {
        men�De�i�tir(oyunMen�);

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
        SceneManager.LoadScene(y�klenecekSahne);
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
    public void m�zikButton()
    {
        if (m�zik == 0)
        {
            PlayerPrefs.SetInt("m�zik", 1);
            m�zik = 1;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = kapal�;
        }
        else
        {
            PlayerPrefs.SetInt("m�zik", 0);
            m�zik = 0;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a��k;
        }
    }
    public void sesButton()
    {
        if (ses == 0)
        {
            PlayerPrefs.SetInt("ses", 1);
            ses = 1;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = kapal�;
        }
        else
        {
            PlayerPrefs.SetInt("ses", 0);
            ses = 0;
            EventSystem.current.currentSelectedGameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a��k;
        }
    }
    public GameObject anaMen�;
    public GameObject ayarlarMen�;
    public GameObject oyunMen�;
    public void ayarlarButton()
    {
        men�De�i�tir(ayarlarMen�);
    }
    public void geriButton()
    {
        men�De�i�tir(anaMen�);
    }
    public GameObject �uankiMen�;
    public void men�De�i�tir(GameObject a��lacakMen�)
    {
        �uankiMen�.SetActive(false);
        a��lacakMen�.SetActive(true);
        �uankiMen� = a��lacakMen�;
    }
    IEnumerator ba�lang��()
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
        buttonlaraT�klanabilirmi = true;
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
    public void ��k��Button()
    {
        Application.Quit();
    }
}