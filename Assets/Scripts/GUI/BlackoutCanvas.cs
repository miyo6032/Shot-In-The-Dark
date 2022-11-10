using Game_Service;
using Game_Service.Services;
using UnityEngine;

public class BlackoutCanvas : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;

    private void Start()
    {
        GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(FadeInCanvasGroup);
    }

    private void FadeInCanvasGroup(GameState gameState)
    {
        if (gameState == GameState.EmpActivated)
            LeanTween.value(gameObject, f => canvasGroup.alpha = f, 0f, 1f, 2.0f)
                .setOnComplete(() => GameServiceProvider.GetService<IGameState>().GameState = GameState.IsDark);
    }
}