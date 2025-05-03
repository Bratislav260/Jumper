using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Circle>(out var circle))
        {
            circle.hitpointsController.GetDamage(100);
        }

        // ParticalManager.Instance.DestroyParticalCall(collision.transform);
    }

}
