using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//�̳�Editor��

[CustomEditor(typeof(EditorTho))]
public class TutorialMonoInspector : Editor 
{
    private Vector3 root = Vector3.zero;

    private Vector3 labelPos = Vector3.zero;
    private string labelText = "������Handles�л��Ƶ��ı���Ϣ������";

    private EditorTho tho;
    private void OnEnable()
    {
        tho = target as EditorTho;//�̳�Editor�����Target TargetΪ�����Ŀ�� 
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI(); //���ø��෽������һ��GUI��TutorialMono��ԭ���Ŀ����л����ݵȻ����������һ�Ρ�
        //��������ø��෽���������Mono��InspectorȫȨ�����������ơ�

        if (GUILayout.Button("����һ����ť"))   //�Զ��尴ť
        {
            Debug.Log("Hello");
        }
    }
    private void OnSceneGUI()
    {
        //Handles.Label(labelPos, labelText);
        //1.from 2.to 3.thickness����ȣ������߶κ��
        Handles.DrawLine(Vector3.zero, new Vector3(-1, 1, 1), 2f);
        //1.from 2.to 3.ScreenSpaceSize����Ļ�ռ��С���������߳���
        Handles.DrawDottedLine(Vector3.zero, Vector3.one, 2f);

        Handles.color = new Color(1, 0, 0, 0.3f); //��ǰʹ��Color������ɫ���ã����ڹ۲�
        Handles.DrawWireArc(Vector3.zero, Vector3.up, Vector3.right, 90, 2); //�����߿���
        Handles.DrawSolidArc(Vector3.zero, Vector3.up, Vector3.back, 90, 2); // ������仡��

        Handles.color = new Color(0, 1, 0, 0.3f);
        Handles.DrawSolidDisc(new Vector3(0, 0, 5), Vector3.up, 5); //�������Բ��
        Handles.DrawWireDisc(new Vector3(0, 0, -5), Vector3.up, 5); //�����߿�Բ��

        Handles.DrawSolidRectangleWithOutline(new Rect(0, 0, 1, 1), Color.green, Color.red);

        Handles.color = Color.gray;
        Handles.BeginGUI();
        GUILayout.Label("SceneView Label");
        if (GUILayout.Button("SceneView Button"))
        {
            Debug.Log("666");
        }
        Handles.EndGUI();

        Handles.DrawSolidDisc(root, Vector3.up, 1); //����Բ����������Ŀ�����
        root = Handles.PositionHandle(root, Quaternion.identity); //���Ʊ�

        Handles.BeginGUI();
        if (GUILayout.Button("����һ�� Cube��ͬʱѡ��"))
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube); //����Cube
            obj.name = "�½���Cube";
            Selection.activeGameObject = obj; //ѡ��Cube
        }
        Handles.EndGUI();
    }
}
