using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class Dormir : MonoBehaviour
{
    public GameObject FezMissao;
    public GameObject FezMissao_Part2;
    public GameObject FezMissao_Part3;
    public GameObject NaoFezMissao;
    public List<GameObject> Final;
    public GameObject Horas;
    public GameObject dormir;
    public PlayableDirector Cutscene_Play;
    public Camera Main_Cam;
    public Camera Cuts_Sleep;
    public Dia_Noite hora;
    public GameObject texto;
    public TextMeshProUGUI Aviso;
    public GameObject GO_aviso;

    public bool AvisadoMS1;
    public bool AvisadoMS2;
    public bool AvisadoMS3;
    bool Deitar;

    void Update()
    {
        if(GameController_Tempo.Perdeu == true)
        {
            Final[1].SetActive(true);
        }

        if (GameController_Tempo.Hora == 0)
        {
            Aviso.text = "Melhor dormir";
            GO_aviso.SetActive(true);
            GameController_Tempo.Hora = 0;
            GameController_Tempo.Minuto_Uni = 0;
        }
        if (Deitar)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(GameController_Tempo.Hora <= 9)
                {
                    Aviso.text = "Daqui a pouco, preciso ir na faculdade.";
                    GO_aviso.SetActive(true);
                    Invoke("Avisado", 4f);
                }
                else if (GameController_Tempo.Hora < 22 && GameController_Tempo.Hora > 9)
                {
                    Horas.transform.Rotate(0, 0, +60);
                    Main_Cam.enabled = false;
                    Cuts_Sleep.enabled = true;
                    Cutscene_Play.Play();
                    dormir.SetActive(true);
                    hora.Sono_Leve = true;
                    hora.gameObject.transform.Rotate(+20, 0, 0);
                    Invoke("Acordar", 2);
                }
                else
                {
                    Aviso.text = "Melhor dormir por mais tempo.";
                    GO_aviso.SetActive(true);
                    Invoke("Avisado", 4f);
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (GameController_Tempo.Hora < 22 && GameController_Tempo.Hora != 0)
                {
                    Aviso.text = "Muito cedo para dormir.";
                    GO_aviso.SetActive(true);
                    Invoke("Avisado", 4f);
                }
                else
                {
                    Horas.transform.Rotate(0, 0, +240);
                    Main_Cam.enabled = false;
                    Cuts_Sleep.enabled = true;
                    Cutscene_Play.Play();
                    dormir.SetActive(true);
                    hora.gameObject.transform.Rotate(+180, 0, 0);
                    hora.Sono_Pesado = true;
                    Invoke("Acordar", 2);
                }
            }
        }
        else
        {
            Main_Cam.enabled = true;
            Cuts_Sleep.enabled = false;
        }
    }
    void Avisado()
    {
        GO_aviso.SetActive(false);
    }

    void Acordar()
    {
        dormir.GetComponent<Animator>().SetBool("Acordar", true);
        hora.Sono_Pesado = false;
        hora.Sono_Leve = false;
        Invoke("MudarCam", 5f);
    }

    void MudarCam()
    {
        dormir.SetActive(false);
        dormir.GetComponent<Animator>().SetBool("Acordar", false);
        Main_Cam.enabled = true;
        Cuts_Sleep.enabled = false;
        if (GameController_Tempo.missaoCumprida == true && GameController_Tempo.Dia == 26 && GameController_Tempo.Mes == 3 && AvisadoMS1 == false)
        {
            FezMissao.SetActive(true);
            AvisadoMS1 = true;
        }
        else if (GameController_Tempo.missaoCumprida == false && GameController_Tempo.Dia == 26 && GameController_Tempo.Mes == 3 && AvisadoMS1 == false)
        {
            NaoFezMissao.SetActive(true);
            AvisadoMS1 = true;
        }

        if (GameController_Tempo.missaoCumprida_part2 == true && GameController_Tempo.Dia == 15 && GameController_Tempo.Mes == 4 && AvisadoMS2 == false)
        {
            FezMissao_Part2.SetActive(true);
            AvisadoMS2 = true;
        }
        else if (GameController_Tempo.missaoCumprida_part2 == false && GameController_Tempo.Dia == 15 && GameController_Tempo.Mes == 4 && AvisadoMS2 == false)
        {
            NaoFezMissao.SetActive(true);
            AvisadoMS2 = true;
        }
        if (GameController_Tempo.missaoCumprida_part3 == true && GameController_Tempo.Dia == 5 && GameController_Tempo.Mes == 5 && AvisadoMS3 == false)
        {
            FezMissao_Part3.SetActive(true);
            AvisadoMS3 = true;
        }
        else if (GameController_Tempo.missaoCumprida_part3 == false && GameController_Tempo.Dia == 5 && GameController_Tempo.Mes == 5 && AvisadoMS3 == false)
        {
            NaoFezMissao.SetActive(true);
            AvisadoMS3 = true;
        }
        if (GameController_Tempo.LigouParaPolicia)
        {
            Final[0].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Deitar = true;
            texto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Deitar = false;
            texto.SetActive(false);
        }
    }
}
