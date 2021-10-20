using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MvcMvpExample.Mvp
{
    public class MvpPlayerSkillsPopupView : MonoBehaviour
    {
        #region Events
        
        public event Action<int> StrengthButtonClick;

        public event Action<int> IntelligenceButtonClick;

        public event Action<int> MagicButtonClick;

        public event Action SaveButtonClicked;
        
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
            SaveButtonClicked?.Invoke();
        }

        private IEnumerator ShakePopupInternal(float shakeDuration, float shakeStrength)
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

        public void UpdateData(int strength, int intelligence, int magic, int playerLevel)
        {
            _strength.text = strength.ToString();
            _intelligence.text = intelligence.ToString();
            _magic.text = magic.ToString();
            _level.text = playerLevel.ToString();
        }
        
        public void Shake()
        {
            StartCoroutine(ShakePopupInternal(_viewShakeDuration, _shakeStrength));
        }
    }
}