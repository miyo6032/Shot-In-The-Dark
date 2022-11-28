using System.Collections.Generic;
using Game_Service;
using Game_Service.Front_End_Services;
using Game_Service.Services;
using Level_Objects;
using Lighting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.U2D;

public class LightingHandler : MonoBehaviour, ILightingService
{
    public const float FadeTime = 1.0f;
    [SerializeField] List<LevelLight> levelLights;
    [SerializeField] Light2D globalLight;
    [SerializeField] private float targetGlobalLightIntensity;
    [SerializeField] private List<HideableVisual> objectsToHide;

    private void Start()
    {
        GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(DisableLights);
    }

    private void DisableLights(GameState gameState)
    {
        if (gameState == GameState.EmpActivated)
        {
            float globalLightDimPerLevelLight = (globalLight.intensity - targetGlobalLightIntensity) / levelLights.Count;
            float spriteRendererDimPerLevelLight = 1.0f / levelLights.Count;
            foreach (var levelLight in levelLights)
            {
                LeanTween.delayedCall(gameObject, Random.Range(0.0f, FadeTime), () =>
                {
                    levelLight.TurnOff();
                    globalLight.intensity -= globalLightDimPerLevelLight;
                    foreach (var spriteRenderer in objectsToHide)
                    {
                        spriteRenderer.Hide(spriteRendererDimPerLevelLight);
                    }
                });
            }

            LeanTween.delayedCall(gameObject, FadeTime, () =>
            {
                GameServiceProvider.GetService<IGameState>().GameState = GameState.IsDark;
                foreach (var spriteRenderer in objectsToHide)
                {
                    spriteRenderer.Hide(0f);
                }
            });
        }
    }

    public static void SetReducedAlpha(SpriteRenderer spriteRenderer, float spriteRendererDimPerLevelLight)
    {
        var color = spriteRenderer.color;
        color = new Color(color.r, color.g, color.b, color.a * spriteRendererDimPerLevelLight);
        spriteRenderer.color = color;
    }

    public void RegisterSpriteToHide(HideableVisual spriteRenderer)
    {
        objectsToHide.Add(spriteRenderer);
        var gameState = GameServiceProvider.GetService<IGameState>().GameState;
        if (gameState != GameState.Setup)
        {
            spriteRenderer.Hide(0.0f);
        }
    }

    public void ShowSpritesInRadius(Vector3 pos, float radius)
    {
        foreach (var spriteRenderer in objectsToHide)
        {
            if ((pos - spriteRenderer.transform.position).sqrMagnitude < radius)
            {
                spriteRenderer.Show();
            } 
        }
    }

    public static void RestoreAlpha(SpriteRenderer spriteRenderer)
    {
        var color = spriteRenderer.color;
        color = new Color(color.r, color.g, color.b, 1.0f);
        spriteRenderer.color = color;
    }
}