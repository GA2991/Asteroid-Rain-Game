using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    public GameObject gameOver;

    public GameObject startButton;
    public GameObject restartButton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        // Suscribirse al evento estático de 'DestroyOutOfBounds'
        DestroyOutOfBounds.onLoser.AddListener(GameOverSequence);
    }

    // Método para ejecutar la secuencia de Game Over
    public void GameOverSequence()
    {
        Debug.Log("Game Over Sequence initiated");
        gameOver.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

