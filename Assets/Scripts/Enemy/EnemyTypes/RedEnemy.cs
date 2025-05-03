using UnityEngine;

public class RedEnemy : Enemy
{
    public override void Reaction(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
        {
            SoundSystem.Instance.Sound("Punch").Play();
            CinemachineShake.Instance.ShakeCamera(10f);
            Dead();
        }
    }
}
