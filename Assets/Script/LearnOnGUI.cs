using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnOnGUI : MonoBehaviour
{
    private bool toggleValue; //记录当前toggle真值情况
    private int Gruidindex,Toolbarindex; //定义多按钮选择的index
    private string[] buttonNames = new string[] { "First", "Second", "Third" }; //定义多按钮的名称
    private float horizontalValue = 0;
    private float verticalValue = 0;

    private float horizontalValue2 = 0; //滑动条数值
    private float verticalValue2 = 0; //滑动条数值
    private float blockSize = 10; //滑动块大小
    private float leftValue = 0; //最左侧/最上侧数值
    private float rightValue = 100; //最右侧/最下侧数值

    private Vector2 scrollViewRoot; //定义滑动窗口当前滑动值，如果不使用这个vector2，滑动窗口将无法滑动


    void OnGUI()
    {
        //第一个参数是当前选择按钮的index。
        //第二个参数是多个按钮的名称，数组长度决定了按钮个数。
        //第三个参数是表示一行按钮有多少个，这里是2，表示一行最多2个按钮。
        Gruidindex = GUILayout.SelectionGrid(Gruidindex, buttonNames, 2);

        Toolbarindex = GUILayout.Toolbar(Toolbarindex, buttonNames);

        toggleValue = GUILayout.Toggle(toggleValue, "This is a toggle"); //第二个参数是Toggle文本信息

        GUILayout.Label("This is a Label Text");

        horizontalValue = GUILayout.HorizontalSlider(horizontalValue, 0, 100, GUILayout.Width(300));
        verticalValue = GUILayout.VerticalSlider(verticalValue, 0, 100);

        horizontalValue2 = GUILayout.HorizontalScrollbar(horizontalValue2, blockSize, leftValue, rightValue, GUILayout.Width(300));
        verticalValue2 = GUILayout.VerticalScrollbar(verticalValue2, blockSize, leftValue, rightValue);

        GUILayout.Box("Box Area", GUILayout.Width(200), GUILayout.Height(200));

        GUILayout.BeginArea(new Rect(400,0, 300, 200)); //定义区域开始，rect参数： x坐标，y坐标，宽度，高度
        GUILayout.Button("Button in Area");  //用一个button作为显示
        GUILayout.EndArea(); //结束区域定义

        GUILayout.BeginHorizontal(); //开始水平布局
        GUILayout.Button("Horizontal Button No.1"); //组件1
        GUILayout.Button("Horizontal Button No.2"); //组件2
        GUILayout.EndHorizontal(); //结束水平布局

        GUILayout.BeginVertical();//开始垂直布局
        GUILayout.Button("Veritical Button No.1"); //组件1
        GUILayout.Button("Veritical Button No.2"); //组件2
        GUILayout.EndVertical(); //结束垂直布局
                                 //值得注意的是，布局方法一般需要成对使用：定义开始/结束，否则会在布局上出现奇怪的bug

        GUILayout.BeginArea(new Rect(400, 200, 400, 400)); //定义可视化区域
        scrollViewRoot = GUILayout.BeginScrollView(scrollViewRoot); //定义滑动视图
        GUILayout.Button("Buttons", GUILayout.Height(50)); //定义组件1，高度200
        GUILayout.Button("Buttons", GUILayout.Height(50)); //定义组件2，高度200
        GUILayout.Button("Buttons", GUILayout.Height(50)); //定义组件3，高度200
        GUILayout.EndScrollView(); //结束滑动窗口
        GUILayout.Space(50);//间隔50
        GUILayout.BeginVertical();//开始垂直布局
        GUILayout.Button("Veritical Button No.1",GUILayout.ExpandWidth(false)); //组件1
        GUILayout.FlexibleSpace();//灵活调整
        GUILayout.Button("Veritical Button No.2",GUILayout.MaxWidth(50)); //组件2
        GUILayout.EndVertical(); //结束垂直布局
        GUILayout.EndArea();// 结束区域定义



    }
}
