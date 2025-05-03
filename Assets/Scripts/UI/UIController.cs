using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private HealbarUI healbarUI;
    [SerializeField] private Timer timer;

    public void Initialize()
    {
        healbarUI.Initialize();
    }

    public void UIUpdate()
    {
        timer.TimerUpdate();
    }
}
