using Player;
using UnityEngine;
using Zenject;

namespace Core
{
    public class AppEntry : MonoBehaviour
    {
        private Data<AppState> _stateData;
        private MovementController _controller;
        private SwipeHandler _handler;

        [Inject]
        public void Construct(MovementController controller, SwipeHandler handler)
        {
            _controller = controller;
            _handler = handler;
        }
        
        private void Start()
        {
            _stateData = new Data<AppState>(AppState.Menu);
            _stateData.OnChanged += StateUpdated;
        }

        private void StateUpdated(AppState state)
        {
            _controller.SetState(state);
            _handler.SetState(state);
        }
    }

    public enum AppState
    {
        Menu,
        Game,
        Lose
    }
}