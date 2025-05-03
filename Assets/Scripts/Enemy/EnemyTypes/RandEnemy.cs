using System.Collections.Generic;
using UnityEngine;

public class RandEnemy : Enemy
{
    [SerializeField] private float force = 4;
    private List<Vector3> RandomDirection = new List<Vector3>();

    public override void Initialize()
    {
        base.Initialize();

        RandomDirection.AddRange(new[] { transform.up, transform.right, -transform.up, -transform.right });
    }

    public override void Reaction(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
        {
            Vector2 randVector = RandomDirection[Random.Range(0, RandomDirection.Count)];
            circle.jumpController.Jumping(randVector * force, true);

            SoundSystem.Instance.Sound("Hit").Play();
            CinemachineShake.Instance.ShakeCamera(5f);
            Dead();
        }
    }
}
