using System;

namespace Core
{
    public class Data<T>
    {
        private T _value;
        private event Action<T> _onChanged;
        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value)) return;

                _value = value;
                _onChanged?.Invoke(_value);
            }
        }

        public event Action<T> OnChanged
        {
            add
            {
                _onChanged += value;
                _onChanged?.Invoke(_value);
            }
            remove => _onChanged -= value;
        }

        public Data(T defaultValue)
        {
            Value = defaultValue;
        }
    }
}