using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPontTag = "InitialPoint";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
           _sceneLoader.Load(sceneName, onLoaded); 
        }

        private void onLoaded()
        {
            var hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPontTag));
            _gameFactory.CreateHud(this);
            
            CameraFollow(hero);
            
            _stateMachine.Enter<GameLoopState>();
        }

        private void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);  
        }

        public void Exit()
        {
            _curtain.Hide();
        }
    }
}