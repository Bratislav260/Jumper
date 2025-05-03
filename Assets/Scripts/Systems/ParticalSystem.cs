using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    public ParticleSystem DestroyPar;
    public static ParticalSystem Instance { get; private set; }

    public void Initialize()
    {
        Instance = this;
    }

    public void CallDestroyPartical(Transform target)
    {
        ParticleSystem tempPartical = Instantiate(DestroyPar, target.position, Quaternion.identity);

        var main = tempPartical.main;

        if (target.TryGetComponent<IColorful>(out var colorful))
        {
            main.startColor = colorful.color;
        }
    }
}