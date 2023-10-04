using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public enum camState
{
    normal,
    dialogue
}
public class player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward, strafe, vertical;
    float gravity, jumpSpeed;
    public float forwardSpeed = 5, strafeSpeed = 2;
    public float maxJumpHeight = 2, timeToMaxHeight = 0.5f;



    /*public bool chave = false, dire = false, aluno = false, joao = false, ingle = false, puz1 = false, faxi = false, balde = false, esfre = false, sabao = false, luva = false, paper = false, puz3 = false, aud = false; //itens de missões
    public bool paper1 = false, paper2 = false, paper3 = false, paper4 = false, paper5 = false, paper6 = false, paper7 = false, paper8 = false, paper9 = false, paper10 = false, paper11 = false; //Papeis
    public bool neuza = false, hudson = false, exandro = false, david = false, igor = false, clovis = false, sonia = false, secretaria = false, fun = false; //Professores e Empregados
    public bool paulo = false, edson = false, cubas = false, lucio = false, karen = false, celia = false, james = false, pallaoro = false; //Alunos*/
    public camState state = camState.normal;
    PhotonView phView;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;

        phView = GetComponent<PhotonView>();

    }

    void Update()
    {

        if (phView.IsMine)
        {
            switch (state)
            {
                case camState.normal:

                    float forwardInput = Input.GetAxisRaw("Vertical");
                    float strafeInput = Input.GetAxisRaw("Horizontal");

                    forward = forwardInput * forwardSpeed * transform.forward;
                    strafe = strafeInput * strafeSpeed * transform.right;

                    vertical += gravity * Time.deltaTime * Vector3.up;
                    if (controller.isGrounded)
                    {
                        if (Input.GetButtonDown("Jump"))
                        {
                            vertical = jumpSpeed * Vector3.up;
                        }
                    }

                    Vector3 finalVelocity = forward + strafe + vertical;
                    controller.Move(finalVelocity * Time.deltaTime);



                    if (Input.GetButtonDown("Book"))
                    {


                    }

                    break;

                case camState.dialogue:


                    break;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {


        Debug.Log("no mames");
        vertical += gravity * Time.deltaTime * Vector3.up;
        if (controller.isGrounded)
        {

            Debug.Log("no mames2");
            if (collision.gameObject.tag == "pulo")
            {
                Debug.Log("no mames3");
                vertical = (jumpSpeed * 3) * Vector3.up;
            }
        }
            


    }
}