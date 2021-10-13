using System;
using System.Collections;
using Models;
using UnityEngine;
using UnityEngine.UI;

namespace MvcMvpExample
{
    public class MvcPlayerSkillsPopupView : MonoBehaviour
    {
        #region Events

        public event Action<int> StrengthButtonClick;

        public event Action<int> IntelligenceButtonClick;

        public event Action<int> MagicButtonClick;

        public event Action SaveButtonClick;

        #endregion

        #region Editor

        [SerializeField]
        private Text _strength;

        [SerializeField]
        private Text _intelligence;

        [SerializeField]
        private Text _magic;

        [SerializeField]
        private Text _level;

        [SerializeField]
        [Range(0.1f, 1f)]
        private float _viewShakeDuration = 0.5f;

        [SerializeField]
        [Range(1f, 5f)]
        private float _shakeStrength = 1f;

        #endregion

        #region Fields

        private PlayerSkillsModel _model;

        #endregion

        private void Start()
        {
            UpdateView();
        }

        public void SetModel(PlayerSkillsModel model)
        {
            _model = model;
            _model.DataChanged += OnModelDataChange;
            _model.PlayerLevelChanged += OnPlayerLevelChanged;
        }

        private void OnPlayerLevelChanged()
        {
            StartCoroutine(ShakePopup(_viewShakeDuration, _shakeStrength));
        }

        private void OnDestroy()
        {
            if (_model != null)
            {
                _model.DataChanged -= OnModelDataChange;
                _model.PlayerLevelChanged -= OnPlayerLevelChanged;
            }
        }

        private void OnModelDataChange()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _strength.text = _model.Strength.ToString();
            _intelligence.text = _model.Intelligence.ToString();
            _magic.text = _model.Magic.ToString();
            _level.text = _model.PlayerLevel.ToString();
        }

        public void OnStrengthButtonClick(int increment)
        {
            StrengthButtonClick?.Invoke(increment);
        }

        public void OnIntelligenceButtonClick(int increment)
        {
            IntelligenceButtonClick?.Invoke(increment);
        }

        public void OnMagicButtonClick(int increment)
        {
            MagicButtonClick?.Invoke(increment);
        }

        public void OnSaveButtonClick()
        {
            _model.Save();
            SaveButtonClick?.Invoke();
        }

        private IEnumerator ShakePopup(float shakeDuration, float shakeStrength)
        {
            var endTime = Time.time + shakeDuration;
            var originalPosition = transform.position;
            while (Time.time < endTime)
            {
                var rnd = UnityEngine.Random.insideUnitCircle * shakeStrength;
                transform.position += new Vector3(rnd.x, rnd.y, 0);
                yield return null;
            }

            transform.position = originalPosition;
        }
    }
}