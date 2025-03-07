using CodeBase.Services.Input;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine _stateMachine;
        public static IInputService InputService;

        public Game()
        {
           _stateMachine = new GameStateMachine();
        }
    }
}