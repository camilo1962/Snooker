using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    // Referencias a los clips de audio
    public AudioClip cueBallCollisionClip;
    public AudioClip ballsCollisionClip;
    public AudioClip ballPocketedClip;
    public AudioClip turnChangeClip;
    public AudioClip gameWonClip;
    public AudioClip bolanegraDentroClip;
    public AudioClip bolaBordesClip;
    public AudioClip bolaTrayClip;





    // Referencia al AudioSource para reproducir los clips de audio
    public AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

    // Método para inicialización
    void Start()
    {
        // Obtener el componente AudioSource adjunto a este objeto
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproducir el sonido de choque de taco-bola
    public void PlayCueBallCollisionSound()
    {
        PlaySound(cueBallCollisionClip);
    }

    // Método para reproducir el sonido de choque entre bolas
    public void PlayBallsCollisionSound()
    {
        PlaySound(ballsCollisionClip);
    }

    // Método para reproducir el sonido de bola metida
    public void PlayBallPocketedSound()
    {
        PlaySound(ballPocketedClip);
    }

    // Método para reproducir el sonido de cambio de turno
    public void PlayTurnChangeSound()
    {
        PlaySound(turnChangeClip);
    }

    // Método para reproducir el sonido de partida ganada
    public void PlayGameWonSound()
    {
        PlaySound(gameWonClip);
    }
    // Método para reproducir el sonido de bola negra metida
    public void PlayBallBlackSound()
    {
        PlaySound(bolanegraDentroClip);
    }

    // Método para reproducir el sonido de bola en el borde
    public void PlayBallBordeSound()
    {
        PlaySound(bolaBordesClip);
    }
    // Método para reproducir el sonido de bola por el tray
    public void PlayBallTraySound()
    {
        PlaySound(bolaTrayClip);
    }
    // Método privado para reproducir un clip de audio
    private void PlaySound(AudioClip clip)
    {
        // Reproducir el clip de audio en el AudioSource
        audioSource.PlayOneShot(clip);
    }
}
