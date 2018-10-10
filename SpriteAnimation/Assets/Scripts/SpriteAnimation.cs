using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [SerializeField]
    private Sprite[] m_Sprites;

    [SerializeField]
    private float m_FrameDuration = 1.0f;

    [SerializeField]
    private SpriteRenderer m_Renderer;

    private float m_FrameRemainingTime = 0.0f;
    private int m_FrameIndex = 0;
    private bool m_invalidated = true;


    private void Awake()
    {
        if (m_Sprites.Length > 0)
        {
            m_Renderer.sprite = m_Sprites[0];
        }
    }

    void Update()
    {

        if(m_invalidated)
        {
            UpdateSprite();
        }

        m_FrameRemainingTime -= Time.deltaTime;
        if(m_FrameRemainingTime <=0.0f)
        {
            m_FrameIndex++;
            m_FrameIndex %= m_Sprites.Length;
            m_invalidated = true;
            m_FrameRemainingTime += m_FrameDuration;
        }        
    }

    private void UpdateSprite()
    {
        m_invalidated = false;
        m_Renderer.sprite = m_Sprites[m_FrameIndex % m_Sprites.Length];
    }
}
