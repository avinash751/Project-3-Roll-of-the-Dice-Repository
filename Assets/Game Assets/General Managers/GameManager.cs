using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

   
     
    public float CurrentTime;

    
    

    public enum GameStates
    {
        Start,
        Play,
        End
    }
    public GameStates gameState;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
           
        }
        
    }

    public void Start()
    {
       
      
    }

    void Update()
    {
        CountDownTime();
    }

 

    void CountDownTime()
    {
        CurrentTime += Time.deltaTime;
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quitgame()
    {
        Application.Quit();
    }

    
}
