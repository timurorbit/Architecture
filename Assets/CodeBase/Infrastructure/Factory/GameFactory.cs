using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.States;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at)
        {
            return _assets.Instantiate(AssetPath.HeroPath,at: at.transform.position);
        }

        public void CreateHud(LoadLevelState loadLevelState)
        {
            _assets.Instantiate(AssetPath.HudPath);
        }
    }
}