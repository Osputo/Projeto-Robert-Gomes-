using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class camControl2 : MonoBehaviour
{
    public Transform charBody, charHead;
    float maxY=90, minY=-45;
    float rotationX = 0, rotationY = 0;
    public float senseX=1.2f, senseY=1.2f;
    float smoothRotX = 0, smoothRotY=0;
    float smoothCoefX = 1.5f, smoothCoefY=1.5f;
    float range = 1.7f;

    public Image canvaCursor;
    // Start is called before the first frame update
    void Start()
    {
        if(!charBody.GetComponent<PhotonView>().IsMine)
            Destroy(this.gameObject);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void LateUpdate()
    {
        transform.position = charHead.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!charBody.GetComponent<PhotonView>().IsMine)
            return;
        FpsCamera();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (!hit.collider)
                canvaCursor.color = Color.gray;
            else if (hit.collider.CompareTag("Interact"))
            {
                print(hit.collider.name);
                canvaCursor.color = Color.red;
                if (Input.GetButtonDown("Fire1"))
                {
                    hit.collider.SendMessage("Interaction", SendMessageOptions.DontRequireReceiver);
                }
            }
            else if(hit.collider.CompareTag("Block"))
            {
                print(hit.collider.name);
                canvaCursor.color = Color.red;
                if (Input.GetButtonDown("Fire1"))
                    charBody.GetComponent<PhotonView>().RPC("RPCTradeMaterial", RpcTarget.AllBuffered, hit.collider.GetComponent<ColorBrick>().material.name);
            }
            else
            {
                print(hit.collider.name);
                canvaCursor.color = Color.gray;
            }

        }
        Debug.DrawRay(transform.position, transform.forward*range, Color.red);
        
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
