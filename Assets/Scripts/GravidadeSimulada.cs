using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GravidadeSimulada : MonoBehaviour
{
    public Rigidbody rb;           // Corpo do planeta
    public Transform sol;          // Referência ao objeto "Sol"
    public float massaSol = 1000f; // Massa do Sol
    public float constanteGravitacional = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 direcao = sol.position - transform.position;
        float distancia = direcao.magnitude;
        float forca = constanteGravitacional * (massaSol * rb.mass) / (distancia * distancia);
        Vector3 forcaGravitacional = direcao.normalized * forca;

        rb.AddForce(forcaGravitacional);
        //if (GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("Panel/Toggle").GetComponent<Toggle>().isOn)
        //{
        //}
    }
}
