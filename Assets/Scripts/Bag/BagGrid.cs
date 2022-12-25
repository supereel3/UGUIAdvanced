using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGrid : MonoBehaviour
{
    private ArticleItem articleItem;
    public ArticleItem ArticleItem
    {
        get
        {
            return articleItem;
        }
    }

    //���ø�������
    public void SetArticleItem(ArticleItem articleItem)
    {
        this.articleItem = articleItem;

        this.articleItem = articleItem;
        // ���ø�����
        this.articleItem.transform.SetParent(transform);
        Debug.Log("��ǰarticleItem�ĸ������ǣ�" + this.articleItem.transform.parent);
        // ����λ��
        this.articleItem.transform.localPosition = Vector3.zero;
        // ����Scale
        this.articleItem.transform.localScale = Vector3.one;
        // ����
        this.articleItem.GetComponent<RectTransform>().offsetMin = new Vector2(5, 5);
        this.articleItem.GetComponent<RectTransform>().offsetMax = new Vector2(-5, -5);
    }

    //��ո���
    public void ClearGrid()
    {
        articleItem.gameObject.SetActive(false);
        articleItem.transform.SetParent(null);
        articleItem = null;
    }
}
