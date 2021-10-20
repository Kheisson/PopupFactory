using Models;
using UnityEngine;

namespace MvcMvpExample.Mvp
{

    public class MvpPlayerSkillsPopupPresenter
    {
        PlayerSkillsModel _model;
        MvpPlayerSkillsPopupView _view;


        public MvpPlayerSkillsPopupPresenter(MvpPlayerSkillsPopupView view, PlayerSkillsModel model)
        {
            _model = model;
            _view = view;
            Subscribe();
            UpdateView();
        }

        private void Subscribe()
        {
            _view.StrengthButtonClick += OnStrengthButtonClick;
            _view.IntelligenceButtonClick += OnIntelligenceButtonClick;
            _view.MagicButtonClick += OnMagicButtonClick;
            _view.SaveButtonClicked += OnSaveButtonClick;

            _model.DataChanged += OnDataChanged;
            _model.PlayerLevelChanged += OnPlayerLevelChanged;
        }

        private void Unsubscribe()
        {
            _view.StrengthButtonClick -= OnStrengthButtonClick;
            _view.IntelligenceButtonClick -= OnIntelligenceButtonClick;
            _view.MagicButtonClick -= OnMagicButtonClick;
            _view.SaveButtonClicked -= OnSaveButtonClick;

            _model.DataChanged -= OnDataChanged;
            _model.PlayerLevelChanged -= OnPlayerLevelChanged;
        }

        private void OnPlayerLevelChanged()
        {
            _view.Shake();
        }

        private void OnDataChanged()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _view.UpdateData(_model.Strength, _model.Intelligence, _model.Magic, _model.PlayerLevel);
        }

        private void OnSaveButtonClick()
        {
            _model.Save();
            Unsubscribe();

            Object.Destroy(_view.gameObject);
        }

        private void OnMagicButtonClick(int increment)
        {
            var magic = _model.Magic + increment;
            magic = Mathf.Clamp(magic, 0, PlayerSkillsModel.MAX_MAGIC);
            _model.UpdateMagic(magic);
        }

        private void OnIntelligenceButtonClick(int increment)
        {
            var intelligence = _model.Intelligence + increment;
            intelligence = Mathf.Clamp(intelligence, 0, PlayerSkillsModel.MAX_INTELLIGENCE);
            _model.UpdateIntelligence(intelligence);

        }

        private void OnStrengthButtonClick(int increment)
        {
            var strength = _model.Strength + increment;
            strength = Mathf.Clamp(strength, 0, PlayerSkillsModel.MAX_STRENGTH);
            _model.UpdateStrength(strength);

        }
    }
}
