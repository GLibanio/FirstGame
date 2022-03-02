using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController_Tempo
{
    public static bool OpcaoDisponivel = false;
    public static bool ChegaDeWhats = false;

    public static bool Perdeu = false;
    public static bool AceitouMissao3 = false;
    public static bool ComecouMissao3 = false;

    public static bool AvisadoAmiga = false;
    public static bool AvisadoAmigo = false;
    public static bool AvisadoNamo = false;
    public static bool AvisadoStalker = false;

    public static int missoesConcluidas = 0;

    public static bool missaoCumprida = false;
    public static bool missaoCumprida_part2 = false;
    public static bool missaoCumprida_part3 = false;

    public static bool LigouParaPolicia = false;
    public static bool ConheceStalker = false;

    public static int Mes = 2;
    public static int Dia = 25;
    public static int Ano = 2021;

    public static string Semana = "Sex";
    public static int SemanaEmNum = 5;

    public static float Minuto_Uni;
    public static float Minuto_Deze;
    public static float Hora = 7;

    public static float TempoInstalacao = 0;
}
