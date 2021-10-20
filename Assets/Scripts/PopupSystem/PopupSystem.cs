using Models;
using UnityEngine;

public abstract class PopupSystem : MonoBehaviour
{
    #region Editor

    [SerializeField] protected RectTransform _parentTransform;

    [SerializeField] protected Object _playerSkillsPopupPrefabRef;

    [SerializeField] protected PlayerSkillsModel _model;
    #endregion

    public abstract void ShowPlayerSkillsPopup();
}
