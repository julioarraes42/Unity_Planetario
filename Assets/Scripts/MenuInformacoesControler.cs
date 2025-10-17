using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuInformacoesControler : MonoBehaviour
{
    public string nome;
    public string descricao;
    public string massa;
    public string raio;
    public string distanciaSol;
    public string curiosidade;

    public GameObject menuInformacoes;
    public GameObject menuInstanciadoInformacoes;

    public MenuControlador menuControlador;

    private bool segurado = false;

    public void Start()
    {
        menuInstanciadoInformacoes = Instantiate(menuInformacoes, transform.position, Quaternion.identity);
        menuInstanciadoInformacoes.name = "MenuInformacoes_" + nome; // Nome único para o menu instanciado

        menuInstanciadoInformacoes.transform.Find("Azul/NomePlaneta").GetComponent<TextMeshProUGUI>().text = nome;
        menuInstanciadoInformacoes.transform.Find("Azul/Descricao").GetComponent<TextMeshProUGUI>().text = descricao;
        menuInstanciadoInformacoes.transform.Find("Verde/EstatisticasMassa/MassaTexto").GetComponent<TextMeshProUGUI>().text = massa + " kg";
        menuInstanciadoInformacoes.transform.Find("Verde/EstatisticasRaio/RaioTexto").GetComponent<TextMeshProUGUI>().text = raio + " km";
        menuInstanciadoInformacoes.transform.Find("Verde/EstatisticasSol/SolDistanceTexto").GetComponent<TextMeshProUGUI>().text = distanciaSol + " km";
        menuInstanciadoInformacoes.transform.Find("Vermelho/PanelCuriosidade/CuriosidadeTexto").GetComponent<TextMeshProUGUI>().text = curiosidade;

        menuInstanciadoInformacoes.SetActive(false); // Inicialmente desabilitar o menu
    }

    public void Update()
    {
        // Manter o menu instanciado preso ao planeta um pouco acima dele
        if (menuInstanciadoInformacoes != null)
        {
            menuInstanciadoInformacoes.transform.position = transform.position + new Vector3(0, 1f, 0);
        }

        // Manter o menu instanciado sempre voltado para a câmera
        if (menuInstanciadoInformacoes != null)
        {
            menuInstanciadoInformacoes.transform.LookAt(Camera.main.transform);
            menuInstanciadoInformacoes.transform.Rotate(0, 180, 0); // Ajustar a rotação para que fique voltado para o jogador
        }

        if (menuControlador.informacoesVisiveis && segurado) {
            menuInstanciadoInformacoes.SetActive(true);
        } else { 
            menuInstanciadoInformacoes.SetActive(false);
        }
    }
    public void AbilitarMenu()
    {
        segurado = true;
    }
    
    public void DesabilitarMenu()
    {
        segurado = false;
    }


}
