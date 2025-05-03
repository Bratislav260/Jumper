using UnityEngine;

public class PlayerInput
{
    private Circle player;

    public void Initialize(Circle player)
    {
        this.player = player;
    }

    public void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Debug.Log("MouseButton - Down");
            player.jumpController.GoingToJumping();
        }
        if (Input.GetMouseButton(0))
        {
            player.jumpController.PrepareJumping();
        }
        if (Input.GetMouseButtonUp(0))
        {
            // Debug.Log("MouseButton - Up");
            player.jumpController.Jumped();
        }
    }
}
