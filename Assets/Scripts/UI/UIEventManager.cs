using UnityEngine.Events;

public class UIEventManager
{
    public static UnityEvent<float> onHitpoints = new UnityEvent<float>();

    public static void HealbarUpdate(float hitpoints)
    {
        onHitpoints.Invoke(hitpoints);
    }
}
