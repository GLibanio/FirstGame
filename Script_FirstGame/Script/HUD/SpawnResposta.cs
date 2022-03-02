using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SpawnResposta : MonoBehaviour
{
    GameObject ConversasPassada;
    GameObject RespostasPassada;

    public GameObject SobreJogador;

    public GameObject EnviarResposta;
    public GameObject OpcaoDeResposta;

    public GameObject Foto;
    public GameObject PrintConversa;
    public GameObject Stalker;
    public On_Off StatusOnline;
    public GameObject Aviso_Decisao;
    public Transform Recebido_Transform;
    public GameObject MSN_Enviado;
    public GameObject MSN_Recebido;
    public Image Mensagem_Enviada;
    public Image Mensagem_Recebida;
    public TextMeshProUGUI TextoEscolha1;
    public TextMeshProUGUI TextoEscolha2;
    public TextMeshProUGUI TextoEscolha3;

    public List<int> MudancaDaHistoria;

    public List<int> MudancaDePersonagem;
    public List<int> QualPersonagem;
    public List<GameObject> ProxPersonagem;
    public GameObject PersonagemSelecionado;

    int Escolha;
    int Numero_Escolha;
    public int opcao = 1;

    public List<string> Resposta1_escolha1_MissaoFeita;
    public List<string> Resposta2_escolha2_MissaoFeita;
    public List<string> Resposta3_escolha3_MissaoFeita;
    public List<string> Resposta1_escolha1;
    public List<string> Resposta2_escolha2;
    public List<string> Resposta3_escolha3;
    public List<string> Option1_Resposta1;
    public List<string> Option1_Resposta2;
    public List<string> Option1_Resposta3;
    public List<string> Option2_Resposta1;
    public List<string> Option2_Resposta2;
    public List<string> Option2_Resposta3;
    public List<string> Option3_Resposta1;
    public List<string> Option3_Resposta2;
    public List<string> Option3_Resposta3;
    public List<string> Option1_Resposta1_MissaoFeita;
    public List<string> Option1_Resposta2_MissaoFeita;
    public List<string> Option1_Resposta3_MissaoFeita;
    public List<string> Option2_Resposta1_MissaoFeita;
    public List<string> Option2_Resposta2_MissaoFeita;
    public List<string> Option2_Resposta3_MissaoFeita;
    public List<string> Option3_Resposta1_MissaoFeita;
    public List<string> Option3_Resposta2_MissaoFeita;
    public List<string> Option3_Resposta3_MissaoFeita;

    private void Start()
    {
        TextoEscolha1.text = Option1_Resposta1[0];
        TextoEscolha2.text = Option1_Resposta2[0];
        TextoEscolha3.text = Option1_Resposta3[0];
    }
    private void Update()
    {
        if (IsInvoking("MudePersonagem"))
        {
            EnviarResposta.SetActive(true);
            OpcaoDeResposta.SetActive(false);
        }
        ConversasPassada = GameObject.FindGameObjectWithTag("Conversa");
        RespostasPassada = GameObject.FindGameObjectWithTag("Resposta");

        if (GameController_Tempo.Mes == 4 && GameController_Tempo.Dia == 15 && GameController_Tempo.AvisadoStalker == false)
        {
            PersonagemSelecionado.SetActive(false);
            Stalker.SetActive(true);
        }

        if (GameController_Tempo.Mes == 6 && GameController_Tempo.Dia == 10 && GameController_Tempo.missoesConcluidas >= 2)
        {
            PersonagemSelecionado.SetActive(false);
            Stalker.SetActive(true);
            ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Estarei na praça as 14 horas para você me conhecer";
            GameController_Tempo.Perdeu = false;
            GameController_Tempo.OpcaoDisponivel = true;
            Invoke("FecharPC", 5f);
        }
        else if(GameController_Tempo.Mes == 6 && GameController_Tempo.Dia == 10 && GameController_Tempo.missoesConcluidas < 2)
        {
            PersonagemSelecionado.SetActive(false);
            Stalker.SetActive(true);
            ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Você não nos ajudou, agora você e a proxima!";
            GameController_Tempo.Perdeu = true;
            Invoke("FecharPC", 5f);
        }

        if (this.gameObject.CompareTag("Stalker"))
        {
            GameController_Tempo.ConheceStalker = true;

            if (opcao == 1 && Numero_Escolha == 10)
            {
                GameController_Tempo.AceitouMissao3 = true;
            }
            if (opcao == 2 && Numero_Escolha == 10)
            {
                GameController_Tempo.AceitouMissao3 = false;
            }
            if (opcao == 3 && Numero_Escolha == 10)
            {
                GameController_Tempo.AceitouMissao3 = true;
            }
            if (GameController_Tempo.missaoCumprida_part2 && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoStalker == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Nessa Última você terá que jogar com seu amigo até a gente conseguir instalar o vírus.";
                Numero_Escolha = 10;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[10];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[10];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[10];
                GameController_Tempo.AvisadoStalker = true;
                SobreJogador.SetActive(false);
                checar();
            }
            if (!GameController_Tempo.missaoCumprida_part2 && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoStalker == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Nessa Última você terá que jogar com seu amigo até a gente conseguir instalar o vírus.";
                Numero_Escolha = 10;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[10];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[10];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[10];
                GameController_Tempo.AvisadoStalker = true;
                SobreJogador.SetActive(false);
                checar();
            }
            if (GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoStalker == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Muito bom, agora falta 3 objetivos";
                Numero_Escolha = 6;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[6];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[6];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[6];
                GameController_Tempo.AvisadoStalker = true;
                checar();
            }
            if (!GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoStalker == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Por que você não cumpriu o combinado?";
                Numero_Escolha = 5;
                TextoEscolha1.text = Option1_Resposta1[5];
                TextoEscolha2.text = Option1_Resposta2[5];
                TextoEscolha3.text = Option1_Resposta3[5];
                GameController_Tempo.AvisadoStalker = true;
                checar();
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Faça isso, depois posso dar mais detalhes")
            {
                Numero_Escolha += 1;
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = ".";
                TextoEscolha1.text = Option1_Resposta1[3];
                TextoEscolha2.text = Option1_Resposta2[3];
                TextoEscolha3.text = Option1_Resposta3[3];
                Invoke("MudePersonagem", 3f);
                Invoke("DesativarPesonagem", 3.5f);
            }
            if (opcao == 1 && Numero_Escolha == 8 || opcao == 2 && Numero_Escolha == 8 || opcao == 3 && Numero_Escolha == 8)
            {
                if (GameController_Tempo.Mes == 3)
                {
                    Numero_Escolha = 8;
                    PersonagemSelecionado.SetActive(false);
                    ProxPersonagem[0].SetActive(true);
                    while (MudancaDePersonagem[0] < Numero_Escolha)
                    {
                        MudancaDaHistoria.Remove(MudancaDaHistoria[0]);
                        MudancaDePersonagem.Remove(MudancaDePersonagem[0]);
                        QualPersonagem.Remove(QualPersonagem[0]);
                    }
                }

            }
        }

        if (this.gameObject.CompareTag("Namorado"))
        {
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Ta irei no cinema, se quiser ir to la.")
            {
                GameController_Tempo.missaoCumprida = true;
            }
            else if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Não, seus amigos cancelaram")
            {
                GameController_Tempo.missaoCumprida = false;
            }
            else if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "A gente esta distante recentemente, você agora em uma faculdade diferente e longe.")
            {
                GameController_Tempo.missaoCumprida = false;
            }
            else if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Ta vou ligar para a policia!")
            {
                GameController_Tempo.LigouParaPolicia = true;
                GameController_Tempo.missaoCumprida = false;
            }
        }

        if (this.gameObject.CompareTag("Amigo"))
        {
            if (GameController_Tempo.ComecouMissao3)
            {
                Invoke("FecharPC", 5f);
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Ai a foto.")
            {
                Foto.SetActive(true);
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Print da conversa.")
            {
                PrintConversa.SetActive(true);
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Vamos!")
            {
                GameController_Tempo.ComecouMissao3 = true;
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Por que?" || (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Quem?"))
            {
                GameController_Tempo.ComecouMissao3 = false;
                GameController_Tempo.missaoCumprida_part3 = false;
            }
            if (GameController_Tempo.missaoCumprida_part2 && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoAmigo == false)
            {
                Numero_Escolha = 6;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[6];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[6];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[6];
                GameController_Tempo.AvisadoAmigo = true;
                checar();
            }
            if (!GameController_Tempo.missaoCumprida_part2 && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoAmigo == false)
            {
                Numero_Escolha = 6;
                TextoEscolha1.text = Option1_Resposta1[6];
                TextoEscolha2.text = Option1_Resposta2[6];
                TextoEscolha3.text = Option1_Resposta3[6];
                GameController_Tempo.AvisadoAmigo = true;
                checar();
            }
            if (GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoAmigo == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Pegou fogo onde a gente ia.";
                Numero_Escolha = 4;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[4];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[4];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[4];
                GameController_Tempo.AvisadoAmigo = true;
                checar();
            }
            if (!GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoAmigo == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Ficou sabendo que sua amiga traiu você?";
                Numero_Escolha = 5;
                TextoEscolha1.text = Option1_Resposta1[5];
                TextoEscolha2.text = Option1_Resposta2[5];
                TextoEscolha3.text = Option1_Resposta3[5];
                GameController_Tempo.AvisadoAmigo = true;
                checar();
            }

            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Vamos vai ser legal.")
            {
                GameController_Tempo.missaoCumprida = false;
            }
            else if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Vou denunciar ele.")
            {
                GameController_Tempo.LigouParaPolicia = true;
                GameController_Tempo.missaoCumprida = false;
            }
        }

        if (this.gameObject.CompareTag("Amiga"))
        { 
            if (opcao == 1 && Numero_Escolha == 11)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Meu endereço é rua Dr. Libanio 240";
                StatusOnline.Online = false;
                GameController_Tempo.missaoCumprida_part2 = true;
            }
            else if(opcao == 2 && Numero_Escolha == 11)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Meu deus! Vou trancar tudo!";
                StatusOnline.Online = false;
                GameController_Tempo.missaoCumprida_part2 = false;
            }
            if (GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoAmiga == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Se viu o que aconteceu?";
                Numero_Escolha = 7;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[7];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[7];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[7];
                GameController_Tempo.AvisadoAmiga = true;
                checar();
            }
            if (!GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 4 && GameController_Tempo.AvisadoAmiga == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Você perdeu de não ir";
                Numero_Escolha = 5;
                TextoEscolha1.text = Option1_Resposta1[5];
                TextoEscolha2.text = Option1_Resposta2[5];
                TextoEscolha3.text = Option1_Resposta3[5];
                GameController_Tempo.AvisadoAmiga = true;
                checar();
            }
            if (GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoAmiga == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Se viu o que aconteceu?";
                Numero_Escolha = 7;
                TextoEscolha1.text = Option1_Resposta1_MissaoFeita[7];
                TextoEscolha2.text = Option1_Resposta2_MissaoFeita[7];
                TextoEscolha3.text = Option1_Resposta3_MissaoFeita[7];
                GameController_Tempo.AvisadoAmiga = true;
                checar();
            }
            if (!GameController_Tempo.missaoCumprida && GameController_Tempo.Mes == 3 && GameController_Tempo.AvisadoAmiga == false)
            {
                ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text = "Você perdeu de não ir";
                Numero_Escolha = 4;
                TextoEscolha1.text = Option1_Resposta1[4];
                TextoEscolha2.text = Option1_Resposta2[4];
                TextoEscolha3.text = Option1_Resposta3[4];
                GameController_Tempo.AvisadoAmiga = true;
                checar();
            }
            if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Ta, mas eu vou.")
            {
                GameController_Tempo.missaoCumprida = false;
            }
            else if (ConversasPassada.GetComponentInChildren<TextMeshProUGUI>().text == "Ta vou ligar.")
            {
                GameController_Tempo.LigouParaPolicia = true;
                GameController_Tempo.missaoCumprida = false;
            }

            if(opcao == 1 && Numero_Escolha == 5 || opcao == 2 && Numero_Escolha == 5 || opcao == 3 && Numero_Escolha == 5)
            {
                if(GameController_Tempo.Mes == 3)
                {
                    Invoke("MudarNum", 1f);
                }
                
            }
        }

        ChecarMudancaPersonagem();
        ChecarMudancaHistoria();

        if (opcao == 1)
        {
            if (Escolha == 1 || Escolha == 2 || Escolha == 3)
            {
                checar();
                for (int i = 0; i <= Numero_Escolha; i++)
                {
                    if (Numero_Escolha == i)
                    {
                        Escolha = 0;
                        Image NewResposta = Instantiate(Mensagem_Recebida, MSN_Recebido.transform);
                        NewResposta.transform.position = Recebido_Transform.position;

                        if (GameController_Tempo.missaoCumprida == false && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta1_escolha1[i - 1];
                            TextoEscolha1.text = Option1_Resposta1[i];
                            TextoEscolha2.text = Option1_Resposta2[i];
                            TextoEscolha3.text = Option1_Resposta3[i];
                        }
                        else if (GameController_Tempo.missaoCumprida == true && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta1_escolha1_MissaoFeita[i - 2];
                            TextoEscolha1.text = Option1_Resposta1_MissaoFeita[i];
                            TextoEscolha2.text = Option1_Resposta2_MissaoFeita[i];
                            TextoEscolha3.text = Option1_Resposta3_MissaoFeita[i];
                        }
                    }
                }
            }
        }
        if (opcao == 2)
        {
            if (Escolha == 1 || Escolha == 2 || Escolha == 3)
            {
                checar();
                for (int i = 0; i <= Numero_Escolha; i++)
                {
                    if (Numero_Escolha == i)
                    {
                        Escolha = 0;
                        Image NewResposta = Instantiate(Mensagem_Recebida, MSN_Recebido.transform);
                        NewResposta.transform.position = Recebido_Transform.position;

                        if (GameController_Tempo.missaoCumprida == false && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta2_escolha2[i - 1];
                            TextoEscolha1.text = Option2_Resposta1[i];
                            TextoEscolha2.text = Option2_Resposta2[i];
                            TextoEscolha3.text = Option2_Resposta3[i];
                        }
                        else if (GameController_Tempo.missaoCumprida == true && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta2_escolha2_MissaoFeita[i - 2];
                            TextoEscolha1.text = Option2_Resposta1_MissaoFeita[i];
                            TextoEscolha2.text = Option2_Resposta2_MissaoFeita[i];
                            TextoEscolha3.text = Option2_Resposta3_MissaoFeita[i];
                        }
                    }
                }
            }
        }
        if (opcao == 3)
        {
            if (Escolha == 1 || Escolha == 2 || Escolha == 3)
            {
                checar();
                for (int i = 0; i <= Numero_Escolha; i++)
                {
                    if (Numero_Escolha == i)
                    {
                        Escolha = 0;
                        Image NewResposta = Instantiate(Mensagem_Recebida, MSN_Recebido.transform);
                        NewResposta.transform.position = Recebido_Transform.position;

                        if (GameController_Tempo.missaoCumprida == false && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta3_escolha3[i - 1];
                            TextoEscolha1.text = Option3_Resposta1[i];
                            TextoEscolha2.text = Option3_Resposta2[i];
                            TextoEscolha3.text = Option3_Resposta3[i];
                        }
                        else if (GameController_Tempo.missaoCumprida == true && StatusOnline.Online == true)
                        {
                            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = Resposta3_escolha3_MissaoFeita[i - 2];
                            TextoEscolha1.text = Option3_Resposta1_MissaoFeita[i];
                            TextoEscolha2.text = Option3_Resposta2_MissaoFeita[i];
                            TextoEscolha3.text = Option3_Resposta3_MissaoFeita[i];
                        }
                    }
                }
            }
        }
    }
    public void Escolha1()
    {
        if (TextoEscolha1.text != "")
        {
            Escolheu();
            Image NewResposta = Instantiate(Mensagem_Enviada, MSN_Enviado.transform);
            NewResposta.transform.position = transform.position;
            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = TextoEscolha1.text;
            Escolha = 1;
        }
    }
    public void Escolha2()
    {
        if (TextoEscolha2.text != "")
        {
            Escolheu();
            Image NewResposta = Instantiate(Mensagem_Enviada, MSN_Enviado.transform);
            NewResposta.transform.position = transform.position;
            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = TextoEscolha2.text;
            Escolha = 2;
        }
    }

    public void Escolha3()
    {
        if (TextoEscolha3.text != "")
        {
            Escolheu();
            Image NewResposta = Instantiate(Mensagem_Enviada, MSN_Enviado.transform);
            NewResposta.transform.position = transform.position;
            NewResposta.GetComponentInChildren<TextMeshProUGUI>().text = TextoEscolha3.text;
            Escolha = 3;

        }
    }

    void Escolheu()
    {
        EnviarResposta.SetActive(true);
        OpcaoDeResposta.SetActive(false);
        Destroy(ConversasPassada);
        Destroy(RespostasPassada);
        Numero_Escolha += 1;
    }

    void MudePersonagem()
    {
        if(GameController_Tempo.Mes >= 3 && QualPersonagem[0] == 1)
        {
            MudancaDePersonagem.Remove(MudancaDePersonagem[0]);
            QualPersonagem.Remove(QualPersonagem[0]);
        }
        if(QualPersonagem[0] == 4)
        {
            MudancaDePersonagem.Remove(MudancaDePersonagem[0]);
            QualPersonagem.Remove(QualPersonagem[0]);
            SceneManager.LoadScene(1);
            GameController_Tempo.ChegaDeWhats = true;
        }
        else
        {
            PersonagemSelecionado.SetActive(false);
            ProxPersonagem[QualPersonagem[0]].SetActive(true);
            MudancaDePersonagem.Remove(MudancaDePersonagem[0]);
            QualPersonagem.Remove(QualPersonagem[0]);
        }
    }
    void DesativarDecisao()
    {
        MudancaDaHistoria.Remove(MudancaDaHistoria[0]);
        Aviso_Decisao.SetActive(false);
    }

    void FecharPC()
    {
        SceneManager.LoadScene(1);
    }

    void checar()
    {
        while(MudancaDePersonagem[0] < Numero_Escolha)
        {
            MudancaDaHistoria.Remove(MudancaDaHistoria[0]);
            MudancaDePersonagem.Remove(MudancaDePersonagem[0]);
            QualPersonagem.Remove(QualPersonagem[0]);
        }
    }

    void ChecarMudancaHistoria()
    {
        if (Escolha == 1 && MudancaDaHistoria[0] == Numero_Escolha)
        {
            Aviso_Decisao.SetActive(true);
            opcao = 1;
            Invoke("DesativarDecisao", 2f);
        }
        else if (Escolha == 2 && MudancaDaHistoria[0] == Numero_Escolha)
        {
            Aviso_Decisao.SetActive(true);
            opcao = 2;
            Invoke("DesativarDecisao", 2f);
        }
        else if (Escolha == 3 && MudancaDaHistoria[0] == Numero_Escolha)
        {
            Aviso_Decisao.SetActive(true);
            opcao = 3;
            Invoke("DesativarDecisao", 2f);
        }
    }

    void ChecarMudancaPersonagem()
    {
        if (Escolha == 1 && MudancaDePersonagem[0] == Numero_Escolha)
        {
            Invoke("MudePersonagem", 3f);
        }
        else if (Escolha == 2 && MudancaDePersonagem[0] == Numero_Escolha)
        {
            Invoke("MudePersonagem", 3f);
        }
        else if (Escolha == 3 && MudancaDePersonagem[0] == Numero_Escolha)
        {
            Invoke("MudePersonagem", 3f);
        }
    }

    void MudarNum()
    {
         Numero_Escolha = 10;
    }
}

