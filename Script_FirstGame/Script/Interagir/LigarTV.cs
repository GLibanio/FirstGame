using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigarTV : MonoBehaviour
{
    public GameObject Instrucao;
    public GameObject CanalTv;
    bool ligar_TV;
    bool TV_Ligada;
    void Update()
    {
        if (ligar_TV)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!TV_Ligada)
                {
                    CanalTv.SetActive(true);
                    TV_Ligada = true;
                }
                else
                {
                    CanalTv.SetActive(false);
                    TV_Ligada = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ligar_TV = true;
            Instrucao.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ligar_TV = false;
            Instrucao.SetActive(false);
        }
    }
}
