//using UnityEngine;
//using TMPro;
//
//public class GameManager : MonoBehaviour
//{
//    public static GameManager instance; // Singleton para acceder /fácilmente /desde otros scripts
//   
//    public int redBallsCount = 15; // Número de bolas rojas inicialmente
//    public int coloredBallsCount = 6; // Número de bolas de colores inicialmente
//    public int currentPlayer = 1; // Jugador actual (1 o 2)
//    public int redBallsPottedByPlayer1 = 0; // Contador de bolas rojas metidas por el jugador 1 en el turno actual
//    public int coloredBallsPottedByPlayer1 = 0; // Contador de bolas de colores metidas por el jugador 1 en el turno actual
//    public int redBallsPottedByPlayer2 = 0; // Contador de bolas rojas metidas por el jugador 2 en el turno actual
//    public int coloredBallsPottedByPlayer2 = 0; // Contador de bolas de colores metidas por el jugador 2 en el turno actual
//    public int redBallsPotted = 0; // Contador de bolas rojas metidas
//    public int coloredBallsPotted = 0; // Contador de bolas de colores metidas
//    public GameObject panelGameOver;
//
//    public Player Camilo;
//    public Player MariaDelMar;
//
//    public bool player1 , player2 ;
//    public GameObject[] ballsprefabs;
//    public bool estanMoviendose = false;
//    public bool whiteIn = false;
//    public bool golpeBlanca = false;
//    bool bolaMetida = false;
//      
//    private bool bolaBlancaGolpeada = false; // Bandera para verificar si la bola blanca ha sido golpeada en el turno actual
//    private bool algunaBolaEntrada = false; // Bandera para verificar si alguna bola ha entrado en el hoyo en el turno actual
//
//    public bool pausar = false;
//    public int CamiloScore , MariaDelMarScore;
//    public TMP_Text camiloPuntos, mariadelMarPuntos;
//    [SerializeField] Transform positionInicial;
//
//    public TMP_Text turnText;
//
//    [System.Serializable]
//    public class Player
//    {
//        public string playerName;
//        public int score;
//
//        public Player(string name)
//        {
//            playerName = name;
//            score = 0;
//        }
//    }
//
//    void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//            return;
//        }
//
//        // Configurar jugadores
//        Camilo = new Player("Camilo");
//        MariaDelMar = new Player("Maria del Mar");
//    }
//    public void EndTurn()
//    {
//        // Verificar si se han metido bolas durante el turno actual
//        if (bolaBlancaGolpeada== true && redBallsPotted == 0 && coloredBallsPotted == 0)
//        {
//            ChangeTurn();
//        }
//
//        // Reiniciar contadores para el siguiente turno
//        redBallsPotted = 0;
//        coloredBallsPotted = 0;
//        // Verificar si se han metido bolas durante el turno actual
//        if (currentPlayer == 1)
//        {
//            if (redBallsPottedByPlayer1 == 0 && coloredBallsPottedByPlayer1 == 0)
//            {
//                ChangeTurn();
//                Invoke("UpdateTurnText", .5f);
//                return;
//            }
//        }
//        else if (currentPlayer == 2)
//        {
//            if (redBallsPottedByPlayer2 == 0 && coloredBallsPottedByPlayer2 == 0)
//            {
//                ChangeTurn();
//                Invoke("UpdateTurnText", .5f);
//                return;
//            }
//        }
//        // Reiniciar contadores para el siguiente turno
//        redBallsPottedByPlayer1 = 0;
//        coloredBallsPottedByPlayer1 = 0;
//        redBallsPottedByPlayer2 = 0;
//        coloredBallsPottedByPlayer2 = 0;      
//    }
//   
//    public void Start()
//    {
//        panelGameOver.SetActive(false);
//        player1 = true;
//        UpdateTurnText();
//        IniciarJuego();
//    }
//    public void Update()
//    {
//        camiloPuntos.text = CamiloScore.ToString();
//        mariadelMarPuntos.text = MariaDelMarScore.ToString();
//        BolaEntrada();
//       
//        // Verifica si no hay bolas en movimiento y ninguna bola ha sido metida
//        if ( !algunaBolaEntrada && !pausar)
//        {
//            // Cambia de turno automáticamente
//            ChangeTurn();
//             //EndTurn();
//        }
//    }
//    public void IniciarJuego()
//    {       
//        bolaBlancaGolpeada = false;
//        algunaBolaEntrada = false;
//      
//    }
//    public void BolaEntrada()
//    {
//        // Marca que alguna bola ha entrado en el hoyo
//        algunaBolaEntrada = true;
//    }
//   
//    private void LateUpdate()
//    {
//        if (golpeBlanca)
//            checkBallMovement();
//      
//    }
//    public void checkBallMovement()
//    {
//        int counter = 0;
//        for (int i = 0; i < ballsprefabs.Length; i++)
//        {
//            if (ballsprefabs[i].GetComponent<Rigidbody>().velocity.magnitude == 0f)
//            {               
//                counter++;
//                if (counter == 15)
//                {
//                    estanMoviendose = false;
//                    bolaMetida = false;
//                    //ChangeTurn();
//                }
//            }
//        }
//        if(!bolaMetida && !estanMoviendose )
//        {
//            ChangeTurn();
//        }
//    }
//    public void OnTriggerEnter(Collider other)
//    {
// 
//        if (other.gameObject.GetComponent<BallsState>())
//        {
//            Destroy(other.gameObject);
//        }
//        else
//        {
//            other.gameObject.transform.position = positionInicial.position;
//            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
//            other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
//        }    
//    }
//    public void ChangeTurn()
//    {
//        currentPlayer = (currentPlayer == 1) ? 2 : 1;
//        UpdateTurnText();
//        Debug.Log("Cambio de turno: Jugador " + currentPlayer);
//    }
//   
//    public void UpdateTurnText()
//    {
//        string playerName = (currentPlayer == 1) ? "Camilo" : "Maria del Mar";
//        if (currentPlayer == 1)
//        {
//            turnText.text = "Turno de " + playerName;
//        }
//        else if (currentPlayer == 2)
//        {
//            turnText.text = "Turno de " + playerName;
//        }
//    }
//    public void GameOver()
//    {
//        if(redBallsCount == 15 && coloredBallsPotted == 6)
//        {
//            panelGameOver.SetActive(true);
//
//        }
//    }
//   
//
//}

using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton para acceder fácilmente desde otros scripts
    Cue cue;
    public enum PlayerID { Jugador1, Jugador2 }
    public PlayerID currentPlayer = PlayerID.Jugador1; // Jugador actual (1 o 2)

    public int redBallsCount = 15; // Número de bolas rojas inicialmente
    public int coloredBallsCount = 6; // Número de bolas de colores inicialmente
    public int RedBallMetidasJ1 = 15;
    public int RedBallMetidasJ2 = 15;
    public TMP_Text turnText;
    [SerializeField] Transform positionInicial;
    public GameObject panelGameOver;
    public bool pausar = false;
    public bool algunaBolaEntrada = false;
    public TMP_Text camiloPuntos, mariadelMarPuntos;
    public int MariaDelMarScore = 0;
    public int CamiloScore = 0;
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

    public void Start()
    {
        panelGameOver.SetActive(false);
        UpdateTurnText();
    }
    public void EndTurn()
    {
        if (algunaBolaEntrada == true && cue.heGolpeadoBola == true)
        {
            Debug.Log("no he metido bolas");
            ChangeTurn();
            return; // Salir de la función si se cambió de turno   
        }
        // Verificar si se han metido bolas durante el turno actual
        else 
        {
            Debug.Log("he metido");
        
        }
        
        // Reiniciar la bandera para el próximo turno
        algunaBolaEntrada = false;
        //ChangeTurn();
       
    }

    public void BolaEntrada()
    {
        // Marca que alguna bola ha entrado en el hoyo
        algunaBolaEntrada = true;
    }


    public void Update()
    {
        camiloPuntos.text = CamiloScore.ToString();
        mariadelMarPuntos.text = MariaDelMarScore.ToString();
        //BolaEntrada();

        GameOver();

    }
    public void OnTriggerEnter(Collider other)
    {
    
          if (other.gameObject.GetComponent<BallsState>())
          {
              Destroy(other.gameObject);
          }
          else
          {
              other.gameObject.transform.position = positionInicial.position;
              other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
              other.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
          }    
    }
    public void ChangeTurn()
    {
        currentPlayer = (currentPlayer == PlayerID.Jugador1) ? PlayerID.Jugador2 : PlayerID.Jugador1;
        SoundManager.instance.PlayTurnChangeSound();
        UpdateTurnText();
    }

    void UpdateTurnText()
    {
        string playerName = (currentPlayer == PlayerID.Jugador1) ? "Jugador 1" : "Jugador 2";
        turnText.text = "Turno de " + playerName;
    }

    public void GameOver()
    {
        if(redBallsCount == 0 && coloredBallsCount == 3)
        {
            panelGameOver.SetActive(true);
  
        }
    }
}
