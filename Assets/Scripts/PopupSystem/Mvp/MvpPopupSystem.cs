namespace MvcMvpExample.Mvp
{

    public class MvpPopupSystem : PopupSystem
    {
        private MvpPlayerSkillsPopupFactory _playerSkillsPopupFactory;

        private void Awake()
        {
            _playerSkillsPopupFactory = new MvpPlayerSkillsPopupFactory(_playerSkillsPopupPrefabRef, _model);
        }

        public override void ShowPlayerSkillsPopup()
        {
            _playerSkillsPopupFactory.Create(_parentTransform);
        }
    }

}