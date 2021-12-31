using RogueLike.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemEditorWindow : EditorWindow
{
    private Rect sideSection;
    private Rect headerSection;
    private Rect bodySection;
    private Rect bottomSection;

    private float spacing = 10f;

    private Vector2 sideScrollPosition;
    private Vector2 characteristicsScrollPosition;

    private Texture iconTexture;
    private string itemTitle;
    private string itemDescription;

    private string pathToSaveLoad = "Assets/Scriptable Objects/Scriptable Inventory";

    private Object[] loadedItems;

    [MenuItem("Window/Rogue Like/Item's Designer")]
    public static void Open()
    {
        ItemEditorWindow window = (ItemEditorWindow)GetWindow<ItemEditorWindow>();
        window.minSize = new Vector2(600, 300);
        window.titleContent = new GUIContent("Item Designer Window");
        window.Show();
    }

    private void OnEnable()
    {
        LoadItemsAssets();
        InitializeList();
    }

    private void OnGUI()
    {
        InitializeSections();
        DrawSideBar();
        DrawHeader();
        DrawBody();
        DrawBottom();
    }

    private void InitializeSections()
    {
        sideSection.x = 0;
        sideSection.y = 0;
        sideSection.height = Screen.height;
        sideSection.width = 150f;

        headerSection.x = sideSection.width + spacing;
        headerSection.y = 0;
        headerSection.height = 100f;
        headerSection.width = position.width - sideSection.width - spacing;

        bodySection.x = sideSection.width + spacing;
        bodySection.y = headerSection.height;
        bodySection.height = 400f;
        bodySection.width = position.width - sideSection.width - spacing;

        bottomSection.x = sideSection.width + spacing;
        bottomSection.y = headerSection.height + bodySection.height;
        bottomSection.height = 100f;
        bottomSection.width = position.width - sideSection.width - spacing;
    }

    private void DrawSideBar()
    {
        GUILayout.BeginArea(sideSection);
        sideScrollPosition = GUILayout.BeginScrollView(sideScrollPosition, "box", GUILayout.Width(sideSection.width), GUILayout.Height(sideSection.height));
        for (int i = 0; i < loadedItems.Length; i++)
        {
            GUILayout.Button($"Item {i}", GUILayout.Width(sideSection.width - 10f), GUILayout.Height(25));
        }
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

    private void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);
        GUILayout.BeginHorizontal("box", GUILayout.Width(headerSection.width), GUILayout.Height(headerSection.height));

        if (!iconTexture)
        {
            GUI.DrawTexture(new Rect(10, 10, 60, 60), iconTexture, ScaleMode.ScaleToFit, true, 10.0F);
        }

        GUILayout.BeginVertical();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Item Name");
        itemTitle = EditorGUILayout.TextArea(itemTitle, GUILayout.Width(450));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Item Description");
        itemDescription = EditorGUILayout.TextArea(itemDescription, GUILayout.Width(450));
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    private List<ItemDataEditor> itemDataEditors = new List<ItemDataEditor>();

    private void InitializeList()
    {
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
        itemDataEditors.Add(new ItemDataEditor { });
    }

    private void DrawBody()
    {
        GUILayout.BeginArea(bodySection);
        GUILayout.Space(spacing);

        GUILayout.Label("Item Characteristics");

        characteristicsScrollPosition = GUILayout.BeginScrollView(characteristicsScrollPosition);

        for (int i = 0; i < itemDataEditors.Count; i++)
        {
            GUILayout.BeginHorizontal("box", GUILayout.Width(150), GUILayout.Height(30));
            GUILayout.Label(itemDataEditors[i].Name + i);
            itemDataEditors[i].value = EditorGUILayout.FloatField(itemDataEditors[i].value, GUILayout.Width(50), GUILayout.Height(20));
            GUILayout.EndHorizontal();
        }

        GUILayout.EndScrollView();

        GUILayout.EndArea();
    }

    private void DrawBottom()
    {
        GUILayout.BeginArea(bottomSection);
        GUILayout.Space(spacing);
        GUILayout.BeginHorizontal("box", GUILayout.Width(bottomSection.width), GUILayout.Height(bottomSection.height));
        GUILayout.Button("Reset", GUILayout.Width(100), GUILayout.Height(25));

        if (GUILayout.Button("Save", GUILayout.Width(100), GUILayout.Height(25)))
        {
            CreateMyAsset();
        }

        GUILayout.Button("Delete", GUILayout.Width(100), GUILayout.Height(25));

        if (GUILayout.Button("Load", GUILayout.Width(100), GUILayout.Height(25)))
        {
            LoadItemsAssets();
        }

        GUILayout.EndHorizontal();
        GUILayout.EndArea();
    }

    public void CreateMyAsset()
    {
        InventoryItemInfoSO asset = ScriptableObject.CreateInstance<InventoryItemInfoSO>();

        SerializedObject serializedObject = new UnityEditor.SerializedObject(asset);

        SerializedProperty serializedPropertyItem;

        serializedPropertyItem = serializedObject.FindProperty("title");
        serializedPropertyItem.stringValue = itemTitle;
        
        serializedPropertyItem = serializedObject.FindProperty("description");
        serializedPropertyItem.stringValue = itemDescription;

        serializedObject.ApplyModifiedProperties();

        AssetDatabase.CreateAsset(asset, $"{pathToSaveLoad}/{itemTitle}.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

    public void LoadItemsAssets()
    {
        loadedItems = AssetDatabase.LoadAllAssetsAtPath(pathToSaveLoad);

        for (int i = 0; i < loadedItems.Length; i++)
        {
            Debug.Log(loadedItems[i].name);
        }
    }
}

[System.Serializable]
public class ItemDataEditor
{
    [SerializeField] public string Name = "Power";
    [SerializeField] public float value;

    public bool IsEmpty()
    {
        if(value <= 0)
        {
            return true;
        }

        return false;
    }
}