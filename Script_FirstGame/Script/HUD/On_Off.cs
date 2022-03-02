using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class On_Off : MonoBehaviour
{
    public bool Online;
    public GameObject Amigo;
    public GameObject Namorado;
    public GameObject Estranho;
    public Image on_off;
    public TextMeshProUGUI Texton_off;

    void Update()
    {
        if(GameController_Tempo.Hora >= 7 && GameController_Tempo.Hora <= 20)
        {
            Online = true;
            on_off.color = Color.green;
            Texton_off.text = "Online";
        }
        else
        {
            Online = false;
            on_off.color = Color.red;
            Texton_off.text = "Offline";
        }
    }
}
