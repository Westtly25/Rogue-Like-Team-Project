using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using RogueLike.Characteristics;

public class CharacterEditorWindow : EditorWindow
{
    AnimationCurve progresCurve = new AnimationCurve();

    private Rect headerSection;
    private Rect characteristicsSection;
    private Rect bottomSection;

    private static ScriptableCharacteristicsContainer characteristicsCharacter;
    public static ScriptableCharacteristicsContainer CharacteristicsCharacter { get { return characteristicsCharacter; }}


    [MenuItem("Window/Rogue Like/Character Designer")]
    public static void Open()
    {
        CharacterEditorWindow window = (CharacterEditorWindow)GetWindow<CharacterEditorWindow>();
        window.minSize = new Vector2(600, 300);
        window.Show();
    }

    private void OnEnable()
    {
        InitData();
    }

    private void OnGUI()
    {
        DrawLayouts();
        DrawHeader();
        DrawCharacteristics();
        DrawBottom();

    }

    private void InitData()
    {
        characteristicsCharacter = (ScriptableCharacteristicsContainer)ScriptableObject.CreateInstance(typeof(ScriptableCharacteristicsContainer));

        SetCurve();
    }

    private void InitTextures()
    {

    }

    private void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 0;

        headerSection.width = Screen.width;
        headerSection.height = 50;

        characteristicsSection.x = 0;
        characteristicsSection.y = 50;
        characteristicsSection.width = Screen.width;
        characteristicsSection.height = Screen.height - 50;

        bottomSection.x = 0;
        bottomSection.y = Screen.height - 100;

        bottomSection.width = Screen.width;
        bottomSection.height = 50;
    }

    private void DrawHeader()
    {
        GUILayout.BeginArea((headerSection));
        GUILayout.BeginVertical("box", GUILayout.Width(Screen.width), GUILayout.Height(50));
        GUILayout.Label("Character");
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }

    private void DrawBottom()
    {
        GUILayout.BeginArea((bottomSection));
        GUILayout.BeginHorizontal("box");
        if(GUILayout.Button("РАСЧЕТ", GUILayout.Width(100), GUILayout.Height(25)))
        {
            for (var j = 0; j < values.GetLength(0); j++)
            {
                for (var cell = 0; cell < values.GetLength(1); cell++)
                {
                    values[j, cell] = valuesBase[cell] * progresCurve.keys[j].value;
                }
            }
        }
        GUILayout.Space(10f);
        GUILayout.Button("СОХРАНИТЬ", GUILayout.Width(100), GUILayout.Height(25));
        GUILayout.Space(10f);
        if(GUILayout.Button("СБРОСИТЬ", GUILayout.Width(100), GUILayout.Height(25)))
        {
            for (var i = 0; i < values.GetLength(0); i++)
            {
                for (var j = 0; j < values.GetLength(1); j++)
                {
                    values[i, j] = 0;
                }
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private void SetCurve()
    {
        float keysCount = 100;
        for (var i = 0; i < keysCount; i++)
        {
            progresCurve.AddKey(Mathf.RoundToInt(i), Mathf.RoundToInt(i));
        }
    }

    private Vector2 scrollPos;

    private float characterLevel;
    private float CharacterLevel
    {
        get { return characterLevel; }
        set
        {
            characterLevel = value;
            Debug.Log("Value Changed " + value);
        }
    }

    private float minCharacterLevel = 0;
    private float maxCharacterLevel = 100;

    private float[] valuesBase = new float[5] { 100f, 100f, 100f, 100f, 100f };
    private float[,] values = new float[100, 5];
    private string[] stringsTitle = new string[] {"Health", "Rage" ,"Strength", "Agility" , "Speed"};

    private void DrawCharacteristics()
    {
        GUILayout.BeginArea(characteristicsSection);
        GUILayout.BeginVertical(GUILayout.Width(Screen.width));

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Characteristics Chart");
        EditorGUILayout.CurveField(progresCurve, GUILayout.Width(300), GUILayout.Height(300));
        GUILayout.EndVertical();

        GUILayout.BeginVertical();
        GUILayout.Label("Base Characteristics");
        GUILayout.BeginVertical("box", GUILayout.Width(Screen.width - 20f));
        for (var i = 0; i < valuesBase.Length; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(stringsTitle[i], EditorStyles.boldLabel);
            valuesBase[i] = EditorGUILayout.FloatField(valuesBase[i], GUILayout.Width(100), GUILayout.Height(25));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal("box", GUILayout.Width(Screen.width - 10f));
        if(GUILayout.Button("ЛИНЕЙНЫЙ", GUILayout.Width(100), GUILayout.Height(25)))
        {

        }
        GUILayout.Space(10f);
        if(GUILayout.Button("ЛИНЕЙНЫЙ", GUILayout.Width(100), GUILayout.Height(25)))
        {

        }
        GUILayout.Space(10f);
        if(GUILayout.Button("ЛИНЕЙНЫЙ", GUILayout.Width(100), GUILayout.Height(25)))
        {
        }
        GUILayout.Space(10f);
        if(GUILayout.Button("ОБНОВИТЬ ГРАФИК", GUILayout.Width(150), GUILayout.Height(25)))
        {
            SetCurve();
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(Screen.width));

        GUILayout.BeginVertical();
        GUILayout.Label("Character Level");

        GUILayout.BeginHorizontal("box");
        GUILayout.Label(minCharacterLevel.ToString());
        CharacterLevel = GUILayout.HorizontalSlider(Mathf.RoundToInt(CharacterLevel), minCharacterLevel, maxCharacterLevel, GUILayout.Width(Screen.width - 60f));
        GUILayout.Label(maxCharacterLevel.ToString());
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal("box");
        GUILayout.Label($"Current Level : {CharacterLevel}");
        GUILayout.Label($"Current Value : {progresCurve.keys[Mathf.RoundToInt(CharacterLevel)].value}");
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        GUILayout.Space(20f);

        GUILayout.Label("Base Characteristics");

        GUILayout.BeginHorizontal("box", GUILayout.Width(Screen.width - 20f));
        for (var i = 0; i < valuesBase.Length; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(stringsTitle[i], EditorStyles.boldLabel);
            valuesBase[i] = EditorGUILayout.FloatField(valuesBase[i], GUILayout.Width(100), GUILayout.Height(25));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(5f);

        GUILayout.Label("Calculated Characteristics");

        scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(Screen.width - 10), GUILayout.Height(400));

        GUILayout.BeginVertical();

        for (var i = 0; i < values.GetLength(0); i++)
        {
            GUILayout.Label($"Level {i}");

            GUILayout.BeginHorizontal("box");
            for (var cell = 0; cell < values.GetLength(1); cell++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(stringsTitle[cell]);
                values[i, cell] = EditorGUILayout.FloatField(values[i, cell], GUILayout.Width(60), GUILayout.Height(20));
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();
        }
        GUILayout.EndVertical();
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
        GUILayout.EndVertical();

        GUILayout.EndArea();
    }
}