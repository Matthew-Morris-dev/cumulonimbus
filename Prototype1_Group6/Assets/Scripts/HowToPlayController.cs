using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayController : MonoBehaviour
{
    [SerializeField]
    private Sprite[] keyboards;
    [SerializeField]
    private SpriteRenderer keyboardHolder;
    
    public void RenderKeyboard(int stage)
    {
        if (stage <= keyboards.Length)
        {
            keyboardHolder.sprite = keyboards[stage];
        }
    }
}
