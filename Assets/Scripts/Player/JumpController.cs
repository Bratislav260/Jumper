using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private LineDrawer lineVector;
    private new Rigidbody2D rigidbody;
    private float jumpForce;

    public bool IsAvableToJump = true;
    private bool IsGoingToJumping = false;

    public void Initialize(Rigidbody2D rigidbody, float jumpForce)
    {
        this.rigidbody = rigidbody;
        this.jumpForce = jumpForce;

        lineVector.Initialize();
    }

    public void Jumping(Vector2 direction, bool resetVelocity = false)
    {
        if (resetVelocity)
        {
            rigidbody.velocity = Vector2.zero;
        }

        rigidbody.AddForce(direction * jumpForce, ForceMode2D.Impulse);
    }

    public void GoingToJumping()
    {
        if (IsAvableToJump)
        {
            IsGoingToJumping = true;
            IsAvableToJump = false;
        }
    }

    public void PrepareJumping()
    {
        if (IsGoingToJumping)
        {
            Time.timeScale = 0.2f;
            lineVector.DrawVectorLine(GetMousePosition(), transform.position);
        }
    }

    public void Jumped()
    {
        if (IsGoingToJumping)
        {
            lineVector.CleenLine();

            Vector3 direction = GetMousePosition() - transform.position;
            Jumping(direction, true);

            IsGoingToJumping = false;
            // IsAvableToJump = true;
            Time.timeScale = 1f;
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePosInScreen = Input.mousePosition;
        mousePosInScreen.z = 0f;

        Vector3 mousePosInWorld = Camera.main.ScreenToWorldPoint(mousePosInScreen);

        return mousePosInWorld;
    }
}
