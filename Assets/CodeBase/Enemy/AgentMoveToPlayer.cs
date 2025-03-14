﻿using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace CodeBase.Enemy
{
    public class AgentMoveToPlayer : Follow
    {
        [FormerlySerializedAs("agent")] public NavMeshAgent Agent;
        private Transform _heroTransform;
        private IGameFactory _gameFactory;
        private const float MinimalDistance = 1;


        private void Start()
        {
            _gameFactory = AllServices.Container.Single<IGameFactory>();

            if (_gameFactory.HeroGameObject != null)
            {
                InitializeHeroTransform();
            }
            else
            {
                _gameFactory.HeroCreated += HeroCreated;
            }
        }

        private void Update()
        {
            if (Initialized() && HeroNotReached())
            {
                Agent.destination = _heroTransform.position;
            }
        }

        private bool Initialized()
        {
            return _heroTransform != null;
        }

        private void InitializeHeroTransform()
        {
            _heroTransform = _gameFactory.HeroGameObject.transform;
        }

        private void HeroCreated()
        {
            InitializeHeroTransform();
        }

        private bool HeroNotReached()
        {
            return Vector3.Distance(Agent.transform.position, _heroTransform.position) >= MinimalDistance;
        }
    }
}