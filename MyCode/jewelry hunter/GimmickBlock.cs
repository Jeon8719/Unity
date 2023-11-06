using UnityEngine;

public class GimmickBlock : MonoBehaviour
{
    public float length = 0.01f; //낙하 탐지 거리
    public bool isDelete = false; //낙하 후 제거 여부
    bool isFell = false; //낙하에 대한 처리
    float fadeTime = 0.5f; //페이드 아웃

    private void Start()
    {
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        rbody.bodyType = RigidbodyType2D.Static;
        //리지드 바디를 정지 상태로 설정
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
