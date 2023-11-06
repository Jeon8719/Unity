using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.01f; //���� Ž�� �Ÿ�
    public bool isDelete = false; //���� �� ���� ����
    bool isFell = false; //���Ͽ� ���� ó��
    float fadeTime = 0.5f; //���̵� �ƿ�

    private void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
        //������ �ٵ� ���� ���·� ����
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float d = Vector2.Distance(transform.position, player.transform.position);
            if (length >= d)
            {
                Rigidbody2D rbody = GetComponent<Rigidbody2D>();
                if (rbody.bodyType == RigidbodyType2D.Static)
                {
                    rbody.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
        if (isFell)
        {
            fadeTime -= Time.deltaTime;
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = fadeTime;
            GetComponent<SpriteRenderer>().color = color;

            if (fadeTime <= 0.0f)
                Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDelete)
        {
            isFell = true;
        }
    }
}
