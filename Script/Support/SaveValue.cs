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
            {"�ִ� ü��","Max Health" },           // 0
            {"���ݷ�", "Physic" },                 // 1
            {"���� �����", "PhysicPiercing" },    // 2
            {"������", "Magic" },                  // 3
            {"���� �����", "MagicPiercing" },     // 4
            {"���� �ӵ�", "Attack Speed" },        // 5
            {"����", "Armor" },                  // 6
            {"���� ���׷�", "Resist" },            // 7
            {"ġ��Ÿ Ȯ��", "CriticalChance" },    // 8
            {"ġ��Ÿ ����", "CriticalDamage" },    // 9
            {"ü�� ���", "Absorb" },              // 10
            {"���� ��Ÿ�", "Attack Range" },      // 11
            {"�̵� �ӵ�", "Move Speed" },          // 12
            {"���� ����", "DamageReduction" },     // 13
            {"���� ����", "DamageIncrease" }       // 14
        };
        
        #region Event
        public static string[] Event_BackButton = { "�ڷΰ���", "Back" };

        public static string[,] Event_00 =
        {
            { "\'õ���� ��\'�� ������ϴ�.", "You have obtained \'Angelic Blood\'." },
            { "\'�Ǹ��� ��\'�� ������ϴ�.", "You have obtained \'Demon Blood\'." },
            { "������ ������ �ϳ� �Ҿ����ϴ�.", "You lost a random unit." },
        };
        public static string[,] Event_01 =
        {
            { "������ ������ �ϳ� ������ϴ�.", "You get a random unit." },
            { "������ ������ �� ������ϴ�.", "You get two random units." },
            { "������ ������ �� ������ϴ�.", "You get three random units." },
            { "��ȥ�� ������ ���� ��� ��������ϴ�.", "The spirits disappeared with nothing but insufficient coin." },
            { "��ȥ�� ���� �ǳ��� ���� ������� ���ᰡ �Ǿ���.", "When he handed the coin to the spirit, it disappeared and became his companion." },
            { "\"���� ������ �� ����\"\n\n��ȥ�� ���� ����������� �������.", "\"I guess I don't have enough money.\"\n\nThe spirit grew fainter and fainter, then disappeared." },
        };
        public static string[,] Event_02 =
        {
            { "��带 ������ϴ�.", "You've earned Coin." },
            { "��� ��带 �Ҿ����ϴ�.", "lost all Coin." },
            { "\"�����ϳ�!\"\n\n\"�ڳ��� ��⸦ ������ ����� �ްԳ�!\"", "\"Congratulation!, you've shown your courage!\"" },
            { "\"�ƽ��� ����α���!\"\n\n\"������ ���� ��⿡ ���������� ������ ���ڲٳ�\"", "\"What a disappointing result!\"\n\n\"But I'm pleased with your courage, so I'll see you next time.\"" },
        };
        public static string[,] Event_03 =
        {
            { "��긦 ������ϴ�.", "You get hubs." },
        };
        public static string[,] Event_04 =
        {
            { "\'��ü�Ҹ��� å\'�� ������ϴ�..", "I got a \'Book of Mystery\'." },
        };
        public static string[,] Event_05 =
        {
            { "��ȭ�� ������ϴ�.", "You get Coin" },
            { "���ʸ� ������ϴ�.", "You get Herb" },
            { "�������� ������ϴ�.", "You get Item" },
            { "������ ������ �ϳ� �Ҿ����ϴ�.", "You got a gold coin." },
        };
        public static string[,] Event_06 =
        {
            { "% ���� �޽��ϴ�.", "% off your shop" },
            { "\"���ε� ���� �� ������ �㼼�θ��� ���Գ�\"\n\n������ ���ε� ���� ������ �����ϴٸ� ��¿ �� ����", "\"Don't show off when you don't have the coin.\"\n\nIf you're too poor to invest, so be it." },
        };

        #endregion

        #region Stage

        public static string[,] Stage_Name =
        {
            {"�Ϲ� ��������", "Nomal Stage" },
            {"����Ʈ ��������", "Elite Stage" },
            {"���� ��������", "Boss Stage" },
            {"����", "Shop" },
            {"�޽�", "Rest" },
            {"����ǥ", "Question" },
        };
        public static string[,] Stage_Description =
        {
            {"����� ���� �����մϴ�.", "A nomal enemy  appears." },
            {"������ ���� �����մϴ�.", "A powerful enemy appears." },
            {"�������� �����մϴ�.", "Challenge a boss." },
            {"�������̳� ������ ������ �� �ִ� ����Դϴ�.", "A place to purchase items or units." },
            {"��� ����� ����Դϴ�.", "A place to take a break." },
            {"���� ���� �Ͼ�� �� �� �����ϴ�.", "You don't know what's going to happen." },
        };

        #endregion

        #region Rest

        public static string[] Rest_Exp = { "����ġ", "Exp" };
        public static string[,] Rest_Button =
        {
            {"�ܷ�", "Training" },
            {"���� ã��", "Herb Search" },
            {"��ȥ ã��", "Soul Search" },
        };
        public static string[,] Rest_ButtonDescription =
        {
            {"��� ������ ����ġ�� ����ϴ�.", "All units gain Experience." },
            {"�ֺ��� ���ʸ� Ž���մϴ�.\n\n���� ���� + (1 ~ 3)", "Look around for herbs.\n\nRandom Herb + (1 ~ 3)" },
            {"���ᰡ �� �� �ִ� ��ȥ�� �ִ��� ã�ƺ��ϴ�.\n\n���� ��ȥ + (0 ~ 1)", "Look for kindred spirits who can be your colleagues.\n\nRandom Soul + (0 ~ 1)" },
        };

        #endregion

        #region Shop
        public static string[,] Shop_True =
        {
            {"�ΰ� �� ���� �ʾҳ�?", "Didn't I get a good deal?" },
            {"���� �ŷ� �����ϳ�.", "Thanks for the gool deal." },
            {"�� �������� �ڳ��� ����� �������� ����.", "This item may save your life." },
        };
        public static string[,] Shop_False =
        {
            {"���� �ִ°ǰ�?", "Do you have the coin?" },
            {"�� ���� �������� �Ѻ��� ����.", "Don't take the item without money." },
            {"�� �� ������ ������ ���� �ٲ��� �ʴ� ���� �� �ų��̶��.", "I believe in not changing the price once it's set." },
        };

        #endregion

        #region Fight_Skill

        public static string[] Skill_CostText = { "����", "Mana" };
        public static string[] Skill_CostDescription = { "ĳ���� ��ų�� ����ϱ� ���� ����ϴ� �ڿ�", "Resources used to access character skills" };

        public static string[] Skill_DelayText = { "��Ÿ��", "Delay" };
        public static string[,] Skill_FailedText =
        {
            {"����� ��ų�� ����� �� �����ϴ�.", "The skill is currently unavailable." },
            {"���� ��Ÿ���� ��ų �Դϴ�.", "The current cooldown skill." },
            {"������ �����մϴ�.", "Not enough Mana." },
            {"�߸��� Ÿ���Դϴ�.", "Invalid target." }
        };
        public static string[,] Skill_SetText =
        {
            {"��ų�� ����� ���� ����", "Select a team to use the skill on" },
            {"��ų�� ����� ���� ����", "Select an enemy to use the skill on" },
            {"������ �� 3�� ��ȭ", "Ignite 3 random enemies" },
        };
        #endregion
        
        #region Fight_UnitInfo

        public static string[] Head_LevelTooltip_HeadTeXT = { "����", "Level" };
        public static string[] Head_LevelTooltip_BodyTeXT = { "������ ���� �� ���� �ִ� ü��, ���ݷ�, ������, ���� �ӵ�, ����, ���� ���׷��� ���̽� ���� 10% ����Ѵ�.", "Each level increases the base values of your Max Health, Physic, Magic, Attack Speed, Armor, and Resist by 10%." };

        public static string[] Head_Perk_Text = { "Ư��", "Perk" };
        public static string[] Head_PerkTooltip_NonTextHead = { "Ư�� ����", "No Perk" };
        public static string[] Head_PerkTooltip_NonTextBody = { "�� ������ Ư���� �����ϴ�.", "This unit has no perks." };
        
        public static string[,] Stat_Tooltip_HeadText =
        {
            {"���ݷ�", "Physic" },
            {"������", "Magic" },
            {"���� �ӵ�", "Attack Speed"  },
            {"����", "Armor" },
            {"���� ���׷�", "Resist" },
            {"ġ��Ÿ Ȯ��", "CriticalChance" },
            {"ġ��Ÿ ����", "CriticalDamage" },
            {"ü�� ���", "Absorb"},
            {"���� ��Ÿ�", "Attack Range"},
            {"�̵� �ӵ�", "Move Speed"}
        };
        public static string[,] Stat_Tooltip_BodyText =
        {
            {"�⺻ �������� �ִ� ����", "Basic Attack Damage" },
            {"���� �������� �ִ� ����", "Magic Attack Damage" },
            {"������ 1 �� ���� �ϴ� �⺻ ���� ��", "Number of basic attacks a unit makes in 1 second" },
            {"���� ������ �氨�� ������ �ִ� ��ġ", "Numbers that affect physical damage mitigation" },
            {"���� ������ �氨�� ������ �ִ� ��ġ", "Numbers that affect magic damage mitigation" },
            {"�⺻ ������ ġ������ ���ط� ������ Ȯ��", "Chance of Basic Attacks Hitting for Critical Damage" },
            {"ġ��Ÿ�� ���� ���� ���� ���", "Damage multiplier for critical hits" },
            {"������ ���ظ� ��������� ����ϴ� ��ġ", "The amount of damage you deal that is absorbed into health" },
            {"������ �⺻ ���� ��Ÿ�", "Unit's base attack range" },
            {"������ 1 �� ���� �̵��ϴ� ���", "Block where units move for 1 second" }
        };
        #endregion

        #region Fight_Inventory

        public static string[,] Inventory_UseText = 
        {
            { "������ Ÿ�� ����", "Select the Tile to use" },
            { "����� ���� ����", "Select the Unit to use" }
        };
        public static string[,] Inventory_UseFalseText =
        {
            { "������ ������ �� ���� ��ġ�Դϴ�.", "A location where units cannot be created." },
            { "�������� ����� �� ���� ����Դϴ�.", "The item is not available to." }
        };

        #endregion

        #region Fight_Reward
        
        public static string[] Reward_Coin = { "���", "Coin" };
        public static string[] Reward_CoinDescription = { "�������� ����ϴ� ��ȭ�Դϴ�.", "Gold coins used in dungeons." };
        public static string[] Reward_Exp = { "����ġ", "Exp" };
        public static string[] Reward_ExpDescription = { "�ο� ������ ������ ��� ����ġ �Դϴ�.", "The experience gained by units in the fight." };

        #endregion
        
        #region Panel

        public static string[] Panel_RefundName = { "ȯ��", "Refund" };
        public static string[] Panel_Passive_RefundDescription = { "�нú꿡 ����� �ݾ��� 50%�� �����޽��ϴ�.", "You get back 50% of what you spent on passive." };
        public static string[] Panel_Skill_RefundDescription = { "��ų�� ����� �ݾ��� 50%�� �����޽��ϴ�.", "You get back 50% of the money you spent on the skill." };

        #endregion

        #region Gameover

        public static string[] Gameover_Dead = { "���� ����", "Dead units" };
        public static string[,] Gameover_Info =
        {
            { "���൵", "Progress" },
            { "���� ���� ��", "Gained Units" },
            { "���� ���� ��", "Dead Units" },
            { "���� ����", "Monsters killed" },
            { "���� ������ ��", "Items Obtained" },
            { "����� ������ ��", "Items Used" },
            { "���� ����", "Coins Earned" },
            { "����� ����", "Coins Spent" },
            { "���� - �Ϲ� ��������", "Stage - Nomal Stage" },
            { "���� - ���� ��������", "Stage - Elite Stage" },
            { "���� - ���� ��������", "Stage - Boss Stage" },
            { "���� - ����", "Stage - Shop" },
            { "���� - �޽�", "Stage - Rest" },
            { "���� - ����ǥ", "Stage - Question" },
        };
        public static string[,] Gameover_Character =
        {
            { "ĳ���� �̸�", "Character Name" },
            { "�нú� ����", "Passive Level" },
            { "[1] ��ų ����", "[1] SKill Level" },
            { "[2] ��ų ����", "[2] SKill Level" },
            { "[3] ��ų ����", "[3] SKill Level" },
            { "���� ����ġ", "Experience Gained" },
        };
        public static string[,] Gameover_ResultName =
        {
            { "���", "Result" },
            { "���� ����ġ", "Experience Gained" },
            { "��", "Gem" }
        };

        public static string[,] Gameover_ResultValue =
        {
            { "�¸�", "Victory" },
            { "�й�", "Defeat" },
        };

        #endregion

        #region Setting

        public static string[,] Setting_Head =
        {
            {"���","Language" },

            {"ȭ�� �ػ�","Scrreen Resolution"},
            {"��ü ȭ��","Fullscreen Mode"},
            
            {"�Ҹ� ũ�� (�����)","Volume (Background)"},
            {"�Ҹ� ũ�� (ȿ����)","Volume (Effect)"},
            
            {"�ο� UI","Fight UI" }, // ���� �����, �̸��� ����� ���� ���̱�
        };
        public static string[,] Setting_AddText =
        {
            { "���� ����� �� ����� ����˴ϴ�." ,"Language is properly applied on redo."}
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
            "�ѱ���",
            "English",
            //"������",
            //"����",
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
    // ������ ������ ���� �����ϴ� �ٲ��� �ʴ� ��
    public static class SaveValue
    {
        // ȭ�� ������
        public static int[] Screen_X = { 512, 640, 640, 800, 1024, 1280, 1280, 1280, 1280, 1280, 1360, 1400, 1440, 1600, 1680, 1920 };
        public static int[] Screen_Y = { 384, 400, 480, 600, 768,  600,  720,  800,  960,  1024, 768,  1050, 900,  900,  1650, 1080 };
        // �� ������
        public static int MapSize_X { get; private set; } = 10;
        public static int MapSize_Z { get; private set; } = 8;
        
        // �̸�
        public static string[] Name_First { get; private set; } = { "Dike", "Dawson", "Lambert", "Nelson", "Greenwood", "Reynolds", "Lively", "Middleton", "Bruce", "Grobbelaar", "Vader", "Spencer", "swan", "Black", "Best", "Strong", "Cowell", "Pegg", "Dominic", "Vernon", "Wells", "Syke", "Adams", "Bradley", "Andrews", "Edwards", "West", "Chapman", "Chester", "Jazz", "Ramsey", "Fowler", "Doyle", "Robson" };
        public static string[] Name_Second { get; private set; } = { "John", "Jackson", "Tara", "David", "Simon", "Bryan", "Brooke", "Kelly", "Jackie", "Bob", "Conor", "Omar", "Leon", "Aaron", "Billy", "Mark", "Roy", "Herbert", "James", "Rubin", "Darel", "Thomas", "Henry", "Danny", "Batth", "Glenn", "Victor", "Robbie", "Mike", "Morgan", "Rogers", "Max", "Scott", "Parker" };
        
        // ��
        public static Color[] StarColor { get; private set; } = { Color.gray, Color.yellow * 0.6f, Color.red * 0.6f, Color.green * 0.6f, Color.cyan * 0.6f, Color.blue * 0.6f, Color.magenta * 0.6f, Color.yellow * 1.2f, Color.red * 1.2f, Color.green * 1.2f, Color.cyan * 1.2f, Color.blue * 1.2f, Color.magenta * 1.2f, Color.white, Color.black };
        public static Color[] PerkColor { get; private set; } = { ColorData.Gray_Light, ColorData.Green_Light, ColorData.Yellow_Light, ColorData.Red_Light };
        public static Color[] ItemColor { get; private set; } = { ColorData.Gray_Light, ColorData.Blue_Light, ColorData.Yellow_Light, ColorData.Red_Light };
        
        // ����
        public static float DefenseConstant { get; private set; } = 250;
        public static float DamageRate { get; private set; } = 20;
        
        // ��������
        public static float[] StageFloor { get; private set; } = { 30, 30, 30 };
        public static int Min_StageButton { get; private set; } = 2;
        public static int Max_StageButton { get; private set; } = 6;

    }
    // �ɼǰ� ���� �÷��̾�� ����� ���� �� ��
    public static class SaveValuePlayer
    {
        public static float[] GameSpeed = { 1f, 1.5f, 2f, 4f };

        public static float Volume_Background = 1;
        public static float Volume_Effect = 1f;
        // Life
        public static bool Life_Active = true;                              // Life �����
        public static bool Life_ActiveName = true;                          // Life �̸��� �����

        public static Color Life_PlayerNameColor = ColorData.White;         // Life �÷��̾� ���� �̸� ��
        public static Color Life_EnamyNameColor = ColorData.Red;            // Life �� ���� �̸� ��

        public static Color Life_HpColor = ColorData.Green_Light;           // Life ü�� ����
        public static Color Life_ShieldColor = ColorData.Gray_Light;        // Life ���� ����
        public static Color Life_MpColor = ColorData.Blue_Light;            // Life ���� ����
        // Damage Color
        public static Color[] DamageColor = { ColorData.Gray_Light, ColorData.BlueSky, ColorData.Magenta };

        public static int LanguageValue = 0;
    }
    // �÷����ϸ� �÷��̾ �ٲٴ� ���� �� ��
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

                    // �� ���� ��
                    if (res > 0)
                        Canvas_Main.instance._GameOver.Data_info[5] += res;
                    // �� ���� ��
                    if (res < 0)
                        Canvas_Main.instance._GameOver.Data_info[6] -= res;

                }

                _Gold = value;
            }
        }

        public static int Stage = 0;
        public static int Floor = 0;
    }

    //�÷��̾ ���� �ܿ� �����ؾ��� ����
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
    // ���ð�
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

            // ���̺갡 ������
            if (PlayerPrefs.HasKey("Setting " + value))
            {
                // ����� ���� �ٸ���
                if (SettingValue[value] != save)
                {
                    SettingValue[value] = save;
                    DataSetting(value, save);
                    PlayerPrefs.SetInt("Setting " + value, save);
                }
            }
            // ���̺갡 ������
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