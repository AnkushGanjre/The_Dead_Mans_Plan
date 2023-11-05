using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConversationManagerScript : MonoBehaviour
{
    // Unity events
    [SerializeField] private UnityEvent onErasing, onWriting, gamePlay;

    // ScriptableObject
    [SerializeField] private DataMangerSO dataMangerSO;


    // All prefabs
    [SerializeField] private GameObject botChatPrefab;
    [SerializeField] private GameObject botDpChatPrefab;
    [SerializeField] private GameObject botTimeStampPrefab;
    [SerializeField] private GameObject botWritingPrefab;
    [SerializeField] private GameObject picturePrefab;
    [SerializeField] private GameObject playerEmojiPrefab;
    [SerializeField] private GameObject playerChatPrefab;
    [SerializeField] private GameObject playerTimeStampPrefab;
    [SerializeField] private GameObject onlineOfflinePrefab;

    // GameObjects
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject chatConversation;
    [SerializeField] private GameObject botNameStatus;
    [SerializeField] private GameObject replyIdle;
    [SerializeField] private GameObject replyActive;
    [SerializeField] private GameObject option3;
    [SerializeField] private GameObject option4;
    [SerializeField] private GameObject cursor;
    [SerializeField] private GameObject scrollView;
    [SerializeField] private Transform chatParent;

    // Some Important Parameter
    [SerializeField] private Font font;
    [SerializeField] private int fontSize;
    private Button replyButton;
    //[SerializeField] private float chatSpeed;
    private float padding = 75f;
    private string currentText;
    private int lineCount;
    private int maxCharLength;
    private GameObject chatPrefab;
    private GameObject timePrefab;

    //Bots
    private string BOTONE;
    private string BOTTWO;
    private string BOTTHIRD;
    private string BOTFOUR;
    private string BOTFIVE;
    private string BOTSIX;
    private string BOTSEVEN;
    private string BOTEIGHT;

    //Common Variables for each SO.
    [SerializeField] private string botStatus;
    [SerializeField] private int loopTimes;
    [SerializeField] private int historyNum;
    [SerializeField] private int botChatNum;
    [SerializeField] private int playerOptionsNum;
    public int picListNum;
    [SerializeField] private List<string> chatHistory;
    [SerializeField] private List<string> chatFromBot;
    [SerializeField] private List<string> optionsToPlayer;
    public List<Sprite> pictureList;

    //Extra parameters
    private bool isRunning;
    private GameObject animWrite;
    private int numOfOptions;
    private RectTransform scrollRectTranf, activeRectTranf;

    //Emoji Sprite
    [SerializeField] private Sprite emoji1;
    [SerializeField] private Sprite emoji2;
    [SerializeField] private Sprite emoji3;
    [SerializeField] private Sprite emoji4;
    [SerializeField] private Sprite emoji5;

    // Start is called before the first frame update
    void Start()
    {
        replyButton = replyIdle.GetComponent<Button>();
        numOfOptions = 0;

        scrollRectTranf = scrollView.transform.GetComponent<RectTransform>();
        activeRectTranf = replyActive.transform.GetComponent<RectTransform>();
    }
    private void OnEnable()
    {
        isRunning = true;
        StartCoroutine(OnChatInterfaceOpened());
    }
    private void OnDisable()
    {
        CharDataToSO(dataMangerSO.nrmlChatSOList[dataMangerSO.chatIndex]);
        isRunning = false;
    }
    private IEnumerator OnChatInterfaceOpened() // when opened chat display name, online status, & previous chats.
    {
        yield return new WaitForSeconds(0.00000000001f);
        if (dataMangerSO.chatsIntroduced[dataMangerSO.chatIndex] != null)
        {
            int i = dataMangerSO.chatIndex;
            CharDataFromSO(dataMangerSO.nrmlChatSOList[i]); //Getting data from SO.

            //Setting the name of the chat clicked.
            botNameStatus.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = dataMangerSO.chatsIntroduced[i];
            //Setting the Status of the chat clicked.
            botNameStatus.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = botStatus;
            

            // Printing all the previous chat.
            if (chatHistory.Count > 0) //Previous chat exist or not.
            {
                historyNum = 0;
                picListNum = 0;
                loopTimes = chatHistory.Count;
                for (int a = 0; a < chatHistory.Count; a++)
                {
                    if (chatHistory[a] == "BOTONE" | chatHistory[a] == "BOTTWO" | chatHistory[a] == "BOTTHIRD" | chatHistory[a] == "BOTFOUR")
                    {
                        loopTimes = loopTimes - 1; //Making loop cycle times our need.
                    }
                    if (chatHistory[a] == "BOTFIVE" | chatHistory[a] == "BOTSIX" | chatHistory[a] == "BOTSEVEN" | chatHistory[a] == "BOTEIGHT")
                    {
                        loopTimes = loopTimes - 1; //Making loop cycle times our need.
                    }
                    if (chatHistory[a] == "PLAYER" | chatHistory[a] == "TIMESTAMP")
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
                        A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = BOTONE + " is Online";
                        chatHistory.RemoveAt(historyNum);
                    }
                    else if (currentText == "PICTURE")
                    {
                        GameObject A1 = Instantiate(picturePrefab, chatParent);
                        A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                        A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnPictureOpen());
                        picListNum++;
                        historyNum++;
                    }
                    else
                    {
                        if (currentText == "BOTONE")
                        {
                            dataMangerSO.activeBot = BOTONE;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTONE);
                        }
                        else if (currentText == "BOTTWO")
                        {
                            dataMangerSO.activeBot = BOTTWO;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTTWO);
                        }
                        else if (currentText == "BOTTHIRD")
                        {
                            dataMangerSO.activeBot = BOTTHIRD;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTTHIRD);
                        }
                        else if (currentText == "BOTFOUR")
                        {
                            dataMangerSO.activeBot = BOTFOUR;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTFOUR);
                        }
                        else if (currentText == "BOTFIVE")
                        {
                            dataMangerSO.activeBot = BOTFIVE;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTFIVE);
                        }
                        else if (currentText == "BOTSIX")
                        {
                            dataMangerSO.activeBot = BOTSIX;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTSIX);
                        }
                        else if (currentText == "BOTSEVEN")
                        {
                            dataMangerSO.activeBot = BOTSEVEN;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTSEVEN);
                        }
                        else if (currentText == "BOTEIGHT")
                        {
                            dataMangerSO.activeBot = BOTEIGHT;

                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 34;
                            chatPrefab = botDpChatPrefab;
                            timePrefab = botTimeStampPrefab;
                            ChatSpawn();
                            GettingDP(BOTEIGHT);
                        }
                        else if (currentText == "PLAYER")
                        {
                            historyNum++;
                            currentText = chatHistory[historyNum];
                            maxCharLength = 40;
                            if (currentText == "EMOJI1")
                            {
                                GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
                                A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji1;
                            }
                            else if (currentText == "EMOJI2")
                            {
                                GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
                                A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji2;
                            }
                            else if (currentText == "EMOJI3")
                            {
                                GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
                                A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji3;
                            }
                            else if (currentText == "EMOJI4")
                            {
                                GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
                                A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji4;
                            }
                            else if (currentText == "EMOJI5")
                            {
                                GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
                                A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji5;
                            }
                            else
                            {
                                chatPrefab = playerChatPrefab;
                                timePrefab = playerTimeStampPrefab;
                                ChatSpawn();
                            }
                            
                        }
                        else
                        {
                            chatPrefab = botChatPrefab;
                            ChatSpawn();
                        }
                        historyNum++;
                    }
                }
            }
            if (i == dataMangerSO.currentActiveCharacterNum)
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
            currentText = chatFromBot[botChatNum];
            if (currentText == "PARTENDS")
            {
                GameObject A1 = Instantiate(onlineOfflinePrefab, chatParent);
                A1.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = dataMangerSO.activeBot + " is Offline";
                botStatus = "Offline";
                botNameStatus.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>().text = botStatus;

                botChatNum++;
                string partNum = chatFromBot[botChatNum];
                int num = int.Parse(partNum);
                dataMangerSO.currentActiveCharacterNum = num;

                gamePlay.Invoke();
                botChatNum++;
            }
            else if (currentText == "ERASING")
            {
                animWrite = Instantiate(botWritingPrefab, chatParent);   //Writing Animation.
                for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                {
                    if (dataMangerSO.activeBot == dataMangerSO.allCharacters[a])
                    {
                        animWrite.transform.GetChild(0).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                    }
                }
                yield return new WaitForSeconds(2);
                onErasing.AddListener(EraseAction);
                onErasing.Invoke();
                yield return new WaitForSeconds(1.5f);
                onWriting.AddListener(WriteAction);
                onWriting.Invoke();

                DeletingLastChild();        //Deleting Writing Animation
                yield return new WaitForSeconds(1);
                botChatNum++;
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "SKIPOPTIONS")
            {
                botChatNum++;
                string skipOptionsCount = chatFromBot[botChatNum];
                int skipLineNum = int.Parse(skipOptionsCount);
                playerOptionsNum = playerOptionsNum + skipLineNum;
                botChatNum++;
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "SKIPLINE")
            {
                botChatNum++;
                string skipLineCount = chatFromBot[botChatNum];
                int skipLineNum = int.Parse(skipLineCount);
                botChatNum = botChatNum + skipLineNum;
                StartCoroutine(AdvancingConversation());
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
                GameObject A1 = Instantiate(picturePrefab, chatParent);
                A1.transform.GetChild(0).GetComponent<Image>().sprite = pictureList[picListNum];
                A1.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnPictureOpen());

                TimeStamp();
                picListNum++;
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "PLAYER")
            {
                // ChatHistory Title "PLAYER2".
                if (chatHistory[chatHistory.Count - 1] == "PLAYER")
                {
                    chatHistory.RemoveAt(chatHistory.Count - 1);
                }
                chatHistory.Add(currentText);

                // Activating User input field button & cursor.
                replyButton.interactable = true;
                cursor.SetActive(true);
            }
            else if (currentText == "PLAYER2")
            {
                // ChatHistory Title "PLAYER2".
                if (chatHistory[chatHistory.Count - 1] == "PLAYER2")
                {
                    chatHistory.RemoveAt(chatHistory.Count - 1);
                }
                chatHistory.Add(currentText);

                DeletingLastChild();                            //Deleting time text.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.

                // Activating User input field button & cursor.
                replyButton.interactable = true;
                cursor.SetActive(true);
            }
            else if (currentText == "BOTONE")
            {
                dataMangerSO.activeBot = BOTONE;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTTWO")
            {
                dataMangerSO.activeBot = BOTTWO;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTTHIRD")
            {
                dataMangerSO.activeBot = BOTTHIRD;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTTHIRD);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTFOUR")
            {
                dataMangerSO.activeBot = BOTFOUR;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTFOUR);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTFIVE")
            {
                dataMangerSO.activeBot = BOTFIVE;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTFIVE);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTSIX")
            {
                dataMangerSO.activeBot = BOTSIX;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 434;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTSIX);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTSEVEN")
            {
                dataMangerSO.activeBot = BOTSEVEN;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTSEVEN);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else if (currentText == "BOTEIGHT")
            {
                dataMangerSO.activeBot = BOTEIGHT;
                chatHistory.Add(currentText);   // ChatHistory Title "BOTTURN".

                botChatNum++;
                currentText = chatFromBot[botChatNum];
                maxCharLength = 34;
                chatPrefab = botDpChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding Time to history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                GettingDP(BOTEIGHT);
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(1);
                StartCoroutine(AdvancingConversation());
            }
            else
            {
                // Writing animation of bot
                GameObject A1 = Instantiate(botWritingPrefab, chatParent);
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
                DeletingLastChild();    //Deleting Animation.

                yield return new WaitForSeconds(0.001f);
                DeletingLastChild();    //Deleting TimeStamp.
                maxCharLength = 34;
                chatPrefab = botChatPrefab;
                timePrefab = botTimeStampPrefab;

                //Adding to history.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
                chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.
                chatHistory.Add(currentText);
                DateTime msgTime = DateTime.Now;
                string hour = LeadingZero(msgTime.Hour);
                string minute = LeadingZero(msgTime.Minute);
                chatHistory.Add("TIMESTAMP");
                chatHistory.Add(hour + ":" + minute);

                //Printing Text
                ChatSpawn();
                TimeStamp();
                botChatNum++;
                yield return new WaitForSeconds(3);
                StartCoroutine(AdvancingConversation());
            }
        }
    }
    public void ReplyOption1Select()
    {
        currentText = replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        maxCharLength = 40;
        chatPrefab = playerChatPrefab;
        timePrefab = playerTimeStampPrefab;

        //Adding to history.
        chatHistory.Add(currentText);
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        chatHistory.Add("TIMESTAMP");
        chatHistory.Add(hour + ":" + minute);

        if (currentText == "(Don't say anything)")
        {
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Current Text
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum += 2;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI1")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji1;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI2")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji2;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI3")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji3;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI4")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji4;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI5")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji5;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else
        {
            ChatSpawn();
            TimeStamp();
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
    }
    public void ReplyOption2Select()
    {
        currentText = replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        maxCharLength = 40;
        chatPrefab = playerChatPrefab;
        timePrefab = playerTimeStampPrefab;

        //Adding to history.
        chatHistory.Add(currentText);
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        chatHistory.Add("TIMESTAMP");
        chatHistory.Add(hour + ":" + minute);

        if (currentText == "(Don't say anything)")
        {
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Current Text
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum += 2;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI1")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji1;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI2")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji2;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI3")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji3;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI4")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji4;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI5")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji5;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else
        {
            ChatSpawn();
            TimeStamp();
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum = botChatNum + 6;
            PlayerReplyIdle();
        }
    }
    public void ReplyOption3Select()
    {
        currentText = replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        maxCharLength = 40;
        chatPrefab = playerChatPrefab;
        timePrefab = playerTimeStampPrefab;

        //Adding to history.
        chatHistory.Add(currentText);
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        chatHistory.Add("TIMESTAMP");
        chatHistory.Add(hour + ":" + minute);

        if (currentText == "(Don't say anything)")
        {
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Current Text
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum += 2;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI1")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji1;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI2")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji2;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI3")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji3;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI4")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji4;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI5")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji5;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else
        {
            ChatSpawn();
            TimeStamp();
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum = botChatNum + 11;
            PlayerReplyIdle();
        }
    }
    public void ReplyOption4Select()
    {
        currentText = replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text;
        maxCharLength = 40;
        chatPrefab = playerChatPrefab;
        timePrefab = playerTimeStampPrefab;

        //Adding to history.
        chatHistory.Add(currentText);
        DateTime msgTime = DateTime.Now;
        string hour = LeadingZero(msgTime.Hour);
        string minute = LeadingZero(msgTime.Minute);
        chatHistory.Add("TIMESTAMP");
        chatHistory.Add(hour + ":" + minute);

        if (currentText == "(Don't say anything)")
        {
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Current Text
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "TIMESTAMP" from history.
            chatHistory.RemoveAt(chatHistory.Count - 1);    // Deleting Text "Time" from history.
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum += 2;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI1")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji1;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI2")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji2;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI3")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji3;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI4")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji4;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else if (currentText == "EMOJI5")
        {
            GameObject A1 = Instantiate(playerEmojiPrefab, chatParent);
            A1.transform.GetChild(1).GetComponent<Image>().sprite = emoji5;

            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum++;
            PlayerReplyIdle();
        }
        else
        {
            ChatSpawn();
            TimeStamp();
            playerOptionsNum = playerOptionsNum + numOfOptions;
            botChatNum = botChatNum + 16;
            PlayerReplyIdle();
        }
    }
    public void PlayerReplyActive()
    {
        // Getting options Text.
        if (optionsToPlayer[playerOptionsNum] == "2")
        {
            option3.SetActive(false);
            option4.SetActive(false);
            numOfOptions = 2;
            playerOptionsNum++;
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum];
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 1];

            //Resizing scroll view & replyActive panel accroding to num of options
            activeRectTranf.sizeDelta = new Vector2(activeRectTranf.sizeDelta.x, 350);    //350f calculated height for 2 options
            scrollRectTranf.offsetMin = new Vector2(scrollRectTranf.offsetMin.x, 350);
        }
        else if (optionsToPlayer[playerOptionsNum] == "3")
        {
            option3.SetActive(true);
            option4.SetActive(false);
            numOfOptions = 3;
            playerOptionsNum++;
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum];
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 1];
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 2];

            //Resizing scroll view & replyActive panel accroding to num of options
            activeRectTranf.sizeDelta = new Vector2(activeRectTranf.sizeDelta.x, 450);    //450f calculated height for 2 options
            scrollRectTranf.offsetMin = new Vector2(scrollRectTranf.offsetMin.x, 450);
        }
        else
        {
            option3.SetActive(true);
            option4.SetActive(true);
            numOfOptions = 4;
            playerOptionsNum++;
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum];
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 1];
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 2];
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = optionsToPlayer[playerOptionsNum + 3];

            //Resizing scroll view & replyActive panel accroding to num of options
            activeRectTranf.sizeDelta = new Vector2(activeRectTranf.sizeDelta.x, 550);    //550f calculated height for 2 options
            scrollRectTranf.offsetMin = new Vector2(scrollRectTranf.offsetMin.x, 550);
        }

        //Emoji Check for 1st Option
        if (replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI1")
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>().sprite = emoji1;
        }
        else if (replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI2")
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>().sprite = emoji2;
        }
        else if (replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI3")
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>().sprite = emoji3;
        }
        else if (replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI4")
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>().sprite = emoji4;
        }
        else if (replyActive.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI5")
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>().sprite = emoji5;
        }
        else
        {
            replyActive.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        //Emoji Check for 2nd Option
        if (replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI1")
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = emoji1;
        }
        else if (replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI2")
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = emoji2;
        }
        else if (replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI3")
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = emoji3;
        }
        else if (replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI4")
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = emoji4;
        }
        else if (replyActive.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI5")
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>().sprite = emoji5;
        }
        else
        {
            replyActive.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(1).GetChild(1).gameObject.SetActive(false);
        }

        //Emoji Check for 3rd Option
        if (replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI1")
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().sprite = emoji1;
        }
        else if (replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI2")
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().sprite = emoji2;
        }
        else if (replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI3")
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().sprite = emoji3;
        }
        else if (replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI4")
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().sprite = emoji4;
        }
        else if (replyActive.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI5")
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>().sprite = emoji5;
        }
        else
        {
            replyActive.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(2).GetChild(1).gameObject.SetActive(false);
        }

        //Emoji Check for 4th Option
        if (replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI1")
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>().sprite = emoji1;
        }
        else if (replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI2")
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>().sprite = emoji2;
        }
        else if (replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI3")
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>().sprite = emoji3;
        }
        else if (replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI4")
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>().sprite = emoji4;
        }
        else if (replyActive.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text == "EMOJI5")
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>().sprite = emoji5;
        }
        else
        {
            replyActive.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
            replyActive.transform.GetChild(1).GetChild(3).GetChild(1).gameObject.SetActive(false);
        }

        //Activating Options panel
        replyIdle.SetActive(false);
        replyActive.SetActive(true);
        onScrollValueChange();
    }
    private void PlayerReplyIdle()
    {
        //Deactivating User input field button & Cursor.
        replyButton.interactable = false;
        cursor.SetActive(false);
        // Resizing & Deactivating Options panel.
        scrollRectTranf.offsetMin = new Vector2(scrollRectTranf.offsetMin.x, 200);
        replyIdle.SetActive(true);
        replyActive.SetActive(false);
        StartCoroutine(AdvancingConversation());
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
            lineCount = 2 + ((charLength - maxCharLength) / maxCharLength);       //   maxCharLength was 35, why 35???
        }

        GUIStyle style = new GUIStyle();
        style.font = font;
        style.fontSize = fontSize;

        float width = style.CalcSize(new GUIContent(currentText)).x;
        float height = style.CalcSize(new GUIContent(currentText)).y;
        if (width < 150)
        {
            width = 150;
        }
        Vector2 textSize = new Vector2(width, height);          //90 Height feels right

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
            A1.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(a1Width, a1Height + (85f * (lineCount - 1)));
            A1.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(imageWidth, imageHeight + (85f * (lineCount - 1)));
            A1.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = new Vector2(textWidth, textHeight + (85f * (lineCount - 1)));
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
        Transform lastChild = chatParent.GetChild(chatParent.childCount - 1);
        Destroy(lastChild.gameObject);
    }
    private void EraseAction()
    {
        animWrite.GetComponent<AnimBotWritingScript>().OnErasing();
    }
    private void WriteAction()
    {
        animWrite.GetComponent<AnimBotWritingScript>().OnWriting();
    }
    private void CharDataFromSO(CharChatDataSO activeCharDataSO)
    {
        // Here we assign all the data for the chat from the SO file.
        botStatus = activeCharDataSO.botStatus;
        historyNum = activeCharDataSO.historyNum;
        botChatNum = activeCharDataSO.botChatNum;
        playerOptionsNum = activeCharDataSO.playerOptionsNum;
        picListNum = activeCharDataSO.picListNum;
        BOTONE = activeCharDataSO.BOTONE;
        BOTTWO = activeCharDataSO.BOTTWO;
        BOTTHIRD = activeCharDataSO.BOTTHIRD;
        BOTFOUR = activeCharDataSO.BOTFOUR;
        BOTFIVE = activeCharDataSO.BOTFIVE;
        BOTSIX = activeCharDataSO.BOTSIX;
        BOTSEVEN = activeCharDataSO.BOTSEVEN;
        BOTEIGHT = activeCharDataSO.BOTEIGHT;
        chatHistory = activeCharDataSO.chatHistory;
        chatFromBot = activeCharDataSO.chatFromBot;
        optionsToPlayer = activeCharDataSO.optionsToPlayer;
        pictureList = activeCharDataSO.pictureList;
    }
    private void CharDataToSO(CharChatDataSO activeCharDataSO)
    {
        // Here we assign all the data for the chat back to SO file.
        activeCharDataSO.botStatus = botStatus;
        activeCharDataSO.historyNum = historyNum;
        activeCharDataSO.botChatNum = botChatNum;
        activeCharDataSO.playerOptionsNum = playerOptionsNum;
        activeCharDataSO.picListNum = picListNum;
        activeCharDataSO.BOTONE = BOTONE;
        activeCharDataSO.BOTTWO = BOTTWO;
        activeCharDataSO.BOTTHIRD = BOTTHIRD;
        activeCharDataSO.BOTFOUR = BOTFOUR;
        activeCharDataSO.BOTFIVE = BOTFIVE;
        activeCharDataSO.BOTSIX = BOTSIX;
        activeCharDataSO.BOTSEVEN = BOTSEVEN;
        activeCharDataSO.BOTEIGHT = BOTEIGHT;
        activeCharDataSO.chatHistory = chatHistory;
        activeCharDataSO.chatFromBot = chatFromBot;
        activeCharDataSO.optionsToPlayer = optionsToPlayer;
        activeCharDataSO.pictureList = pictureList;
    }
}
