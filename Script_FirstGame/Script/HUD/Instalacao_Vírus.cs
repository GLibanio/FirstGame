using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instalacao_Vírus : MonoBehaviour
{
    public static float TempoTotal = 100;

    public Image Barra_Progress;
    public GameObject Missao3;

    private void Start()
    {
        Barra_Progress.fillAmount = GameController_Tempo.TempoInstalacao / TempoTotal;
    }
    void Update()
    {
        Barra_Progress.fillAmount += GameController_Tempo.TempoInstalacao / TempoTotal;

        if (Barra_Progress.fillAmount == 1)
        {
            GameController_Tempo.missaoCumprida_part3 = true;
            GameController_Tempo.ComecouMissao3 = false;
        }

        if(GameController_Tempo.ComecouMissao3 == false)
        {
            Missao3.SetActive(false);
        }
        else
        {
            Missao3.SetActive(true);
            GameController_Tempo.TempoInstalacao += 0.001f * Time.deltaTime;
        }
    }
}
