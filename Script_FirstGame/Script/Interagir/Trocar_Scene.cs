using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trocar_Scene : MonoBehaviour
{
    public GameObject Jornal;
    public bool jornal;
    public int levelIndex;

    public void Start()
    {
        jornal = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jornal == false)
            {
                jornal = true;
                Jornal.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(levelIndex);
            }
        }
    }
}
