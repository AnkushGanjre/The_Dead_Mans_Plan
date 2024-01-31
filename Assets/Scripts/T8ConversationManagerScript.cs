using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class T8ConversationManagerScript : MonoBehaviour
{
    // Unity events
    [SerializeField] private UnityEvent gamePlay;

    // ScriptableObject
    [SerializeField] private DataMangerSO dataMangerSO;

    // All prefabs
    [SerializeField] private GameObject bot1DPChatPrefab;
    [SerializeField] private GameObject bot1ChatPrefab;
    [SerializeField] private GameObject bot1TimeStampPrefab;
    [SerializeField] private GameObject bot2DPChatPrefab;
    [SerializeField] private GameObject bot2ChatPrefab;
    [SerializeField] private GameObject bot2TimeStampPrefab;
    [SerializeField] private GameObject onlineOfflinePrefab;
    [SerializeField] private GameObject bot1WritingPrefab;
    [SerializeField] private GameObject bot2WritingPrefab;
    [SerializeField] private GameObject picturePrefabBot1;
    [SerializeField] private GameObject picturePrefabBot2;

    // GameObjects
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject t8BotNameStatus;
    [SerializeField] private GameObject bottomLineOnline;
    [SerializeField] private GameObject bottomLineOffline;
    [SerializeField] private GameObject scrollView;

    [SerializeField] private Transform chatParent;

    // Chat Text Settings
    [SerializeField] private Font font;
    [SerializeField] private int fontSize;

    private float padding = 75f;
    private string currentText;
    private int lineCount;
    private int maxCharLength;
    [SerializeField] private GameObject chatPrefab;
    [SerializeField] private GameObject timePrefab;

    //Common Variables for each SO.
    [SerializeField] private int historyNum;
    [SerializeField] private int chatNum;
    public int picListNum;
    [SerializeField] private List<string> chatHistory;
    [SerializeField] private List<string> chatFromBot;
    public List<Sprite> pictureList;

    private bool isRunning;
    [SerializeField] private int loopTimes;

    //Bots
    private string BOTONE;
    private string BOTTWO;

    private void OnEnable()
    {
        isRunning = true;
        StartCoroutine(OnT8ChatInterfaceOpened());
    }
    private void OnDisable()
    {
        ChatDataToSO(dataMangerSO.t8ChatSOList[dataMangerSO.chatIndex]);
        isRunning = false;
    }
    private IEnumerator OnT8ChatInterfaceOpened()
    {
        yield return new WaitForSeconds(0.00000000001f);
        if (dataMangerSO.t8ChatIntroduced[dataMangerSO.chatIndex] != null)
        {
            int i = dataMangerSO.chatIndex;
            ChatDataFromSO(dataMangerSO.t8ChatSOList[i]); //Getting data from SO.

            //Setting the name of the chat clicked.
            t8BotNameStatus.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.t8ChatIntroduced[i];
            //Setting the Live Status of the chat clicked.
            if (i + 101 == dataMangerSO.currentActiveCharacterNum)
            {
                t8BotNameStatus.transform.GetChild(2).gameObject.SetActive(true);
                t8BotNameStatus.transform.GetChild(3).gameObject.SetActive(false);
                bottomLineOnline.SetActive(true);
                bottomLineOffline.SetActive(false);
            }
            else
            {
                t8BotNameStatus.transform.GetChild(2).gameObject.SetActive(false);
                t8BotNameStatus.transform.GetChild(3).gameObject.SetActive(true);
                bottomLineOnline.SetActive(false);
                bottomLineOffline.SetActive(true);
            }

            // Printing all the previous chat.
            if (chatHistory.Count > 0) //Previous chat exist or not.
            {
                historyNum = 0;
                picListNum = 0;
                loopTimes = chatHistory.Count;
                for (int a = 0; a < chatHistory.Count; a++)
                {
                    if (chatHistory[a] == "BOTONE" | chatHistory[a] == "BOTTWO")
                    {
                        loopTimes = loopTimes - 1; //Making loop cycle times our need.
                    }
                    if (chatHistory[a] == "TIMESTAMP" | chatHistory[a] == "PARTENDS")
                    {
                        loopTimes = loopTimes - 1; //Making loop cycle times our need.
                    }
                }
                for (int a = 0; a < loopTimes; a++)
                {
                    currentText = chatHistory[historyNum];
                    if (currentText == "TIMESTAMP")
                    {
                        historyNum++;
                        currentText = chatHistory[historyNum];
                        GameObject A1 = Instantiate(timePrefab, chatParent);
                        A1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentText;
                        historyNum++;
                    }
                    else if (currentText == "PARTSTARTS")
                    {
                        GameObject A1 = Instantiate(onlineOfflinePrefab, chatParent);
                        if (chatHistory[historyNum + 1] == "BOTONE")
                        {
                            A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = BOTONE + " is Online";
                        }
                        else
                        {
                            A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = BOTTWO + " is Online";
                        }
                        chatHistory.RemoveAt(historyNum);
                    }
                    else if (currentText == "PARTENDS")
                    {
                        GameObject A1 = Instantiate(onlineOfflinePrefab, chatParent);
                        A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.activeBot + " is Offline";
                        historyNum++;
                    }
                    else if (currentText == "PICTURE")
                    {
                        if (dataMangerSO.activeBot == BOTONE)
                        {
                            GameObject A1 = Instantiate(picturePrefabBot1, chatParent);
                            A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                            A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8PictureOpen());
                            picListNum++;
                            historyNum++;
                        }
                        else
                        {
                            GameObject A1 = Instantiate(picturePrefabBot2, chatParent);
                            A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                            A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8PictureOpen());
                            picListNum++;
                            historyNum++;
                        }
                        
                    }
                    else
                    {
                        if (currentText == "BOTONE")
                        {
                            dataMangerSO.activeBot = BOTONE;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 40;
                            chatPrefab = bot1DPChatPrefab;
                            timePrefab = bot1TimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTONE);
                        }
                        else if (currentText == "BOTTWO")
                        {
                            dataMangerSO.activeBot = BOTTWO;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 40;
                            chatPrefab = bot2DPChatPrefab;
                            timePrefab = bot2TimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTTWO);
                        }
                        else
                        {
                            if (dataMangerSO.activeBot == BOTONE)
                            {
                                chatPrefab = bot1ChatPrefab;
                                timePrefab = bot1TimeStampPrefab;
                                ChatSpawn();
                            }
                            if (dataMangerSO.activeBot == BOTTWO)
                            {
                                chatPrefab = bot2ChatPrefab;
                                timePrefab = bot2TimeStampPrefab;
                                ChatSpawn();
                            }
                        }
                        historyNum++;
                    }
                }  
            }
            if (i + 101 == dataMangerSO.currentActiveCharacterNum)
            {
                yield return new WaitForSeconds(1.5f);
                StartCoroutine(AdvancingConversation());
            }
            
        }
        
    }
    private IEnumerator AdvancingConversation()
    {
        if (isRunning)
        {
            // Start Conversation.
            currentText = chatFromBot[chatNum];
            maxCharLength = 40;
            if (currentText == "PARTENDS")
            {
                GameObject A1 = Instantiate(onlineOfflinePrefab, chatParent); 
                A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.activeBot + " is offline";

                t8BotNameStatus.transform.GetChild(2).gameObject.SetActive(false);
                t8BotNameStatus.transform.GetChild(3).gameObject.SetActive(true);
                bottomLineOnline.SetActive(false);
                bottomLineOffline.SetActive(true);

                chatNum++;
                string partNum = chatFromBot[chatNum];
                int num = int.Parse(partNum);
                dataMangerSO.currentActiveCharacterNum = num;

                gamePlay.Invoke();
                chatNum++;
            }
            else if (currentText == "PICTURE")
            {
                //Adding to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Instantiating Picture
                if (dataMangerSO.activeBot == BOTONE)
                {
                    GameObject A1 = Instantiate(picturePrefabBot1, chatParent);
                    A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                    A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8PictureOpen());
                    picListNum++;
                    historyNum++;
                }
                else
                {
                    GameObject A1 = Instantiate(picturePrefabBot2, chatParent);
                    A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                    A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8PictureOpen());
                    picListNum++;
                    historyNum++;
                }

                TimeStamp();
                picListNum++;
                chatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTONE")
            {
                dataMangerSO.activeBot = BOTONE;

                //Adding to ChatHistory Title "BOTONE".
                chatHistory.Add(currentText);

                chatPrefab = bot1DPChatPrefab;
                timePrefab = bot1TimeStampPrefab;

                chatNum++;
                currentText = chatFromBot[chatNum];

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(bot1WritingPrefab, chatParent);
                for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                {
                    if (dataMangerSO.activeBot == dataMangerSO.allCharacters[a])
                    {
                        A1.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                    }
                }
                float animTime = currentText.Length / 15;
                if (animTime < 2f)
                {
                    animTime = 2f;
                }
                if (animTime > 6f)
                {
                    animTime = 6f;
                }
                yield return new WaitForSeconds(animTime);
                DeletingLastChild();    //Deleting Animation

                //Printing Text
                ChatSpawn();
                GettingDP(BOTONE);
                TimeStamp();
                chatNum++;
                yield return new WaitForSeconds(3);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTTWO")
            {
                dataMangerSO.activeBot = BOTTWO;

                //Adding to ChatHistory Title "BOTTWO".
                chatHistory.Add(currentText);

                chatPrefab = bot2DPChatPrefab;
                timePrefab = bot2TimeStampPrefab;

                chatNum++;
                currentText = chatFromBot[chatNum];

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(bot2WritingPrefab, chatParent);
                for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                {
                    if (dataMangerSO.activeBot == dataMangerSO.allCharacters[a])
                    {
                        A1.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                    }
                }
                float animTime = currentText.Length / 15;
                if (animTime < 2f)
                {
                    animTime = 2f;
                }
                if (animTime > 6f)
                {
                    animTime = 6f;
                }
                yield return new WaitForSeconds(animTime);
                DeletingLastChild();    //Deleting Animation

                //Printing Text
                ChatSpawn();
                GettingDP(BOTTWO);
                TimeStamp();
                chatNum++;
                yield return new WaitForSeconds(3);
                StartCoroutine(AdvancingConversation());
            }
            else
            {
                // Writing animation of bot
                if (dataMangerSO.activeBot == BOTONE)       //Assigning prefab & DP
                {
                    GameObject A1 = Instantiate(bot1WritingPrefab, chatParent);
                    for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                    {
                        if (dataMangerSO.activeBot == dataMangerSO.allCharacters[a])
                        {
                            A1.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                        }
                    }
                }
                else                                         //Assigning prefab & DP
                {
                    GameObject A1 = Instantiate(bot2WritingPrefab, chatParent);
                    for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                    {
                        if (dataMangerSO.activeBot == dataMangerSO.allCharacters[a])
                        {
                            A1.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                        }
                    }
                }
                
                float animTime = currentText.Length / 15;       //15 optimal time
                if (animTime < 2f)
                {
                    animTime = 2f;
                }
                if (animTime > 6f)
                {
                    animTime = 6f;
                }
                yield return new WaitForSeconds(animTime);
                DeletingLastChild();    //Deleting Animation

                yield return new WaitForSeconds(0.001f);
                DeletingLastChild();        //Deleting TimeStamp.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.

                if (dataMangerSO.activeBot == BOTONE)
                {
                    chatPrefab = bot1ChatPrefab;
                    timePrefab = bot1TimeStampPrefab;
                }
                if (dataMangerSO.activeBot == BOTTWO)
                {
                    chatPrefab = bot2ChatPrefab;
                    timePrefab = bot2TimeStampPrefab;
                }

                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                ChatSpawn();
                TimeStamp();
                chatNum++;
                yield return new WaitForSeconds(3);
                StartCoroutine(AdvancingConversation());
            }
        }
    }
    private void ChatSpawn() //Chat + time.
    {
        int charLength = currentText.Length;
        if (charLength < maxCharLength)
        {
            lineCount = 1;
        }
        else
        {
            lineCount = 2 + ((charLength - maxCharLength) / maxCharLength);
        }

        GUIStyle style = new GUIStyle();
        style.font = font;
        style.fontSize = fontSize;

        float width = style.CalcSize(new GUIContent(currentText)).x;
        float height = style.CalcHeight(new GUIContent(currentText), width);
        Vector2 textSize = new Vector2(width, height);

        GameObject A1 = Instantiate(chatPrefab, chatParent);
        A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = currentText;

        float a1Width = A1.transform.GetComponent<RectTransform>().rect.width;
        float imageWidth = A1.transform.GetChild(0).GetComponent<RectTransform>().rect.width;
        float textWidth = A1.transform.GetChild(1).GetComponent<RectTransform>().rect.width;

        float a1Height = A1.transform.GetComponent<RectTransform>().rect.height;
        float imageHeight = A1.transform.GetChild(0).GetComponent<RectTransform>().rect.height;
        float textHeight = A1.transform.GetChild(1).GetComponent<RectTransform>().rect.height;

        if (lineCount == 1)
        {
            A1.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = textSize + new Vector2(padding, padding);
        }
        if (lineCount > 1)
        {
            A1.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(a1Width, a1Height + (70f * (lineCount - 1)));
            A1.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(imageWidth, imageHeight + (70f * (lineCount - 1)));
            A1.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight + (70f * (lineCount - 1)));
        }
        onScrollValueChange();
    }
    private void TimeStamp()
    {
        GameObject A2 = Instantiate(timePrefab, chatParent);
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        A2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = hour + ":" + minute;
        onScrollValueChange();
    }
    private void GettingDP(string abc)
    {
        //Getting Dp
        for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
        {
            if (abc == dataMangerSO.allCharacters[a])
            {
                chatParent.GetChild(chatParent.childCount - 1).GetChild(2).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
            }
        }
        //Function assign
    }
    private void onScrollValueChange()
    {
        scrollView.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
    }
    private string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
    private void DeletingLastChild()
    {
        Transform lastChild = chatParent.transform.GetChild(chatParent.transform.childCount - 1);
        Destroy(lastChild.gameObject);
    }
    private void ChatDataFromSO(T8ChatDataSO activeChatDataSO)
    {
        // Here we assign all the data for the chat from the SO file.
        historyNum = activeChatDataSO.historyNum;
        chatNum = activeChatDataSO.chatNum;
        chatHistory = activeChatDataSO.chatHistory;
        chatFromBot = activeChatDataSO.chatFromBot;
        picListNum = activeChatDataSO.picListNum;
        BOTONE = activeChatDataSO.BOTONE;
        BOTTWO = activeChatDataSO.BOTTWO;
        pictureList = activeChatDataSO.pictureList;
    }
    private void ChatDataToSO(T8ChatDataSO activeChatDataSO)
    {
        // Here we assign all the data for the chat back to SO file.
        activeChatDataSO.historyNum = historyNum;
        activeChatDataSO.chatNum = chatNum;
        activeChatDataSO.chatHistory = chatHistory;
        activeChatDataSO.chatFromBot = chatFromBot;
        activeChatDataSO.picListNum = picListNum;
        activeChatDataSO.BOTONE = BOTONE;
        activeChatDataSO.BOTTWO = BOTTWO;
        activeChatDataSO.pictureList = pictureList;
    }
}
