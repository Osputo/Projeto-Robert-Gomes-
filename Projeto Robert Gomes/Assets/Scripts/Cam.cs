using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Cam : MonoBehaviour
{
    PhotonView phView;
    //Par�metros p�blicos do corpo e cabe�a do player
    public Transform characterBody;
    //A cabe�a s� serve para definir a altura onde a c�mera fica
    public Transform characterHead;

    //Sensibilidade da movimenta��o da c�mera
    //Poderia ser colocado na tela de configura��es uma refer�ncia
    //Para modificar os valores de acordo com a prefer�ncia do player
    float sensitivityX = 1.2f;
    float sensitivityY = 1.2f;
    //Rota��o da C�mera
    float rotationX = 0, rotationY = 0;
    //�ngulos de rota��o limite, evitar que o jogador quebre o pesco�o
    float angleYMin = -90, angleYMax = 90;

    //Suaviza��o para a c�mera
    float smoothRotX = 0;
    float smoothRotY = 0;

    //Modificador da suaviza��o
    float smoothCoefx = 0.5f;
    float smoothCoefy = 0.5f;
    private void Start()
    {
        phView = characterBody.GetComponent<PhotonView>();
        if (!phView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }
    private void LateUpdate()//Para seguir o objeto com a posi��o j� atualizada
    {
        transform.position = characterHead.position;
    }
    // Update is called once per frame
    void Update()
    {
        //Vari�veis recebendo entrada do mouse
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        //Suaviza��o da c�mera
        smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefx);
        smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefy);
        //

        rotationX += smoothRotX;
        rotationY += smoothRotY;

        // Limitar rota��o da c�mera entre dois valores
        rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax);

        // Fazer o personagem se mover na dire��o para onde a c�mera aponta
        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
        

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


    }
}
