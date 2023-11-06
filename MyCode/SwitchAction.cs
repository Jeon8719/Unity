using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAction : MonoBehaviour
{
    public GameObject targetMoveBlock;
    public Sprite imageOn;
    public Sprite imageOff;
    public bool on = false; //스위치 활성화 여부 (on = true, off = false)

    private void Start()
    {
        if (on) GetComponent<SpriteRenderer>().sprite = imageOn;
        else GetComponent<SpriteRenderer>().sprite = imageOff;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(on)
            {
                on = false;
                GetComponent<SpriteRenderer>().sprite = imageOff;
                MovingBlock movingBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movingBlock.Stop();
            }
            else
            {
                on = true;
                GetComponent <SpriteRenderer>().sprite = imageOn;
                MovingBlock movingBlock = targetMoveBlock.GetComponent<MovingBlock>();
                movingBlock.Stop();
            }

        }
    }



}
