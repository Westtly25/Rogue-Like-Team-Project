using UnityEngine;
using UnityEditor;
using RogueLike.Combat;

public class DamageResistanceContainerSOEditorWindow : EditorWindow
{

    [MenuItem("Window/Rogue Like/Damage Resistance ContainerSO Editor Window")]
    public static void Open(DamageResistanceDataContainerSO damageResistanceContainerSO)
    {
        var window = GetWindow<DamageResistanceContainerSOEditorWindow>();
        window.titleContent = new GUIContent("DamageResistanceContainerSOEditorWindow");
        window.minSize = new Vector2(600, 600);
    }

    Rect headerRect;
    Rect sideBarRect;
    Rect bodyRect;
    Rect bottomRect;
    Vector2 scrollPosition;

    float spacing = 10f;

    private GUIStyle titleLabelStyle;

    private string searchText;

    private void OnEnable()
    {
        InitializeStyles();
    }

    private void OnGUI()
    {
        DrawHeader();
        DrawSideBar();
        DrawBodySection();
        DrawBottomSection();
    }

    private void InitializeStyles()
    {
        titleLabelStyle = new GUIStyle(GUI.skin.label) { fontSize = 25, fontStyle = FontStyle.Bold, alignment = TextAnchor.MiddleLeft, margin = new RectOffset(10, 10, 10, 10) };
    }

    private void DrawHeader()
    {
        headerRect = new Rect(0, 0, EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.width , 50f);

        GUILayout.BeginArea(headerRect, "", "box");

        GUILayout.Label("Damage Resistace Editor", titleLabelStyle);
        

        GUILayout.EndArea();
    }

    private void DrawSideBar()
    {
        sideBarRect = new Rect(0, headerRect.height + spacing,
                               EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.width / 3,
                               EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.height - headerRect.height - spacing - bottomRect.height);

        GUILayout.BeginArea(sideBarRect, "" ,"box");
        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Button("New");
        GUILayout.Button("Delete");
        GUILayout.EndHorizontal();

        GUILayout.Button("Save");

        GUILayout.BeginHorizontal();
        searchText = GUILayout.TextField(searchText, GUI.skin.FindStyle("ToolbarSeachTextField"));
        if (GUILayout.Button("", GUI.skin.FindStyle("ToolbarSeachCancelButton")))
        {
            searchText = "";
            GUI.FocusControl(null);
        }
        GUILayout.EndHorizontal();

        GUILayout.Label("Damage Resistances List");

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, "box");
        for (int i = 0; i < 10; i++)
        {
            GUILayout.Button("Resistance");
        }
        GUILayout.EndScrollView();

        GUILayout.EndVertical();
        GUILayout.EndArea();

    }

    private void DrawBodySection()
    {
        bodyRect = new Rect(sideBarRect.width + spacing, headerRect.height + spacing,
                            EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.width - sideBarRect.width - spacing,
                            EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.height - headerRect.height - spacing - bottomRect.height);

        GUILayout.BeginArea(bodyRect, "", "box");
        if(GUILayout.Button("Load"))
        {
            Load();
        }
        GUILayout.EndArea();
    }

    private void DrawBottomSection()
    {
        bottomRect = new Rect(0 , headerRect.height + spacing + sideBarRect.height,
                            EditorWindow.GetWindow<DamageResistanceContainerSOEditorWindow>().position.width,
                            20);

        GUILayout.BeginArea(bottomRect, "Project Dreams Studio", "box");
        GUILayout.EndArea();
    }

    private void Load()
    {
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath("Assets/Scripts/Combat/Damage Type");
        Debug.Log(objects.Length);
    }
}