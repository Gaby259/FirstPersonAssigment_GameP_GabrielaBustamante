using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;

    void Start()
    {
        _pauseMenu.SetActive(false);
    }

    void Update()
    {
        TriggerPauseMenu();
    }
   
    //Move to the second part of the game
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SecondScene");
        }
    }
    //Move to the END menu 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinalObject"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("FinishScene");
        }
    }
    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void TriggerPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("x is pressed");
            if (_pauseMenu.activeInHierarchy)
            {
                ResumeGame();
            }
            else
            {
                _pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
       
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void QuitGame()
    {
            Application.Quit();
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Puzzle2()
    {
        SceneManager.LoadScene("SecondScene");
    }
    public void Puzzle1()
    {
        SceneManager.LoadScene("StartScene");
    }
    
    
}
