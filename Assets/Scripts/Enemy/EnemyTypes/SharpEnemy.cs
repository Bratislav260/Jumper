using UnityEngine;

public class SharpEnemy : Enemy
{
    public override void Reaction(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
        {
            circle.hitpointsController.GetDamage(100);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        Reaction(collision);
    }
}
