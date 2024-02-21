using System.Collections.Generic;
using UnityEngine;

public class BolasColores : MonoBehaviour
{
    public static BolasColores instance;


    private Vector3 inicialPosicion;
  

    void Start()
    {
        // Guarda la posición inicial de la bola de color
        inicialPosicion = transform.position;
       
    }

  

    public void OnTriggerEnter(Collider other)
    {

        if (GameManager.instance.redBallsCount >= 1)
        {
            if (other.CompareTag("Hoyo"))
            {
                GameManager.PlayerID player = GameManager.instance.currentPlayer;
                if (player == GameManager.PlayerID.Jugador1)
                {

                    GameManager.instance.BolaEntrada();
                    SoundManager.instance.PlayBallPocketedSound();

                }
                if (player == GameManager.PlayerID.Jugador2)
                {
                    GameManager.instance.BolaEntrada();
                    SoundManager.instance.PlayBallPocketedSound();
                }
            }
            else
            {
                GameManager.instance.EndTurn();
            }
        }
        else
        {
            if (other.CompareTag("Hoyo"))
            {
                GameManager.PlayerID player = GameManager.instance.currentPlayer;
                if (player == GameManager.PlayerID.Jugador1)
                {

                    GameManager.instance.BolaEntrada();
                    SoundManager.instance.PlayBallPocketedSound();
                    
                }
                if (player == GameManager.PlayerID.Jugador2)
                {
                    GameManager.instance.BolaEntrada();
                    SoundManager.instance.PlayBallPocketedSound();
                }
            }
            else
            {
                GameManager.instance.EndTurn();
            }
        }
           
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bordes")
        {
            SoundManager.instance.PlayBallBordeSound();
        }
        if (collision.collider.tag == "Bola")
        {
            SoundManager.instance.PlayBallsCollisionSound();
        }

    }

    void Update()
    {
       
    }

    bool HayBolasRojasRestantes()
    {
        // Aquí deberías implementar la lógica para verificar si quedan bolas rojas en la mesa
        // Por ejemplo, podrías contar cuántas bolas rojas quedan en la mesa y devolver true si hay al menos una
        // Esto puede depender de cómo esté implementado tu juego y cómo estás manejando las bolas rojas
        // Si necesitas ayuda con esta parte específica, avísame y puedo proporcionarte más detalles.
        return true; // Deberías cambiar esto según tu implementación real
    }
}
