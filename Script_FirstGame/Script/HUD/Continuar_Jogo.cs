using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continuar_Jogo : MonoBehaviour
{
    
    void Update()
    {
        if (this.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
