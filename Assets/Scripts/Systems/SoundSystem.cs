using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem Instance { get; private set; }
    [SerializeField] private Sound[] sounds;

    public void Initialize()
    {
        Instance = this;
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audioClip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public AudioSource Sound(string name)
    {
        foreach (var s in sounds)
        {
            if (s.name == name)
            {
                return s.source;
            }
            else
            {
                // Debug.Log($"{s.name} - нет такого звука");
            }
        }
        return null;
    }
}
