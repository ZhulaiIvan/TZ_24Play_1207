using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace UI
{
    public class FingerAnimation : MonoBehaviour
    {
        [SerializeField] private RectTransform _line;
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _movementOffset = 10f;

        private float _maxX;
        private float _minX;

        private void Start()
        {
            _maxX = _line.rect.width / 2 - _movementOffset;
            _minX = -_line.rect.width / 2 + _movementOffset;
            float[] positions = new[] { _minX, _maxX, 0 };
            Sequence sequence = DOTween.Sequence();
            
            foreach (float pos in positions)
            { 
                sequence.Append(transform.DOLocalMoveX(pos, _duration));
                sequence.Join(transform.DOPunchScale(-transform.localScale / 5, _duration / 2, 3, _duration / 2));
            }
            sequence.SetLoops(-1, LoopType.Restart);
        }
    }
}
