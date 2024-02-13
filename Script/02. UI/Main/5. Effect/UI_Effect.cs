using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ricimi;

public class UI_Effect : MonoBehaviour
{
    public enum EffectText
    {
        Main,
        Sub,
    }

    public Image Effect_Black;
    public TextMeshProUGUI[] Effect_Text;

    private IEnumerator[] IEnumerator_Text = new IEnumerator[2];

    public void SetEffect_Text(EffectText effect, string text, Color color, float delay)
    {
        if (IEnumerator_Text[(int)effect] != null)
            StopCoroutine(IEnumerator_Text[(int)effect]);

        IEnumerator_Text[(int)effect] = TextEffect(effect, text, color, delay);
        StartCoroutine(IEnumerator_Text[(int)effect]);
    }
    private IEnumerator TextEffect(EffectText effect, string text, Color color, float delay)
    {
        // 다른 텍스트 있으면 제거하고 텍스트 변경
        yield return StartCoroutine(Utils.FadeOut(Effect_Text[(int)effect].GetComponent<CanvasGroup>(), 0.0f, 0.1f));
        
        Effect_Text[(int)effect].text = text;
        Effect_Text[(int)effect].color = color;
        
        yield return StartCoroutine(Utils.FadeIn(Effect_Text[(int)effect].GetComponent<CanvasGroup>(), 1.0f, 0.5f));
        yield return new WaitForSeconds(delay);
        yield return StartCoroutine(Utils.FadeOut(Effect_Text[(int)effect].GetComponent<CanvasGroup>(), 0.0f, 0.1f));
    }
    public IEnumerator FadeInBlack(float delay)
    {
        CanvasGroup can = Effect_Black.GetComponent<CanvasGroup>();
        yield return StartCoroutine(Utils.FadeIn(can, 1.0f, delay));
        can.blocksRaycasts = true;
    }
    public IEnumerator FadeOutBlack(float delay)
    {
        CanvasGroup can = Effect_Black.GetComponent<CanvasGroup>();
        yield return StartCoroutine(Utils.FadeOut(can, 0.0f, delay));
        can.blocksRaycasts = false;
    }
}
