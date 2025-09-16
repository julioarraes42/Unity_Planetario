using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GravidadeSimulada : MonoBehaviour
{
    public Rigidbody rb;                // Corpo do planeta
    public Transform[] corposCelestes;  // Referência aos corpos celestes que orbitam o Sol
    public float massaSol = 1000f;      // Massa do Sol
    public float constanteGravitacional = 1f;
    public float velocidadeMaxima = 100f; // Limite de velocidade para evitar sumiço

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < corposCelestes.Length; i++)
        {
            if (corposCelestes[i] != null)
            {
                Vector3 direcao = corposCelestes[i].position - transform.position;
                float distancia = direcao.magnitude;

                float forca;
                if ( distancia > 0.001f)
                {
                    if (i == 0)
                    {
                        // Atração pelo "Sol"
                        forca = constanteGravitacional * (massaSol * rb.mass * 10f) / (distancia * distancia);
                    }
                    else
                    {
                        // Atração por outros corpos celestes
                        Rigidbody rbCorpo = corposCelestes[i].GetComponent<Rigidbody>();
                        if (rbCorpo == null) continue;
                        forca = constanteGravitacional * (rbCorpo.mass * rb.mass) / (distancia * distancia);
                    }

                    Vector3 forcaGravitacional = direcao.normalized * forca;
                    // Aplica a força considerando o tempo fixo de atualização
                    rb.AddForce(forcaGravitacional * Time.fixedDeltaTime);
                }
           
            }
        }

        // 🔹 Limitar a velocidade máxima
        if (rb.velocity.magnitude > velocidadeMaxima)
        {
            rb.velocity = rb.velocity.normalized * velocidadeMaxima;
        }
    }
}
