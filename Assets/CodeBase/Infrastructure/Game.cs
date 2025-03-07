using CodeBase.Services.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine _stateMachine;
        public static IInputService InputService;

        public Game(ICoroutineRunner coroutineRunner)
        {
           _stateMachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}