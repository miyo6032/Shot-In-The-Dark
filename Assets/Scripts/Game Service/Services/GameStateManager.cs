namespace Game_Service.Services
{
    public class GameStateManager : IGameState
    {
        public GameState GameState { get; set; }
    }

    public interface IGameState : IGameService
    {
        public GameState GameState { get; set; }
    }

    public enum GameState
    {
        Setup,
        Emp
    }
}