using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fechar_App : MonoBehaviour
{
    void Update()
    {
        if (GameController_Tempo.Hora == 22)
        {
            SceneManager.LoadScene(1);
        }

        if(GameController_Tempo.Hora == 8)
        {
            SceneManager.LoadScene(1);
        }
    }
}
