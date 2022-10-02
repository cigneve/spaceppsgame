using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed;
   
    void Start()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 takip = new Vector3(mousePosition.x - 2, mousePosition.y, mousePosition.z);
        transform.position = Vector2.Lerp(transform.position, takip, moveSpeed);
    }
    void Update()
    {
        if (GameObject.Find("Uzay Ana Obje").GetComponent<UzayAnaKod>().oyunDurum)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 takip = new Vector3(mousePosition.x - 2, mousePosition.y, mousePosition.z);
            transform.position = Vector2.Lerp(transform.position, takip, moveSpeed);
        }
    }
}
