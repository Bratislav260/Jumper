using UnityEngine;

public class HitpointsController : MonoBehaviour
{
    private float maxHitpoints;
    private float currentHitpoints;
    [SerializeField] private float perSecDecrease;

    public void Initialize(float maxHitpoints)
    {
        this.maxHitpoints = maxHitpoints;
        currentHitpoints = maxHitpoints;
    }

    public void DecreaseHitpoints()
    {
        if (currentHitpoints < 0)
        {
            Dead();
        }

        if (currentHitpoints > 0)
        {
            currentHitpoints -= perSecDecrease;

            UIEventManager.HealbarUpdate(currentHitpoints / maxHitpoints);
        }
    }

    public void Heal()
    {
        currentHitpoints += 20;

        if (currentHitpoints > 100)
        {
            currentHitpoints = maxHitpoints;
        }
    }

    public void GetDamage(float damage)
    {
        currentHitpoints -= damage;
    }

    private void Dead()
    {
        GameManager.Instance.FinishTheGame(waitSeconds: 2);
        ParticalSystem.Instance.CallDestroyPartical(transform);
        SoundSystem.Instance.Sound("Death").Play();
        CinemachineShake.Instance.ShakeCamera(30f);
        Destroy(gameObject);
    }
}
