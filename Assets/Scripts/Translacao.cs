using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Translacao : MonoBehaviour
{
    public Transform centro;
    public float EixoMaior;
    public float EixoMenor;
    public float Velocidade;
    public float velocidadeAtual;
    public float angulo;
    public MenuControlador menuControlador;
    public bool linha;

    private float anguloAtual;

    // Update is called once per frame
    void Update()
    {
        velocidadeAtual = Velocidade * menuControlador.velocidade;
        if (centro == null) return;

        if (linha)
        {
            anguloAtual += Velocidade * Time.deltaTime;
        }
        else
        {
                       anguloAtual += velocidadeAtual * Time.deltaTime;
        }

        float radianos = anguloAtual * Mathf.Deg2Rad;

        float x = EixoMaior * Mathf.Cos(radianos);
        float z = EixoMenor * Mathf.Sin(radianos);

        Quaternion rotacao = Quaternion.Euler(0, angulo, 0);
        Vector3 ellipsePos = rotacao * new Vector3(x, 0, z);

        transform.position = centro.position + ellipsePos;

    }
}
