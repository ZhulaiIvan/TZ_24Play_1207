using System;
using Core;
using UnityEngine;

namespace UI
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField] private AppState _activeState;
        
        public virtual void Initialize(){}
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public bool IsEqualState(AppState state)
        {
            return _activeState == state;
        }

        public bool IsShow()
        {
            return gameObject.activeSelf;
        }
    }
}