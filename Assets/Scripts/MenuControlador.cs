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
    public GameObject[] grades;
    public GameObject[] planetas;
    public GameObject[] centros;
    public float velocidade;
    public TextMeshProUGUI textoVelocidade;
    public Toggle[] touggles;
    public bool linhas;
    public GameObject sol;
    public GameObject menuVelocidade;
    public GameObject asteroideControlador;
    //public GameObject banerInformacaoControle;
    public bool informacoesVisiveis = false;

    private float[] velocidades = { 0f, 0.2f, 0.5f, 1f, 2f, 5f, 10f};

    // InputActions dos botoes
    public InputAction botaoVelocidade;
    public InputAction botaoLinhas;
    public InputAction botaoResetar;
    public InputAction botaoInformacoes;

    public void Update()
    {

    }
    public void alterarVelocidade(int velocidade)
    {
        this.velocidade = velocidades[velocidade];
        textoVelocidade.text = velocidades[velocidade].ToString();
    }
    public void Start()
    {
        menuVelocidade.SetActive(false);
        linhas = false;

        for (int i = 0; i < objetos.Count; i++)
        {
            rigidbodies.Add(objetos[i].GetComponent<Rigidbody>());
        }

        alterarVelocidade(3);
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

        asteroideControlador.GetComponent<CinturaoAsteroides>().Resetar();

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
        linhas = !linhas;

        for (int k = 0; k < grades.Length; k++)
        {
            Debug.Log(linhas);
            grades[k].SetActive(linhas);
        }
    }

    public void SoltarTodos()
    {
        if (!sol.GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("PermanecerOrbita/Toggle").GetComponent<Toggle>().isOn)
        {
            for (int i = 0; i < objetos.Count; i++)
            {
                objetos[i].GetComponent<MenuInformacoesControler>().menuInstanciadoInformacoes.transform.Find("PermanecerOrbita/Toggle").GetComponent<Toggle>().isOn = false;
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

    public void InformacoesVisiveis(InputAction.CallbackContext context)
    {
        informacoesVisiveis = !informacoesVisiveis;
    }

    public void OnEnable()
    {
        botaoVelocidade.Enable();
        botaoLinhas.Enable();
        botaoResetar.Enable();
        botaoInformacoes.Enable();
        botaoVelocidade.performed += abrirMenuVelocidade;
        botaoLinhas.performed += desativarLinhas;
        botaoResetar.performed += resetar;
        botaoInformacoes.performed += InformacoesVisiveis;
    }

    public void OnDisable()
    {
        botaoVelocidade.Disable();
        botaoLinhas.Disable();
        botaoResetar.Disable();
        botaoInformacoes.Disable();
        botaoVelocidade.performed -= abrirMenuVelocidade;
        botaoLinhas.performed -= desativarLinhas;
        botaoResetar.performed -= resetar;
        botaoInformacoes.performed -= InformacoesVisiveis;
    }
}
