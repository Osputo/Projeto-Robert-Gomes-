using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
[RequireComponent(typeof(CharacterController))]
public class MyPlayer : MonoBehaviour
{
    PhotonView phView;
    public Material skin;
    CharacterController controller;
    public float forwardSpeed = 5, strafeSpeed = 3, distanceInteraction = 5;
    Vector3 forward, strafe, vertical;
    public Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        phView = GetComponent<PhotonView>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (phView.IsMine)
        {
            Controls();
            //RaycastInteraction();
        }
    }


    [PunRPC]
    void RPC_ChangeColor()
    {
        ChangeColor();
    }


    void ChangeColor()
    {
            GetComponent<MeshRenderer>().material = skin;
    }
    void RaycastInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, distanceInteraction))
        {
            
            if (Input.GetButtonDown("Fire1"))//Clicar enquanto olha
            {
                print($"Bateu no {hit.collider.gameObject.name}");
            }
        }
    }
    void Controls()
    {
        //As duas variáveis estão pegando o valor do teclado
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");
        //Multiplicação do teclado * velocidade * vetor de direção do objeto
        forward = forwardInput * forwardSpeed * transform.forward;
        strafe = strafeInput * strafeSpeed * transform.right;
        //Vetor referente a gravidade
        vertical = Vector3.down;
        //Vector que recebe a soma dos vetores de cada direção
        Vector3 finalVelocity = forward + strafe + vertical;
        //Aplicando o vetor multiplicado pela atualização de FPS
        controller.Move(finalVelocity * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
        {
            phView.RPC("RPC_ChangeColor", RpcTarget.AllBuffered);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter");
    }
    private void OnCollisionStay(Collision collision)
    {
        print("OnCollisionStay");
    }
    private void OnCollisionExit(Collision collision)
    {
        print("OnCollisionExit");
    }
    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
    }
    private void OnTriggerStay(Collider other)
    {
        print("OnTriggerStay");
    }
    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");
    }
}
