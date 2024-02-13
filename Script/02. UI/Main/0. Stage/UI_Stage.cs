using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using TMPro;
using SaveData;

public class NodeFloor : MonoBehaviour
{
    public GameObject Object;
    public List<GameObject> NodeButton;
}
public class NodeButton : MonoBehaviour
{
    public GameObject Object;

    public int Line;
    public UI_Stage.StageTag Tag;
    public List<GameObject> NextNode;
}
public class UI_Stage : MonoBehaviour
{
    public enum StageTag
    {
        Stage_Nomal,
        Stage_Elite,
        Stage_Boss,
        Shop,
        Rest,
        Question,
    }

    [Header("Line")]
    public GameObject Prefab_Line;
    public GameObject LineContainer;

    [Header("Button")]
    public ScrollRect StagePage;
    public GameObject StageFloor;
    public GameObject[] Prefab_Button;

    [Header("Floor")]
    public List<NodeFloor> Stage_Floor = new List<NodeFloor>();

    [Header("Clip")]
    public AudioClip Clip_Button;

    private void Awake()
    {
        SetStagePage();
    }

    public void SetButton_Next(Button button)
    {
        button.GetComponent<Button>().interactable = false;

        for (int i = 0; i < Stage_Floor[SaveValueGame.Floor].NodeButton.Count; i++)
        {
            Stage_Floor[SaveValueGame.Floor].NodeButton[i].GetComponent<Button>().interactable = false;
        }

        NodeButton node = button.GetComponent<NodeButton>();

        for (int i = 0; i < node.NextNode.Count; i++)
        {
            node.NextNode[i].GetComponent<Button>().interactable = true;
        }

        SaveValueGame.Floor += 1;
        SetStage(button);
        MovePage(300);

        CoroutineSound.Start_Coroutine(Clip_Button, SaveValuePlayer.Volume_Effect, false);
    }

    private void MovePage(float value)
    {
        StartCoroutine(IE_MovePage(value));
    }
    private IEnumerator IE_MovePage(float value)
    {
        RectTransform rect = StagePage.content.GetComponent<RectTransform>();

        for (float i = 0; i <= 1; i += Time.deltaTime / 0.5f)
        {
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y - ((Time.deltaTime / 0.5f) * value));
            yield return null;
        }
    }

    public void SetStage(Button button)
    {
        NodeButton node = button.GetComponent<NodeButton>();
        StageData_Setting setting = ResourcesData.Get_StageSetting(SaveValueGame.Stage);
        
        // 태그별 기능
        switch (node.Tag)
        {
            case StageTag.Stage_Nomal:  StageEvent_StageNomal(setting); break;
            case StageTag.Stage_Elite:  StageEvent_StageElite(setting); break;
            case StageTag.Stage_Boss:   StageEvent_StageBoss(setting);  break;
            case StageTag.Shop:         StageEvent_Shop(setting);       break;
            case StageTag.Rest:         StageEvent_Rest(setting);       break;
            case StageTag.Question:     StageEvent_Question(setting);   break;
            default: break;
        }
    }

    public void StageEvent_StageNomal(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[0] += 1;

        int rand = Random.Range(0, setting.Floor_Nomal[SaveValueGame.Floor - 1].array.Length);
        int stageLevel = setting.Floor_Nomal[SaveValueGame.Floor - 1].array[rand];

        UnitManager.instance.Create_StageUnit(stageLevel);
        SaveValueGame.Current_GameState = GameState.Fight;
    }
    public void StageEvent_StageElite(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[1] += 1;

        int rand = Random.Range(0, setting.Floor_Elite[(SaveValueGame.Floor / 10)].array.Length);
        int stageLevel = setting.Floor_Elite[SaveValueGame.Floor / 10].array[rand];

        UnitManager.instance.Create_StageUnit(stageLevel);
        SaveValueGame.Current_GameState = GameState.Fight;
    }
    public void StageEvent_StageBoss(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[2] += 1;

        int rand = Random.Range(0, setting.Floor_Boss[(SaveValueGame.Floor / 10) - 1].array.Length);
        int stageLevel = setting.Floor_Boss[(SaveValueGame.Floor / 10) - 1].array[rand];

        UnitManager.instance.Create_StageUnit(stageLevel);
        SaveValueGame.Current_GameState = GameState.Fight;
    }
    public void StageEvent_Shop(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[3] += 1;
        
        Canvas_Main.instance._Shop.Init();
        SaveValueGame.Current_GameState = GameState.Shop;
    }
    public void StageEvent_Rest(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[4] += 1;

        Canvas_Main.instance._Rest.Init();
        SaveValueGame.Current_GameState = GameState.Rest;
    }
    public void StageEvent_Question(StageData_Setting setting)
    {
        Canvas_Main.instance._GameOver.Data_Stage[5] += 1;

        // Canvas_Main.instance._Event.SetEvent(7);
        // SaveValueGame.Current_GameState = GameState.Event;
        // return;

        float rand = Random.Range(0f, 10f);
        int Erand = 0;

        bool check = false;
        
        if (rand <= 7)
        {
            int count = 0;
            
            while (true)
            {
                count += 1;
                Erand = Random.Range(0, ResourcesData._EventData.Count);

                if (Canvas_Main.instance._Event._EventCheck.CheckEvent(Erand))
                {
                    // 이벤트 실행
                    check = true; break;
                }
                if (count > 3)
                    break;
            }
        }

        if (check)
        {
            Canvas_Main.instance._Event.SetEvent(Erand);
            SaveValueGame.Current_GameState = GameState.Event;
        }
        else
            StageEvent_StageNomal(setting);
    }
    // 스테이지 생성 부분
    public void SetStagePage()
    {
        for (int i = 0; i < SaveValue.StageFloor[SaveValueGame.Stage]; i++)
        {
            GameObject ins_f = Instantiate(StageFloor);
            ins_f.transform.SetParent(StagePage.content.transform, false);

            NodeFloor floor = ins_f.AddComponent<NodeFloor>();

            floor.Object = ins_f;
            floor.NodeButton = new List<GameObject>();

            Stage_Floor.Add(floor);

            if (i == SaveValue.StageFloor[SaveValueGame.Stage] - 1 || i % 10 == 0 && i != 0)
            {
                // 제일 마지막 줄은 무조건 보스 스테이지
                GameObject ins_b = CreateStageButton(StageTag.Stage_Boss, i);
                ins_b.transform.SetParent(floor.Object.transform);

                floor.NodeButton.Add(ins_b);
            }
            else
            {
                for (int j = 0; j < Random.Range(SaveValue.Min_StageButton, SaveValue.Max_StageButton + 1); j++)
                {
                    GameObject ins_b = null;
                    if (i != 0)
                        ins_b = CreateRandomStageButton(i);
                    else
                    {
                        // 제일 첫줄은 무조건 노말 스테이지
                        ins_b = CreateStageButton(StageTag.Stage_Nomal, i);
                        ins_b.GetComponent<Button>().interactable = true;
                    }

                    ins_b.transform.SetParent(floor.Object.transform);
                    floor.NodeButton.Add(ins_b);
                }
            }
        }

        SetNodeLink();
    }
    public void SetNodeLink()
    {
        for (int i = 0; i < Stage_Floor.Count; i++)
        {
            int CurrentCount = Stage_Floor[i].NodeButton.Count;
            int NextCount = 0;

            if (i != Stage_Floor.Count - 1)
                NextCount = Stage_Floor[i + 1].NodeButton.Count;

            int NodeCount = 0;

            for (int j = 0; j < CurrentCount; j++)
            {
                if (i != Stage_Floor.Count - 1)
                {
                    NodeButton node = Stage_Floor[i].NodeButton[j].GetComponent<NodeButton>();
                    int rand = 0;
                    
                    if (j != CurrentCount - 1)              // 랜덤 연결 수
                        rand = Random.Range(1, 4);
                    else                                    // 마지막 연결
                        rand = NextCount - NodeCount + 1;
                    // 마지막이 아니면 바로 연결할지 넘길지 랜덤
                    if (NodeCount > 0 && Random.Range(0, 2) == 0)
                        NodeCount -= 1;

                    for (int k = 0; k < rand; k++)
                    {
                        if (NextCount <= NodeCount)
                        {
                            node.NextNode.Add(Stage_Floor[i + 1].NodeButton[NextCount - 1]);
                            // 라인 연결
                            SetLine(Stage_Floor[i].NodeButton[j], Stage_Floor[i + 1].NodeButton[NextCount - 1]);
                        }
                        else
                        {
                            node.NextNode.Add(Stage_Floor[i + 1].NodeButton[NodeCount]);
                            // 라인 연결
                            SetLine(Stage_Floor[i].NodeButton[j], Stage_Floor[i + 1].NodeButton[NodeCount]);
                            NodeCount += 1;
                        }

                        if (NextCount <= NodeCount)
                            break;
                    }
                }
            }
        }
    }
    public void SetLine(GameObject startButton, GameObject endButton)
    {
        GameObject ins = Instantiate(Prefab_Line, LineContainer.transform);
        UILineConnector connector = ins.AddComponent<UILineConnector>();

        connector.transforms = new RectTransform[2];
        connector.transforms[0] = startButton.GetComponent<RectTransform>();
        connector.transforms[1] = endButton.GetComponent<RectTransform>();
    }

    // 버튼 생성 부분
    public GameObject CreateRandomStageButton(int line)
    {
        StageTag tag = StageTag.Stage_Nomal;
        
        if (line % 10 > 3)
        {
            int[] value = { 0, 1, 3, 4, 5 };
            tag = (StageTag)value[Random.Range(0, value.Length)];
        }
        else
        {
            int[] value = { 0, 3, 4, 5 };
            tag = (StageTag)value[Random.Range(0, value.Length)];
        }

        // tag = StageTag.Question;
        return CreateStageButton(tag, line);
    }

    public GameObject CreateStageButton(StageTag tag, int line)
    {
        GameObject ins = Instantiate(Prefab_Button[(int)tag]);

        NodeButton node = ins.AddComponent<NodeButton>();
        node.Object = ins;
        node.Tag = tag;
        node.Line = line;
        node.NextNode = new List<GameObject>();

        Button but = ins.GetComponent<Button>();
        but.interactable = false;

        but.onClick.AddListener(() => SetButton_Next(but));

        return ins;
    }
}
