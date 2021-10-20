using System.Collections;
using Models;
using UnityEngine;

namespace MvcMvpExample.Mvp
{

    public class MvpPlayerSkillsPopupFactory : PopupFactory
    {
        public MvpPlayerSkillsPopupFactory(Object popupPrefabRef, PlayerSkillsModel model)
        {
            _popupPrefabRef = popupPrefabRef;
            _model = model;
        }

        public override void Create(RectTransform parentTransform)
        {
            var popupInstance = (GameObject)Object.Instantiate(_popupPrefabRef, parentTransform);
            var mvpView = popupInstance.GetComponent<MvpPlayerSkillsPopupView>();
            var presenter = new MvpPlayerSkillsPopupPresenter(mvpView, _model);
        }
    }

}