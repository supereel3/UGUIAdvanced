using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticleItem : MonoBehaviour
{
    #region �ֶ�
    private Image articleSprite;
    private Text number;

    private Article article;

    private UIDrag uIDrag;

    private Canvas canvas;
    private int defaultSort;

    private Vector3 currentLocalPosition;
    private float moveOriginTimer;  //��ʱ
    private float moveOriginTime = 0.2f;   //ʱ��
    private bool isMovingOrigin = false;
    private Action onMoveEnd;

    #endregion �ֶ�

    private void Awake()
    {
        articleSprite = transform.GetComponent<Image>();
        number = transform.Find("Text").GetComponent<Text>();
        uIDrag = transform.GetComponent<UIDrag>();
        uIDrag.onStartDrag += this.OnStartDrag;
        uIDrag.onDrag += this.OnDrag;
        uIDrag.onEndDrag += this.OnEndDrag;

        canvas = transform.GetComponent<Canvas>();
        defaultSort = canvas.sortingOrder;
        //Debug.Log("����ʱarticleSprite��" + articleSprite + " number��" + number);
    }

    private void Update()
    {
        //��ԭ���ƶ�
        MovingOrigin();
    }

    public void SetArticle(Article article)
    {
        this.article = article;

        // ��ʾ����
        articleSprite.sprite = Resources.Load<Sprite>(article.spritePath);
        number.text = article.count.ToString();
        //Debug.Log("����ʱarticleSprite.sprite��" + articleSprite.sprite + " number.text��" + number.text);
    }

    public void OnStartDrag()
    {
        canvas.sortingOrder = defaultSort + 1;
    }

    public void OnDrag()
    {
        
    }

    public void OnEndDrag()
    {
        //�ص�ԭ��
        MoveToOrigin( () =>
        {
            //�ָ��㼶
            canvas.sortingOrder = defaultSort;
        });
    }

    //������ԭ���ƶ�
    public void MovingOrigin()
    {
        if (isMovingOrigin)
        {
            moveOriginTimer += Time.deltaTime * (1 / moveOriginTime);   //Time.deltaTime������ʱ�䣬(1/moveOriginTime)��1��ʱ�����ϣ���ƶ���ʱ�䣬�õ��ٶȵı���
            transform.localPosition = Vector3.Lerp(currentLocalPosition, Vector3.zero, moveOriginTimer);
            if (moveOriginTimer >= 1)
            {
                isMovingOrigin = false;
                if (onMoveEnd != null) { onMoveEnd(); }
            }
        }
    }

    public void MoveToOrigin(Action onMoveEnd)
    {
        isMovingOrigin = true;
        moveOriginTimer = 0;
        currentLocalPosition = transform.localPosition;
        this.onMoveEnd = onMoveEnd;
    }
}
