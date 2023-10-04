using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Cam : MonoBehaviour
{
    PhotonView phView;
    //Parâmetros públicos do corpo e cabeça do player
    public Transform characterBody;
    //A cabeça só serve para definir a altura onde a câmera fica
    public Transform characterHead;

    //Sensibilidade da movimentação da câmera
    //Poderia ser colocado na tela de configurações uma referência
    //Para modificar os valores de acordo com a preferência do player
    float sensitivityX = 1.2f;
    float sensitivityY = 1.2f;
    //Rotação da Câmera
    float rotationX = 0, rotationY = 0;
    //Ângulos de rotação limite, evitar que o jogador quebre o pescoço
    float angleYMin = -90, angleYMax = 90;

    //Suavização para a câmera
    float smoothRotX = 0;
    float smoothRotY = 0;

    //Modificador da suavização
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
    private void LateUpdate()//Para seguir o objeto com a posição já atualizada
    {
        transform.position = characterHead.position;
    }
    // Update is called once per frame
    void Update()
    {
        //Variáveis recebendo entrada do mouse
        float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
        float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

        //Suavização da câmera
        smoothRotX = Mathf.Lerp(smoothRotX, horizontalDelta, smoothCoefx);
        smoothRotY = Mathf.Lerp(smoothRotY, verticalDelta, smoothCoefy);
        //

        rotationX += smoothRotX;
        rotationY += smoothRotY;

        // Limitar rotação da câmera entre dois valores
        rotationY = Mathf.Clamp(rotationY, angleYMin, angleYMax);

        // Fazer o personagem se mover na direção para onde a câmera aponta
        characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
        

        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);


    }
}
