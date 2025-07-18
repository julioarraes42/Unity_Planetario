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
        if(CompareTag("Planeta"))
        {
            transform.Find("Linha").GetComponent<TrailRenderer>().enabled = false;
            Debug.Log("Linha desativada para o planeta: " + gameObject.name);
        }
    }

    public void Largar()
    {
        Toggle toggle = GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("Panel/Toggle").GetComponent<Toggle>();
        if (toggle.isOn)
        {
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.transform.localPosition = Vector3.zero;
            rigidbody.transform.localRotation = Quaternion.identity;
        }
        else
        {
            rigidbody.isKinematic = false;
        }
        if(CompareTag("Planeta"))
        {
            transform.Find("Linha").GetComponent<TrailRenderer>().enabled = true;
        }
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
        }
    }


}
