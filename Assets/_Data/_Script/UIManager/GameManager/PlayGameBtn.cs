using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameBtn : ButtonAbstract
{
    protected override void OnClick()
    {
        GameManagerUI.Instance.StartGameUI();
        GameManager.Instance.StartGame();
        this.button.gameObject.SetActive(false);
    }
}
