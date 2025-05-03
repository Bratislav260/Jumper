using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] private AnimationCurve cameraSizeCurve;
    [SerializeField] private Transform ground;
    [SerializeField] private Circle player;

    public void ChageCameraSize()
    {
        float height = Mathf.Abs(player.transform.position.y - ground.position.y);
        // Debug.Log(height);

        float newSize = cameraSizeCurve.Evaluate(height);

        virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(virtualCamera.m_Lens.OrthographicSize, newSize, Time.deltaTime * 2f);
    }
}
