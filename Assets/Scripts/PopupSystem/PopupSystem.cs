using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

namespace MvcMvpExample
{

    public class PopupSystem : MonoBehaviour
    {
        [SerializeField] private RectTransform _parentTransform;

        [SerializeField] private Object _playerSkillsPopupPrefabRef;
        
        [SerializeField] private PlayerSkillsModel _model;

        private MvcPlayerSkillsPopupFactory _playerSkillsPopupFactory;

        private void Awake()
        {
            _playerSkillsPopupFactory = new MvcPlayerSkillsPopupFactory(_playerSkillsPopupPrefabRef, _model);
        }

        public void ShowPlayerSkillsPopup()
        {
            _playerSkillsPopupFactory.Create(_parentTransform);
        }
    }
}
