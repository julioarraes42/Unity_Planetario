using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    public float velocidadeRotacao = 10f;

    void Update()
    {
        // Rotaciona em torno do eixo Y
        transform.Rotate(Vector3.forward * velocidadeRotacao * Time.deltaTime);
    }
}
