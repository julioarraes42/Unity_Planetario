using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroide : MonoBehaviour
{
    public bool solto = false;
    public GameObject explosaoParticulas;
    private AudioSource explosao;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    //sera destruido e soltara particulas no EXATO local da colisao
    //    Instantiate(explosaoParticulas, transform.position, Quaternion.identity);
    //    GetComponent<MeshRenderer>().enabled = false;
    //}

    private void Start()
    {
        explosao = GameObject.Find("DestruirAsteroide").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<MeshRenderer>().enabled == true)
        {
            //sera destruido e soltara particulas no EXATO local da colisao
            Instantiate(explosaoParticulas, transform.position, Quaternion.identity);
            GetComponent<MeshRenderer>().enabled = false;

            if (explosao != null)
            {
                explosao.Play();
            }
        }
    }

}
