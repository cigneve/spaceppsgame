using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SoruSorma : MonoBehaviour
{
    public GameObject ilkPanel, ba�lang��Panel, sonPanel;

    public string[] sorular;
    public string[] sorular�ngilizce;
    public string[] do�ruCevaplar;
    public string[] do�ruCevaplar�ngilizce;
    public string[] yanl��Cevaplar;
    public string[] yanl��Cevaplar�ngilizce;
    public string[] yanl��Cevaplar2;
    public string[] yanl��Cevaplar2�ngilizce;
    public bool[] soruldumu;

    public GameObject devamTekrar;

    public Text ilkAnimYaz�;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 1)
        {
            sorular = sorular�ngilizce;
            do�ruCevaplar = do�ruCevaplar�ngilizce;
            yanl��Cevaplar = yanl��Cevaplar�ngilizce;
            yanl��Cevaplar2 = yanl��Cevaplar2�ngilizce;
        }

        ilkPanel.SetActive(true);
        ba�lang��Panel.SetActive(false);
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
            ilkAnimYaz�.resizeTextMaxSize = i;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1f);
        ilkPanel.SetActive(false);
        ba�lang��Panel.SetActive(true);
        sonPanel.SetActive(false);
        StartCoroutine(soruD�ng�());
    }
    IEnumerator soruD�ng�()
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
                soruSor(sorular[random], do�ruCevaplar[random], new string[] { yanl��Cevaplar[random], yanl��Cevaplar2[random] });
                soruldumu[random] = true;
            }   
            soruGe�ildimi = false;
            yield return new WaitUntil(() => soruGe�ildimi == true);
        }
        sorularBitti();
    }
    public bool soruGe�ildimi;

    public Text soruG�sterge;

    public GameObject button1;
    public GameObject button2;
    Text button1Text;
    Text button2Text;
    public void soruSor(string soru, string do�ruCevap, string[] yanl��Cevaplar)
    {
        button1.GetComponent<Image>().color = new Color(255, 255, 255);
        button2.GetComponent<Image>().color = new Color(255, 255, 255);
        int do�ru��k = Random.Range(0, 2);
        int yanl��CevapNo = Random.Range(0, 2);
        string yanl��Cevap = yanl��Cevaplar[yanl��CevapNo];
        soruG�sterge.text = soru;

        if (do�ru��k == 0)
        {
            button1Text.text = do�ruCevap;
            button2Text.text = yanl��Cevap;

            button1.name = "do�ru";
            button2.name = "yanl��";
        }
        else
        {
            button1Text.text = yanl��Cevap;
            button2Text.text = do�ruCevap;

            button1.name = "yanl��";
            button2.name = "do�ru";
        }
        ��kBas�labilirmi = true;
    }
    public int do�ruSay�s�, yanl��Say�s�;
    public void ��kSe�ildi()
    {
        if (��kBas�labilirmi)
        {
            ��kBas�labilirmi = false;
            GameObject ��k = EventSystem.current.currentSelectedGameObject;
            StartCoroutine(��kSe�ildiIe(��k));
        }
    }
    bool ��kBas�labilirmi;
    IEnumerator ��kSe�ildiIe(GameObject ��k)
    {
        if (��k.name == "do�ru")
        {
            do�ruSay�s�++;
            ��k.GetComponent<Image>().color = Color.green;
        }
        else
        {
            yanl��Say�s�++;
            ��k.GetComponent<Image>().color = Color.red;
        }
        yield return new WaitForSeconds(1.5f);
        soruGe�ildimi = true;
    }

    public Text do�ruSay�s�G�sterge, yanl��Say�s�G�sterge;
    public void sorularBitti()
    {
        ba�lang��Panel.SetActive(false);
        sonPanel.SetActive(true);
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            do�ruSay�s�G�sterge.text = "Do�ru Say�s�: " + do�ruSay�s�;
            yanl��Say�s�G�sterge.text = "Yanl�� Say�s�: " + yanl��Say�s�;
        }
        else
        {
            do�ruSay�s�G�sterge.text = "True Count: " + do�ruSay�s�;
            yanl��Say�s�G�sterge.text = "False Count: " + yanl��Say�s�;
        }

        Text devamTekrarText = devamTekrar.transform.GetChild(0).GetComponent<Text>();
        if (yanl��Say�s� > do�ruSay�s�)
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
    public void devamTekrarT�kland�()
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
