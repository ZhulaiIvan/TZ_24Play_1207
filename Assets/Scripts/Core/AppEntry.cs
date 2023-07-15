using System;
using System.Linq;
using Items;
using Player;
using UnityEngine;
using Zenject;
using Screen = UI.Screen;

namespace Core
{
    public class AppEntry : MonoBehaviour
    {
        [SerializeField] private Screen[] _screens;
        [SerializeField] private CollectCubeText _pickupTextPrefab;
    
        private Data<AppState> _stateData;
        private MovementController _controller;
        private SwipeHandler _handler;
        private CubesHandler _cubesHandler;

        [Inject]
        public void Construct(MovementController controller, SwipeHandler handler, CubesHandler cubesHandler)
        {
            _controller = controller;
            _handler = handler;

            _cubesHandler = cubesHandler;
            _cubesHandler.OnPicked += Picked;
        }

        private void Picked(Vector3 position)
        {
            CollectCubeText text = Instantiate(_pickupTextPrefab);
            text.transform.position = position;
        }

        private void Start()
        {
            _stateData = new Data<AppState>(AppState.Menu);
            _stateData.OnChanged += StateUpdated;
            
            foreach (Screen screen in _screens)
                screen.Initialize();
        }

        private void StateUpdated(AppState state)
        {
            _screens.Where(s => s.IsShow()).ToList().ForEach(s => s.Hide());
            _screens.Where(s => s.IsEqualState(state)).ToList().ForEach(s => s.Show());
            
            _controller.SetState(state);
            _handler.SetState(state);
        }

        public void UpdateState(AppState appState)
        {
            _stateData.Value = appState;
        }

        private void OnDestroy()
        {
            _cubesHandler.OnPicked -= Picked;
        }
    }

    public enum AppState
    {
        Menu,
        Game,
        Lose
    }
}