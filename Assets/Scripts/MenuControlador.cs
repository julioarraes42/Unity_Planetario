using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlador : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public List<GameObject> objetos;
    public GameObject[] centros;
    public float velocidade;
    public TextMeshProUGUI[] velocimetros;
    public Toggle[] touggles;
    public bool linhas;

    public void Update()
    {
        velocimetros[0].text = (velocidade/5).ToString("F1") + " X";
        velocimetros[1].text = (velocidade/5).ToString("F1") + " X";
    }
    public void alterarVelocidade(float novaVelocidade)
    {
        velocidade = novaVelocidade;
    }
    public void Start()
    {
        linhas = true;

        for (int i = 0; i < objetos.Count; i++)
        {
            rigidbodies.Add(objetos[i].GetComponent<Rigidbody>());
        }
    }

    public void resetar()
    {
        for (int i = 0; i < rigidbodies.Count; i++)
        {
            ResetarObjeto(rigidbodies[i]);
        }
    }

    public void ResetarObjeto(Rigidbody rigidbody)
    {
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.transform.localPosition = Vector3.zero;
        rigidbody.transform.localRotation = Quaternion.identity;
        rigidbody.isKinematic = false;
    }

    public void DesativarLinhas()
    {
        Debug.Log("Desativando linhas: ");

        linhas = !linhas;

        for (int i = 0; i < touggles.Length; i++)
        {
            if (touggles[i].isOn != linhas)
            {
                Debug.Log("Corrigindo para" + linhas);
                touggles[i].isOn = linhas;

                for (int j = 0; j < centros.Length; j++)
                {
                    centros[j].GetComponent<TrailRenderer>().enabled = linhas;
                }
            }
        }
    }
}
