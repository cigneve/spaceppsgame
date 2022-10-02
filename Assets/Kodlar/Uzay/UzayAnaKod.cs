using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UzayAnaKod : MonoBehaviour
{
    public int kalanKalp;
    public GameObject kalpPanel;
    public GameObject[] kalpler;

    public Sprite doluKalp;
    public Sprite bo�Kalp;

    public int kalanS�re;

    public Text ba�lang��BeklemeG�sterge;
    void Start()
    {
        kalanKalp = 3;
        kalanS�re = 3;
        for (int i = 0; i < kalpler.Length; i++)
        {
            kalpler[i].GetComponent<Image>().sprite = doluKalp;
        }
        ba�lang��BeklemeG�sterge.gameObject.SetActive(true);
        kalpPanel.SetActive(false);
        ba�lang��BeklemeG�sterge.text = kalanS�re.ToString();
        geriSay�mKalanS�re = 15;
        geriSay�mG�sterge.gameObject.SetActive(false);
        StartCoroutine(ba�lang��Bekleme());
    }
    public bool kalpGidebilirmi;
    public void kalpG�t�r()
    {
        if (kalpGidebilirmi)
        {
            kalpGidebilirmi = false;
            kalanKalp--;
            if (kalanKalp == 2)
            {
                kalpler[2].GetComponent<Image>().sprite = bo�Kalp;
                kalpler[1].GetComponent<Image>().sprite = doluKalp;
                kalpler[0].GetComponent<Image>().sprite = doluKalp;
            }
            else if (kalanKalp == 1)
            {
                kalpler[2].GetComponent<Image>().sprite = bo�Kalp;
                kalpler[1].GetComponent<Image>().sprite = bo�Kalp;
                kalpler[0].GetComponent<Image>().sprite = doluKalp;
            }
            else if (kalanKalp == 0)
            {
                kalpler[2].GetComponent<Image>().sprite = bo�Kalp;
                kalpler[1].GetComponent<Image>().sprite = bo�Kalp;
                kalpler[0].GetComponent<Image>().sprite = bo�Kalp;
                oyunDurum = false;
                oyunKaybedildi();
            }
            StartCoroutine(damageAnimasyon());
        }
    }
    public GameObject meteorPrefab;
    Meteor meteor;
    IEnumerator damageAnimasyon()
    {
        GameObject roket = GameObject.Find("Roket");
        for (int i = 0; i < 4; i++)
        {
            roket.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            roket.GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        kalpGidebilirmi = true;
    }
    IEnumerator meteorOlu�turmaBekleme()
    {
        if (oyunDurum)
        {
            meteorOlu�tur();
            yield return new WaitForSeconds(3f);
            StartCoroutine(meteorOlu�turmaBekleme());
        }
        else
        {
            foreach (GameObject klon in GameObject.FindGameObjectsWithTag("Meteor"))
                Destroy(klon);
        }
    }
    public void meteorOlu�tur()
    {
        for (int i = 0; i < 7; i++)
        {
            GameObject klon = Instantiate(meteorPrefab);
            meteor = klon.GetComponent<Meteor>();
            meteor.hareketH�z� = Random.Range(-50, -24);
            meteor.transform.position = new Vector2(70, Random.Range(-13, 19));
        }
    }
    public bool oyunDurum;
    IEnumerator ba�lang��Bekleme()
    {
        yield return new WaitForSeconds(1f);
        kalanS�re--;
        if (kalanS�re == 0)
        {
            if (PlayerPrefs.GetInt("dil") == 1)
            {
                ba�lang��BeklemeG�sterge.text = "Go!";
            }
            else
            {
                ba�lang��BeklemeG�sterge.text = "Ba�la!";
            }
            yield return new WaitForSeconds(1f);
            ba�lang��BeklemeG�sterge.gameObject.SetActive(false);
            kalpPanel.SetActive(true);
            oyunDurum = true;
            kalpGidebilirmi = true;
            geriSay�mG�sterge.gameObject.SetActive(true);
            StartCoroutine(meteorOlu�turmaBekleme());
            StartCoroutine(geriSay());
        }
        else
        {
            ba�lang��BeklemeG�sterge.text = kalanS�re.ToString();
            StartCoroutine(ba�lang��Bekleme());
        }
    }
    public Text geriSay�mG�sterge;
    public int geriSay�mKalanS�re;
    IEnumerator geriSay()
    {
        if (oyunDurum)
        {
            geriSay�mG�sterge.text = geriSay�mKalanS�re.ToString();
            yield return new WaitForSeconds(1f);
            geriSay�mKalanS�re--;
            if (geriSay�mKalanS�re == 0)
            {
                oyunBitti();
                oyunDurum = false;
            }
            else
            {
                StartCoroutine(geriSay());
            }
        }
        else
        {
            geriSay�mG�sterge.text = "";
        }
    }

    public GameObject tekrarOynaPanel;
    void oyunKaybedildi()
    {
        tekrarOynaPanel.SetActive(true);
    }
    public void tekrarBa�lat()
    {
        SceneManager.LoadScene("Uzay Gemisi S�rme");
    }
    void oyunBitti()
    {
        SceneManager.LoadScene("Ara Sahne");
    }
}