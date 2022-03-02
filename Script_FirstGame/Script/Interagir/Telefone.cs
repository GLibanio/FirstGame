using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telefone : MonoBehaviour
{
    public GameObject Final_Presos;
    public GameObject Text;
    public List<GameObject> ConversaPolicia;
    bool podeLigar;
    void Update()
    {
        if (ConversaPolicia[0].activeInHierarchy)
        {
            Invoke("proximaConversa", 3f);
        }
        if (ConversaPolicia[1].activeInHierarchy)
        {
            Invoke("proximaConversa2", 3f);
        }
        if (ConversaPolicia[2].activeInHierarchy)
        {
            Invoke("proximaConversa3", 3f);
        }
        if (ConversaPolicia[3].activeInHierarchy)
        {
            ConversaPolicia[3].SetActive(false);
        }

        if (podeLigar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(GameController_Tempo.Mes == 6 && GameController_Tempo.Dia == 10 && GameController_Tempo.Hora >= 14 && GameController_Tempo.missoesConcluidas >= 2)
                {
                    Final_Presos.SetActive(true);
                }
                else
                {
                    ConversaPolicia[0].SetActive(true);
                    GameController_Tempo.LigouParaPolicia = true;
                }
            }
        }
    }
    void proximaConversa()
    {
        ConversaPolicia[0].SetActive(false);
        ConversaPolicia[1].SetActive(true);
    }

    void proximaConversa2()
    {
        ConversaPolicia[1].SetActive(false);
        ConversaPolicia[2].SetActive(true);
    }
    void proximaConversa3()
    {
        ConversaPolicia[2].SetActive(false);
        ConversaPolicia[3].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (GameController_Tempo.ConheceStalker)
            {
                Text.SetActive(true);
                podeLigar = true;
            } 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            podeLigar = false;
            Text.SetActive(false);
        }
    }
}
