using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Interacao : MonoBehaviour
{
    public Transform centro;
    public AudioSource segurarSom;
    public GameObject particulas;
    public AudioSource audioDestruicao;

    private Rigidbody rigidbody;
    private XRController controladorDireito;
    private bool preso = true;

    void Start()
    {
        centro = transform.parent;
        GetComponent<Rigidbody>().isKinematic = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Segurar()
    {
        rigidbody.isKinematic = false;
        transform.parent = null;
        segurarSom.Play();
        
    }

    public void Largar()
    {
        rigidbody.isKinematic = false;
    }
    private void OnCollisionEnter(Collision colisao)
    {
        if (colisao.gameObject.CompareTag("Estrela"))
        {
            if (GetComponent<MenuInformacoesControler>().nome == "Saturno")
            {
                transform.Find("Planeta").GetComponent<MeshRenderer>().enabled = false;
                transform.Find("Anel").GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<SphereCollider>().enabled = false;
            }

            Vector3 pontoImpacto = colisao.contacts[0].point;

            Quaternion rotacao = Quaternion.FromToRotation(Vector3.up, colisao.contacts[0].normal);
            Instantiate(particulas, pontoImpacto, rotacao);
            audioDestruicao.Play();
        }
    }


}
