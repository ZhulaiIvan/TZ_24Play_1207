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
            
            playerCube.transform.position = _cubes.Last().transform.position + Vector3.up;
            _cubes.Add(playerCube);
            _stickMan.transform.position = _cubes.Last().transform.position + Vector3.up;
        }

        private void OnDestroy()
        {
            _cubes.ForEach(Unsubscribe);
            _cubes.Clear();
        }
    }
}