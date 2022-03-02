using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conversa_Final : MonoBehaviour
{
    public List<GameObject> ConversaFinal;
    public GameObject FecharOlho;
    IEnumerator Start()
    {
        for (int i = 0; i < ConversaFinal.Count - 1; i++)
        {
            yield return new WaitForSecondsRealtime(4);
            if (ConversaFinal[i].activeInHierarchy)
            {
                ConversaFinal[i].SetActive(false);
                ConversaFinal[i + 1].SetActive(true);
            }
        }
        if (ConversaFinal[9].activeInHierarchy)
        {
            yield return new WaitForSecondsRealtime(3);
            FecharOlho.SetActive(true);
            Invoke("voltarMenu", 3f);
        }
    }

    void voltarMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
