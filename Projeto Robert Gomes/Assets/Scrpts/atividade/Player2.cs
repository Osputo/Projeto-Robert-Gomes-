using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player2 : MonoBehaviour
{
    Rigidbody rb;
    private float moveSpeed = 6;
    public bool chave = false;

    float horizontalInput;
    float verticalInput;

    public Transform orientation;

    Vector3 moveDirection;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (!GetComponent<PhotonView>().IsMine)
            return;

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //calculate movement Dierction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on grounded


        rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);


        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("jump"))
        {
            rb.AddForce(transform.up * 7.5f, ForceMode.Impulse);
        }
    }
    [PunRPC]
    public void RPCTradeMaterial(string target)
    {
        Material newMat = Resources.Load(target, typeof(Material)) as Material;
        GetComponent<Renderer>().material = newMat;
    }
}