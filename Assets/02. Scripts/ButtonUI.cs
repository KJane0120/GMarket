using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Button newStartBtn;
    public Button continueBtn;

    private void Start()
    {
        newStartBtn = UIManager.Instance.newStartBtn;
        continueBtn = UIManager.Instance.continueBtn;
    }
    public void OnClickNewStartBtn()
    {

    }
}
