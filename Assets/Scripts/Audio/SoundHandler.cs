using UnityEngine;
using Event = AK.Wwise.Event;

public class SoundHandler : MonoBehaviour
{
    // Wwise References //
    [Header("Wwise Audio Events:")]
    public Event music;

    private void Start()
    {
        music.Post(gameObject);
    }
}
