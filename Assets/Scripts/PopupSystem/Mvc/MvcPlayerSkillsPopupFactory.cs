using Models;
using UnityEngine;

namespace MvcMvpExample
{

    public class MvcPlayerSkillsPopupFactory : PopupFactory
    {
       
        public MvcPlayerSkillsPopupFactory(Object popupPrefabRef, PlayerSkillsModel model)
        {
            _popupPrefabRef = popupPrefabRef;
            _model = model;
        }

        public override void Create(RectTransform parentTransform)
        {
            var popupInstance = (GameObject)Object.Instantiate(_popupPrefabRef, parentTransform);
            var mvcView = popupInstance.GetComponent<MvcPlayerSkillsPopupView>();
            var controller = new MvcPlayerSkillsPopupController(mvcView, _model);
            mvcView.SetModel(_model);
        }
    }
}
