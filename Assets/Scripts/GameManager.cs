using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject StartScreen;
    public GameObject FinishScreen;
    private bool isGameStarted = false;
    private bool isGameFinished = false;
    [SerializeField] private Bootstrap bootstrap;
    [SerializeField] private Timer timer;

    private void Awake()
    {
        Instance = GetComponent<GameManager>();
        Time.timeScale = 0;
        StartScreen.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit The Game");
        }

        if (Input.anyKeyDown && isGameStarted == false)
        {
            Time.timeScale = 1;
            StartScreen.SetActive(false);
            bootstrap.InitializeTheGame();
            timer.StartTimer();
            isGameStarted = true;
            SoundSystem.Instance.Sound("Start").Play();
        }
        else if (Input.anyKeyDown && isGameFinished)
        {
            FinishScreen.SetActive(false);
            isGameFinished = false;
            // timer.ResetTimer();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public async void FinishTheGame(float waitSeconds = 0)
    {
        await Task.Delay((int)(waitSeconds * 1000));

        FinishScreen.SetActive(true);
        bootstrap.enabled = false;
        isGameFinished = true;
        timer.StopTimer();
    }
}
