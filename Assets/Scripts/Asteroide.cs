using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public bool solto = false;
    public GameObject explosaoParticulas;


    //private void OnCollisionEnter(Collision collision)
    //{
    //    //sera destruido e soltara particulas no EXATO local da colisao
    //    Instantiate(explosaoParticulas, transform.position, Quaternion.identity);
    //    GetComponent<MeshRenderer>().enabled = false;
    //}

    private void OnTriggerEnter(Collider other)
    {
        //sera destruido e soltara particulas no EXATO local da colisao
        Instantiate(explosaoParticulas, transform.position, Quaternion.identity);
        GetComponent<MeshRenderer>().enabled = false;
    }

}
