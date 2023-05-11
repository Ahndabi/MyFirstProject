using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityScript : MonoBehaviour    // �ݵ��MonoBehaviour�� ��� �޾ƾ� ��
{
	/************************************************************************
	 * ������Ʈ (Component)
	 * 
	 * Ư���� ����� ������ �� �ֵ��� ������ ���� ����� ����
	 * ���ӿ�����Ʈ�� �۵��� ������ ��ǰ
	 * ���ӿ�����Ʈ�� �߰�, �����ϴ� ����� ������ ��ǰ
	 ************************************************************************/

	/************************************************************************
	 * MonoBehaviour
	 * 
	 * ������Ʈ�� �⺻Ŭ������ �ϴ� Ŭ������ ����Ƽ ��ũ��Ʈ�� �Ļ��Ǵ� �⺻ Ŭ����
	 * ���� ������Ʈ�� ��ũ��Ʈ�� ������Ʈ�μ� ������ �� �ִ� ������ ����
	 * ��ũ��Ʈ ����ȭ ���, ����Ƽ�޽��� �̺�Ʈ�� �޴� ���, �ڷ�ƾ ����� ������
	 ***********************************************************************/

	// <��ũ��Ʈ ����ȭ ���>
	// �ν����� â���� ������Ʈ�� �ɹ����� ���� Ȯ���ϰų� �����ϴ� ���
	// ������Ʈ�� ������ �����͸� Ȯ���ϰų� ����
	// ������Ʈ�� �������� �����͸� �巡�� �� ��� ������� ����
	// �ν����� â�� ���� ��ũ��Ʈ ���� ������ �� �켱��

	// private�� �ν����� â���� �� ����

	// <�ν�����â ����ȭ�� ������ �ڷ���>
	[Header("C# Type")]
	public bool boolValue;
	public int intValue;
	public float floatValue;
	public string stringValue;
	// �� �� �⺻ �ڷ���

	// �⺻ �ڷ����� �����ڷᱸ��
	public int[] array;
	public List<int> list;

	[Header("Unity Type")]
	public Vector3 vector3;		// 3���� ���� x, y, z��	(2���� ������ Vector2)
	public Color color;
	public LayerMask layerMask;
	public AnimationCurve curve;
	public Gradient gradient;

	[Header("Unity GameObject")]
	public GameObject obj;

	[Header("Unity Component")]
	public new Transform transform;
	public new Rigidbody rigidbody;
	public new Collider collider;

	[Header("Unity Event")]
	public UnityEvent OnEvent;

	// <��Ʈ����Ʈ>
	// Ŭ����, ������Ƽ �Ǵ� �Լ� ���� ����Ͽ� Ư���� ������ ��Ÿ�� �� �ִ� ��Ŀ
	// �ڵ忡 ���������� ������ ��ġ�� �� �ƴ����� �Ӽ� ���� ���� ǥ��
	[Space(30)]

	[Header("Unity Attribute")]
	[SerializeField]	 // private���� �ν����Ϳ��� ���̰� ��
	private int privateValue;
	[HideInInspector]	 // public������ �ν����Ϳ��� �� ���̰� ��
	public int publicValue;

	[Range(0, 10)]		 // ���� ����
	public float rangeValue;

	[TextArea(3, 5)]	 // �ؽ�Ʈ�� ���� �ٷ� �� �� ����
	public string textField;
}
