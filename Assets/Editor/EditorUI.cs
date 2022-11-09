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
    string myString = "Editor浮动窗口练习练习";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    Vector2 windowSize =new Vector2(200,200);

    private GUIContent myLabel = new GUIContent("DropDown");

    private GameObject m_objectValue; //定义Object

    private Texture texture;

    private Material material;

    private int m_intValue; //定义修改内容；

    private int m_layer;
    private string m_tag;

    private Color m_color;
    private GUIContent colorTitle = new GUIContent("颜色选择");

    private AnimationCurve m_curve = AnimationCurve.Linear(0, 0, 1, 1);

    private TutorialEnum m_enum;

    private TutorialEnum1 m_enum2;

    private int m_singleInt;
    private int m_multiInt;
    private string[] intSelections = new string[] { "整数10", "整数20", "整数30" };
    private string[] intMultiSelections = new string[] { "1号", "2号", "3号" };
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

    private GUIStyle defaultStyle = new GUIStyle(); //定义 GUIStyle

    [MenuItem("MyWindows/TutorialWindow")] //定义菜单栏位置
    public static void OpenWindow() //打开窗口函数，必须是static
    {
        EditorWindow.GetWindow(typeof(EditorUI));
    }
   // 在打开自定义窗口的情况下，在Scene刷新的时候执行某些东西 这样可以在窗口中对数据进行编辑操作
    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI; //对SceneView的刷新事件进行注册
        SceneView.duringSceneGui += OnSceneView;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= OnSceneGUI; //对SceneView的刷新事件取消注册
        SceneView.duringSceneGui -= OnSceneView;
    }
    private void OnSceneGUI(SceneView sceneView)
    {
        //先判断 按下去的是什么类型的设备 类型对应的按键是那个
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            Debug.Log("鼠标左键在场景中Clicked....");
        }
    }
    //射线检测碰撞生成球体
    private void OnSceneView(SceneView sceneView)
    {
        //Event.current.Use(); 让其他GUI 元素忽略这次事件 就是说只对这次事件生效 忽略其他相同按键的事件。
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0) //检测鼠标点击
        {
            var mousePos = Event.current.mousePosition; //获取鼠标在SceneView中的屏幕位置
            var ray = HandleUtility.GUIPointToWorldRay(mousePos); //生成屏幕坐标-->世界坐标的射线
            RaycastHit hit; //定义射线检测结果结构体
            if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask)) //进行射线检测，layerMask是检测层级
            {
                var obj = GameObject.CreatePrimitive(PrimitiveType.Sphere); //如果检测成功，创建一个球体。
                obj.transform.position = hit.point; //把球体坐标设置为hit交点处。
            }
        }
    }
    private void OnGUI()
    {
        //别的面板也是类似的
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.A)
        {
            Debug.Log("键盘A键在Window面板中按下....");
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
        //对象域
        m_objectValue = EditorGUILayout.ObjectField(m_objectValue, typeof(GameObject), true) as GameObject;
        texture=EditorGUILayout.ObjectField(texture, typeof(Texture), true) as Texture;
    
        if(GUILayout.Button("Ping对象"))
        EditorGUIUtility.PingObject(texture);



        material = EditorGUILayout.ObjectField(material, typeof(Material), true) as Material;
        if (GUILayout.Button("获取文件路径"))
        {
            path = AssetDatabase.GetAssetPath(material);
        }
        EditorGUILayout.LabelField("资产路径是", path);
        //---------------分隔
        m_intValue = EditorGUILayout.IntField("整型输入框", m_intValue);

        EditorGUILayout.LabelField("文本标题", "文本内容");

        m_layer = EditorGUILayout.LayerField("层级选择", m_layer);//类似 unity组件里的层级选择和标签选择
        m_tag = EditorGUILayout.TagField("标签选择", m_tag);

        //第一个参数： GUIContent，通常拿来作为Title
        //第二个参数： Color，目标修改数据
        //第三个参数： bool ，是否显示拾色器
        //第四个参数： bool ，是否显示透明度通道
        //第五个参数： bool ，是否支持HDR。
        m_color = EditorGUILayout.ColorField(colorTitle, m_color, true, true, true);

        m_curve = EditorGUILayout.CurveField("动画曲线：", m_curve);

        m_enum = (TutorialEnum)EditorGUILayout.EnumPopup("枚举选择", m_enum);

        m_enum2 = (TutorialEnum1)EditorGUILayout.EnumFlagsField("枚举多选", m_enum2);

        m_singleInt = EditorGUILayout.IntPopup("整数单选框", m_singleInt, intSelections, intValues);
        EditorGUILayout.LabelField($"m_singleInt is {m_singleInt}");
        m_multiInt = EditorGUILayout.MaskField("整数多选框", m_multiInt, intMultiSelections);
        EditorGUILayout.LabelField($"m_multiInt is {m_multiInt}");

        foldOut = EditorGUILayout.Foldout(foldOut, "一般路过折叠栏");
        if (foldOut) //只有foldout为true时，才会显示下方内容，相当于“折叠”了。
        {
            EditorGUILayout.LabelField("这是折叠标签内容");
            EditorGUILayout.LabelField("这是折叠标签内容");
            EditorGUILayout.LabelField("这是折叠标签内容");
        }

        //折叠组的使用
        foldOut2 = EditorGUILayout.BeginFoldoutHeaderGroup(foldOut2, "折叠栏组");
        if (foldOut2) //只有foldout为true时，才会显示下方内容，相当于“折叠”了。
        {
            EditorGUILayout.LabelField("这是折叠标签内容");

            EditorGUILayout.LabelField("这是折叠标签内容");

            EditorGUILayout.LabelField("这是折叠标签内容");
        }
        EditorGUILayout.EndFoldoutHeaderGroup(); //只不过这种折叠需要成对使用，不然会有BUG

        toggle = EditorGUILayout.Toggle("Normal Toggle", toggle);
        toggle2 = EditorGUILayout.ToggleLeft("Left Toggle", toggle2);

        toggle3 = EditorGUILayout.BeginToggleGroup("开关组", toggle3);
        EditorGUILayout.LabelField("------Input Field------");
        m_inputText = EditorGUILayout.TextField("输入内容：", m_inputText);
        EditorGUILayout.EndToggleGroup();

        //第一个参数： string label 控件名称标签  
        //第二个参数： float value 滑动当前值  
        //第三个参数： float leftValue 滑动最小值   
        //第四个参数： float rightValue 滑动最大值
        m_sliderValue = EditorGUILayout.Slider("滑动条Sample：", m_sliderValue, 0.123f, 7.77f);
        //参数同上
        m_sliderIntValue = EditorGUILayout.IntSlider("整数值滑动条", m_sliderIntValue, 2, 16);

        EditorGUILayout.MinMaxSlider("双块滑动条", ref m_leftValue, ref m_rightValue, 0.25f, 10.25f);
        EditorGUILayout.FloatField("滑动左值：", m_leftValue);
        EditorGUILayout.FloatField("滑动右值：", m_rightValue);

        //HelpBox

        EditorGUILayout.HelpBox("一般提示", MessageType.Info);
        GUI.color = Color.yellow;
        EditorGUILayout.HelpBox("警告提示", MessageType.Warning);
        GUI.color = Color.red;
        EditorGUILayout.HelpBox("错误提示", MessageType.Error);
        GUI.color = Color.white;
        if (GUILayout.Button("查找法线贴图"))
        {
            //参数释义
            //1. 查找对象的引用
            //2. 是否允许查找场景对象
            //3. 查找对象名称过滤（比如这里的normal是指文件名称中有normal的会被搜索到）
            //4. controlID, 默认写0
            EditorGUIUtility.ShowObjectPicker<Texture>(tex, false,"", 0);
        }

        //Handles.Label(Vector3.zero,"Handle绘制");

        if (GUILayout.Button("创建一个 Cube，同时选中"))
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube); //创建Cube
            obj.name = "新建的Cube";
            Selection.activeGameObject = obj; //选中Cube
        }
        defaultStyle.fontSize = 10;
        defaultStyle.fontStyle = FontStyle.Normal;
        defaultStyle.alignment = TextAnchor.MiddleCenter;
        defaultStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("这是折叠标签内容",defaultStyle);
        defaultStyle.alignment = TextAnchor.MiddleLeft;
        defaultStyle.normal.textColor = Color.green;
        defaultStyle.fontStyle = FontStyle.Bold;
        EditorGUILayout.LabelField("这是折叠标签内容",defaultStyle);
        defaultStyle.fontStyle = FontStyle.Bold;
        defaultStyle.fontSize = 15;
        defaultStyle.normal.textColor = Color.blue;
        EditorGUILayout.LabelField("这是折叠标签内容", defaultStyle);

        EditorGUILayout.BeginVertical("box");
        EditorGUILayout.LabelField("第一区域");
        EditorGUILayout.Vector3Field("三维向量",Vector3.one);
        //EditorGUILayout.BeginFadeGroup(20);
        //EditorGUILayout.LabelField("我在这");
        //EditorGUILayout.EndFadeGroup();
        EditorGUILayout.EndVertical();
        EditorGUILayout.Space(10);
        //布局传入的参数是GUISkin的内容
        EditorGUILayout.BeginVertical("frameBox");
        EditorGUILayout.LabelField("这是【frameBox】样式，用于显示面板的分区");
        EditorGUILayout.BoundsField("比如这是一个BoundField", new Bounds());
        EditorGUILayout.Slider("比如这是一个Slider", 5, 0, 10);
        EditorGUILayout.TextArea("SearchTextField", "SearchTextField");
        EditorGUILayout.EndVertical();
    }
}
