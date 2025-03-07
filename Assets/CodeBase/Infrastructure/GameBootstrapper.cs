﻿using System;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game._stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}