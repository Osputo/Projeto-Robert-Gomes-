using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;
using static System.Net.Mime.MediaTypeNames;

public class camControl : MonoBehaviour
{
    public Transform charBody, charHead;
    float maxY=90, minY=-45;
    float rotationX = 0, rotationY = 0;
    public float senseX=1.2f, senseY=1.2f;
    float smoothRotX = 0, smoothRotY=0;
    float smoothCoefX = 1.5f, smoothCoefY=1.5f;
    float range = 0.7f;
    public GameObject inte;

    bookControler book;

    player player;

    PhotonView phview;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        phview = GetComponent<PhotonView>();

        

        player = FindObjectOfType(typeof(player)) as player;
    }
    private void LateUpdate()
    {

        if (!phview.IsMine)
            gameObject.SetActive(false);

        switch (player.state)
        {
            case camState.normal:
                transform.position = charHead.position;

                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (player.state)
        {
            case camState.normal:

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;


                FpsCamera();

                RaycastHit hit2;
                if (Physics.Raycast(transform.position, transform.forward, out hit2, range))
                {
                    if (hit2.collider.CompareTag("Interact"))
                    {
                        inte.SetActive(true);
                    }


                    if (Input.GetButtonDown("Fire1"))
                    {
                        phview.RPC("RayCastAct", RpcTarget.All);
                    }
                }
                else
                {
                    inte.SetActive(false);
                }
                break;

            case camState.dialogue:

                inte.SetActive(false);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;

            case camState.book1:

                inte.SetActive(false);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;

            case camState.pause:

                inte.SetActive(false);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;

        }
        
        
    }
    [PunRPC]
    void RayCastAct()
    {
        switch (player.state)
        {
            case camState.normal:

                RaycastHit hit;

                if (Physics.Raycast(transform.position, transform.forward, out hit, range))
                {
                        if (hit.collider.CompareTag("Interact"))
                        {  
                            hit.collider.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver); 
                        }

                }
                Debug.DrawRay(transform.position, transform.forward * range, Color.red);

                break;
        }
    }


    void FpsCamera()
    {
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * senseY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * senseX;
        rotationX += smoothRotX;
        rotationY += smoothRotY;

        smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefX);
        smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefY);
        rotationY = Mathf.Clamp(rotationY, minY, maxY);

        charBody.localEulerAngles = new Vector3(0, rotationX, 0);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }

}
