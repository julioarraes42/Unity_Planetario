using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using UnityEngine.UI;

public class CinturaoAsteroides : MonoBehaviour
{
    public Transform centro;
    public GameObject[] modelosAsteroides;
    public int quantidade = 100;
    public float eixoMaior = 50f;
    public float eixoMenor = 30f;
    public float larguraCinturao = 5f; 
    public float alturaCinturao = 10f;
    public float velocidade = 10f;
    public MenuControlador menuControlador;
    public GameObject[] corposCelestes;

    private List<float> alturasY = new List<float>();
    private List<float> deslocamentos = new List<float>();
    private List<Transform> asteroides = new List<Transform>();
    private List<float> angulos = new List<float>();
    private float velocidadeBase;
    [SerializeField]private List<GameObject> asteroidesGerados = new List<GameObject>();

    void Start()
    {
        velocidadeBase = velocidade;

        GerarCinturao();
    }

    void Update()
    {
        velocidade = velocidadeBase * menuControlador.velocidade;

        for (int i = 0; i < asteroides.Count; i++)
        {
            if (asteroides[i] != null)
            {
                angulos[i] += velocidade * Time.deltaTime;
                float rad = angulos[i] * Mathf.Deg2Rad;

                float deslocamento = deslocamentos[i];

                float x = (eixoMaior + deslocamento) * Mathf.Cos(rad);
                float z = (eixoMenor + deslocamento) * Mathf.Sin(rad);

                Vector3 pos = centro.position + new Vector3(x, alturasY[i], z);
                asteroides[i].position = pos;

                // Rotação leve do asteroide
                asteroides[i].Rotate(Vector3.up * Time.deltaTime * 20f);
            }
        }
    }

    public void GerarCinturao()
    {
        for (int i = 0; i < quantidade; i++)
        {
            // Escolhe um modelo aleatório
            GameObject prefab = modelosAsteroides[Random.Range(0, modelosAsteroides.Length)];

            // Gera um ângulo aleatório
            float angulo = Random.Range(0f, 360f);
            angulos.Add(angulo);

            // Gera um deslocamento aleatório dentro da largura do cinturão
            float deslocamento = Random.Range(-larguraCinturao, larguraCinturao);
            deslocamentos.Add(deslocamento);

            // Calcula posição elíptica
            float rad = angulo * Mathf.Deg2Rad;
            float x = (eixoMaior + deslocamento) * Mathf.Cos(rad);
            float z = (eixoMenor + deslocamento) * Mathf.Sin(rad);
            float y = Random.Range(-alturaCinturao / 2f, alturaCinturao / 2f);

            Vector3 pos = centro.position + new Vector3(x, y, z);

            alturasY.Add(y);

            GameObject asteroide = Instantiate(prefab, pos, Random.rotation, transform);

            Transform[] transforms = new Transform[corposCelestes.Length];

            for (int j = 0; j < corposCelestes.Length; j++)
            {
                transforms[j] = corposCelestes[j].transform;
            }

            string nomeBase = prefab.name; // Usa o nome do prefab como base
            string nomeUnico = nomeBase + "_" + i;
            asteroide.name = nomeUnico;

            asteroides.Add(asteroide.transform);

            asteroidesGerados.Add(asteroide);
        }
    }

    public void Resetar()
    {
        // Ativa o mesh renderer de todos os asteroides gerados
        foreach (GameObject asteroide in asteroidesGerados)
        {
            if (asteroide != null)
            {
                asteroide.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
