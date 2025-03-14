﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud(LoadLevelState loadLevelState);
        List<ISavedProgressReader> ProgressReaders { get; }
        GameObject HeroGameObject { get; }

        event Action HeroCreated;
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
    }
}