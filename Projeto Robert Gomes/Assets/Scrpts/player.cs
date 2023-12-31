using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public enum camState
{
    normal,
    dialogue,
    book1,
    pause
}
public class player : MonoBehaviour
{
    CharacterController controller;
    Vector3 forward, strafe, vertical;
    float gravity, jumpSpeed;
    public float forwardSpeed = 5, strafeSpeed = 2;
    public float maxJumpHeight = 2, timeToMaxHeight = 0.5f;

    public GameObject book, keypad;
    public GameObject pause;

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
                        book.SetActive(true);
                        state = camState.book1;
                    }

                    if (Input.GetButtonDown("Pause"))
                    {
                        pause.SetActive(true);
                        state = camState.pause;
                    }

                    break;

                case camState.book1:

                    if (Input.GetButtonDown("Book"))
                    {
                        book.SetActive(false);
                        state = camState.normal;
                    }
                    if (Input.GetButtonDown("Pause"))
                    {
                        book.SetActive(false);
                        pause.SetActive(true);
                        state = camState.pause;
                    }
                    break;


                case camState.pause:

                    if (Input.GetButtonDown("Pause"))
                    {
                        pause.SetActive(false);
                        state = camState.normal;
                    }
                    if (Input.GetButtonDown("Book"))
                    {
                        pause.SetActive(false);
                        book.SetActive(true);
                        state = camState.book1;
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

    public void EnterInKeypad()
    {
        keypad.gameObject.SetActive(true);
        state = camState.dialogue;

        if (Input.GetButtonDown("Pause"))
        {
            keypad.gameObject.SetActive(false);
            state = camState.dialogue;
        }

    }

}