using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagController : MonoBehaviour
{
    [SerializeField] private GameObject magPanel;
    [SerializeField] private GameObject smithy; // панель кузницы


    [SerializeField] private Button smithyButton;
    [SerializeField] private Button sneilLevelStartButton;


    private void Start()
    {
        magPanel.SetActive(false);
        smithy.SetActive(false);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            magPanel.SetActive(true);
        }
    }



    public void onCleckExitMagButton()
    {
        magPanel.SetActive(false);
    }

    public void onClickSmithybutton()
    {
        smithy.SetActive(true);
        smithyButton.interactable = false;
    }

    public void onClickExitSmithybutton()
    {
        smithy.SetActive(false);
        smithyButton.interactable = true;
    }


}
