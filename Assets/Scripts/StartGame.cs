using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class StartGame : MonoBehaviour
{
    public GameObject canvasToClose; 
    private Button startButton;
    public bool isGameActive = true;
    public GameObject gameOverPanel; 
    private void Start()
    { 
        startButton = GetComponent<Button>();
       
    }
    
    public void StartAndClose()
    {
        canvasToClose.SetActive(false); 
      
    }
    public void GameOver()
    {
        if (isGameActive)
        {
            isGameActive = false;
            gameOverPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}