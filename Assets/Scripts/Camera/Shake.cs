using UnityEngine;
using Cinemachine;
using System.Collections;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;

    public void Initialize()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBMCP =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBMCP.m_AmplitudeGain = intensity;

        StartCoroutine(ShakeTimer(cinemachineBMCP));
    }

    private IEnumerator ShakeTimer(CinemachineBasicMultiChannelPerlin cinemachineBMCP)
    {
        while (0 < cinemachineBMCP.m_AmplitudeGain)
        {
            cinemachineBMCP.m_AmplitudeGain -= 0.2f;

            yield return null;
        }

        cinemachineBMCP.m_AmplitudeGain = 0;
    }
}
