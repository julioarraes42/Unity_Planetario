using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuControlador : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public List<GameObject> objetos;
    public GameObject[] centros;
    public GameObject[] planetas;
    public float velocidade;
    public TextMeshProUGUI velocimetro;
    public Toggle[] touggles;
    public bool linhas;
    public GameObject sol;


    public void Update()
    {
        velocimetro.text = (velocidade/10).ToString("F1") + " X";
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
        for (int j = 0; j < planetas.Length; j++)
        {
            if (planetas[j].GetComponent<MenuInformacoesControler>().name == "Saturno")
            {
                planetas[j].transform.Find("Planeta").GetComponent<MeshRenderer>().enabled = true;
                planetas[j].transform.Find("Anel").GetComponent<MeshRenderer>().enabled = true;
                planetas[j].GetComponent<SphereCollider>().enabled = true;
            }
            else
            {
                planetas[j].GetComponent<MeshRenderer>().enabled = true;
                planetas[j].GetComponent<SphereCollider>().enabled = true;
            }

        }

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
    }

    public void DesativarLinhas()
    {
        Debug.Log("Desativando linhas: ");

        linhas = !linhas;

        for (int j = 0; j < centros.Length; j++)
        {
            centros[j].GetComponent<TrailRenderer>().enabled = linhas;
        }
    }

    public void SoltarTodos()
    {
        if (!sol.GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("Panel/Toggle").GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < objetos.Count; i++)
            {
                objetos[i].GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("Panel/Toggle").GetComponent<Toggle>().isOn = false;
                objetos[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
