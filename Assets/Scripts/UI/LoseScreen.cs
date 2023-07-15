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
        
        private AppEntry _entry;

        [Inject]
        public void Construct(AppEntry entry)
        {
            _entry = entry;
        }
        public override void Initialize()
        {
            _restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                _entry.UpdateState(AppState.Game);
                Hide();
            });
        }
    }
}