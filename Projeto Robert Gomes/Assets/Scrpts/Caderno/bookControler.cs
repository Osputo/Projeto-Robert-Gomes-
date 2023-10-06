using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookControler : MonoBehaviour
{
    public GameObject[] content;
    [SerializeField] bool[] activateContent;
   
    // Start is called before the first frame update
    void Start()
    {
        activateContent = new bool[content.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (activateContent[0])
            content[0].SetActive(true); //Ao entrar na escola

        if (activateContent[1])
            content[1].SetActive(true); //Depois de conversar com diretora


        if (activateContent[2])
            content[2].SetActive(true); //Depois de conversar com qualquer aluno

        if (activateContent[3])
            content[3].SetActive(true); //Depois da cutscene do João

        if (activateContent[4])
            content[4].SetActive(true); //Depois de conversar com a professora de Inglês.

        if (activateContent[5])
            content[5].SetActive(true); //Depois de resolver o puzzle

        if (activateContent[6])
        {
            content[6].SetActive(true); //Depois de conversar com a faxineira
            content[7].SetActive(true);
        }
            

        if (activateContent[7])
            content[8].SetActive(true); //Balde

        if (activateContent[8])
            content[9].SetActive(true); //Esfregão

        if (activateContent[9])
            content[10].SetActive(true); //Sabão

        if (activateContent[10])
            content[11].SetActive(true); //Luva

        if (activateContent[11])
        {
            content[12].SetActive(true); //ped0
            content[13].SetActive(true);
        }
            

        if (activateContent[12])
            content[14].SetActive(true); content[13].SetActive(true);//ped1

        if (activateContent[13])
            content[15].SetActive(true); content[13].SetActive(true);//ped2

        if (activateContent[14])
            content[16].SetActive(true); content[13].SetActive(true);//ped3

        if (activateContent[15])
            content[17].SetActive(true); content[13].SetActive(true);//ped4

        if (activateContent[16])
            content[18].SetActive(true); content[13].SetActive(true);//ped5

        if (activateContent[17])
            content[19].SetActive(true); content[13].SetActive(true);//ped6

        if (activateContent[18])
            content[20].SetActive(true); content[13].SetActive(true);//ped7

        if (activateContent[19])
            content[21].SetActive(true); content[13].SetActive(true); //ped8

        if (activateContent[20])
            content[22].SetActive(true); //parte de cima mapa

        if (activateContent[21])
            content[23].SetActive(true); //Depois de resolver o puzzle 3

        if (activateContent[22])
            content[24].SetActive(true); //Depois de abrir o auditório
    }
}
