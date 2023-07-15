using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LoseScreen : Screen
    {
        [SerializeField] private Button _restartButton;
        
        private AppCore core;

        [Inject]
        public void Construct(AppCore core)
        {
            this.core = core;
        }
        public override void Initialize()
        {
            _restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                core.UpdateState(AppState.Game);
                Hide();
            });
        }
    }
}