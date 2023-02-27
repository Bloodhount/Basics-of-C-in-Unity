using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HW9 : MonoBehaviour
{
}
[CustomEditor(typeof(TestBehaviour))]
class MyTestBehaviourEditor : UnityEditor.Editor
{

}
class MenuItems
{
    [MenuItem("Geekbrains/ Меню ДЗ-9, задача No 1/Подменю No 1/Подподеню No 1 _i")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(MyTestWindow), false, "Geekbrains");
    }

    [MenuItem("Geekbrains/  Меню ДЗ-9, задача No 1/Подменю No 2 _u ")]
    private static void MenuOption2()
    {
        EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
    }
}
class MyTestWindow : EditorWindow
{
    //private Rect screenRect = new Rect(15, 25, 20, 20);
    public string _nameObject = "some name";
    private bool _isPressButton;
    private void OnGUI()
    {
        //GUILayout.BeginArea(screenRect, _nameObject);
        GUILayout.Label("Window", EditorStyles.boldLabel);
        _nameObject = EditorGUILayout.TextField("ввод названия объекта", _nameObject);

        var button2 = GUILayout.Button(" Открыть окно  \"MyWindow\"");
        if (button2)
        {
            GUILayout.BeginArea(new Rect(15, 25, 40, 40), _nameObject);
            GUILayout.Label("Window 2", EditorStyles.boldLabel); EditorGUILayout.HelpBox(" Кнопка работает ", MessageType.Info);
            EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
            GUILayout.EndArea();
        }

        var isPressButton = GUILayout.Button("Button", EditorStyles.miniButtonLeft);
        _isPressButton = GUILayout.Toggle(_isPressButton, "press");
        if (isPressButton)
        {
            _isPressButton = true;
        }

        if (_isPressButton)
        {
            EditorGUILayout.HelpBox("jhjkghjghjgjh", MessageType.Warning);
        }
    }
}
class MyWindow : EditorWindow
{
    public static GameObject ObjectInstantiate;
    public string _nameObject = "some name";
    public bool _groupEnabled;
    public bool _randomColor = true;
    public int _countObject = 9;
    public float _radius = 5;
    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);

        ObjectInstantiate = GameObject.Find("CubeHW9");
        ObjectInstantiate = EditorGUILayout.ObjectField("Объект который хотим вставить", ObjectInstantiate, typeof(GameObject), true) as GameObject;

        _nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);

        _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", _groupEnabled);
        _randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
        _countObject = EditorGUILayout.IntSlider("Количество объектов", _countObject, 1, 40);
        _radius = EditorGUILayout.Slider("Радиус окружности", _radius, 3, 25);
        EditorGUILayout.EndToggleGroup();

        var button = GUILayout.Button("Создать объекты");
        if (button)
        {
            if (ObjectInstantiate)
            {
                GameObject root = new GameObject("Root");

                for (int i = 0; i < _countObject; i++)
                {
                    float angle = i * Mathf.PI * 2 / _countObject;
                    Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;

                    GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                    temp.name = _nameObject + "(" + i + ")";
                    temp.active = true;
                    temp.GetComponent<Rigidbody>().useGravity = true;
                    temp.GetComponent<Rigidbody>().mass = 0;
                    //      Physics.gravity = 7 * Vector3.up;
                    temp.GetComponent<Rigidbody>().AddExplosionForce(20, root.transform.position, 20, 5, ForceMode.VelocityChange);
                    Destroy(root, 4);
                    temp.transform.parent = root.transform;
                    var tempRenderer = temp.GetComponent<Renderer>();
                    if (tempRenderer && _randomColor)
                    {
                        tempRenderer.material.color = Random.ColorHSV();
                    }
                }
            }
        }
    }
}