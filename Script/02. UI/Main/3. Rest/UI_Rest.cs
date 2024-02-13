using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Rest : MonoBehaviour
{
    public TextMeshProUGUI[] ButtonText;
    public TextMeshProUGUI[] TooltipText;

    [Header("Clip")]
    public AudioClip[] Clip_Button;

    int exp;
    
    public void Init()
    {
        exp = (SaveValueGame.Stage * 300) + (SaveValueGame.Floor * 10);

        for (int i = 0; i < ButtonText.Length; i++)
        {
            ButtonText[i].text = LanguageData.Rest_Button[i, SaveValuePlayer.LanguageValue];
            TooltipText[i].text = LanguageData.Rest_ButtonDescription[i, SaveValuePlayer.LanguageValue] + (i == 0 ? "\n\n" + LanguageData.Rest_Exp[SaveValuePlayer.LanguageValue]+ " " + exp : "");
        }
    }
    public void Exit()
    {

    }

    public void SetButton_(int value)
    {
        switch (value)
        {
            case 0:
                {
                    // ¸ðµç À¯´Ö °æÇèÄ¡
                    for (int i = 0; i < UnitManager.instance.Units_AllPlayer.Count; i++)
                    {
                        UnitManager.instance.Units_AllPlayer[i].Exp += exp;
                    }
                } break;
            case 1:
                {
                    // ·£´ý Çãºê 1 ~ 3
                    int count = Random.Range(1, 4);

                    for (int i = 0; i < count; i++)
                    {
                        PlayerManager.instance.AddItem(Random.Range(12,19));
                    }
                } break;
            case 2:
                {
                    // ·£´ý ¿µÈ¥ 0 ~ 1
                    int count = Random.Range(0, 2);

                    for (int i = 0; i < count; i++)
                    {
                        PlayerManager.instance.AddItem(Random.Range(100, 107));
                    }
                } break;
            default: break;
        }
        
        Exit();
        SaveValueGame.Current_GameState = GameState.Stage;
        CoroutineSound.Start_Coroutine(Clip_Button[value], SaveValuePlayer.Volume_Effect, false);
    }
}
