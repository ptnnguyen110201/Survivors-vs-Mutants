using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileCloseBtn : ButtonAbstract
{
    protected override void OnClick()
    {
        ProfileManager.Instance.Hide();
    }
}