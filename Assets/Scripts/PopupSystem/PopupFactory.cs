using Models;
using UnityEngine;

public abstract class PopupFactory
{
    protected Object _popupPrefabRef;
    protected PlayerSkillsModel _model;

    public abstract void Create(RectTransform parentTransform);
}
