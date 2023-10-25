using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUtility : MonoBehaviour
{
    public Button button01;
    public Button button02;
    public Button button03;
    public RectTransform BG;
    public Text text01;
    //��ũ��Ʈ�� ���� ��ư ����
    //��ư�� ����� �߰��ϴ� 2���� ���
    //1. �Ϲ� public ������ �Լ��� ���� ��ư ������Ʈ�� OnClick�� �߰� ��
    //������Ʈ�� �����ϰ� �Լ��� �����ϰ� �����.

    //Listerner ���� ���� ����
    //1. button01.onClick.AddListener(�Լ� �̸�);
    //2. button01.onClick.AddListener(() => �Լ��� �̸�(��)); �� ���� �̺�Ʈ ����
    //3. button01.onClick.RemoveListener(�Լ� �̸�): ����� �̺�Ʈ ����
    //4. button01.onClick.RemoveAllListener(�Լ� �̸�): ����� �̺�Ʈ ��� ����

    //inspector�� ���� ���� UnityEvent�� ����ϴ� ���� 
    //AddListener�� ���� ����ϴ� ����� ����

    //1)inspector�� ���
    //���Ӽ�(inspector �������� ���� ���� �ڵ�δ� �� ����



    //2)AddListener�� ��� �����Ӽ�
    //(�ڵ�θ� ���� ���� 




    // Start is called before the first frame update
    void Start()
    {

        button01.onClick.AddListener(OnButtonEnter);
        //onClick.AddListener�� onClick���κ��� �̺�Ʈ �����ʸ� �߰��ϴ� �ڵ�
        //�̺�Ʈ ������(Event Listener)�� �̺�Ʈ �߻��� �� ó���� ����ϴ� ���� �Լ�
        //=�̺�Ʈ �ڵ鷯(Event Handler)

        button02.onClick.AddListener(() => OnButtonEnter(10));
        //pararmeter�� �����Ǿ��ִ� �Լ��� Lamda Expresssion(���ٽ�)�� Ȱ���� ����
        //
        button03.onClick.AddListener(CallBG);



    }

    private void CallBG()
    {
        StartCoroutine(BGLerp());
        //IEnumerator ������ �Լ��� ����
        //IEnumerator = C#�� �����ڶ�� �Ҹ��� ������ ����
        //-yield 1�� �̻� �ʿ�
        //IEnumerator ��ü�� ���� ���� ����� ��� ���� ��� �����ڸ� �����ؾ��Ѵ�.

        //yield�� ������ ���� ���
        //yield return�� ���� �Լ��� ȣ������ ���� ���� ������ �ٽ� �Լ��� ���ƿ�
        //yield return�� ���� (�Դٰ����ϴ� �ڵ�)

    }

    private IEnumerator BGLerp()
    {


        Vector3 start = BG.anchoredPosition;
        Vector3 target = BG.anchoredPosition.x < -310 ? new Vector3(-310, 0, 0) : new Vector3(-1545, 0, 0);
        //���� ������
        //���ǽ� ? : ���ǽ��� ���� ����� ��� : ���ǽ��� Ʋ�� ����� ���;
        //���� ���� �� a �ƴϸ� b��� Ȯ���Ǵ� ��� if�� ��ü ����
        float time_check = 0.0f;
        while (time_check < 1.0f)
        {
            BG.anchoredPosition = Vector3.Lerp(start, target, time_check / 1.0f);
            time_check += Time.deltaTime;
                yield return null;//�� �����Ӹ��� �ݺ� Ż��
            /*
                        yield return new WaitForEndOfFrame();//������ ���������� ���
                        yield return new WaitForFixedUpdate();//FixedUpdate  �Լ� ������� ���
                        yield return new WaitForSeconds(1);//1�ʴ��
                        yield return new WaitForSecondsRealtime(time);//���� �ð���ŭ ���
            */

        }
        BG.anchoredPosition = target;

        }
        //Vector3.Lerp(������ġ,������ġ,����);
        //������ġ���� ������ġ���� �ε巴�� �̵��ϴ� �ڵ� (���� ����)
        //������ 0~1 ���̷� ����
        //���� = 0�̸� ���� ��ġ return
        //���� = 1�̸� ���� ��ġ�� ���� ��ġ�� return
        //���� = 0.5�� ��� ���۰� ���� ������ ���� ������ ����
        //���� : ������ġ * (1-����) + ������ġ * ����

        //������ : Lerp�� Update���� �� �����ӿ� �� ������ ����
        //��ư���� �����ϸ� ����
        //���� ���� : �ݺ��� �����ϸ�, Ư�� �ð����� �ݺ��� Ż���� �� �ִ� �ڷ�ƾ���� ����
        /*if (BG.anchoredPosition.x <= -340)
        {
            BG.anchoredPosition = Vector3.Lerp(BG.anchoredPosition, new Vector2(-340, 0), 1f * Time.deltaTime);
        }
        else
        {
            BG.anchoredPosition = Vector3.Lerp(BG.anchoredPosition, new Vector2(-1245, 0), 1f * Time.deltaTime);
        }
        */
    

    //���� �̸��� �Ű������� ������ ����, ������ �ۼ� ������ �ٸ� ���
    //���� �̸��̶� �ٸ� ������� �Ǵ��� (Method Overloading)
    private void OnButtonEnter(int v)
    {
        text01.text += v;
    }

    private void OnButtonEnter()
    {
        text01.text = "��ư �̺�Ʈ ���� ����!";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
