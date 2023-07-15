using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class CubesHandler : MonoBehaviour
    {
        [SerializeField] private StickMan _stickMan;
        [SerializeField] private PlayerCube _startCube;

        [Header("Player cube prefab")] 
        [SerializeField] private PlayerCube _playerCubePrefab;
        
        private List<PlayerCube> _cubes = new();
        public event Action OnCollide;
        public event Action<Vector3> OnPicked;

        private void Start()
        {
            Subscribe(_startCube);
            _cubes.Add(_startCube);
        }

        private void Subscribe(PlayerCube playerCube)
        {
            playerCube.OnPickupTriggered += PickupTriggered;
            playerCube.OnCollision += WallColliding;
        }

        private void WallColliding(PlayerCube playerCube)
        {
            Unsubscribe(playerCube);
            playerCube.transform.SetParent(null);
            _cubes.Remove(playerCube);
            OnCollide?.Invoke();
        }

        private void Unsubscribe(PlayerCube playerCube)
        {
            playerCube.OnPickupTriggered -= PickupTriggered;
            playerCube.OnCollision -= WallColliding;
        }

        private void PickupTriggered()
        {
            PlayerCube playerCube = Instantiate(_playerCubePrefab, transform);
            Subscribe(playerCube);

            playerCube.transform.position = GetNewPosition();
            _cubes.Add(playerCube);
            _stickMan.Jump(GetNewPosition());
            
            OnPicked?.Invoke(GetNewPosition());
        }

        private Vector3 GetNewPosition()
        {
            return _cubes.Last().transform.position 
                   + _cubes.Last().transform.localScale.y * Vector3.up;
        }
        
        private void OnDestroy()
        {
            _cubes.ForEach(Unsubscribe);
            _cubes.Clear();
        }
    }
}