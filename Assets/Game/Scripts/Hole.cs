using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private BallsState ballsState;
    [SerializeField] private LayerMask ballLayer;
    public GameManager turnoManager; // Referencia al TurnoManager

    private void OnTriggerEnter(Collider other)
    {
        if (ballLayer == (ballLayer | (1 << other.gameObject.layer)))
        {
            ballsState.RemoveBall(other.gameObject);
            // Llamar a EndTurn() del GameManager cuando una bola entre en el hoyo
            //turnoManager.EndTurn();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bola") || collision.gameObject.CompareTag("BolaBlanca"))
        {
            SoundManager.instance.PlayBallPocketedSound();
        }
    }
}
