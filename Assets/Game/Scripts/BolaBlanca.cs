using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaBlanca : MonoBehaviour
{
    public static BolaBlanca instance;

    public GameObject bolaBlanca;
    private Vector3 originalBolaBlancaPosition;

    

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    void Start()
    {
        originalBolaBlancaPosition = bolaBlanca.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bordes")
        {
            Debug.Log("toco borde");
            SoundManager.instance.PlayBallBordeSound();
        }

        
        if (collision.collider.tag == "Bola" || collision.collider.tag == "BolaAmarilla" || collision.collider.tag == "BolaAzul" || collision.collider.tag == "BolaMarron" || collision.collider.tag == "BolaNegra" || collision.collider.tag == "BolaRosa" || collision.collider.tag == "BolaVerde")
        {
            SoundManager.instance.PlayBallsCollisionSound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoyo"))
        {
            // Detiene el movimiento de la bola blanca
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            GameManager.instance.ChangeTurn();
            SoundManager.instance.PlayBallPocketedSound();
            // Mueve la bola blanca de nuevo a su posición inicial
            transform.position = originalBolaBlancaPosition;
        }
    }
}
