using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Util;

public class SightRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float length;
    private bool rendererEnabled;

    public void Start()
    {
        GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(EnableSightRender);
        lineRenderer.positionCount = 2;
    }

    private void EnableSightRender(GameState gameState)
    {
        if (gameState == GameState.IsDark)
        {
            rendererEnabled = true;
        }
    }

    public void Update()
    {
        if (GameServiceProvider.GetService<IGamePauseService>().IsGamePaused) return;
        if (GameServiceProvider.GetService<IGameState>().GameState != GameState.IsDark) return;
        lineRenderer.enabled = rendererEnabled;
        
        var position = transform.position;
        lineRenderer.SetPosition(0, position);

        Vector2 shootDirection = MathUtils.CalculateShootDirection2D(Input.mousePosition, position);
        lineRenderer.SetPosition(1, position + (Vector3)(shootDirection * 5));
    }


}