using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SoruSorma : MonoBehaviour
{
    public GameObject ilkPanel, başlangıçPanel, sonPanel;

    public string[] sorular;
    public string[] sorularİngilizce;
    public string[] doğruCevaplar;
    public string[] doğruCevaplarİngilizce;
    public string[] yanlışCevaplar;
    public string[] yanlışCevaplarİngilizce;
    public string[] yanlışCevaplar2;
    public string[] yanlışCevaplar2İngilizce;
    public bool[] soruldumu;

    public GameObject devamTekrar;

    public Text ilkAnimYazı;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            sorular = sorularİngilizce;
            doğruCevaplar = doğruCevaplarİngilizce;
            yanlışCevaplar = yanlışCevaplarİngilizce;
            yanlışCevaplar2 = yanlışCevaplar2İngilizce;
        }

        ilkPanel.SetActive(true);
        başlangıçPanel.SetActive(false);
        sonPanel.SetActive(false);
        button1Text = button1.transform.GetChild(0).gameObject.GetComponent<Text>();
        button2Text = button2.transform.GetChild(0).gameObject.GetComponent<Text>();
        soruldumu = new bool[sorular.Length];
        for (int i = 0; i < sorular.Length; i++)
        {
            soruldumu[i] = false;
        }
        StartCoroutine(ilkPanelAnim());
    }
    IEnumerator ilkPanelAnim()
    {
        for (int i = 10; i < 80; i++)
        {
            ilkAnimYazı.resizeTextMaxSize = i;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        ilkPanel.SetActive(false);
        başlangıçPanel.SetActive(true);
        sonPanel.SetActive(false);
        StartCoroutine(soruDöngü());
    }
    IEnumerator soruDöngü()
    {
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, sorular.Length);
            while (soruldumu[random])
            {
                random = Random.Range(0, sorular.Length);
            }
            if (!soruldumu[random])
            {
                soruSor(sorular[random], doğruCevaplar[random], new string[] { yanlışCevaplar[random], yanlışCevaplar2[random] });
                soruldumu[random] = true;
            }   
            soruGeçildimi = false;
            yield return new WaitUntil(() => soruGeçildimi == true);
        }
        sorularBitti();
    }
    public bool soruGeçildimi;

    public Text soruGösterge;

    public GameObject button1;
    public GameObject button2;
    Text button1Text;
    Text button2Text;
    public void soruSor(string soru, string doğruCevap, string[] yanlışCevaplar)
    {
        button1.GetComponent<Image>().color = new Color(255, 255, 255);
        button2.GetComponent<Image>().color = new Color(255, 255, 255);
        int doğruŞık = Random.Range(0, 2);
        int yanlışCevapNo = Random.Range(0, 2);
        string yanlışCevap = yanlışCevaplar[yanlışCevapNo];
        soruGösterge.text = soru;

        if (doğruŞık == 0)
        {
            button1Text.text = doğruCevap;
            button2Text.text = yanlışCevap;

            button1.name = "doğru";
            button2.name = "yanlış";
        }
        else
        {
            button1Text.text = yanlışCevap;
            button2Text.text = doğruCevap;

            button1.name = "yanlış";
            button2.name = "doğru";
        }
        şıkBasılabilirmi = true;
    }
    public int doğruSayısı, yanlışSayısı;
    public void şıkSeçildi()
    {
        if (şıkBasılabilirmi)
        {
            şıkBasılabilirmi = false;
            GameObject şık = EventSystem.current.currentSelectedGameObject;
            StartCoroutine(şıkSeçildiIe(şık));
        }
    }
    bool şıkBasılabilirmi;
    IEnumerator şıkSeçildiIe(GameObject şık)
    {
        if (şık.name == "doğru")
        {
            doğruSayısı++;
            şık.GetComponent<Image>().color = Color.green;
        }
        else
        {
            yanlışSayısı++;
            şık.GetComponent<Image>().color = Color.red;
        }
        yield return new WaitForSeconds(1.5f);
        soruGeçildimi = true;
    }

    public Text doğruSayısıGösterge, yanlışSayısıGösterge;
    public void sorularBitti()
    {
        başlangıçPanel.SetActive(false);
        sonPanel.SetActive(true);
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            doğruSayısıGösterge.text = "Doğru Sayısı: " + doğruSayısı;
            yanlışSayısıGösterge.text = "Yanlış Sayısı: " + yanlışSayısı;
        }
        else
        {
            doğruSayısıGösterge.text = "True Count: " + doğruSayısı;
            yanlışSayısıGösterge.text = "False Count: " + yanlışSayısı;
        }

        Text devamTekrarText = devamTekrar.transform.GetChild(0).GetComponent<Text>();
        if (yanlışSayısı > doğruSayısı)
        {
            if (PlayerPrefs.GetInt("dil") == 0)
            {
                devamTekrarText.text = "Tekrar Deneyin";
            }
            else
            {
                devamTekrarText.text = "Try Again";
            }
            devamTekrar.name = "Tekrar";
        }
        else
        {
            if (PlayerPrefs.GetInt("dil") == 0)
            {
                devamTekrarText.text = "Devam";
            }
            else
            {
                devamTekrarText.text = "Continue";
            }
            devamTekrar.name = "Devam";
        }
    }
    public void devamTekrarTıklandı()
    {
        if (devamTekrar.name == "Devam")
        {
            SceneManager.LoadScene("Son");
        }
        else if (devamTekrar.name == "Tekrar")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
