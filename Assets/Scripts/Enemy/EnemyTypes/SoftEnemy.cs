using UnityEngine;

public class SoftEnemy : Enemy
{
    [SerializeField] private float increaseSpeed;
    public override void Reaction(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
        {
            circle.SpeedIncrease(increaseSpeed);

            SoundSystem.Instance.Sound("Jump").Play();
            CinemachineShake.Instance.ShakeCamera(3f);
            Dead();
        }
    }
}
