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

    public InputAction botao;
    void Start()
    {
        centro = transform.parent;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ///if (preso)
        ///{
        ///    rigidbody.isKinematic = true;
        ///}
        ///else {             
        ///    rigidbody.isKinematic = false; 
        ///}
        
    }

    private void OnEnable()
    {
        botao.Enable();
        botao.performed += OnBotaoPressionado;
    }

    private void OnDisable()
    {
        botao.Disable();
        botao.performed -= OnBotaoPressionado;
    }

    private void OnBotaoPressionado(InputAction.CallbackContext context)
    {
        rigidbody.isKinematic = true;
        ///Resetar a posiçao e velocidade do objeto
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        transform.parent = centro;
        transform.localPosition = Vector3.zero;
        rigidbody.isKinematic = false;
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
