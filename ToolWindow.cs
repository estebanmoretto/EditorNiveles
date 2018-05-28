using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ToolWindow : EditorWindow {

    private Texture2D _focusObject;
    private GameObject _focusGameObject;
    public GameObject brush;
    private Material material;
    public string nameB;
    public string tipo;
    public string[] tiposDeDatos = { "PREFAB", "SPRITE" };
    public int tipoID;

    [MenuItem("Creator / Brushes")]


    static void CreateWindow() // Crea la ventana a mostrar
    {

        ((ToolWindow)GetWindow(typeof(ToolWindow))).Show(); //Esta línea va a obtener la ventana o a crearla. Una vez que haga esto, va a mostrarla.

    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Seleccionar un Sprite", EditorStyles.boldLabel);

        if (_focusGameObject != null)
        {
            EditorGUILayout.HelpBox("Seleciona una imagen", MessageType.Info);
        }
        _focusGameObject = (GameObject)EditorGUILayout.ObjectField("Prefab: ", _focusGameObject, typeof(GameObject), false);

        EditorGUILayout.HelpBox("Escribe el nombre de tu pincel", MessageType.Info);
        nameB = EditorGUILayout.TextField("Nombre: ", nameB);

        if (GUILayout.Button("Generar Brush", GUILayout.Height(40)))
        {
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(_focusGameObject), "Assets/Resources/Decal/brush.prefab"); //AssetDatabase.CopyAsset() copia un objeto
            ScriptableObjectBrush.CreateAsset<Brush>(nameB);
            var gameobject = (GameObject)Resources.Load("Decal/brush.prefab");
            AssetDatabase.Refresh();
        }
    }


}
