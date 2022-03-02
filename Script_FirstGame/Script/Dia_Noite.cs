using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dia_Noite : MonoBehaviour
{
    public static EntrarNoComputador PC;
    public TextMeshProUGUI HR;
    public TextMeshProUGUI Minutos_Unidade;
    public TextMeshProUGUI Minutos_Dezena;
    public TextMeshProUGUI Dia;
    public TextMeshProUGUI Meses;
    public TextMeshProUGUI Anos;
    public TextMeshProUGUI Semana;
    public GameObject Horas;
    public GameObject Min;

    public bool Sono_Leve;
    public bool Sono_Pesado;

    public float Intensidade;
    private float Inclinação;
    public bool EstaDeNoite;


    public float Sec;

    private void Start()
    {
        for (int i = 0; i < GameController_Tempo.Hora; i++)
        {
            Horas.transform.Rotate(0, 0, +30);
        }
        for (int i = 0; i < GameController_Tempo.Minuto_Uni; i++)
        {
            Horas.transform.Rotate(0, 0, +1);
        }
        for (int i = 0; i < GameController_Tempo.Minuto_Deze; i++)
        {
            Horas.transform.Rotate(0, 0, +5);
        }
        for (int i = 0; i < GameController_Tempo.Minuto_Uni; i++)
        {
            Min.transform.Rotate(0, 0, +5);
        }
        for (int i = 0; i < GameController_Tempo.Minuto_Deze; i++)
        {
            Min.transform.Rotate(0, 0, +60);
        }
    }
    void Update()
    {
        Semana.text = GameController_Tempo.Semana;
        HR.text = GameController_Tempo.Hora.ToString();
        Minutos_Unidade.text = GameController_Tempo.Minuto_Uni.ToString();
        Minutos_Dezena.text = GameController_Tempo.Minuto_Deze.ToString();
        Anos.text = GameController_Tempo.Ano.ToString();
        Meses.text = GameController_Tempo.Mes.ToString();
        Dia.text = GameController_Tempo.Dia.ToString();

        if (!Pause.pausado)
        {
            Sec += 1 * 365 / 6 * Time.unscaledDeltaTime;
        }

        if (Sono_Leve)
        {
            for (int i = 0; i < 2; i++)
            {
                GameController_Tempo.Hora += 1;
                if(GameController_Tempo.Hora == 24)
                {
                    GameController_Tempo.Hora = 0;
                    GameController_Tempo.Dia += 1;
                }
                Debug.Log(GameController_Tempo.Hora);
            }
            Sono_Leve = false;
            Debug.Log(GameController_Tempo.Hora);
        }
        if (Sono_Pesado)
        {
            GameController_Tempo.Hora = 7;
            if (GameController_Tempo.Dia == 25 && GameController_Tempo.Mes == 2)
            {
                Resetar();
                GameController_Tempo.Semana = "Seg";
                GameController_Tempo.Dia = 26;
                GameController_Tempo.Mes = 3;
            }
            else if (GameController_Tempo.Dia == 26 && GameController_Tempo.Mes == 3)
            {
                Resetar();
                GameController_Tempo.Semana = "Qua";
                GameController_Tempo.Dia = 15;
                GameController_Tempo.Mes = 4;
            }
            else if (GameController_Tempo.Dia == 15 && GameController_Tempo.Mes == 4)
            {
                ChecarMissoes();
                Resetar();
                GameController_Tempo.Semana = "Ter";
                GameController_Tempo.Dia = 10;
                GameController_Tempo.Mes = 6;
            }

            Sono_Pesado = false;
        }

        if (Sec >= 60)
        {
            GameController_Tempo.Minuto_Uni += 1;
            Sec = 0;
        }
        if (GameController_Tempo.Minuto_Uni >= 10)
        {
            GameController_Tempo.Minuto_Uni = 0;
            GameController_Tempo.Minuto_Deze += 1;
        }
        if (GameController_Tempo.Minuto_Deze >= 6)
        {
            GameController_Tempo.Minuto_Deze = 0;
            GameController_Tempo.Minuto_Uni = 0;
            GameController_Tempo.Hora += 1;
        }
        if (GameController_Tempo.Hora == 24)
        {
            GameController_Tempo.Hora = 0;
            GameController_Tempo.Dia += 1;
            if(GameController_Tempo.Semana == "Sex")
            {
                GameController_Tempo.SemanaEmNum = 6;
                GameController_Tempo.Semana = "Sab";
            }
            else if (GameController_Tempo.Semana == "Sab")
            {
                GameController_Tempo.SemanaEmNum = 7;
                GameController_Tempo.Semana = "Dom";
            }
            else if (GameController_Tempo.Semana == "Dom")
            {
                GameController_Tempo.SemanaEmNum = 1;
                GameController_Tempo.Semana = "Seg";
            }
            else if (GameController_Tempo.Semana == "Seg")
            {
                GameController_Tempo.SemanaEmNum = 2;
                GameController_Tempo.Semana = "Ter";
            }
            else if (GameController_Tempo.Semana == "Ter")
            {
                GameController_Tempo.SemanaEmNum = 3;
                GameController_Tempo.Semana = "Qua";
            }
            else if (GameController_Tempo.Semana == "Qua")
            {
                GameController_Tempo.SemanaEmNum = 4;
                GameController_Tempo.Semana = "Qui";
            }
            else if (GameController_Tempo.Semana == "Qui")
            {
                GameController_Tempo.SemanaEmNum = 5;
                GameController_Tempo.Semana = "Sex";
            }
        }

        if (GameController_Tempo.Mes == 1 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 2 && GameController_Tempo.Dia > 28)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 3 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 4 && GameController_Tempo.Dia > 30)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 5 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 6 && GameController_Tempo.Dia > 30)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 7 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 8 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 9 && GameController_Tempo.Dia > 30)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 10 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 11 && GameController_Tempo.Dia > 30)
        {
            GameController_Tempo.Mes += 1;
            GameController_Tempo.Dia = 0;
        }
        if (GameController_Tempo.Mes == 12 && GameController_Tempo.Dia > 31)
        {
            GameController_Tempo.Mes = 1;
            GameController_Tempo.Dia = 0;
        }

        gameObject.transform.Rotate(Intensidade * 64 / 6 * Time.deltaTime, 0, 0);
        Horas.transform.Rotate(0, 0, Intensidade * 64 / 6 * Time.deltaTime);
        Min.transform.Rotate(0, 0, Intensidade * 730 / 6 * Time.deltaTime);

        Inclinação = gameObject.transform.eulerAngles.x;

        if(Inclinação >= 180)
        {
            EstaDeNoite = true;
        }
        else
        {
            EstaDeNoite = false;
        }
    }

    void Resetar()
    {
        GameController_Tempo.ChegaDeWhats = false;
        GameController_Tempo.AvisadoAmiga = false;
        GameController_Tempo.AvisadoAmigo = false;
        GameController_Tempo.AvisadoStalker = false;
        GameController_Tempo.AvisadoNamo = false;
    }

    void ChecarMissoes()
    {
        if (GameController_Tempo.missaoCumprida == true)
        {
            GameController_Tempo.missoesConcluidas = 0;
            GameController_Tempo.missoesConcluidas += 1;
            GameController_Tempo.missaoCumprida = false;
        }
        if (GameController_Tempo.missaoCumprida_part2 == true)
        {
            GameController_Tempo.missoesConcluidas += 1;
            GameController_Tempo.missaoCumprida_part2 = false;
        }
        if (GameController_Tempo.missaoCumprida_part3 == true)
        {
            GameController_Tempo.missoesConcluidas += 1;
            GameController_Tempo.missaoCumprida_part3 = false;
        }
        Debug.Log(GameController_Tempo.missoesConcluidas);
    }
}
