using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

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
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Segurar()
    {
        transform.parent = null;
        segurarSom.Play();
    }

    private void OnCollisionEnter(Collision colisao)
    {
        if(colisao.gameObject.CompareTag("Planeta"))
        {
            Vector3 pontoImpacto = colisao.contacts[0].point;

            Quaternion rotacao = Quaternion.FromToRotation(Vector3.up, colisao.contacts[0].normal);
            Instantiate(particulas, pontoImpacto, rotacao);
        }
    }


}
