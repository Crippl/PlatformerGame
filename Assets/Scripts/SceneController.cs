using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject youLooseScreen;
    [SerializeField] private GameObject levelWinScreen;
    private int maxGameLevel;
    private Health playerHealth;
    private PlayerHUD playerHUD;
    private int mainMenuIndex = 0;

    private void Start()
    {
        playerHUD=player.GetComponent<PlayerHUD>();
        maxGameLevel = SceneManager.sceneCountInBuildSettings - 1;
        playerHealth=player.GetComponent<Health>();
    }

    private void Update()
    {
        CheckPlayerDeath();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        playerHUD.TotalScoreSumm();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuIndex);
    }

    public void StartGame()
    {
        playerHUD.MainMenuStartGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void CheckPlayerDeath()
    {
        if (playerHealth.CheckIsAlive() == false)
        {
            youLooseScreen.SetActive(true);
        }
    }

    public void YouWin()
    {
        playerHUD.LevelScoreSumm();
        if (SceneManager.GetActiveScene().buildIndex == maxGameLevel)
        {
            levelWinScreen.SetActive(true);
            playerHUD.TotalScoreSumm();
        }
        else levelWinScreen.SetActive(true);
    }
}
