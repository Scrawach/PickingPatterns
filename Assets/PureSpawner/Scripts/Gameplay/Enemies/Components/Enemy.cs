using PureSpawner.Gameplay.Enemies.Services;
using PureSpawner.Infrastructure.Pausing;
using UnityEngine;
using Zenject;

namespace PureSpawner.Gameplay.Enemies.Components
{
    public class Enemy : MonoBehaviour, IPause
    {
        private int _health;
        private float _speed;

        private IEnemyTarget _target;

        private bool _isPaused;

        [Inject]
        private void Construct(IEnemyTarget target, PauseHandler pauseHandler)
        {
            _target = target;
            pauseHandler.Add(this);
        }

        public virtual void Initialize(int health, float speed)
        {
            _health = health;
            _speed = speed;
        }

        private void Update()
        {
            if (_isPaused)
                return;

            var direction = (_target.Position - transform.position).normalized;
            Debug.Log($"{_speed}");
            transform.position += direction * _speed * Time.deltaTime;
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        public void MoveTo(Vector3 position) => 
            transform.position = position;

        public void SetPause(bool isPause) => 
            _isPaused = isPause;
    }
}