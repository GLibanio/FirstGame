using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Particula : MonoBehaviour
{
    public GameObject Hud;
    public GameObject Particula;

    bool Aberto;
    bool Clicar;
    
    void Update()
    {
        if (Clicar) 
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!Aberto)
                {
                    Particula.SetActive(true);
                    Aberto = true;
                }
                else
                {
                    Particula.SetActive(false);
                    Aberto = false;
                }
            } 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hud.SetActive(true);
        Clicar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Hud.SetActive(false);
        Clicar = false;
    }
}
