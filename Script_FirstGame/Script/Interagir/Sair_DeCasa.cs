using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sair_DeCasa : MonoBehaviour
{
    public TextMeshProUGUI Aviso;
    public GameObject GO_aviso;
    public GameObject Final_Alternativo;

    public GameObject Horas;
    public Dia_Noite Sol_hora;
    public GameObject Text_Sair;
    public GameObject Cutscene;

    bool PodeSair = false;
    

    void Update()
    {
        if(GameController_Tempo.Hora == 9)
        {
            if (!IsInvoking("Avisado"))
            {
                Aviso.text = "Vou a faculdade!";
                GO_aviso.SetActive(true);
                Invoke("Avisado", 3f);
            }
           
            Horas.transform.Rotate(0, 0, +240);
            Sol_hora.gameObject.transform.Rotate(+120, 0, 0);
            Cutscene.SetActive(true);
            if (!IsInvoking("voltar"))
            {
                Invoke("voltar", 2);
            }
        }

        if (PodeSair)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameController_Tempo.Mes == 6 && GameController_Tempo.Dia == 10 && GameController_Tempo.Hora >= 14 && GameController_Tempo.missoesConcluidas >= 2)
                {
                    SceneManager.LoadScene(10);
                }
                Horas.transform.Rotate(0, 0, +240);
                Sol_hora.gameObject.transform.Rotate(+120, 0, 0);
                Cutscene.SetActive(true);
                Invoke("voltar", 2);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Final_Alternativo.SetActive(true);
            }
        }
    }

    void voltar()
    {
        Cutscene.GetComponent<Animator>().SetBool("Acordar", true);
        GameController_Tempo.Hora += 8;
        Invoke("Resete_Cuts", 5f);
    }

    void Resete_Cuts()
    {
        Cutscene.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameController_Tempo.Mes == 6 && GameController_Tempo.Dia == 10 && GameController_Tempo.Hora >= 14 && GameController_Tempo.missoesConcluidas >= 2)
        {
            if (other.gameObject.tag == "Player")
            {
                Text_Sair.GetComponentInChildren<TextMeshProUGUI>().text = "Ir encontrar o stalker no parque ('E')";
                Text_Sair.SetActive(true);
                PodeSair = true;
            }
        }
        else if (GameController_Tempo.Hora == 8)
        {
            if(GameController_Tempo.SemanaEmNum >= 1 && GameController_Tempo.SemanaEmNum <= 5)
            {
                if (other.gameObject.tag == "Player")
                {
                    Text_Sair.GetComponentInChildren<TextMeshProUGUI>().text = "Ir para faculdade ('E') Faltar na faculdade('F')";
                    Text_Sair.SetActive(true);
                    PodeSair = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "Player")
            {
                Text_Sair.SetActive(false);
                PodeSair = false;
            }
    }

    void Avisado()
    {
        GO_aviso.SetActive(false);
    }
}
