using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public bool solto = false;


    private void OnCollisionEnter(Collision collision)
    {
        solto = true;
    }
}
