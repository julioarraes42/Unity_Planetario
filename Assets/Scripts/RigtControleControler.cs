using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigtControleControler : MonoBehaviour
{
    public MenuControlador menuControlador;
    public GameObject uI;


    private void Start()
    {
        GameObject obj = GameObject.Find("Menu");
        menuControlador = obj.GetComponent<MenuControlador>();
    }
    void Update()
    {
        if (menuControlador.informacoesVisiveis)
        {
            uI.SetActive(true);
        }
        else
        {
            uI.SetActive(false);
        }
    }
}
