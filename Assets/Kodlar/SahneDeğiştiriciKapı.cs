using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneDeğiştiriciKapı : MonoBehaviour
{
    public string gidilecekSahne;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Amca") 
        {
            SceneManager.LoadScene(gidilecekSahne);
        }
    }
}
