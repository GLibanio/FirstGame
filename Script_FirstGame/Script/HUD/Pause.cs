using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject TelaPause;
    public static bool pausado;
    void Start()
    {
        TelaPause.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Player.LeuHistoria)
            {
                if (!pausado)
                {
                    pausado = true;
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    Time.timeScale = 0;
                    TelaPause.SetActive(true);
                }
                else
                {
                    pausado = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Time.timeScale = 1;
                    TelaPause.SetActive(false);
                }
            }
        }
    }
}
