using System;
using Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class MenuScreen : Screen
    {
        [SerializeField] private Button _startButton;
        private AppEntry _appEntry;

        [Inject]
        public void Construct(AppEntry appEntry)
        {
            _appEntry = appEntry;
        }

        public override void Initialize()
        {
            _startButton.onClick.AddListener(() =>
            {
                _appEntry.UpdateState(AppState.Game);
                Hide();
            });
        }
    }
}