using UnityEngine;

public class Circle : MonoBehaviour, IColorful
{
    private new Rigidbody2D rigidbody;
    public JumpController jumpController { get; private set; }
    public HitpointsController hitpointsController { get; private set; }
    private PlayerInput playerInput;

    [field: SerializeField] public float maxHitpoints { get; private set; } = 100;
    [SerializeField] private float jumpForce = 0;
    [field: SerializeField] public Color color { get; set; }


    public void Initialize()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        jumpController = GetComponent<JumpController>();
        jumpController.Initialize(rigidbody, jumpForce);

        hitpointsController = GetComponent<HitpointsController>();
        hitpointsController.Initialize(maxHitpoints);

        playerInput = new PlayerInput();
        playerInput.Initialize(this);
    }

    public void PlayerUpdate()
    {
        playerInput.InputPlayer();
        hitpointsController.DecreaseHitpoints();
    }

    public void SpeedIncrease(float increaseSpeed)
    {
        rigidbody.AddForce(rigidbody.velocity * increaseSpeed, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ReBounce"))
        {
            jumpController.IsAvableToJump = true;
        }
    }
}
