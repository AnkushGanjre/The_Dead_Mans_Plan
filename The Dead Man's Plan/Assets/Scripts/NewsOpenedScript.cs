using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewsOpenedScript : MonoBehaviour
{
    [SerializeField] private UnityEvent gamePlay;
    [SerializeField] private DataMangerSO dataMangerSO;

    private int newsNum;
    private GameObject childGameObject;
    [SerializeField] private GameObject detailedNews;
    [SerializeField] private Transform contentParent;
    [SerializeField] private List<Sprite> newsImages = new List<Sprite>();

    [SerializeField] private Sprite news001;
    [SerializeField] private Sprite news002;
    [SerializeField] private Sprite news003;
    [SerializeField] private Sprite news004;
    [SerializeField] private Sprite news005;
    [SerializeField] private Sprite news006;
    [SerializeField] private Sprite news007;
    [SerializeField] private Sprite news008;
    [SerializeField] private Sprite news009;
    [SerializeField] private Sprite news010;


    private void Start()
    {
        newsNum = 0;
        newsImages.Clear();
        newsImages.Add(news001);
        newsImages.Add(news002);
        newsImages.Add(news003);
        newsImages.Add(news004);
        newsImages.Add(news005);
        newsImages.Add(news006);
        newsImages.Add(news007);
        newsImages.Add(news008);
        newsImages.Add(news009);
        newsImages.Add(news010);
    }
    private void OnEnable()
    {
        StartCoroutine(OnNewsOpened());
    }
    private IEnumerator OnNewsOpened()
    {
        yield return new WaitForSeconds(0.00000000001f);
        int i = dataMangerSO.chatIndex;
        string gameObjectName = dataMangerSO.chatIndex.ToString();
        detailedNews.transform.GetComponent<Image>().sprite = newsImages[i];

        yield return new WaitForSeconds(3);
        if (contentParent.Find(gameObjectName))
        {
            childGameObject = contentParent.Find(gameObjectName).gameObject;
            NewsReadBoolScript newsScript = childGameObject.GetComponent<NewsReadBoolScript>();
            if (newsScript.firstTimeRead)
            {
                contentParent.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                newsScript.firstTimeRead = false;
                dataMangerSO.currentActiveCharacterNum = dataMangerSO.afterNewsEvent[newsNum];
                gamePlay.Invoke();
                newsNum++;
            }
        }
    }
}
