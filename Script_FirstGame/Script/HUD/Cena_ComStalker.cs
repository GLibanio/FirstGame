using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cena_ComStalker : MonoBehaviour
{
    public List<GameObject> ConversaFinal;
    void Update()
    {
        if (ConversaFinal[0].activeInHierarchy)
        {
            Invoke("proximaConversa", 3f);
        }
        if (ConversaFinal[1].activeInHierarchy)
        {
            Invoke("proximaConversa2", 3f);
        }
    }

    void proximaConversa()
    {
        ConversaFinal[0].SetActive(false);
        ConversaFinal[1].SetActive(true);
    }

    void proximaConversa2()
    {
        ConversaFinal[1].SetActive(false);
        ConversaFinal[2].SetActive(true);
        Invoke("voltarMenu", 3f);
    }

    void voltarMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
