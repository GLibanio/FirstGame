using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController Movement;
    Vector3 direcaoPlayer;
    Camera Cam;
    Animator Anim;

    public float inputX;
    public float inputZ;
    public float speed = 3;
    public float speedCam;
    
    float rotationSpeed = 0.3f;
    float allowrotation = 0.1f;
    float velY;
    float Gravity = 9.8f;

    public GameObject Historia;
    public static bool LeuHistoria;

    void Start()
    {
        Time.timeScale = 1;
        Anim = GetComponent<Animator>();
        Movement = GetComponent<CharacterController>();
        Cam = Camera.main;
    }


    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && LeuHistoria == false)
        {
            GameController_Tempo.Hora = 7;
            LeuHistoria = true;
        }

        if (LeuHistoria)
        {
            Historia.SetActive(false);
            Gravidade();
            MakeRotation();
            Move();
        } 
    }

    void Move()
    {    
        var FinalMove = direcaoPlayer * speed;
        FinalMove.y = velY;
        Movement.Move(FinalMove * Time.deltaTime);
    }

    void Gravidade()
    {
        velY -= Gravity * Time.deltaTime;
    }

    void MakeRotation()
    {
        speedCam = new Vector3(inputX, inputZ).normalized.magnitude;

        if (speedCam >= allowrotation)
        {
            Anim.SetFloat("Speed", 1);
            rotation();
        }
        else
        {
            Anim.SetFloat("Speed", 0);
            direcaoPlayer = Vector3.zero;
        }
    }

    void rotation()
    {
        var foward = Cam.transform.forward;
        var right = Cam.transform.right;

        foward.y = 0;
        right.y = 0;

        foward.Normalize();
        right.Normalize();

        direcaoPlayer = foward * inputZ + right * inputX;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direcaoPlayer), rotationSpeed);
    }
}
