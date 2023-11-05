using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePlayControllerScript : MonoBehaviour
{
    //Unity Events
    [SerializeField] private UnityEvent onExitNotification, onEntryNotification;
    [SerializeField] private UnityEvent chatRefresh, t8ChatRefresh, newsRefresh;
    [SerializeField] private UnityEvent onPhoneCalls, makingcall;
    [SerializeField] private UnityEvent onHomeButton;

    //ScriptableObjects
    [SerializeField] private DataMangerSO dataMangerSO;

    //GameObjects
    [SerializeField] private GameObject uiParent;
    [SerializeField] private GameObject chapterLoad;

    [SerializeField] private GameObject notificationPanel;
    [SerializeField] private GameObject t8BotNameStatus;
    [SerializeField] private GameObject bottomLineOnline;
    [SerializeField] private GameObject bottomLineOffline;

    //Transforms
    [SerializeField] private Transform chatContentParent;       // For moving chat on top use- child.transform.SetAsFirstSibling();
    [SerializeField] private Transform t8ChatContentParent;

    [SerializeField] private int chapterNum;
    private int personIndex;
    private int t8ChatIndex;
    private int newsIndex;

    [SerializeField] private Sprite imagePrivate;
    [SerializeField] private Sprite newsImage;

    [SerializeField] private Animator animator;

    private void Start()
    {
        chapterNum = 1;
        personIndex = 0;
        t8ChatIndex = 0;
        newsIndex = 0;
        chapterLoad.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "CHAPTER " + chapterNum;
        uiParent.SetActive(false);
        chapterLoad.SetActive(true);
        chapterLoad.transform.GetChild(0).gameObject.SetActive(true);       //Button active.
        chapterLoad.transform.GetChild(1).gameObject.SetActive(false);        //Crossfade Tnactive.
    }
    public void GamePlay()
    {
        // Go to chat one on one conv
        if (dataMangerSO.currentActiveCharacterNum < 100)                                                   //0-100
        {
            if (dataMangerSO.currentActiveCharacterNum == dataMangerSO.chatsIntroduced.Count)
            {
                OnCharacterIntroduced();
            }
            StartCoroutine(ChatActivation(dataMangerSO.currentActiveCharacterNum));
        }
        // Go to chat T8 Conv
        if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)   //100-200
        {
            if ((dataMangerSO.currentActiveCharacterNum-101) == dataMangerSO.t8ChatIntroduced.Count)
            {
                OnT8ChatIntroduced();
            }
            StartCoroutine(T8Activation(dataMangerSO.currentActiveCharacterNum-101));
        }
        // Go to Phone
        if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)   //200-300
        {
            StartCoroutine(MakingACall());
            //bottomPanel.GetChild(2).GetChild(2).gameObject.SetActive(true);
        }
        // Go to News
        if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)   //300-400
        {
            StartCoroutine(NewsActivation());
        }
        // Chapter Ends
        if (dataMangerSO.currentActiveCharacterNum == 555)
        {
            StartCoroutine(NextChapter());
        }
        // Game End
        if (dataMangerSO.currentActiveCharacterNum == 999)
        {
            //chapterLoad.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "End of Chapter 1";
            uiParent.SetActive(false);
            chapterLoad.SetActive(true);
            chapterLoad.transform.GetChild(0).gameObject.SetActive(false);       //Button inactive.
            chapterLoad.transform.GetChild(1).gameObject.SetActive(false);        //Crossfade inactive.
            chapterLoad.transform.GetChild(2).gameObject.SetActive(true);        //Crossfade inactive.
        }
    }
    private IEnumerator MakingACall()
    {

        yield return new WaitForSeconds(2);
        onPhoneCalls.Invoke();
        makingcall.Invoke();
    }
    private IEnumerator NewsActivation()
    {
        //Adding news to list newsIntroduced
        dataMangerSO.newsIntroduced.Add(dataMangerSO.allNews[newsIndex]);

        //Setting dp and name on notification
        notificationPanel.transform.GetChild(0).GetComponent<Image>().sprite = newsImage;    //all dp Set of privacy
        notificationPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "NEWS FLASH";    //name
        notificationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dataMangerSO.allNews[newsIndex];

        yield return new WaitForSeconds(1);
        StartCoroutine(OnNotification());
        yield return new WaitForSeconds(0.5f);
        newsRefresh.Invoke();
        newsIndex++;
    }
    private IEnumerator T8Activation(int i)
    {
        // Adding Term Botturn & text to history
        dataMangerSO.t8ChatSOList[i].chatHistory.Add(dataMangerSO.t8ChatSOList[i].chatFromBot[dataMangerSO.t8ChatSOList[i].chatNum]);
        dataMangerSO.t8ChatSOList[i].chatHistory.Add(dataMangerSO.t8ChatSOList[i].chatFromBot[dataMangerSO.t8ChatSOList[i].chatNum + 1]);
        dataMangerSO.t8ChatSOList[i].chatHistory.Add(dataMangerSO.t8ChatSOList[i].chatFromBot[dataMangerSO.t8ChatSOList[i].chatNum + 2]);

        //Adding time to history
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        dataMangerSO.t8ChatSOList[i].chatHistory.Add("TIMESTAMP");
        dataMangerSO.t8ChatSOList[i].chatHistory.Add(hour + ":" + minute);

        //Increasing ChatNum
        dataMangerSO.t8ChatSOList[i].chatNum += 3;

        //Setting dp and name on notification
        notificationPanel.transform.GetChild(0).GetComponent<Image>().sprite = imagePrivate;    //all dp Set of privacy
        notificationPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.t8ChatIntroduced[i];  //name
        notificationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "SPY MODE";

        yield return new WaitForSeconds(1);
        StartCoroutine(OnNotification());
        yield return new WaitForSeconds(0.5f);
        t8ChatRefresh.Invoke();
    }
    private IEnumerator ChatActivation(int i)
    {
        // Setting status to Online
        dataMangerSO.nrmlChatSOList[i].botStatus = "Online";

        // Adding Term Botturn & text to history
        dataMangerSO.nrmlChatSOList[i].chatHistory.Add(dataMangerSO.nrmlChatSOList[i].chatFromBot[dataMangerSO.nrmlChatSOList[i].botChatNum]);
        dataMangerSO.nrmlChatSOList[i].chatHistory.Add(dataMangerSO.nrmlChatSOList[i].chatFromBot[dataMangerSO.nrmlChatSOList[i].botChatNum + 1]);
        dataMangerSO.nrmlChatSOList[i].chatHistory.Add(dataMangerSO.nrmlChatSOList[i].chatFromBot[dataMangerSO.nrmlChatSOList[i].botChatNum + 2]);
        
        //Adding time to history
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        dataMangerSO.nrmlChatSOList[i].chatHistory.Add("TIMESTAMP");
        dataMangerSO.nrmlChatSOList[i].chatHistory.Add(hour + ":" + minute);

        //Increasing botChatNum
        dataMangerSO.nrmlChatSOList[i].botChatNum += 3;

        //Setting dp and name on notification
        notificationPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.chatsIntroduced[i];  //name
        notificationPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = "NEW MESSAGE";
        //Getting Dp
        for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
        {
            if (dataMangerSO.chatsIntroduced[i] == dataMangerSO.allCharacters[a])
            {
                notificationPanel.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
            }
        }

        yield return new WaitForSeconds(1);
        StartCoroutine(OnNotification());
        yield return new WaitForSeconds(0.5f);
        chatRefresh.Invoke();
    }
    private IEnumerator OnNotification()
    {
        notificationPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        onExitNotification.Invoke();

        yield return new WaitForSeconds(1);
        notificationPanel.SetActive(false);
        onEntryNotification.Invoke();
    }
    public void OnCharacterIntroduced()       //add Bot Chat to introduced list
    {
        if (personIndex < dataMangerSO.allNrmlChats.Count)
        {
            dataMangerSO.chatsIntroduced.Add(dataMangerSO.allNrmlChats[personIndex]);
            personIndex++;
        }
    }
    public void OnT8ChatIntroduced()       //add T8 Chat to introduced list
    {
        if (t8ChatIndex < dataMangerSO.allT8Chats.Count)
        {
            dataMangerSO.t8ChatIntroduced.Add(dataMangerSO.allT8Chats[t8ChatIndex]);
            t8ChatIndex++;
        }
    }
    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

    public void OnChapterLoad()
    {
        uiParent.SetActive(true);
        chapterLoad.transform.GetChild(0).gameObject.SetActive(false);       //Button Inactive.
        chapterLoad.transform.GetChild(1).gameObject.SetActive(true);        //Crossfade active.
        animator.SetTrigger("CroddFadeStart");
        StartCoroutine(StartChapter());
    }
    private IEnumerator StartChapter()
    {
        OnCharacterIntroduced();
        dataMangerSO.currentActiveCharacterNum = dataMangerSO.afterChapterStarts[chapterNum - 1];
        yield return new WaitForSeconds(1);
        StartCoroutine(ChatActivation(dataMangerSO.afterChapterStarts[chapterNum - 1]));
        yield return new WaitForSeconds(1);
        chapterLoad.SetActive(false);
        chapterNum++;
    }
    private IEnumerator NextChapter()
    {
        chapterLoad.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "CHAPTER " + chapterNum;
        uiParent.SetActive(false);
        chapterLoad.SetActive(true);
        chapterLoad.transform.GetChild(0).gameObject.SetActive(false);       //Button active.
        chapterLoad.transform.GetChild(1).gameObject.SetActive(true);        //Crossfade active.
        animator.SetTrigger("CrossFadeEnd");
        yield return new WaitForSeconds(2);
        chapterLoad.transform.GetChild(0).gameObject.SetActive(true);       //Button active.
        chapterLoad.transform.GetChild(1).gameObject.SetActive(false);        //Crossfade Unactive.
        onHomeButton.Invoke();
    }
}
