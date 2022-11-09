using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class EditorUI : EditorWindow
{
    private enum TutorialEnum
    {
        One,
        Two,
        Three
    }

    private enum TutorialEnum1
    {
        None = 0,
        OneAndTwo = One | Two,
        One = 1 << 0,
        Two = 1 << 1,
        Three = 1 << 2
    }
    string myString = "Editor����������ϰ��ϰ";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    Vector2 windowSize =new Vector2(200,200);

    private GUIContent myLabel = new GUIContent("DropDown");

    private GameObject m_objectValue; //����Object

    private Texture texture;

    private Material material;

    private int m_intValue; //�����޸����ݣ�

    private int m_layer;
    private string m_tag;

    private Color m_color;
    private GUIContent colorTitle = new GUIContent("��ɫѡ��");

    private AnimationCurve m_curve = AnimationCurve.Linear(0, 0, 1, 1);

    private TutorialEnum m_enum;

    private TutorialEnum1 m_enum2;

    private int m_singleInt;
    private int m_multiInt;
    private string[] intSelections = new string[] { "����10", "����20", "����30" };
    private string[] intMultiSelections = new string[] { "1��", "2��", "3��" };
    private int[] intValues = new int[] { 10, 20, 30 };

    private bool foldOut;
    private bool foldOut2;

    private bool toggle;

    private bool toggle2;

    private bool toggle3;
    private string m_inputText;

    private float m_sliderValue=3;
    private int m_sliderIntValue=3;

    private float m_leftValue;
    private float m_rightValue;

    private Texture tex;

    private string path;

    private LayerMask layerMask = -1;

    private GUIStyle defaultStyle = new GUIStyle(); //���� GUIStyle

    [MenuItem("MyWindows/TutorialWindow")] //����˵���λ��
    public static void OpenWindow() //�򿪴��ں�����������static
    {
        EditorWindow.GetWindow(typeof(EditorUI));
    }
   // �ڴ��Զ��崰�ڵ�����£���Sceneˢ�µ�ʱ��ִ��ĳЩ���� ���������ڴ����ж����ݽ��б༭����
    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI; //��SceneView��ˢ���¼�����ע��
        SceneView.duringSceneGui += OnSceneView;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI; //��SceneView��ˢ���¼�ȡ��ע��
        SceneView.duringSceneGui -= OnSceneView;
    }
    private void OnSceneGUI(SceneView sceneView)
    {
        //���ж� ����ȥ����ʲô���͵��豸 ���Ͷ�Ӧ�İ������Ǹ�
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Debug.Log("�������ڳ�����Clicked....");
        }
    }
    //���߼����ײ��������
    private void OnSceneView(SceneView sceneView)
    {
        //Event.current.Use(); ������GUI Ԫ�غ�������¼� ����˵ֻ������¼���Ч ����������ͬ�������¼���
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0) //��������
        {
            var mousePos = Event.current.mousePosition; //��ȡ�����SceneView�е���Ļλ��
            var ray = HandleUtility.GUIPointToWorldRay(mousePos); //������Ļ����-->�������������
            RaycastHit hit; //�������߼�����ṹ��
            if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask)) //�������߼�⣬layerMask�Ǽ��㼶
            {
                var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere); //������ɹ�������һ�����塣
                obj.transform.position = hit.point; //��������������Ϊhit���㴦��
            }
        }
    }
    private void OnGUI()
    {
        //������Ҳ�����Ƶ�
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
        {
            Debug.Log("����A����Window����а���....");
        }

        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        myString = EditorGUILayout.TextField("Text Field", myString);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
        myBool = EditorGUILayout.Toggle("Toggle", myBool);
        myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
        EditorGUILayout.EndToggleGroup();

        if (EditorGUILayout.DropdownButton(myLabel, FocusType.Passive))
        {
            Debug.Log(m_color);
        }
        //������
        m_objectValue = EditorGUILayout.ObjectField(m_objectValue, typeof(GameObject), true) as GameObject;
        texture=EditorGUILayout.ObjectField(texture, typeof(Texture), true) as Texture;
    
        if(GUILayout.Button("Ping����"))
        EditorGUIUtility.PingObject(texture);



        material = EditorGUILayout.ObjectField(material, typeof(Material), true) as Material;
        if (GUILayout.Button("��ȡ�ļ�·��"))
        {
            path = AssetDatabase.GetAssetPath(material);
        }
        EditorGUILayout.LabelField("�ʲ�·����", path);
        //---------------�ָ�
        m_intValue = EditorGUILayout.IntField("���������", m_intValue);

        EditorGUILayout.LabelField("�ı�����", "�ı�����");

        m_layer = EditorGUILayout.LayerField("�㼶ѡ��", m_layer);//���� unity�����Ĳ㼶ѡ��ͱ�ǩѡ��
        m_tag = EditorGUILayout.TagField("��ǩѡ��", m_tag);

        //��һ�������� GUIContent��ͨ��������ΪTitle
        //�ڶ��������� Color��Ŀ���޸�����
        //������������ bool ���Ƿ���ʾʰɫ��
        //���ĸ������� bool ���Ƿ���ʾ͸����ͨ��
        //����������� bool ���Ƿ�֧��HDR��
        m_color = EditorGUILayout.ColorField(colorTitle, m_color, true, true, true);

        m_curve = EditorGUILayout.CurveField("�������ߣ�", m_curve);

        m_enum = (TutorialEnum)EditorGUILayout.EnumPopup("ö��ѡ��", m_enum);

        m_enum2 = (TutorialEnum1)EditorGUILayout.EnumFlagsField("ö�ٶ�ѡ", m_enum2);

        m_singleInt = EditorGUILayout.IntPopup("������ѡ��", m_singleInt, intSelections, intValues);
        EditorGUILayout.LabelField($"m_singleInt is {m_singleInt}");
        m_multiInt = EditorGUILayout.MaskField("������ѡ��", m_multiInt, intMultiSelections);
        EditorGUILayout.LabelField($"m_multiInt is {m_multiInt}");

        foldOut = EditorGUILayout.Foldout(foldOut, "һ��·���۵���");
        if (foldOut) //ֻ��foldoutΪtrueʱ���Ż���ʾ�·����ݣ��൱�ڡ��۵����ˡ�
        {
            EditorGUILayout.LabelField("�����۵���ǩ����");
            EditorGUILayout.LabelField("�����۵���ǩ����");
            EditorGUILayout.LabelField("�����۵���ǩ����");
        }

        //�۵����ʹ��
        foldOut2 = EditorGUILayout.BeginFoldoutHeaderGroup(foldOut2, "�۵�����");
        if (foldOut2) //ֻ��foldoutΪtrueʱ���Ż���ʾ�·����ݣ��൱�ڡ��۵����ˡ�
        {
            EditorGUILayout.LabelField("�����۵���ǩ����");

            EditorGUILayout.LabelField("�����۵���ǩ����");

            EditorGUILayout.LabelField("�����۵���ǩ����");
        }
        EditorGUILayout.EndFoldoutHeaderGroup(); //ֻ���������۵���Ҫ�ɶ�ʹ�ã���Ȼ����BUG

        toggle = EditorGUILayout.Toggle("Normal Toggle", toggle);
        toggle2 = EditorGUILayout.ToggleLeft("Left Toggle", toggle2);

        toggle3 = EditorGUILayout.BeginToggleGroup("������", toggle3);
        EditorGUILayout.LabelField("------Input Field------");
        m_inputText = EditorGUILayout.TextField("�������ݣ�", m_inputText);
        EditorGUILayout.EndToggleGroup();

        //��һ�������� string label �ؼ����Ʊ�ǩ  
        //�ڶ��������� float value ������ǰֵ  
        //������������ float leftValue ������Сֵ   
        //���ĸ������� float rightValue �������ֵ
        m_sliderValue = EditorGUILayout.Slider("������Sample��", m_sliderValue, 0.123f, 7.77f);
        //����ͬ��
        m_sliderIntValue = EditorGUILayout.IntSlider("����ֵ������", m_sliderIntValue, 2, 16);

        EditorGUILayout.MinMaxSlider("˫�黬����", ref m_leftValue, ref m_rightValue, 0.25f, 10.25f);
        EditorGUILayout.FloatField("������ֵ��", m_leftValue);
        EditorGUILayout.FloatField("������ֵ��", m_rightValue);

        //HelpBox

        EditorGUILayout.HelpBox("һ����ʾ", MessageType.Info);
        GUI.color = Color.yellow;
        EditorGUILayout.HelpBox("������ʾ", MessageType.Warning);
        GUI.color = Color.red;
        EditorGUILayout.HelpBox("������ʾ", MessageType.Error);
        GUI.color = Color.white;
        if (GUILayout.Button("���ҷ�����ͼ"))
        {
            //��������
            //1. ���Ҷ��������
            //2. �Ƿ�������ҳ�������
            //3. ���Ҷ������ƹ��ˣ����������normal��ָ�ļ���������normal�Ļᱻ��������
            //4. controlID, Ĭ��д0
            EditorGUIUtility.ShowObjectPicker<Texture>(tex, false,"", 0);
        }

        //Handles.Label(Vector3.zero,"Handle����");

        if (GUILayout.Button("����һ�� Cube��ͬʱѡ��"))
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube); //����Cube
            obj.name = "�½���Cube";
            Selection.activeGameObject = obj; //ѡ��Cube
        }
        defaultStyle.fontSize = 10;
        defaultStyle.fontStyle = FontStyle.Normal;
        defaultStyle.alignment = TextAnchor.MiddleCenter;
        defaultStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("�����۵���ǩ����",defaultStyle);
        defaultStyle.alignment = TextAnchor.MiddleLeft;
        defaultStyle.normal.textColor = Color.green;
        defaultStyle.fontStyle = FontStyle.Bold;
        EditorGUILayout.LabelField("�����۵���ǩ����",defaultStyle);
        defaultStyle.fontStyle = FontStyle.Bold;
        defaultStyle.fontSize = 15;
        defaultStyle.normal.textColor = Color.blue;
        EditorGUILayout.LabelField("�����۵���ǩ����", defaultStyle);

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("��һ����");
        EditorGUILayout.Vector3Field("��ά����",Vector3.one);
        //EditorGUILayout.BeginFadeGroup(20);
        //EditorGUILayout.LabelField("������");
        //EditorGUILayout.EndFadeGroup();
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space(10);
        //���ִ���Ĳ�����GUISkin������
        EditorGUILayout.BeginVertical("frameBox");
        EditorGUILayout.LabelField("���ǡ�frameBox����ʽ��������ʾ���ķ���");
        EditorGUILayout.BoundsField("��������һ��BoundField", new Bounds());
        EditorGUILayout.Slider("��������һ��Slider", 5, 0, 10);
        EditorGUILayout.TextArea("SearchTextField", "SearchTextField");
        EditorGUILayout.EndVertical();
    }
}
