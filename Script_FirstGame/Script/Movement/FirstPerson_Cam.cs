using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson_Cam : MonoBehaviour
{
    public Camera Cam_Principal;
    public Camera Cam_Cutscene;

    public Transform characterBody;
    public Transform characterHead;

    float sensY = 1.5f;
    float sensX = 1.5f;

    float rotationX = 0;
    float rotationY = 0;

    float smoothRotx = 0;
    float smoothRoty = 0;
    float smoothCoeFx = 0.5f;
    float smoothCoeFy = 0.5f;

    float angleYmin = -60;
    float angleYMax = 60;
    void Start()
    {
        Cam_Cutscene.enabled = false;
        Cam_Principal.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate()
    {
        transform.position = characterHead.position;
    }
    void Update()
    {
        if(Time.timeScale != 0)
        {
            //Pega a movimentação do mouse e multiplica pela sensibilidade
            float VerticalDelta = Input.GetAxisRaw("Mouse Y") * sensY;
            float HorizontalDelta = Input.GetAxisRaw("Mouse X") * sensX;

            //Suaviza a movimentação da câmera
            smoothRotx = Mathf.Lerp(smoothRotx, HorizontalDelta, smoothCoeFx);
            smoothRoty = Mathf.Lerp(smoothRoty, VerticalDelta, smoothCoeFy);

            //Adiciona o valores 1, 0 ou -1 para a rotação da câmera
            rotationX += HorizontalDelta;
            rotationY += VerticalDelta;

            //Limita a rotação no Y para que não de um loop
            rotationY = Mathf.Clamp(rotationY, angleYmin, angleYMax);

            // o Player muda o ângulo para que va para onde a câmera apontar
            characterBody.localEulerAngles = new Vector3(0, rotationX, 0);

            //passa a rotação da câmera
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
    }
}
