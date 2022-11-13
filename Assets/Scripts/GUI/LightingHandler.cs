using System.Collections.Generic;
using Game_Service;
using Game_Service.Front_End_Services;
using Game_Service.Services;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightingHandler : MonoBehaviour, ILightingService
{
    [SerializeField] List<Light2D> levelLights;
    [SerializeField] Light2D globalLight;
    [SerializeField] private float targetGlobalLightIntensity;
    [SerializeField] private List<SpriteRenderer> objectsToHide; 

    private void Start()
    {
        GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(DisableLights);
    }

    private void DisableLights(GameState gameState)
    {
        if (gameState == GameState.EmpActivated)
        {
            float fadeTime = 1.0f;
            float globalLightDimPerLevelLight = (globalLight.intensity - targetGlobalLightIntensity) / levelLights.Count;
            float spriteRendererDimPerLevelLight = 1.0f / levelLights.Count;
            foreach (var levelLight in levelLights)
            {
                LeanTween.delayedCall(gameObject, Random.Range(0.0f, fadeTime), () =>
                {
                    levelLight.gameObject.SetActive(false);
                    globalLight.intensity -= globalLightDimPerLevelLight;
                    foreach (var spriteRenderer in objectsToHide)
                    {
                        spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a * spriteRendererDimPerLevelLight);
                    }
                });
            }

            LeanTween.delayedCall(gameObject, fadeTime, () =>
            {
                GameServiceProvider.GetService<IGameState>().GameState = GameState.IsDark;
            });
        }
    }

    public void RegisterSpriteToHide(SpriteRenderer spriteRenderer)
    {
        objectsToHide.Add(spriteRenderer);
        var gameState = GameServiceProvider.GetService<IGameState>().GameState;
        if (gameState != GameState.Setup)
        {
            spriteRenderer.color = Color.clear;
        }
    }
}