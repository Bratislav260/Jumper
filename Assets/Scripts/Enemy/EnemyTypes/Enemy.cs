using UnityEngine;

public abstract class Enemy : MonoBehaviour, IColorful
{
    [field: SerializeField] public Color color { get; set; }

    private void Awake()
    {
        Initialize();
    }

    public virtual void Initialize()
    {
        Rotation();
    }

    public abstract void Reaction(Collision2D collision);

    public virtual void Healing(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
            circle.hitpointsController.Heal();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Reaction(collision);
        Healing(collision);
    }

    public virtual void Rotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-360, 360));
    }

    public void Dead()
    {
        ParticalSystem.Instance.CallDestroyPartical(transform);
        Destroy(gameObject);
    }
}
