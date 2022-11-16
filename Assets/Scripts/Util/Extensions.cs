using System.Linq;
using Game_Service.Services;

namespace Util
{
    public static class Extensions
    {
        public static bool Contains(this GameState gameState, params GameState[] gameStates)
        {
            return gameStates.Contains(gameState);
        }
    }
}