using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIÇeviri : MonoBehaviour
{
    public Text[] textler;
    public string[] türkçeler;
    public string[] ingilizceler;
    void Start()
    {
        if (PlayerPrefs.GetInt("dil") == 0)
        {
            for (int i = 0; i < türkçeler.Length; i++)
            {
                textler[i].text = türkçeler[i];
            }
        }
        else
        {
            for (int i = 0; i < türkçeler.Length; i++)
            {
                textler[i].text = ingilizceler[i];
            }
        }
    }
}
