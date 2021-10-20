using Models;
using UnityEngine;

namespace MvcMvpExample
{

    public class MvcPlayerSkillsPopupFactory
    {
        private readonly Object _popupPrefabRef;
        private readonly PlayerSkillsModel _model;

        public MvcPlayerSkillsPopupFactory(Object popupPrefabRef, PlayerSkillsModel model)
        {
            _popupPrefabRef = popupPrefabRef;
            _model = model;
        }

        public void Create(RectTransform parentTransform)
        {
            var popupInstance = (GameObject)Object.Instantiate(_popupPrefabRef, parentTransform);
            var mvcView = popupInstance.GetComponent<MvcPlayerSkillsPopupView>();
            var controller = new MvcPlayerSkillsPopupController(mvcView, _model);
            mvcView.SetModel(_model);
        }
    }
}
