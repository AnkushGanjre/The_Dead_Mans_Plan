using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllChatPeoplesScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;

    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject chatPeoplePrefab;
    [SerializeField] private GameObject gameController;

    private bool firstTime;
    private string chatText;
    private int maxLength = 36;

    private void Awake()
    {
        firstTime = true;
    }
    private void OnEnable()
    {
        if (!firstTime)
        {
            ChatRefresh();
        }
    }
    public void ChatRefresh()
    {
        for (int i = 0; i < dataMangerSO.chatsIntroduced.Count; i++)
        {
            if (contentParent.childCount > i)
            {
                for (int i2 = 0; i2 < dataMangerSO.chatsIntroduced.Count; i2++)
                {
                    if (contentParent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text == dataMangerSO.chatsIntroduced[i2])
                    {
                        //Name Matches then set last chat.
                        if (dataMangerSO.nrmlChatSOList[i2].chatHistory.Count != 0)
                        {
                            if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 1] == "PLAYERTURN")
                            {
                                chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 4];
                            }
                            else if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 2] == "TIMESTAMP")
                            {
                                chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 3];
                            }
                            else if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 1] == "PARTENDS")
                            {
                                chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 4];
                            }

                            // Setting the text length
                            if (chatText.Length > maxLength)
                            {
                                chatText = chatText.Substring(0, maxLength);
                            }
                            contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
                        }

                        // Online / Offline Dot.
                        if (i2 == dataMangerSO.currentActiveCharacterNum)
                        {
                            contentParent.GetChild(i).GetChild(4).gameObject.SetActive(true);
                            contentParent.GetChild(i).SetAsFirstSibling();
                        }
                        else
                        {
                            contentParent.GetChild(i).GetChild(4).gameObject.SetActive(false);
                        }
                    }
                }
            }
            else
            {
                //Bot not found, instantiating.
                GameObject A1 = Instantiate(chatPeoplePrefab, contentParent);
                A1.name = i.ToString();
                //Setting Name
                A1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dataMangerSO.chatsIntroduced[i];
                //Getting Dp
                for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                {
                    if (dataMangerSO.chatsIntroduced[i] == dataMangerSO.allCharacters[a])
                    {
                        A1.transform.GetChild(1).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                    }
                }


                //Assigning function
                A1.GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnChatOpen(A1.name));
                //Setting last text msg.
                if (dataMangerSO.nrmlChatSOList[i].chatHistory.Count != 0)
                {
                    if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 1] == "PLAYERTURN")
                    {
                        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 4];
                    }
                    else if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 2] == "TIMESTAMP")
                    {
                        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 3];
                    }
                    else if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 1] == "PARTENDS")
                    {
                        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 4];
                    }
                    // Setting the text length
                    if (chatText.Length > maxLength)
                    {
                        chatText = chatText.Substring(0, maxLength);
                    }
                    contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
                }

                // Online / Offline Dot.
                if (i == dataMangerSO.currentActiveCharacterNum)
                {
                    contentParent.GetChild(i).GetChild(4).gameObject.SetActive(true);
                    contentParent.GetChild(i).SetAsFirstSibling();
                }
                else
                {
                    contentParent.GetChild(i).GetChild(4).gameObject.SetActive(false);
                }
            }
        }
        firstTime = false;
    }
}
