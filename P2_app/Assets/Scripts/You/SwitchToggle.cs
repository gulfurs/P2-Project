using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchToggle : MonoBehaviour
{
    [SerializeField] RectTransform uiHandleRectTransform;
    [SerializeField] Color backgroundActiveColor;

    Toggle toggle;
    Vector2 handlePosition;
    Color backgroundDefaultColor;
    Image backgroundImage;

    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        handlePosition = uiHandleRectTransform.anchoredPosition;
        backgroundImage = uiHandleRectTransform.parent.GetComponent<Image>();
        backgroundDefaultColor = backgroundImage.color;
 
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);

    }

    private void OnSwitch(bool on)
    {
        if (on)
            uiHandleRectTransform.anchoredPosition = handlePosition * -1;
        else
            uiHandleRectTransform.anchoredPosition = handlePosition;
        backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor;
    }

    private void OnDestroy()
    {
        toggle.onValueChanged.RemoveListener(OnSwitch);
    }
}
