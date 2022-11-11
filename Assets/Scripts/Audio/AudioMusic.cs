using UnityEngine;

public class AudioMusic : MonoBehaviour
{

    // Wwise References //
    [Header("Wwise Audio Events:")]
    public AK.Wwise.Event FactoryAmbience;

    private void Start()
    {
        FactoryAmbience.Post(gameObject);
    }
}
