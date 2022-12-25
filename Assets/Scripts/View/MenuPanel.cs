using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : ViewBase
{
    public BagPanel bagPanel;
    
    public void OnBtnBagPanelClick()
    {
        bagPanel.Show();
        this.Hide();
    }

    public override void Hide()
    {
        //base.Hide();
        transform.GetComponent<Animator>().SetBool("isShow", false);
    }

    public override void Show()
    {
        //base.Show();
        transform.GetComponent<Animator>().SetBool("isShow", true);
    }
}
