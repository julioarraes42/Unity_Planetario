using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class JogadorControler : MonoBehaviour
{
    public GameObject menu;
    public InputAction botao;

    public void Start()
    {
        menu.SetActive(false);
    }
    private void OnEnable()
    {
        botao.Enable();
        botao.performed += OnBotaoPressionado;
    }

    private void OnDisable()
    {
        botao.Disable();
        botao.performed -= OnBotaoPressionado;
    }

    private void OnBotaoPressionado(InputAction.CallbackContext context)
    {
        menu.SetActive(!menu.activeSelf);
    }
}
