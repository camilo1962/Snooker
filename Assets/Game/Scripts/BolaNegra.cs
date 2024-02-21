using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaNegra : MonoBehaviour
{

   
    public Vector3 originalBolaNegraPosition;
    private Rigidbody rb;

    void Start()
    {
        originalBolaNegraPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.redBallsCount >= 1)
        {
            if (other.tag == "Hoyo")
            {
                GameManager.PlayerID player = GameManager.instance.currentPlayer;

                if (player == GameManager.PlayerID.Jugador1)
                {
                    SumarPuntos("Negra", player);
                    Debug.Log("Metió Camilo la bola negra");
                    transform.position = originalBolaNegraPosition;
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                  
                }
                else if (player == GameManager.PlayerID.Jugador2)
                {
                    SumarPuntos("Negra", player);
                    Debug.Log("Metió Maria del Mar la bola negra");
                    transform.position = originalBolaNegraPosition;
                    GetComponent<Rigidbody>().velocity = Vector3.zero;
                    GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                    GameManager.instance.BolaEntrada();
                }
            }
            else
            {
                GameManager.instance.EndTurn();
            }
        }
        else
        {
            if (other.tag == "Hoyo")
            {
                GameManager.PlayerID player = GameManager.instance.currentPlayer;

                if (player == GameManager.PlayerID.Jugador1)
                {
                    SumarPuntos("Negra", player);
                    Debug.Log("Metió Camilo la bola negra");
                    GameManager.instance.algunaBolaEntrada = true;
                    GameManager.instance.coloredBallsCount--;

                }
                else if (player == GameManager.PlayerID.Jugador2)
                {
                    SumarPuntos("Negra", player);
                    Debug.Log("Metió Maria del Mar la bola negra");
                    GameManager.instance.algunaBolaEntrada = true;
                    GameManager.instance.coloredBallsCount--;
                }
            }
            else
            {
                GameManager.instance.EndTurn();
            }

        }


    }

    public void SumarPuntos(string tipoBola, GameManager.PlayerID currentPlayer)
    {
        int puntos = 0;
        GameManager.PlayerID player = GameManager.instance.currentPlayer;
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
