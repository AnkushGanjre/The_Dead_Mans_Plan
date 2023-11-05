using System.Collections;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AllT8PeopleScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;

    [SerializeField] private Transform contentParent;
    [SerializeField] private GameObject t8ChatPeoplePrefab;
    [SerializeField] private GameObject gameController;

    [SerializeField] private GameObject t8EnterAnim;
    [SerializeField] private GameObject t8LoopAnim;
    [SerializeField] private GameObject scrollView;

    [SerializeField] private GameObject topPanel;
    [SerializeField] private GameObject bottomPanel;

    private void Awake()
    {
        t8EnterAnim.SetActive(false);
        t8LoopAnim.SetActive(false);
        scrollView.SetActive(false);
    }
    private void OnEnable()
    {
        t8EnterAnim.SetActive(true);
        t8LoopAnim.SetActive(false);
        scrollView.SetActive(false);

        StartCoroutine(T8AnimStart());
    }
    private IEnumerator T8AnimStart()
    {
        yield return new WaitForSeconds(5);
        //t8EnterAnim.SetActive(false);
        t8LoopAnim.SetActive(true);
    }
    public void T8EnterButton()
    {
        t8LoopAnim.SetActive(false);
        scrollView.SetActive(true);
        T8ChatRefresh();
    }
    public void T8ChatRefresh()
    {
        for (int i = 0; i < dataMangerSO.t8ChatIntroduced.Count; i++)
        {
            if (contentParent.childCount > i)
            {
                for (int i2 = 0; i2 < dataMangerSO.t8ChatIntroduced.Count; i2++)
                {
                    if (contentParent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text == dataMangerSO.t8ChatIntroduced[i2])
                    {
                        //Name Matches then set last chat.
                        //if (dataMangerSO.nrmlChatSOList[i2].chatHistory.Count != 0)
                        //{
                        //    if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 1] == "PLAYERTURN")
                        //    {
                        //        chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 4];
                        //    }
                        //    else if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 2] == "TIMESTAMP")
                        //    {
                        //        chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 3];
                        //    }
                        //    else if (dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 1] == "PARTENDS")
                        //    {
                        //        chatText = dataMangerSO.nrmlChatSOList[i2].chatHistory[dataMangerSO.nrmlChatSOList[i2].chatHistory.Count - 4];
                        //    }

                        //    // Setting the text length
                        //    if (chatText.Length > maxLength)
                        //    {
                        //        chatText = chatText.Substring(0, maxLength);
                        //    }
                        //    contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
                        //}

                        // Online / Offline Dot.
                        if (i2 + 101 == dataMangerSO.currentActiveCharacterNum)
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
                GameObject A1 = Instantiate(t8ChatPeoplePrefab, contentParent);
                A1.name = i.ToString();
                //Setting Name
                A1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dataMangerSO.t8ChatIntroduced[i];
                //Getting Dp
                for (int a = 0; a < dataMangerSO.allCharacters.Count; a++)
                {
                    if (dataMangerSO.chatsIntroduced[i] == dataMangerSO.allCharacters[a])
                    {
                        A1.transform.GetChild(1).GetComponent<Image>().sprite = dataMangerSO.allCharDp[a];
                    }
                }

                //Assigning function
                A1.GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8ChatOpen(A1.name));
                A1.AddComponent<T8LockScript>();
                //Setting last text msg.
                //if (dataMangerSO.nrmlChatSOList[i].chatHistory.Count != 0)
                //{
                //    if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 1] == "PLAYERTURN")
                //    {
                //        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 4];
                //    }
                //    else if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 2] == "TIMESTAMP")
                //    {
                //        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 3];
                //    }
                //    else if (dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 1] == "PARTENDS")
                //    {
                //        chatText = dataMangerSO.nrmlChatSOList[i].chatHistory[dataMangerSO.nrmlChatSOList[i].chatHistory.Count - 4];
                //    }
                //    // Setting the text length
                //    if (chatText.Length > maxLength)
                //    {
                //        chatText = chatText.Substring(0, maxLength);
                //    }
                //    contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
                //}

                // Online / Offline Dot.
                if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
                {
                    if (dataMangerSO.currentActiveCharacterNum == i + 101)
                    {
                        contentParent.GetChild(i).GetChild(4).gameObject.SetActive(true);
                        contentParent.GetChild(i).SetAsFirstSibling();
                    }
                }
                else
                {
                    contentParent.GetChild(i).GetChild(4).gameObject.SetActive(false);
                }
            }
        }


        //for (int i = 0; i < dataMangerSO.t8ChatIntroduced.Count; i++)
        //{
        //    if (contentParent.childCount > i)
        //    {
        //        if (contentParent.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text == dataMangerSO.t8ChatIntroduced[i])
        //        {
        //            //Name Matches then set last chat.
        //            //if (dataMangerSO.charSOList[i].chatHistory.Count != 0)
        //            //{
        //            //                if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 1] == "PLAYERTURN")
        //            //                {
        //            //                    chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 4];
        //            //                }
        //            //                else if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 2] == "TIMESTAMP")
        //            //                {
        //            //                    chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 3];
        //            //                }
        //            //                else if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 1] == "PARTENDS")
        //            //                {
        //            //                    chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 4];
        //            //                }
        //            //                // Setting the text length
        //            //                if (chatText.Length > maxLength)
        //            //                {
        //            //                    chatText = chatText.Substring(0, maxLength);
        //            //                }
        //            //                contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
        //            //            }
        //            //}
        //            // Online / Offline Dot.
        //            if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //            {
        //                if (dataMangerSO.currentActiveCharacterNum == i+ 101)
        //                {
        //                    contentParent.GetChild(i).GetChild(4).gameObject.SetActive(true);
        //                    contentParent.GetChild(i).SetAsFirstSibling();
        //                }
        //            }
        //            else
        //            {
        //                contentParent.GetChild(i).GetChild(4).gameObject.SetActive(false);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //Chat not found, instantiating.
        //        GameObject A1 = Instantiate(t8ChatPeoplePrefab, contentParent);
        //        A1.name = i.ToString();
        //        //Setting Name & DP.
        //        A1.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = dataMangerSO.t8ChatIntroduced[i];
        //        //A1.transform.GetChild(1).GetComponent<Image>().sprite = dataMangerSO.allCharDP[i]; not setting the DP.
        //        //Assigning function
        //        A1.GetComponent<Button>().onClick.AddListener(() => gameController.GetComponent<InterfaceControllerScript>().OnT8ChatOpen(A1.name));
        //        //Setting last text msg.
        //        //if (allBotDataSO.charSOList[i].chatHistory.Count != 0)
        //        //{
        //        //    if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 1] == "PLAYERTURN")
        //        //    {
        //        //        chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 4];
        //        //    }
        //        //    else if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 2] == "TIMESTAMP")
        //        //    {
        //        //        chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 3];
        //        //    }
        //        //    else if (allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 1] == "PARTENDS")
        //        //    {
        //        //        chatText = allBotDataSO.charSOList[i].chatHistory[allBotDataSO.charSOList[i].chatHistory.Count - 4];
        //        //    }
        //        //    // Setting the text length
        //        //    if (chatText.Length > maxLength)
        //        //    {
        //        //        chatText = chatText.Substring(0, maxLength);
        //        //    }
        //        //    contentParent.GetChild(i).GetChild(3).GetComponent<TextMeshProUGUI>().text = chatText;
        //        //}

        //        // Online / Offline Dot.
        //        if (i == dataMangerSO.currentActiveCharacterNum)
        //        {
        //            contentParent.GetChild(i).GetChild(4).gameObject.SetActive(true);
        //            contentParent.GetChild(i).SetAsFirstSibling();
        //        }
        //        else
        //        {
        //            contentParent.GetChild(i).GetChild(4).gameObject.SetActive(false);
        //        }
        //    }
        //}
    }
}
