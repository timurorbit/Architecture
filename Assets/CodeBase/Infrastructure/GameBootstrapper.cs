﻿using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] public LoadingCurtain CurtainPrefab;
        
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(CurtainPrefab));
            _game._stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}