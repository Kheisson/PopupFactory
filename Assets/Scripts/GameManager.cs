using UnityEngine;


public class GameManager : MonoBehaviour
{
    #region Editor
    [SerializeField]
    private PopupSystem _popupSystem;
    #endregion

    #region Methods

    public void OnShowButtonClick()
    {
        _popupSystem.ShowPlayerSkillsPopup();
    }

    #endregion
}
