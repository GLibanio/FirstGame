using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Acender_Apagar : MonoBehaviour
{
    public TextMeshProUGUI Texto;
    public GameObject[] Luzes;
    public bool ApagarLuz;
    public bool LuzesApagada;

    private void Start()
    {
        LuzesApagada = true;
    }
    void Update()
    {
        if (ApagarLuz == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (LuzesApagada == false)
                {
                    LuzesApagada = true;
                }
                else
                {
                    LuzesApagada = false;
                }
                for (int i = 0; i < Luzes.Length; i++)
                {
                    Luzes[i].GetComponent<Light>().gameObject.SetActive(LuzesApagada);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ApagarLuz = true;
            Texto.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ApagarLuz = false;
            Texto.gameObject.SetActive(false);
        }
    }
}
