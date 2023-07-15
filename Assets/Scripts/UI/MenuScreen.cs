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
        private AppCore appCore;

        [Inject]
        public void Construct(AppCore appCore)
        {
            this.appCore = appCore;
        }

        public override void Initialize()
        {
            _startButton.onClick.AddListener(() =>
            {
                appCore.UpdateState(AppState.Game);
                Hide();
            });
        }
    }
}