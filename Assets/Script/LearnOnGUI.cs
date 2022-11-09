using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnOnGUI : MonoBehaviour
{
    private bool toggleValue; //��¼��ǰtoggle��ֵ���
    private int Gruidindex,Toolbarindex; //����ఴťѡ���index
    private string[] buttonNames = new string[] { "First", "Second", "Third" }; //����ఴť������
    private float horizontalValue = 0;
    private float verticalValue = 0;

    private float horizontalValue2 = 0; //��������ֵ
    private float verticalValue2 = 0; //��������ֵ
    private float blockSize = 10; //�������С
    private float leftValue = 0; //�����/���ϲ���ֵ
    private float rightValue = 100; //���Ҳ�/���²���ֵ

    private Vector2 scrollViewRoot; //���廬�����ڵ�ǰ����ֵ�������ʹ�����vector2���������ڽ��޷�����


    void OnGUI()
    {
        //��һ�������ǵ�ǰѡ��ť��index��
        //�ڶ��������Ƕ����ť�����ƣ����鳤�Ⱦ����˰�ť������
        //�����������Ǳ�ʾһ�а�ť�ж��ٸ���������2����ʾһ�����2����ť��
        Gruidindex = GUILayout.SelectionGrid(Gruidindex, buttonNames, 2);

        Toolbarindex = GUILayout.Toolbar(Toolbarindex, buttonNames);

        toggleValue = GUILayout.Toggle(toggleValue, "This is a toggle"); //�ڶ���������Toggle�ı���Ϣ

        GUILayout.Label("This is a Label Text");

        horizontalValue = GUILayout.HorizontalSlider(horizontalValue, 0, 100, GUILayout.Width(300));
        verticalValue = GUILayout.VerticalSlider(verticalValue, 0, 100);

        horizontalValue2 = GUILayout.HorizontalScrollbar(horizontalValue2, blockSize, leftValue, rightValue, GUILayout.Width(300));
        verticalValue2 = GUILayout.VerticalScrollbar(verticalValue2, blockSize, leftValue, rightValue);

        GUILayout.Box("Box Area", GUILayout.Width(200), GUILayout.Height(200));

        GUILayout.BeginArea(new Rect(400,0, 300, 200)); //��������ʼ��rect������ x���꣬y���꣬��ȣ��߶�
        GUILayout.Button("Button in Area");  //��һ��button��Ϊ��ʾ
        GUILayout.EndArea(); //����������

        GUILayout.BeginHorizontal(); //��ʼˮƽ����
        GUILayout.Button("Horizontal Button No.1"); //���1
        GUILayout.Button("Horizontal Button No.2"); //���2
        GUILayout.EndHorizontal(); //����ˮƽ����

        GUILayout.BeginVertical();//��ʼ��ֱ����
        GUILayout.Button("Veritical Button No.1"); //���1
        GUILayout.Button("Veritical Button No.2"); //���2
        GUILayout.EndVertical(); //������ֱ����
                                 //ֵ��ע����ǣ����ַ���һ����Ҫ�ɶ�ʹ�ã����忪ʼ/������������ڲ����ϳ�����ֵ�bug

        GUILayout.BeginArea(new Rect(400, 200, 400, 400)); //������ӻ�����
        scrollViewRoot = GUILayout.BeginScrollView(scrollViewRoot); //���廬����ͼ
        GUILayout.Button("Buttons", GUILayout.Height(50)); //�������1���߶�200
        GUILayout.Button("Buttons", GUILayout.Height(50)); //�������2���߶�200
        GUILayout.Button("Buttons", GUILayout.Height(50)); //�������3���߶�200
        GUILayout.EndScrollView(); //������������
        GUILayout.Space(50);//���50
        GUILayout.BeginVertical();//��ʼ��ֱ����
        GUILayout.Button("Veritical Button No.1",GUILayout.ExpandWidth(false)); //���1
        GUILayout.FlexibleSpace();//������
        GUILayout.Button("Veritical Button No.2",GUILayout.MaxWidth(50)); //���2
        GUILayout.EndVertical(); //������ֱ����
        GUILayout.EndArea();// ����������



    }
}
