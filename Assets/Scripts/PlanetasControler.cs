using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlanetasControler : MonoBehaviour
{
    public GameObject[] corposSelestes;

    public void resetarPlanet(GameObject planeta)
    {
        for (int i = 0; i < corposSelestes.Length; i++)
        {
            if (corposSelestes[i].GetComponent<MenuInformacoesControler>().nome == planeta.GetComponent<MenuInformacoesControler>().nome)
            {
                corposSelestes[i].GetComponent<Rigidbody>().isKinematic = true;
                corposSelestes[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                corposSelestes[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                corposSelestes[i].transform.localPosition = Vector3.zero;
                corposSelestes[i].transform.localRotation = Quaternion.identity;
                corposSelestes[i].GetComponent<Rigidbody>().isKinematic = false;
                break;
            }
        }
    }
}
