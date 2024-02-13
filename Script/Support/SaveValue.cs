using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum AttackType
{
    Physic,
    Magic,
    Pure,
}
public enum Language
{
    Korean,
    English,
}

namespace SaveData
{
    public static class LanguageData
    {
        public static string[,] Stat =
        {
            {"최대 체력","Max Health" },           // 0
            {"공격력", "Physic" },                 // 1
            {"물리 관통력", "PhysicPiercing" },    // 2
            {"마법력", "Magic" },                  // 3
            {"마법 관통력", "MagicPiercing" },     // 4
            {"공격 속도", "Attack Speed" },        // 5
            {"방어력", "Armor" },                  // 6
            {"마법 저항력", "Resist" },            // 7
            {"치명타 확률", "CriticalChance" },    // 8
            {"치명타 피해", "CriticalDamage" },    // 9
            {"체력 흡수", "Absorb" },              // 10
            {"공격 사거리", "Attack Range" },      // 11
            {"이동 속도", "Move Speed" },          // 12
            {"피해 감소", "DamageReduction" },     // 13
            {"피해 증가", "DamageIncrease" }       // 14
        };
        
        #region Event
        public static string[] Event_BackButton = { "뒤로가기", "Back" };

        public static string[,] Event_00 =
        {
            { "\'천사의 피\'를 얻었습니다.", "You have obtained \'Angelic Blood\'." },
            { "\'악마의 피\'를 얻었습니다.", "You have obtained \'Demon Blood\'." },
            { "랜덤한 유닛을 하나 잃었습니다.", "You lost a random unit." },
        };
        public static string[,] Event_01 =
        {
            { "랜덤한 유닛을 하나 얻었습니다.", "You get a random unit." },
            { "랜덤한 유닛을 둘 얻었습니다.", "You get two random units." },
            { "랜덤한 유닛을 셋 얻었습니다.", "You get three random units." },
            { "영혼은 부족한 돈만 들고 사라졌습니다.", "The spirits disappeared with nothing but insufficient coin." },
            { "영혼에 돈이 건네자 돈이 사라지며 동료가 되었다.", "When he handed the coin to the spirit, it disappeared and became his companion." },
            { "\"돈이 부족한 거 같군\"\n\n영혼이 점점 희미해지더니 사라졌다.", "\"I guess I don't have enough money.\"\n\nThe spirit grew fainter and fainter, then disappeared." },
        };
        public static string[,] Event_02 =
        {
            { "골드를 얻었습니다.", "You've earned Coin." },
            { "모든 골드를 잃었습니다.", "lost all Coin." },
            { "\"축하하네!\"\n\n\"자네의 용기를 보여준 결과를 받게나!\"", "\"Congratulation!, you've shown your courage!\"" },
            { "\"아쉬운 결과로구나!\"\n\n\"하지만 너의 용기에 만족했으니 다음에 보자꾸나\"", "\"What a disappointing result!\"\n\n\"But I'm pleased with your courage, so I'll see you next time.\"" },
        };
        public static string[,] Event_03 =
        {
            { "허브를 얻었습니다.", "You get hubs." },
        };
        public static string[,] Event_04 =
        {
            { "\'정체불명의 책\'을 얻었습니다..", "I got a \'Book of Mystery\'." },
        };
        public static string[,] Event_05 =
        {
            { "금화를 얻었습니다.", "You get Coin" },
            { "약초를 얻었습니다.", "You get Herb" },
            { "아이템을 얻었습니다.", "You get Item" },
            { "랜덤한 유닛을 하나 잃었습니다.", "You got a gold coin." },
        };
        public static string[,] Event_06 =
        {
            { "% 할인 받습니다.", "% off your shop" },
            { "\"코인도 없는 것 같은데 허세부리지 말게나\"\n\n투자할 코인도 없을 정도로 가난하다면 어쩔 수 없지", "\"Don't show off when you don't have the coin.\"\n\nIf you're too poor to invest, so be it." },
        };

        #endregion

        #region Stage

        public static string[,] Stage_Name =
        {
            {"일반 스테이지", "Nomal Stage" },
            {"엘리트 스테이지", "Elite Stage" },
            {"보스 스테이지", "Boss Stage" },
            {"상점", "Shop" },
            {"휴식", "Rest" },
            {"물음표", "Question" },
        };
        public static string[,] Stage_Description =
        {
            {"평범한 적이 등장합니다.", "A nomal enemy  appears." },
            {"강력한 적이 등장합니다.", "A powerful enemy appears." },
            {"보스에게 도전합니다.", "Challenge a boss." },
            {"아이템이나 유닛을 구매할 수 있는 장소입니다.", "A place to purchase items or units." },
            {"잠시 쉬어가는 장소입니다.", "A place to take a break." },
            {"무슨 일이 일어날지 알 수 없습니다.", "You don't know what's going to happen." },
        };

        #endregion

        #region Rest

        public static string[] Rest_Exp = { "경험치", "Exp" };
        public static string[,] Rest_Button =
        {
            {"단련", "Training" },
            {"약초 찾기", "Herb Search" },
            {"영혼 찾기", "Soul Search" },
        };
        public static string[,] Rest_ButtonDescription =
        {
            {"모든 유닛이 경험치를 얻습니다.", "All units gain Experience." },
            {"주변의 약초를 탐색합니다.\n\n랜덤 약초 + (1 ~ 3)", "Look around for herbs.\n\nRandom Herb + (1 ~ 3)" },
            {"동료가 될 수 있는 영혼이 있는지 찾아봅니다.\n\n랜덤 영혼 + (0 ~ 1)", "Look for kindred spirits who can be your colleagues.\n\nRandom Soul + (0 ~ 1)" },
        };

        #endregion

        #region Shop
        public static string[,] Shop_True =
        {
            {"싸게 잘 사지 않았나?", "Didn't I get a good deal?" },
            {"좋은 거래 감사하네.", "Thanks for the gool deal." },
            {"이 아이템이 자네의 목숨을 구할지도 모르지.", "This item may save your life." },
        };
        public static string[,] Shop_False =
        {
            {"돈은 있는건가?", "Do you have the coin?" },
            {"돈 없이 아이템을 넘보지 말게.", "Don't take the item without money." },
            {"한 번 정해진 가격은 절대 바꾸지 않는 것이 내 신념이라네.", "I believe in not changing the price once it's set." },
        };

        #endregion

        #region Fight_Skill

        public static string[] Skill_CostText = { "마나", "Mana" };
        public static string[] Skill_CostDescription = { "캐릭터 스킬을 사용하기 위해 사용하는 자원", "Resources used to access character skills" };

        public static string[] Skill_DelayText = { "쿨타임", "Delay" };
        public static string[,] Skill_FailedText =
        {
            {"현재는 스킬을 사용할 수 없습니다.", "The skill is currently unavailable." },
            {"현재 쿨타임인 스킬 입니다.", "The current cooldown skill." },
            {"마나가 부족합니다.", "Not enough Mana." },
            {"잘못된 타겟입니다.", "Invalid target." }
        };
        public static string[,] Skill_SetText =
        {
            {"스킬을 사용할 팀을 선택", "Select a team to use the skill on" },
            {"스킬을 사용할 적을 선택", "Select an enemy to use the skill on" },
            {"랜덤한 적 3명 점화", "Ignite 3 random enemies" },
        };
        #endregion
        
        #region Fight_UnitInfo

        public static string[] Head_LevelTooltip_HeadTeXT = { "레벨", "Level" };
        public static string[] Head_LevelTooltip_BodyTeXT = { "레벨이 오를 때 마다 최대 체력, 공격력, 마법력, 공격 속도, 방어력, 마법 저항력의 베이스 값이 10% 상승한다.", "Each level increases the base values of your Max Health, Physic, Magic, Attack Speed, Armor, and Resist by 10%." };

        public static string[] Head_Perk_Text = { "특성", "Perk" };
        public static string[] Head_PerkTooltip_NonTextHead = { "특성 없음", "No Perk" };
        public static string[] Head_PerkTooltip_NonTextBody = { "이 유닛은 특성이 없습니다.", "This unit has no perks." };
        
        public static string[,] Stat_Tooltip_HeadText =
        {
            {"공격력", "Physic" },
            {"마법력", "Magic" },
            {"공격 속도", "Attack Speed"  },
            {"방어력", "Armor" },
            {"마법 저항력", "Resist" },
            {"치명타 확률", "CriticalChance" },
            {"치명타 피해", "CriticalDamage" },
            {"체력 흡수", "Absorb"},
            {"공격 사거리", "Attack Range"},
            {"이동 속도", "Move Speed"}
        };
        public static string[,] Stat_Tooltip_BodyText =
        {
            {"기본 공격으로 주는 피해", "Basic Attack Damage" },
            {"마법 공격으로 주는 피해", "Magic Attack Damage" },
            {"유닛이 1 초 동안 하는 기본 공격 수", "Number of basic attacks a unit makes in 1 second" },
            {"물리 데미지 경감에 영향을 주는 수치", "Numbers that affect physical damage mitigation" },
            {"마법 데미지 경감에 영향을 주는 수치", "Numbers that affect magic damage mitigation" },
            {"기본 공격이 치명적인 피해로 적중할 확률", "Chance of Basic Attacks Hitting for Critical Damage" },
            {"치명타로 인한 피해 증가 계수", "Damage multiplier for critical hits" },
            {"입히는 피해를 생명력으로 흡수하는 수치", "The amount of damage you deal that is absorbed into health" },
            {"유닛의 기본 공격 사거리", "Unit's base attack range" },
            {"유닛이 1 초 동안 이동하는 블록", "Block where units move for 1 second" }
        };
        #endregion

        #region Fight_Inventory

        public static string[,] Inventory_UseText = 
        {
            { "생성할 타일 선택", "Select the Tile to use" },
            { "사용할 유닛 선택", "Select the Unit to use" }
        };
        public static string[,] Inventory_UseFalseText =
        {
            { "유닛을 생성할 수 없는 위치입니다.", "A location where units cannot be created." },
            { "아이템을 사용할 수 없는 대상입니다.", "The item is not available to." }
        };

        #endregion

        #region Fight_Reward
        
        public static string[] Reward_Coin = { "골드", "Coin" };
        public static string[] Reward_CoinDescription = { "던전에서 사용하는 금화입니다.", "Gold coins used in dungeons." };
        public static string[] Reward_Exp = { "경험치", "Exp" };
        public static string[] Reward_ExpDescription = { "싸움에 참여한 유닛이 얻는 경험치 입니다.", "The experience gained by units in the fight." };

        #endregion
        
        #region Panel

        public static string[] Panel_RefundName = { "환불", "Refund" };
        public static string[] Panel_Passive_RefundDescription = { "패시브에 사용한 금액의 50%를 돌려받습니다.", "You get back 50% of what you spent on passive." };
        public static string[] Panel_Skill_RefundDescription = { "스킬에 사용한 금액의 50%를 돌려받습니다.", "You get back 50% of the money you spent on the skill." };

        #endregion

        #region Gameover

        public static string[] Gameover_Dead = { "죽은 유닛", "Dead units" };
        public static string[,] Gameover_Info =
        {
            { "진행도", "Progress" },
            { "얻은 유닛 수", "Gained Units" },
            { "죽은 유닛 수", "Dead Units" },
            { "죽은 몬스터", "Monsters killed" },
            { "얻은 아이템 수", "Items Obtained" },
            { "사용한 아이템 수", "Items Used" },
            { "얻은 코인", "Coins Earned" },
            { "사용한 코인", "Coins Spent" },
            { "진행 - 일반 스테이지", "Stage - Nomal Stage" },
            { "진행 - 정예 스테이지", "Stage - Elite Stage" },
            { "진행 - 보스 스테이지", "Stage - Boss Stage" },
            { "진행 - 상점", "Stage - Shop" },
            { "진행 - 휴식", "Stage - Rest" },
            { "진행 - 물음표", "Stage - Question" },
        };
        public static string[,] Gameover_Character =
        {
            { "캐릭터 이름", "Character Name" },
            { "패시브 레벨", "Passive Level" },
            { "[1] 스킬 레벨", "[1] SKill Level" },
            { "[2] 스킬 레벨", "[2] SKill Level" },
            { "[3] 스킬 레벨", "[3] SKill Level" },
            { "얻은 경험치", "Experience Gained" },
        };
        public static string[,] Gameover_ResultName =
        {
            { "결과", "Result" },
            { "얻은 경험치", "Experience Gained" },
            { "젬", "Gem" }
        };

        public static string[,] Gameover_ResultValue =
        {
            { "승리", "Victory" },
            { "패배", "Defeat" },
        };

        #endregion

        #region Setting

        public static string[,] Setting_Head =
        {
            {"언어","Language" },

            {"화면 해상도","Scrreen Resolution"},
            {"전체 화면","Fullscreen Mode"},
            
            {"소리 크기 (배경음)","Volume (Background)"},
            {"소리 크기 (효과음)","Volume (Effect)"},
            
            {"싸움 UI","Fight UI" }, // 전부 숨기기, 이름만 숨기기 전부 보이기
        };
        public static string[,] Setting_AddText =
        {
            { "언어는 재실행 시 제대로 적용됩니다." ,"Language is properly applied on redo."}
        };
        public static string[] GetSettingValue(int set)
        {
            
            switch (set)
            {
                case 0: return Setting_00;
                case 1: return Setting_01;
                case 2: return Setting_02;
                case 3: return Setting_03;
                case 4: return Setting_04;
                case 5: return Setting_05;
                default: break;
            }

            return null;
        }

        public static string[] Setting_00 =
        {
            "한국어",
            "English",
            //"日本語",
            //"中文",
        };
        public static string[] Setting_01 =
        {
            "1920 x 1080",
            "1680 x 1650",
            "1600 x 900",
            "1440 x 900",
            "1400 x 1050",
            "1360 x 768",
            "1280 x 1024",
            "1280 x 960",
            "1280 x 800",
            "1280 x 720",
            "1280 x 600",
            "1024 x 768",
            "800 x 600",
            "640 x 480",
            "640 x 400",
            "512 x 384",
        };
        public static string[] Setting_02 =
        {
            "On",
            "Off",
        };
        public static string[] Setting_03 =
        {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0",
        };
        public static string[] Setting_04 =
        {
            "10",
            "9",
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "2",
            "1",
            "0",
        };
        public static string[] Setting_05 =
        {
            "Life, Name",
            "Life",
            "Off",
        };

        #endregion
    }

    public static class ColorData
    {
        public static Color White = new Color(1, 1, 1, 1);
        public static Color Black = new Color(0, 0, 0, 1);

        public static Color Gray = new Color(0.5f, 0.5f, 0.5f, 1);
        public static Color Gray_Light = new Color(0.75f, 0.75f, 0.75f, 1);
        public static Color Gray_Dark = new Color(0.25f, 0.25f, 0.25f, 1);

        static float DefaultColor_Up = 210f / 255f;
        static float DefaultColor_Down = 65f / 255f;
        static float DefaultColor_Average = (DefaultColor_Up + DefaultColor_Down) / 2f;

        public static Color Red = new Color(DefaultColor_Up, DefaultColor_Down, DefaultColor_Down, 1);
        public static Color Green = new Color(DefaultColor_Down, DefaultColor_Up, DefaultColor_Down, 1);
        public static Color Blue = new Color(DefaultColor_Down, DefaultColor_Down, DefaultColor_Up, 1);
        public static Color Yellow = new Color(DefaultColor_Up, DefaultColor_Up, DefaultColor_Down, 1);
        public static Color Magenta = new Color(DefaultColor_Up, DefaultColor_Down, DefaultColor_Up, 1);
        public static Color cyan = new Color(DefaultColor_Down, DefaultColor_Up, DefaultColor_Up, 1);
        public static Color Orange = new Color(DefaultColor_Up, DefaultColor_Average, DefaultColor_Down, 1);
        public static Color Pink = new Color(DefaultColor_Up, DefaultColor_Down, DefaultColor_Average, 1);
        public static Color GreenYellow = new Color(DefaultColor_Average, DefaultColor_Up, DefaultColor_Down, 1);
        public static Color GreenBlue = new Color(DefaultColor_Down, DefaultColor_Up, DefaultColor_Average, 1);
        public static Color Purple = new Color(DefaultColor_Average, DefaultColor_Down, DefaultColor_Up, 1);
        public static Color BlueSky = new Color(DefaultColor_Down, DefaultColor_Average, DefaultColor_Up, 1);

        static float DefaultColor_Light_Up = 220f / 255f;
        static float DefaultColor_Light_Down = 123f / 255f;
        static float DefaultColor_Light_Average = (DefaultColor_Light_Up + DefaultColor_Light_Down) / 2f;

        public static Color Red_Light = new Color(DefaultColor_Light_Up, DefaultColor_Light_Down, DefaultColor_Light_Down, 255);
        public static Color Green_Light = new Color(DefaultColor_Light_Down, DefaultColor_Light_Up, DefaultColor_Light_Down, 255);
        public static Color Blue_Light = new Color(DefaultColor_Light_Down, DefaultColor_Light_Down, DefaultColor_Light_Up, 255);
        public static Color Yellow_Light = new Color(DefaultColor_Light_Up, DefaultColor_Light_Up, DefaultColor_Light_Down, 255);
        public static Color Magenta_Light = new Color(DefaultColor_Light_Up, DefaultColor_Light_Down, DefaultColor_Light_Up, 255);
        public static Color cyan_Light = new Color(DefaultColor_Light_Down, DefaultColor_Light_Up, DefaultColor_Light_Up, 255);
        public static Color Orange_Light = new Color(DefaultColor_Light_Up, DefaultColor_Light_Average, DefaultColor_Light_Down, 255);
        public static Color Pink_Light = new Color(DefaultColor_Light_Up, DefaultColor_Light_Down, DefaultColor_Light_Average, 255);
        public static Color GreenYellow_Light = new Color(DefaultColor_Light_Average, DefaultColor_Light_Up, DefaultColor_Light_Down, 255);
        public static Color GreenBlue_Light = new Color(DefaultColor_Light_Down, DefaultColor_Light_Up, DefaultColor_Light_Average, 255);
        public static Color Purple_Light = new Color(DefaultColor_Light_Average, DefaultColor_Light_Down, DefaultColor_Light_Up, 255);
        public static Color BlueSky_Light = new Color(DefaultColor_Light_Down, DefaultColor_Light_Average, DefaultColor_Light_Up, 255);

        static float DefaultColor_Dark_Up = 145f / 255f;
        static float DefaultColor_Dark_Down = 20f / 255f;
        static float DefaultColor_Dark_Average = (DefaultColor_Dark_Up + DefaultColor_Dark_Down) / 2f;

        public static Color Red_Dark = new Color(DefaultColor_Dark_Up, DefaultColor_Dark_Down, DefaultColor_Dark_Down, 255);
        public static Color Green_Dark = new Color(DefaultColor_Dark_Down, DefaultColor_Dark_Up, DefaultColor_Dark_Down, 255);
        public static Color Blue_Dark = new Color(DefaultColor_Dark_Down, DefaultColor_Dark_Down, DefaultColor_Dark_Up, 255);
        public static Color Yellow_Dark = new Color(DefaultColor_Dark_Up, DefaultColor_Dark_Up, DefaultColor_Dark_Down, 255);
        public static Color Magenta_Dark = new Color(DefaultColor_Dark_Up, DefaultColor_Dark_Down, DefaultColor_Dark_Up, 255);
        public static Color cyan_Dark = new Color(DefaultColor_Dark_Down, DefaultColor_Dark_Up, DefaultColor_Dark_Up, 255);
        public static Color Orange_Dark = new Color(DefaultColor_Dark_Up, DefaultColor_Dark_Average, DefaultColor_Dark_Down, 255);
        public static Color Pink_Dark = new Color(DefaultColor_Dark_Up, DefaultColor_Dark_Down, DefaultColor_Dark_Average, 255);
        public static Color GreenYellow_Dark = new Color(DefaultColor_Dark_Average, DefaultColor_Dark_Up, DefaultColor_Dark_Down, 255);
        public static Color GreenBlue_Dark = new Color(DefaultColor_Dark_Down, DefaultColor_Dark_Up, DefaultColor_Dark_Average, 255);
        public static Color Purple_Dark = new Color(DefaultColor_Dark_Average, DefaultColor_Dark_Down, DefaultColor_Dark_Up, 255);
        public static Color BlueSky_Dark = new Color(DefaultColor_Dark_Down, DefaultColor_Dark_Average, DefaultColor_Dark_Up, 255);
    }
    // 게임을 돌리기 위해 저장하는 바뀌지 않는 값
    public static class SaveValue
    {
        // 화면 사이즈
        public static int[] Screen_X = { 512, 640, 640, 800, 1024, 1280, 1280, 1280, 1280, 1280, 1360, 1400, 1440, 1600, 1680, 1920 };
        public static int[] Screen_Y = { 384, 400, 480, 600, 768,  600,  720,  800,  960,  1024, 768,  1050, 900,  900,  1650, 1080 };
        // 맵 사이즈
        public static int MapSize_X { get; private set; } = 10;
        public static int MapSize_Z { get; private set; } = 8;
        
        // 이름
        public static string[] Name_First { get; private set; } = { "Dike", "Dawson", "Lambert", "Nelson", "Greenwood", "Reynolds", "Lively", "Middleton", "Bruce", "Grobbelaar", "Vader", "Spencer", "swan", "Black", "Best", "Strong", "Cowell", "Pegg", "Dominic", "Vernon", "Wells", "Syke", "Adams", "Bradley", "Andrews", "Edwards", "West", "Chapman", "Chester", "Jazz", "Ramsey", "Fowler", "Doyle", "Robson" };
        public static string[] Name_Second { get; private set; } = { "John", "Jackson", "Tara", "David", "Simon", "Bryan", "Brooke", "Kelly", "Jackie", "Bob", "Conor", "Omar", "Leon", "Aaron", "Billy", "Mark", "Roy", "Herbert", "James", "Rubin", "Darel", "Thomas", "Henry", "Danny", "Batth", "Glenn", "Victor", "Robbie", "Mike", "Morgan", "Rogers", "Max", "Scott", "Parker" };
        
        // 색
        public static Color[] StarColor { get; private set; } = { Color.gray, Color.yellow * 0.6f, Color.red * 0.6f, Color.green * 0.6f, Color.cyan * 0.6f, Color.blue * 0.6f, Color.magenta * 0.6f, Color.yellow * 1.2f, Color.red * 1.2f, Color.green * 1.2f, Color.cyan * 1.2f, Color.blue * 1.2f, Color.magenta * 1.2f, Color.white, Color.black };
        public static Color[] PerkColor { get; private set; } = { ColorData.Gray_Light, ColorData.Green_Light, ColorData.Yellow_Light, ColorData.Red_Light };
        public static Color[] ItemColor { get; private set; } = { ColorData.Gray_Light, ColorData.Blue_Light, ColorData.Yellow_Light, ColorData.Red_Light };
        
        // 스텟
        public static float DefenseConstant { get; private set; } = 250;
        public static float DamageRate { get; private set; } = 20;
        
        // 스테이지
        public static float[] StageFloor { get; private set; } = { 30, 30, 30 };
        public static int Min_StageButton { get; private set; } = 2;
        public static int Max_StageButton { get; private set; } = 6;

    }
    // 옵션과 같은 플레이어에게 저장된 게임 외 값
    public static class SaveValuePlayer
    {
        public static float[] GameSpeed = { 1f, 1.5f, 2f, 4f };

        public static float Volume_Background = 1;
        public static float Volume_Effect = 1f;
        // Life
        public static bool Life_Active = true;                              // Life 숨기기
        public static bool Life_ActiveName = true;                          // Life 이름만 숨기기

        public static Color Life_PlayerNameColor = ColorData.White;         // Life 플레이어 유닛 이름 색
        public static Color Life_EnamyNameColor = ColorData.Red;            // Life 적 유닛 이름 색

        public static Color Life_HpColor = ColorData.Green_Light;           // Life 체력 색깔
        public static Color Life_ShieldColor = ColorData.Gray_Light;        // Life 쉴드 색깔
        public static Color Life_MpColor = ColorData.Blue_Light;            // Life 마력 색깔
        // Damage Color
        public static Color[] DamageColor = { ColorData.Gray_Light, ColorData.BlueSky, ColorData.Magenta };

        public static int LanguageValue = 0;
    }
    // 플레이하며 플레이어가 바꾸는 게임 내 값
    public static class SaveValueGame
    {
        public static void Init()
        {
            Current_GameState = GameState.Stage;
            Current_FightState = FightState.Wait;

            Cost = 100;
            
            Gold = 0;
            
            Stage = 0;
            Floor = 0;
        }

        public static int CharacterId;

        public static GameState Current_GameState = GameState.Stage;
        public static FightState Current_FightState = FightState.Wait;

        public static int Cost = 100;

        private static int _Gold;
        public static int Gold
        {
            get { return _Gold; }
            set
            {
                if (SceneManager.GetActiveScene().name == "Main")
                {
                    int res = value - _Gold;

                    // 돈 얻을 때
                    if (res > 0)
                        Canvas_Main.instance._GameOver.Data_info[5] += res;
                    // 돈 잃을 때
                    if (res < 0)
                        Canvas_Main.instance._GameOver.Data_info[6] -= res;

                }

                _Gold = value;
            }
        }

        public static int Stage = 0;
        public static int Floor = 0;
    }

    //플레이어가 게임 외에 저장해야할 정보
    public static class SaveValueOutPlayer
    {
        public static int _Player_Gem = 40000;
        public static int Player_Gem
        {
            get { return _Player_Gem; }
            set
            {
                int cha = value;

                if (value < 0)
                    cha = 0;

                SetGem(cha);
                _Player_Gem = cha;
            }
        }

        public static int[] Character_Exp { get; set; } = { 0, 0, 0 };
        public static int[] Character_PassiveLevel { get; set; } = { 0, 0, 0 };
        public static int[,] Character_SkillLevel { get; set; } = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        public static void Init()
        {
            GetGem();
            GetExp();
        }
        public static void GetGem()
        {
            if (PlayerPrefs.HasKey("Gem"))
                Player_Gem = PlayerPrefs.GetInt("Gem");
            else
                Player_Gem = 0;
        }
        public static void GetExp()
        {
            for (int i = 0; i < Character_Exp.Length; i++)
            {
                if (PlayerPrefs.HasKey("Exp" + i))
                    Character_Exp[i] = PlayerPrefs.GetInt("Exp" + i);
                else
                {
                    Character_Exp[i] = 0;
                    PlayerPrefs.SetInt("Exp" + i, 0);
                }
            }
        }


        public static void SetGem(int value)
        {
            PlayerPrefs.SetInt("Gem", value);
        }
        public static void SetExp(int value)
        {
            PlayerPrefs.SetInt("Exp" + value, Character_Exp[value]);
        }

    }
    // 세팅값
    public static class SaveValueSetting
    {
        public static int[] SettingValue =
        {
            0,
            0,
            0,
            0,
            0,
            0,
        };

        public static void Init()
        {
            for (int i = 0; i < SettingValue.Length; i++)
            {
                GetSetting(i);
                DataSetting(i, SettingValue[i]);
            }
        }

        public static void GetSetting(int value)
        {
            if (value >= SettingValue.Length)
                return;

            if (PlayerPrefs.HasKey("Setting " + value))
            {
                SettingValue[value] = PlayerPrefs.GetInt("Setting " + value);
            }
            else
            {
                SettingValue[value] = 0;
                PlayerPrefs.SetInt("Setting " + value, SettingValue[value]);
            }
        }
        public static void SatSetting(int value, int save)
        {
            if (value >= SettingValue.Length)
                return;

            // 세이브가 있으면
            if (PlayerPrefs.HasKey("Setting " + value))
            {
                // 저장된 값과 다르면
                if (SettingValue[value] != save)
                {
                    SettingValue[value] = save;
                    DataSetting(value, save);
                    PlayerPrefs.SetInt("Setting " + value, save);
                }
            }
            // 세이브가 없으면
            else
            {
                PlayerPrefs.SetInt("Setting " + value, save);
            }
        }

        public static void DataSetting(int value, int save)
        {
            switch (value)
            {
                case 0:
                    {
                        SaveValuePlayer.LanguageValue = save;
                    } break;
                case 1:
                    {
                        GameManager.SetScreenResolution(SaveValue.Screen_X[SaveValue.Screen_X.Length - 1 - save], SaveValue.Screen_Y[SaveValue.Screen_Y.Length - 1 - save], SettingValue[2] == 0 ? true : false);
                    } break;
                case 2:
                    {
                        GameManager.SetScreenResolution(SaveValue.Screen_X[SaveValue.Screen_X.Length - 1 - SettingValue[1]], SaveValue.Screen_Y[SaveValue.Screen_Y.Length - 1 - SettingValue[1]], save == 0 ? true : false);
                    }
                    break;
                case 3:
                    {
                        SaveValuePlayer.Volume_Background = (10f - save) / 10f;
                        
                        if (SceneManager.GetActiveScene().name == "Main")
                            Sound_Main.instance.ChangeBackgroundSound();
                    } break;
                case 4:
                    {
                        SaveValuePlayer.Volume_Effect = (10f - save) / 10f;
                    } break;
                case 5:
                    {
                        switch (save)
                        {
                            case 0:
                                {
                                    SaveValuePlayer.Life_ActiveName = true;
                                    SaveValuePlayer.Life_Active = true;
                                } break;
                            case 1:
                                {
                                    SaveValuePlayer.Life_ActiveName = false;
                                    SaveValuePlayer.Life_Active = true;
                                } break;
                            case 2:
                                {
                                    SaveValuePlayer.Life_ActiveName = false;
                                    SaveValuePlayer.Life_Active = false;
                                } break;
                            default: break;
                        }
                    } break;
                default: break;
            }
            SatSetting(value, save);
        }
    }
}