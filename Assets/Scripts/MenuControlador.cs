using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuControlador : MonoBehaviour
{
    public List<Rigidbody> rigidbodies;
    public List<GameObject> objetos;
    public GameObject[] centroLinhas;
    public GameObject[] planetas;
    public GameObject[] centros;
    public float velocidade;
    public TextMeshProUGUI velocimetro;
    public Toggle[] touggles;
    public bool linhas;
    public GameObject sol;
    public GameObject menuVelocidade;

    // InputActions dos botoes
    public InputAction botaoVelocidade;
    public InputAction botaoLinhas;
    public InputAction botaoResetar;

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
        menuVelocidade.SetActive(false);
        linhas = false;

        for (int i = 0; i < objetos.Count; i++)
        {
            rigidbodies.Add(objetos[i].GetComponent<Rigidbody>());
        }
    }

    private void resetar(InputAction.CallbackContext context)
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

    private void ResetarObjeto(Rigidbody rigidbody)
    {
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.transform.localPosition = Vector3.zero;
        rigidbody.transform.localRotation = Quaternion.identity;
    }

    public void desativarLinhas(InputAction.CallbackContext context)
    {
        Debug.Log("Desativando linhas: ");

        linhas = !linhas;

        for (int j = 0; j < centroLinhas.Length; j++)
        {
            centroLinhas[j].GetComponent<TrailRenderer>().enabled = linhas;
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

            ///for (int j = 0; j < centros.Length; j++)
            ///{
            ///    centros[j].GetComponent<Translacao>().ativo = false;
            ///}
        }
    }

    private void abrirMenuVelocidade(InputAction.CallbackContext context)
    {
        menuVelocidade.SetActive(!menuVelocidade.activeSelf);
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void OnEnable()
    {
        botaoVelocidade.Enable();
        botaoLinhas.Enable();
        botaoResetar.Enable();
        botaoVelocidade.performed += abrirMenuVelocidade;
        botaoLinhas.performed += desativarLinhas;
        botaoResetar.performed += resetar;
    }

    public void OnDisable()
    {
        botaoVelocidade.Disable();
        botaoLinhas.Disable();
        botaoResetar.Disable();
        botaoVelocidade.performed -= abrirMenuVelocidade;
        botaoLinhas.performed -= desativarLinhas;
        botaoResetar.performed -= resetar;
    }
}
