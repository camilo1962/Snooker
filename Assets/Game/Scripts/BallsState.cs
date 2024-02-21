using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsState : MonoBehaviour
{

    

    [SerializeField] private float minBallStopVelocity;
    private List<Rigidbody> _bolas;



    void Start()
    {

        _bolas = new List<Rigidbody>();
        foreach (Transform ball in transform)
        {
            _bolas.Add(ball.GetComponent<Rigidbody>());
        }
    }

    public void RemoveBall(GameObject ball)
    {
        _bolas.Remove(ball.GetComponent<Rigidbody>());
        Destroy(ball);
    }

    public bool BolasEstanParadas()
    {
        foreach (var bolas in _bolas)
        {
            if (bolas.velocity.magnitude > minBallStopVelocity)
            {
                
                return false;
            }
        }
       
        return true;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola") || collision.gameObject.CompareTag("BolaBlanca"))
        {
            // Reproducir el sonido de choque entre bolas
            SoundManager.instance.PlayBallsCollisionSound();
        }
        if (collision.collider.tag == "Bordes")
        {
            SoundManager.instance.PlayBallBordeSound();
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hoyo")
        {
            GameManager.PlayerID player = GameManager.instance.currentPlayer;

            if (player == GameManager.PlayerID.Jugador1)
            {
                SumarPuntos("Roja", player);
                Debug.Log("Metió Camilo la bola roja");
                GameManager.instance.BolaEntrada();
                GameManager.instance.redBallsCount--;
            }
            else if (player == GameManager.PlayerID.Jugador2)
            {
                SumarPuntos("Roja", player);
                Debug.Log("Metió Maria del Mar la bola roja");
                GameManager.instance.BolaEntrada();
                GameManager.instance.redBallsCount--;
            }
            // Llamar a EndTurn() después de manejar la bola que entra en el hoyo
            //GameManager.instance.EndTurn();
        }
        else
        {
            GameManager.instance.EndTurn();
        }
    }

    public void SumarPuntos(string tipoBola, GameManager.PlayerID currentPlayer)
    {
        GameManager.PlayerID player = GameManager.instance.currentPlayer;
        int puntos = 0;

        // Asigna los puntos según el tipo de bola
        switch (tipoBola)
        {
            case "Roja":
                puntos = 1;
                break;
            case "Verde":
                puntos = 2;
                break;
            case "Marron":
                puntos = 3;
                break;
            case "Amarilla":
                puntos = 4;
                break;
            case "Azul":
                puntos = 5;
                break;
            case "Rosa":
                puntos = 6;
                break;
            case "Negra":
                puntos = 7;
                break;
            default:
                Debug.LogError("Tipo de bola desconocido.");
                return;
        }
        // Añade los puntos al jugador correspondiente
        if (player == GameManager.PlayerID.Jugador1)
        {
            GameManager.instance.CamiloScore += puntos;
        }
        else if (player == GameManager.PlayerID.Jugador2)
        {
            GameManager.instance.MariaDelMarScore += puntos;
        }
        else
        {
            Debug.LogError("Número de jugador no válido.");
            return;
        }

        Debug.Log("Puntos del Jugador 1: " + GameManager.instance.CamiloScore);
        Debug.Log("Puntos del Jugador 2: " + GameManager.instance.MariaDelMarScore);
    }
}


