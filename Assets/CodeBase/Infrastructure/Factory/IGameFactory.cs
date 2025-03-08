using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud(LoadLevelState loadLevelState);
    }
}