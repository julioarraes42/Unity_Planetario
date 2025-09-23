using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ponteiros : MonoBehaviour
{
    public GameObject[] ponteiros;

    public void Update()
    {
        // O ponteiro sempre olha para a camera em relação ao eixo Y
        foreach (GameObject ponteiro in ponteiros)
        {
            Vector3 lookPos = Camera.main.transform.position - ponteiro.transform.position;
            lookPos.y = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            ponteiro.transform.rotation = rotation;
        }
    }
}
