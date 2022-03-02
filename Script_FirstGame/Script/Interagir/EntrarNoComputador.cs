using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class EntrarNoComputador : MonoBehaviour
{
    public TextMeshProUGUI Avisos;
    public GameObject Aviso;
    public TextMeshProUGUI Texto;
    public Camera Cam_Principal;
    public Camera Cam_Cutscene;
    public PlayableDirector Cutscene;
    public static bool Dentro_Pc = false;
    bool Mexer_Comp;
    public static bool avisado;
    public GameObject hud;

    private void Update()
    {
        if(GameController_Tempo.Hora == 22 && avisado == false)
        {
            Avisos.text = "Preciso ir dormir.";
            avisado = true;
            Dentro_Pc = false;
            hud.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Aviso.SetActive(true);
            Invoke("desativar", 2f);
        }
        else if(GameController_Tempo.Hora == 23)
        {
            avisado = false;
        }
        if(GameController_Tempo.Hora == 8 && avisado == false)
        {
            if(GameController_Tempo.SemanaEmNum >= 1 && GameController_Tempo.SemanaEmNum <= 5)
            {
                Avisos.text = "Preciso ir para a faculdade.";
                avisado = true;
                Dentro_Pc = false;
                hud.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Aviso.SetActive(true);
                Invoke("desativar", 2f);
            }
        }
        else if (GameController_Tempo.Hora >= 9)
        {
            avisado = false;
        }

        if (Dentro_Pc)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            hud.SetActive(true);
            Cam_Cutscene.enabled = false;
            Cam_Principal.enabled = true;
        }

        if (Mexer_Comp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameController_Tempo.Hora >= 22 || GameController_Tempo.Hora == 0)
                {
                    Avisos.text = "Preciso ir dormir.";
                    Aviso.SetActive(true);
                    Invoke("desativar", 2f);
                }
                else if(GameController_Tempo.Hora == 8)
                {
                    Avisos.text = "Não posso ficar faltando na faculdade.";
                    Aviso.SetActive(true);
                    Invoke("desativar", 2f);
                }
                else
                {
                    Cam_Cutscene.enabled = true;
                    Cam_Principal.enabled = false;
                    Cutscene.Play();
                    Invoke("LigarPc", 3.3f);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Texto.gameObject.SetActive(true);
            Mexer_Comp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Texto.gameObject.SetActive(false);
            Mexer_Comp = false;
        }
    }

    void desativar()
    {
        Aviso.SetActive(false);
    }

    public void LigarPc()
    {
        Dentro_Pc = true;
    }
    public void DesligarComp()
    {
        Dentro_Pc = false;
        hud.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
