using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject Aviso;

    public GameObject Configuração;
    public GameObject Escolha_Wallpaper;
    public List<GameObject> Lista_Wallpaper;

    public GameObject Loading;
    public Slider slider;
    public Text Progress_Tx;

    bool Menu_Ativado;
    bool Config_Ativado;
    bool EscolhaWP_Ativado;

    public GameObject MenuPc;

    public GameObject Mensagem;
    public GameObject Escolhas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
           Vector2 mousePos = Input.mousePosition;

           Configuração.transform.position = mousePos;

          if (!Config_Ativado)
          {
             Configuração.SetActive(true);
             Config_Ativado = true;
          }
          else
          {
               Configuração.SetActive(false);
               Config_Ativado = false;
          }
        }
    }
    public void wallpaper1(int i)
    {
        for (int z = 0; z <= 4; z++)
        {
            Lista_Wallpaper[z].SetActive(false);
            Lista_Wallpaper[i].SetActive(true);
        }
    }

    public void Troca_Wallpaper()
    {
        if (!EscolhaWP_Ativado)
        {
            EscolhaWP_Ativado = true;
            Escolha_Wallpaper.SetActive(true);
        }
        else
        {
            EscolhaWP_Ativado = false;
            Escolha_Wallpaper.SetActive(false);
        }
    }
    public void AbrirJogo(int IndexLevel)
    {
        StartCoroutine(LoadAsynchronously(IndexLevel));
    }
    
    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        if(SceneIndex == 3)
        {
            if(GameController_Tempo.ChegaDeWhats == true)
            {
                Aviso.SetActive(true);
                Invoke("Avisado", 2f);
            }
            else if(GameController_Tempo.Hora <= 9)
            {
                Aviso.SetActive(true);
                Invoke("Avisado", 2f);
            }
            else
            {
                AsyncOperation operation1 = SceneManager.LoadSceneAsync(SceneIndex);

                Loading.SetActive(true);

                while (!operation1.isDone)
                {
                    float progress = Mathf.Clamp01(operation1.progress / 10.9f);

                    slider.value = progress;
                    Progress_Tx.text = progress * 100f + "%";

                    yield return null;
                }
            }
        }
        else
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

            Loading.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 10.9f);

                slider.value = progress;
                Progress_Tx.text = progress * 100f + "%";

                yield return null;
            }
        } 
    }

    void Avisado()
    {
        Aviso.SetActive(false);
    }

    public void Menu_PC()
    {
        if (!Menu_Ativado)
        {
            Menu_Ativado = true;
            MenuPc.SetActive(true);
        }
        else
        {
            Menu_Ativado = false;
            MenuPc.SetActive(false);
        }
    }

    public void Sair()
    {
        Application.Quit();
    }
}
