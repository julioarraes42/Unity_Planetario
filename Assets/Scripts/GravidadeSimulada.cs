using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GravidadeSimulada : MonoBehaviour
{
    public Rigidbody rb;           // Corpo do planeta
    public Transform[] corposCelestes; // Referência aos corpos celestes que orbitam o Sol
    public float massaSol = 1000f; // Massa do Sol
    public float constanteGravitacional = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        for (int i = 0; i < corposCelestes.Length; i++)
        {
            if (corposCelestes[i] != null && i == 0)
            {
                Vector3 direcao = corposCelestes[i].position - transform.position;
                float distancia = direcao.magnitude;
                float forca = constanteGravitacional * (massaSol * rb.mass * 10) / (distancia * distancia);
                Vector3 forcaGravitacional = direcao.normalized * forca;

                rb.AddForce(forcaGravitacional);
            }
            else if (corposCelestes[i] != null && i > 0)
            {
                Vector3 direcao = corposCelestes[i].position - transform.position;
                float distancia = direcao.magnitude;
                float forca = constanteGravitacional * (corposCelestes[i].GetComponent<Rigidbody>().mass * rb.mass) / (distancia * distancia);
                Vector3 forcaGravitacional = direcao.normalized * forca;
                rb.AddForce(forcaGravitacional);
            }
        }
    }
}
