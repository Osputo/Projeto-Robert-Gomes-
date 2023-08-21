using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
    public bool chave=false;
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

                    break;

                case camState.dialogue:
                    break;
            }
        }
    }
}