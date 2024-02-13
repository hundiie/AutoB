using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SaveData;

public class UI_Fight_Life : MonoBehaviour
{
    public GameObject Prefab_Life;

    public void SetLife(Unit unit)
    {
        GameObject ins = Instantiate(Prefab_Life, new Vector3(2000, 2000, 0), Quaternion.identity, transform);
        ins.AddComponent<Life>().Init(unit, ins);
    }

    class Life : MonoBehaviour
    {
        Unit _Unit;
        private GameObject _Object;
        public GameObject Object
        {
            get { return _Object; }
            set
            {
                _Object = value;

                // Name
                Text_Name = _Object.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                
                // Slider
                Slider_Shield = _Object.transform.GetChild(1).GetComponent<Slider>();
                Slider_Hp = Slider_Shield.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
                Slider_Mp = _Object.transform.GetChild(2).GetComponent<Slider>();
                
                // CanvasGroup
                CanvasGroup_Object = _Object.GetComponent<CanvasGroup>();
                CanvasGroup_Name = Text_Name.GetComponent<CanvasGroup>();
            }
        }
        private CanvasGroup CanvasGroup_Object;
        private CanvasGroup CanvasGroup_Name;

        private TextMeshProUGUI Text_Name;
        private Slider Slider_Hp;
        private Slider Slider_Mp;
        private Slider Slider_Shield;

        bool IsExit;
        private void Update()
        {
            if (SaveValuePlayer.Life_Active && CanvasGroup_Object.alpha == 0)
                CanvasGroup_Object.alpha = 1;
            else if (!SaveValuePlayer.Life_Active && CanvasGroup_Object.alpha == 1)
                CanvasGroup_Object.alpha = 0;

            if (SaveValuePlayer.Life_ActiveName && CanvasGroup_Name.alpha == 0)
                CanvasGroup_Name.alpha = 1;
            else if (!SaveValuePlayer.Life_ActiveName && CanvasGroup_Name.alpha == 1)
                CanvasGroup_Name.alpha = 0;

            if (_Unit == null || _Unit.IsDeath && !IsExit)
            {
                IsExit = true;
                Exit();
            }
            else
            {
                transform.position = Camera.main.WorldToScreenPoint(_Unit.transform.position + new Vector3(0, 1f, 0));

                Slider_Hp.value = Support.Math.Get_ValueRate(_Unit.CurrentHp, _Unit.Stat.Hp, 100);
                Slider_Shield.value = Support.Math.Get_ValueRate(_Unit.CurrentShield, _Unit.Stat.Hp, 100);
                Slider_Mp.value = Support.Math.Get_ValueRate(_Unit.CurrentMp, _Unit.Stat.Mp, 100);
            }
        }
        public void Init(Unit unit, GameObject ui)
        {
            _Unit = unit;
            Object = ui;

            Text_Name.text = _Unit.Name;
            SetColor();
        }
        public void Exit()
        {
            Destroy(gameObject);
        }

        public void SetColor()
        {
            switch (_Unit._Faction)
            {
                case Faction.Player: Text_Name.color = SaveValuePlayer.Life_PlayerNameColor; break;
                case Faction.Enamy: Text_Name.color = SaveValuePlayer.Life_EnamyNameColor; break;
                default: break;
            }

            Slider_Hp.fillRect.GetComponent<Image>().color = SaveValuePlayer.Life_HpColor;
            Slider_Mp.fillRect.GetComponent<Image>().color = SaveValuePlayer.Life_MpColor;
            Slider_Shield.fillRect.GetComponent<Image>().color = SaveValuePlayer.Life_ShieldColor;
        }
    }
}
