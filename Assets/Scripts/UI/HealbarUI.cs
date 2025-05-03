using UnityEngine;
using UnityEngine.UI;

public class HealbarUI : MonoBehaviour
{
    [SerializeField] private Image healBar;

    public void Initialize()
    {
        UIEventManager.onHitpoints.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar(float hp)
    {
        healBar.fillAmount = hp;
    }
}
