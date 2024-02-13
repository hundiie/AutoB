using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Stage_Button : MonoBehaviour
{
    public UI_Stage.StageTag _StageTag;

    public TextMeshProUGUI Tooltip_Head;
    public TextMeshProUGUI Tooltip_Body;

    private void Awake()
    {
        SetTooltip(_StageTag);
    }

    public void SetTooltip(UI_Stage.StageTag tag)
    {
        Tooltip_Head.text = SaveData.LanguageData.Stage_Name[(int)tag, SaveData.SaveValuePlayer.LanguageValue];
        Tooltip_Body.text = SaveData.LanguageData.Stage_Description[(int)tag, SaveData.SaveValuePlayer.LanguageValue];
    }
}
