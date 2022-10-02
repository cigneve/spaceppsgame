using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YıldızOluşturucu : MonoBehaviour
{
    public GameObject oluşturulacakYıldız;
    public GameObject oluşturulacakKaradelik;

    public int minYaşam;
    public int maxYaşam;

    public int minXSkala;
    public int maxXSkala;

    public int minYSkala;
    public int maxYSkala;

    public Sprite küçükYıldız;
    public Sprite büyükYıldız;

    public Vector2 yıldızScale;
    public Vector2 karadelikScale;
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            yıldızOluştur();
        }
        for (int i = 0; i < 1; i++)
        {
            karadelikOluştur();
        }
    }
    public void ölümVar()
    {
        yıldızOluştur();
    }
    void karadelikOluştur()
    {
        GameObject klon = Instantiate(oluşturulacakKaradelik);
        float x = Random.Range(minXSkala, maxXSkala + 1) / 10f;
        float y = Random.Range(minYSkala, maxYSkala + 1) / 10f;
        klon.transform.position = new Vector2(x, y);
        klon.transform.localScale = karadelikScale;
        klon.name = "Karadelik";
    }
    void yıldızOluştur()
    {
        int yıldızNo = Random.Range(0, 2);
        GameObject klon = Instantiate(oluşturulacakYıldız);
        float x = Random.Range(minXSkala, maxXSkala + 1) / 10f;
        float y = Random.Range(minYSkala, maxYSkala + 1) / 10f;
        klon.transform.position = new Vector2(x, y);
        int yaşam = Random.Range(minYaşam, maxYaşam + 1);
        OluşturulmuşYıldız oy = klon.GetComponent<OluşturulmuşYıldız>();
        oy.yaşamSüresi = yaşam;
        klon.transform.localScale = yıldızScale;
        if (yıldızNo == 0)
        {
            klon.GetComponent<SpriteRenderer>().sprite = küçükYıldız;
        }
        else
        {
            klon.GetComponent<SpriteRenderer>().sprite = büyükYıldız;
        }
    }
}