using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Buttons_Whts : MonoBehaviour
{
    public GameObject Escolha_FotoPerfil;
    public List<GameObject> Lista_FotoPerfil;
    public List<GameObject> Lista_FotoPerfilInfo;

    public TextMeshProUGUI Nome_jogador;
    public TextMeshProUGUI Nome_Sobrejogador;
    public TextMeshProUGUI Descricao_Sobrejogador;
    public TextMeshProUGUI InputField_Nome;
    public TextMeshProUGUI InputField_SobrePlayer;
    public GameObject inserir_nome;
    public GameObject inserir_Descricao;
 
    public string Name;
    public string Sobre;

    bool Escolhadefoto_Ativado;
    bool RespostaAmiga_Ativado;
    bool RespostaEstranho_Ativado;
    bool RespostaAmigo_Ativado;
    bool RespostaAldair_Ativado;

    bool SobreAmiga_Ativado;
    bool SobreAmigo_Ativado;
    bool SobreEstranho_Ativado;
    bool SobreAldair_Ativado;
    bool SobreJogador_Ativado = true;

    public List<GameObject> Conversas;

    public GameObject RespostasAmiga;
    public GameObject RespostasEstranho;
    public GameObject RespostasAmigo;
    public GameObject RespostasAldair;

    public GameObject SobreAmiga;
    public GameObject SobreAmigo;
    public GameObject SobreEstranho;
    public GameObject SobreAldair;
    public GameObject SobreJogador;

    public GameObject Button_Amiga;
    public GameObject Button_Amigo;
    public GameObject Button_Aldair;
    public GameObject Button_Estranho; 

    public void FecharJogo()
    {
        SceneManager.LoadScene(1);
    }
    public void Resposta_Amigo()
    {
        if (!RespostaAmigo_Ativado)
        {
            RespostaAmigo_Ativado = true;
            RespostasAmigo.SetActive(true);
            Button_Amigo.SetActive(false);
        }
        else
        {
            RespostaAmigo_Ativado = false;
            RespostasAmigo.SetActive(false);
            Button_Amigo.SetActive(true);
        }
    }

    public void Resposta_aldair()
    {
        if (!RespostaAldair_Ativado)
        {
            RespostaAldair_Ativado = true;
            RespostasAldair.SetActive(true);
            Button_Aldair.SetActive(false);
        }
        else
        {
            RespostaAldair_Ativado = false;
            RespostasAldair.SetActive(false);
            Button_Aldair.SetActive(true);
        }
    }
    public void Resposta_Amiga()
    {
        if (!RespostaAmiga_Ativado)
        {
            RespostaAmiga_Ativado = true;
            RespostasAmiga.SetActive(true);
            Button_Amiga.SetActive(false);
        }
        else
        {
            RespostaAmiga_Ativado = false;
            RespostasAmiga.SetActive(false);
            Button_Amiga.SetActive(true);
        }
    }

    public void Resposta_Estranho()
    {
        if (!RespostaEstranho_Ativado)
        {
            RespostaEstranho_Ativado = true;
            RespostasEstranho.SetActive(true);
            Button_Estranho.SetActive(false);
        }
        else
        {
            RespostaEstranho_Ativado = false;
            RespostasEstranho.SetActive(false);
            Button_Estranho.SetActive(true);
        }
    }

    public void Sobre_Amiga()
    {
        if (!SobreAmiga_Ativado)
        {
            SobreAmiga_Ativado = true;
            SobreAmiga.SetActive(true);
        }
        else
        {
            SobreAmiga_Ativado = false;
            SobreAmiga.SetActive(false);
        }
    }

    public void Sobre_Amigo()
    {
        if (!SobreAmigo_Ativado)
        {
            SobreAmigo_Ativado = true;
            SobreAmigo.SetActive(true);
        }
        else
        {
            SobreAmigo_Ativado = false;
            SobreAmigo.SetActive(false);
        }
    }

    public void Sobre_Estranho()
    {
        if (!SobreEstranho_Ativado)
        {
            SobreEstranho_Ativado = true;
            SobreEstranho.SetActive(true);
        }
        else
        {
            SobreEstranho_Ativado = false;
            SobreEstranho.SetActive(false);
        }
    }

    public void Sobre_Aldair()
    {
        if (!SobreAldair_Ativado)
        {
            SobreAldair_Ativado = true;
            SobreAldair.SetActive(true);
        }
        else
        {
            SobreAldair_Ativado = false;
            SobreAldair.SetActive(false);
        }
    }

    public void Sobre_Jogador()
    {
        if (!SobreJogador_Ativado)
        {
            SobreJogador_Ativado = true;
            SobreJogador.SetActive(true);
        }
        else
        {
            SobreJogador_Ativado = false;
            SobreJogador.SetActive(false);
        }
    }

    public void Conversas_Escolhida(int ConversaIndex)
    {
        for (int i = 0; i < Conversas.Count; i++)
        {
            Conversas[i].SetActive(false);
        }
        Conversas[ConversaIndex].SetActive(true);
    }

    public void Renomear()
    {
        inserir_nome.SetActive(true);
    }

    public void Confirmar_Nome()
    {
        inserir_nome.SetActive(false);
        Name = InputField_Nome.text.ToString();
        Nome_jogador.text = Name;
        Nome_Sobrejogador.text = Name;
    }

    public void Escrever_SobreJogador()
    {
        inserir_Descricao.SetActive(true);
    }

    public void Confirmar_SobreJogador()
    {
        inserir_Descricao.SetActive(false);
        Sobre = InputField_SobrePlayer.text.ToString();
        Descricao_Sobrejogador.text = Sobre;
    }

    public void Troca_Perfil()
    {
        if (!Escolhadefoto_Ativado)
        {
            Escolhadefoto_Ativado = true;
            Escolha_FotoPerfil.SetActive(true);
        }
        else
        {
            Escolhadefoto_Ativado = false;
            Escolha_FotoPerfil.SetActive(false);
        }
    }

    public void perfil1(int i)
    {
        for (int z = 0; z <= 6; z++)
        {
            Lista_FotoPerfil[z].SetActive(false);
            Lista_FotoPerfilInfo[z].SetActive(false);
            Lista_FotoPerfil[i].SetActive(true);
            Lista_FotoPerfilInfo[i].SetActive(true);
        }  
    }
}
