using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//继承Editor类

[CustomEditor(typeof(EditorTho))]
public class TutorialMonoInspector : Editor 
{
    private Vector3 root = Vector3.zero;

    private Vector3 labelPos = Vector3.zero;
    private string labelText = "这是在Handles中绘制的文本信息！！！";

    private EditorTho tho;
    private void OnEnable()
    {
        tho = target as EditorTho;//继承Editor类才有Target Target为被检查目标 
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //调用父类方法绘制一次GUI，TutorialMono中原本的可序列化数据等会在这里绘制一次。
        //如果不调用父类方法，则这个Mono的Inspector全权由下面代码绘制。

        if (GUILayout.Button("这是一个按钮"))   //自定义按钮
        {
            Debug.Log("Hello");
        }
    }
    private void OnSceneGUI()
    {
        //Handles.Label(labelPos, labelText);
        //1.from 2.to 3.thickness（厚度）决定线段厚度
        Handles.DrawLine(Vector3.zero, new Vector3(-1, 1, 1), 2f);
        //1.from 2.to 3.ScreenSpaceSize（屏幕空间大小）决定虚线长度
        Handles.DrawDottedLine(Vector3.zero, Vector3.one, 2f);

        Handles.color = new Color(1, 0, 0, 0.3f); //提前使用Color进行颜色设置，便于观察
        Handles.DrawWireArc(Vector3.zero, Vector3.up, Vector3.right, 90, 2); //绘制线框弧线
        Handles.DrawSolidArc(Vector3.zero, Vector3.up, Vector3.back, 90, 2); // 绘制填充弧线

        Handles.color = new Color(0, 1, 0, 0.3f);
        Handles.DrawSolidDisc(new Vector3(0, 0, 5), Vector3.up, 5); //绘制填充圆环
        Handles.DrawWireDisc(new Vector3(0, 0, -5), Vector3.up, 5); //绘制线框圆环

        Handles.DrawSolidRectangleWithOutline(new Rect(0, 0, 1, 1), Color.green, Color.red);

        Handles.color = Color.gray;
        Handles.BeginGUI();
        GUILayout.Label("SceneView Label");
        if (GUILayout.Button("SceneView Button"))
        {
            Debug.Log("666");
        }
        Handles.EndGUI();

        Handles.DrawSolidDisc(root, Vector3.up, 1); //画个圆，假设这是目标对象
        root = Handles.PositionHandle(root, Quaternion.identity); //控制柄

        Handles.BeginGUI();
        if (GUILayout.Button("创建一个 Cube，同时选中"))
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube); //创建Cube
            obj.name = "新建的Cube";
            Selection.activeGameObject = obj; //选中Cube
        }
        Handles.EndGUI();
    }
}
