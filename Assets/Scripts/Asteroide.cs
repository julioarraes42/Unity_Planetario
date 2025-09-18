using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public bool solto = false;
    public GameObject explosaoParticulas;


    private void OnCollisionEnter(Collision collision)
    {
        //sera destruido e soltara particulas no EXATO local da colisao
        solto = true;
        Instantiate(explosaoParticulas, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
