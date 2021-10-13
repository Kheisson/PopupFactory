using System;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(menuName = "Models/Player Skills", fileName = "Player Skills")]
    public class PlayerSkillsModel : ScriptableObject
    {
        #region Consts
        
        public const int MAX_STRENGTH = 25;
        public const int MAX_INTELLIGENCE = 30;
        public const int MAX_MAGIC = 45;
        
        #endregion

        #region Events

        public event Action DataChanged;

        public event Action PlayerLevelChanged;

        #endregion

        #region Editor

        [SerializeField]
        private int _strength;

        [SerializeField]
        private int _intelligence;

        [SerializeField]
        private int _magic;
        
        #endregion

        #region Methods
        
        public void UpdateStrength(int strength)
        {
            var oldLevel = PlayerLevel;
            _strength = strength;
            DataChanged?.Invoke();
            CheckLevelChanged(oldLevel);
        }

        public void UpdateIntelligence(int intelligence)
        {
            var oldLevel = PlayerLevel;
            _intelligence = intelligence;
            DataChanged?.Invoke();
            CheckLevelChanged(oldLevel);
        }

        public void UpdateMagic(int magic)
        {
            var oldLevel = PlayerLevel;
            _magic = magic;
            DataChanged?.Invoke();
            CheckLevelChanged(oldLevel);
        }

        private void CheckLevelChanged(int oldLevel)
        {
            if (PlayerLevel != oldLevel)
            {
                PlayerLevelChanged?.Invoke();
            }
        }

        private int CalculateLevel(int strength, int intelligence, int magic)
        {
            var sum = (float)(strength + intelligence + magic);
            var maxPerks = (float)MAX_STRENGTH + MAX_INTELLIGENCE + MAX_MAGIC;
            var percentage = sum / maxPerks;
            if (percentage > 0f && percentage <= 0.25f)
            {
                return 1;
            }
            if (percentage > 0.25f && percentage <= 0.35f)
            {
                return 2;
            }
            if (percentage > 0.35f && percentage <= 0.55f)
            {
                return 3;
            }

            if (percentage > 0.55f)
            {
                return 4;
            }

            return 0;
        }

        public void Save()
        {
            // TODO: Implement save logic
        }

        #endregion
        
        #region Properties
        
        public int Strength => _strength;

        public int Intelligence => _intelligence;

        public int Magic => _magic;

        public int PlayerLevel => CalculateLevel(Strength, Intelligence, Magic);
        
        #endregion
    }
}