﻿using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpacewareCheats.SDK.ButtonAPI
{
    class QMSingleButton
    {
        public QMSingleButton(Transform parent, string text, string toolTip, Sprite Icon, Action action)
        {
            GameObject singleButton = UnityEngine.Object.Instantiate<GameObject>(Main.Instance.QuickMenuStuff.quickMenu.transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Emojis").gameObject, parent);
            singleButton.transform.parent = parent;
            singleButton.name = text + "_SpacewareCheats_Button";
            singleButton.transform.Find("Text_H4").gameObject.GetComponent<TextMeshProUGUI>().text = text;
            singleButton.transform.Find("Text_H4").GetComponent<TMP_Text>().faceColor = Color.green;
            singleButton.transform.Find("Background").GetComponent<Image>().color = Color.black;
            singleButton.transform.Find("Badge_MMJump").gameObject.active = true;
            if (Icon != null)
            {
                singleButton.transform.Find("Icon").GetComponent<Image>().sprite = Icon;

            }
            else
            {
                UnityEngine.Object.Destroy(singleButton.transform.Find("Icon").GetComponent<Image>());
            }
            singleButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = toolTip;
            Button button = singleButton.GetComponent<Button>();
            button.StartColorTween(Color.green, true);
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(action);
            singleButton.SetActive(true);
        }
    }
}
