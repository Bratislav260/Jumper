using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] Circle circle;
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] CameraController cameraController;
    [SerializeField] PlatformSetManager platformSetManager;
    [SerializeField] UIController uIController;
    [SerializeField] SoundSystem soundSystem;
    [SerializeField] ParticalSystem particalSystem;
    [SerializeField] CinemachineShake cinemachineShake;

    private void Awake()
    {
        enabled = false;
    }

    public void InitializeTheGame()
    {
        enabled = true;

        circle.Initialize();
        enemySpawner.Initialize();
        platformSetManager.Initialize();
        uIController.Initialize();
        soundSystem.Initialize();
        particalSystem.Initialize();
        cinemachineShake.Initialize();
    }

    private void Update()
    {
        if (circle != null)
        {
            circle.PlayerUpdate();
            enemySpawner.CleanTheMap();
            cameraController.ChageCameraSize();
            platformSetManager.SetNewPlatform();
        }

        uIController.UIUpdate();
    }
}
