namespace MvcMvpExample
{

    public class MvcPopupSystem : PopupSystem
    {
        private MvcPlayerSkillsPopupFactory _playerSkillsPopupFactory;

        private void Awake()
        {
            _playerSkillsPopupFactory = new MvcPlayerSkillsPopupFactory(_playerSkillsPopupPrefabRef, _model);
        }

        public override void ShowPlayerSkillsPopup()
        {
            _playerSkillsPopupFactory.Create(_parentTransform);
        }
    }
}
