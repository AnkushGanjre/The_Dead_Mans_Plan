using UnityEngine;
using UnityEngine.UI;

public class InterfaceControllerScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;

    [SerializeField] private bool onHomePage;
    [SerializeField] private bool onChatPage;
    [SerializeField] private bool onTermin8Page;
    [SerializeField] private bool onPhonePage;
    [SerializeField] private bool onNewsPage;
    [SerializeField] private bool onGamePage;
    [SerializeField] private bool onSettingsPage;


    [SerializeField] private GameObject homeScreen;
    [SerializeField] private GameObject middleInterface;
    [SerializeField] private GameObject gameCanvas;

    [SerializeField] private GameObject allParent;
    [SerializeField] private GameObject topBar;
    [SerializeField] private GameObject topPanel;
    [SerializeField] private GameObject middlePanel;
    [SerializeField] private GameObject notificationPanel;

    [SerializeField] private GameObject chatInterfaceTitle;
    [SerializeField] private GameObject allChats;
    [SerializeField] private GameObject botNameStatus;
    [SerializeField] private GameObject chatConversation;
    [SerializeField] private GameObject botProfile;

    [SerializeField] private GameObject termin8InterfaceTitle;
    [SerializeField] private GameObject allT8Chats;
    [SerializeField] private GameObject t8BotNameStatus;
    [SerializeField] private GameObject t8Conversation;

    [SerializeField] private GameObject phoneInterfaceTitle;
    [SerializeField] private GameObject phoneInterface;

    [SerializeField] private GameObject newsInterfaceTitle;
    [SerializeField] private GameObject allNews;
    [SerializeField] private GameObject newsHeading;
    [SerializeField] private GameObject detailedNews;

    [SerializeField] private GameObject profileInterfaceTitle;
    [SerializeField] private GameObject profileSettings;

    [SerializeField] private Transform allChatPeopleParent;
    [SerializeField] private Transform chatConversationParent;

    [SerializeField] private Transform allT8ChatPeopleParent;
    [SerializeField] private Transform t8ConversationParent;
    [SerializeField] private Transform allNewsParent;

    [SerializeField] private GameObject pictureEnlarge;
    [SerializeField] private Transform optionsParent;
    [SerializeField] private Transform store;

    private ConversationManagerScript convManagerScript;
    private T8ConversationManagerScript t8ConvManagerScript;

    private string activeChatNum;       //in use

    void Awake()
    {
        onHomePage = false;
        onChatPage = false;
        onTermin8Page = false;
        onPhonePage = false;
        onNewsPage = false;
        onSettingsPage = false;

        ChangeState(homeScreen, false);
        ChangeState(middleInterface, false);
        ChangeState(gameCanvas, false);

        ChangeState(chatInterfaceTitle, false);
        ChangeState(allChats, false);
        ChangeState(botNameStatus, false);
        ChangeState(chatConversation, false);
        ChangeState(botProfile, false);

        ChangeState(termin8InterfaceTitle, false);
        ChangeState(allT8Chats, false);
        ChangeState(t8BotNameStatus, false);
        ChangeState(t8Conversation, false);


        ChangeState(phoneInterfaceTitle, false);
        ChangeState(phoneInterface, false);

        ChangeState(newsInterfaceTitle, false);
        ChangeState(allNews, false);
        ChangeState(newsHeading, false);
        ChangeState(detailedNews, false);

        ChangeState(profileInterfaceTitle, false);
        ChangeState(profileSettings, false);

        ChangeState(pictureEnlarge, false);
        convManagerScript = chatConversation.GetComponent<ConversationManagerScript>();
        t8ConvManagerScript = t8Conversation.GetComponent<T8ConversationManagerScript>();
    }

    private void Start()
    {
        onHomePage = true;
        ChangeState(homeScreen, true);
    }

    private void ChangeState(GameObject go, bool value)
    { 
        go.SetActive(value);
    }

    public void OnBackButton()
    {

    }

    public void OnHomeButton()
    {
        if (!onHomePage)
        {
            onHomePage = true;
            onChatPage = false;
            onTermin8Page = false;
            onPhonePage = false;
            onNewsPage = false;
            onSettingsPage = false;

            BackToMessages();
            BackToT8Terminal();
            BackToNewsInterface();

            ChangeState(homeScreen, true);
            ChangeState(middleInterface, false);
            ChangeState(gameCanvas, false);
        }
    }

    public void OnChatButton()
    {
        if (!onChatPage)
        {
            onHomePage = false;
            onChatPage = true;
            onTermin8Page = false;
            onPhonePage = false;
            onNewsPage = false;
            onSettingsPage = false;

            ChangeState(homeScreen, false);
            ChangeState(middleInterface, true);

            ChangeState(chatInterfaceTitle, true);
            ChangeState(allChats, true);
            ChangeState(termin8InterfaceTitle, false);
            ChangeState(allT8Chats, false);
            ChangeState(phoneInterfaceTitle, false);
            ChangeState(phoneInterface, false);
            ChangeState(newsInterfaceTitle, false);
            ChangeState(allNews, false);
            ChangeState(profileInterfaceTitle, false);
            ChangeState(profileSettings, false);
        }
        //if (dataMangerSO.currentActiveCharacterNum < 100)
        //{
        //    bottomPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //{
        //    bottomPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)
        //{
        //    bottomPanel.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        //{
        //    bottomPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 400 && dataMangerSO.currentActiveCharacterNum < 500)
        //{
        //    bottomPanel.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        //}
    }
    public void OnTermin8Button()
    {
        if (!onTermin8Page)
        {
            onHomePage = false;
            onChatPage = false;
            onTermin8Page = true;
            onPhonePage = false;
            onNewsPage = false;
            onSettingsPage = false;

            ChangeState(homeScreen, false);
            ChangeState(middleInterface, true);

            ChangeState(chatInterfaceTitle, false);
            ChangeState(allChats, false);
            ChangeState(termin8InterfaceTitle, true);
            ChangeState(allT8Chats, true);
            ChangeState(phoneInterfaceTitle, false);
            ChangeState(phoneInterface, false);
            ChangeState(newsInterfaceTitle, false);
            ChangeState(allNews, false);
            ChangeState(profileInterfaceTitle, false);
            ChangeState(profileSettings, false);
        }
        //if (dataMangerSO.currentActiveCharacterNum < 100)
        //{
        //    bottomPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //{
        //    bottomPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)
        //{
        //    bottomPanel.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        //{
        //    bottomPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 400 && dataMangerSO.currentActiveCharacterNum < 500)
        //{
        //    bottomPanel.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        //}
    }
    public void OnPhoneButton()
    {
        if (!onPhonePage)
        {
            onHomePage = false;
            onChatPage = false;
            onTermin8Page = false;
            onPhonePage = true;
            onNewsPage = false;
            onSettingsPage = false;

            ChangeState(homeScreen, false);
            ChangeState(middleInterface, true);

            ChangeState(chatInterfaceTitle, false);
            ChangeState(allChats, false);
            ChangeState(termin8InterfaceTitle, false);
            ChangeState(allT8Chats, false);
            ChangeState(phoneInterfaceTitle, true);
            ChangeState(phoneInterface, true);
            ChangeState(newsInterfaceTitle, false);
            ChangeState(allNews, false);
            ChangeState(profileInterfaceTitle, false);
            ChangeState(profileSettings, false);
        }
        //if (dataMangerSO.currentActiveCharacterNum < 100)
        //{
        //    bottomPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //{
        //    bottomPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)
        //{
        //    bottomPanel.transform.GetChild(2).GetChild(2).gameObject.SetActive(false);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        //{
        //    bottomPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 400 && dataMangerSO.currentActiveCharacterNum < 500)
        //{
        //    bottomPanel.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        //}
    }
    public void OnNewsButton()
    {
        if (!onNewsPage)
        {
            onHomePage = false;
            onChatPage = false;
            onTermin8Page = false;
            onPhonePage = false;
            onNewsPage = true;
            onSettingsPage = false;

            ChangeState(homeScreen, false);
            ChangeState(middleInterface, true);

            ChangeState(chatInterfaceTitle, false);
            ChangeState(allChats, false);
            ChangeState(termin8InterfaceTitle, false);
            ChangeState(allT8Chats, false);
            ChangeState(phoneInterfaceTitle, false);
            ChangeState(phoneInterface, false);
            ChangeState(newsInterfaceTitle, true);
            ChangeState(allNews, true);
            ChangeState(profileInterfaceTitle, false);
            ChangeState(profileSettings, false);
        }
        //if (dataMangerSO.currentActiveCharacterNum < 100)
        //{
        //    bottomPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //{
        //    bottomPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)
        //{
        //    bottomPanel.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        //{
        //    bottomPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 400 && dataMangerSO.currentActiveCharacterNum < 500)
        //{
        //    bottomPanel.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
        //}
    }

    public void OnGameButton()
    {
        if (!onGamePage)
        {
            onHomePage = false;
            onChatPage = false;
            onTermin8Page = false;
            onPhonePage = false;
            onNewsPage = false;
            onGamePage = true;
            onSettingsPage = false;

            ChangeState(gameCanvas, true);
        }
    }

    public void OnSettingsButton()
    {
        if (!onSettingsPage)
        {
            onHomePage = false;
            onChatPage = false;
            onTermin8Page = false;
            onPhonePage = false;
            onNewsPage = false;
            onGamePage = false;
            onSettingsPage = true;

            ChangeState(homeScreen, false);
            ChangeState(middleInterface, true);

            ChangeState(chatInterfaceTitle, false);
            ChangeState(allChats, false);
            ChangeState(termin8InterfaceTitle, false);
            ChangeState(allT8Chats, false);
            ChangeState(phoneInterfaceTitle, false);
            ChangeState(phoneInterface, false);
            ChangeState(newsInterfaceTitle, false);
            ChangeState(allNews, false);
            ChangeState(profileInterfaceTitle, true);
            ChangeState(profileSettings, true);
        }
        //if (dataMangerSO.currentActiveCharacterNum < 100)
        //{
        //    bottomPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        //{
        //    bottomPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 200 && dataMangerSO.currentActiveCharacterNum < 300)
        //{
        //    bottomPanel.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        //{
        //    bottomPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
        //}
        //else if (dataMangerSO.currentActiveCharacterNum > 400 && dataMangerSO.currentActiveCharacterNum < 500)
        //{
        //    bottomPanel.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
        //}
    }
    public void OnNotification()
    {
        if (chatConversationParent.childCount > 0)
        {
            BackToMessages();
        }
        if (t8ConversationParent.childCount > 0)
        {
            BackToT8Terminal();
        }
        if (allNewsParent.childCount > 0)
        {
            BackToNewsInterface();
        }

        OnHomeButton();

        if (dataMangerSO.currentActiveCharacterNum < 100)
        {
            OnChatButton();
        }
        else if (dataMangerSO.currentActiveCharacterNum > 100 && dataMangerSO.currentActiveCharacterNum < 200)
        {
            OnTermin8Button();
        }
        else if (dataMangerSO.currentActiveCharacterNum > 300 && dataMangerSO.currentActiveCharacterNum < 400)
        {
            OnNewsButton();
        }

        notificationPanel.SetActive(false);
    }
    public void OnChatOpen(string buttonName)
    {
        ChangeState(chatInterfaceTitle, false);
        ChangeState(allChats, false);
        ChangeState(botNameStatus, true);
        ChangeState(chatConversation, true);
        ChangeState(botProfile, false);
        
        if (allChatPeopleParent.Find(buttonName))
        {
            dataMangerSO.chatIndex = int.Parse(buttonName);
        }
        activeChatNum = buttonName;
    }
    public void OnProfileOpen()
    {

        ChangeState(botNameStatus, false);
        ChangeState(chatConversation, false);
        ChangeState(botProfile, true);

    }
    public void ProfileBackButton()
    {
        //Delete all child of chatconversation content parent.
        foreach (Transform child in chatConversationParent)
        {
            Destroy(child.gameObject);
        }
        ChangeState(botNameStatus, true);
        ChangeState(chatConversation, true);
        ChangeState(botProfile, false);
    }
    public void BackToMessages()
    {
        ChangeState(chatInterfaceTitle, true);
        ChangeState(allChats, true);
        ChangeState(botNameStatus, false);
        ChangeState(chatConversation, false);

        //Delete all child of chatconversation content parent.
        foreach (Transform child in chatConversationParent)
        {
            Destroy(child.gameObject);
        }
    }
    public void OnT8ChatOpen(string buttonName)
    {
        T8LockScript script = allT8ChatPeopleParent.GetChild(0).GetComponent<T8LockScript>();

        if (script != null)
        {
            // Access the bool variable of the script
            bool lockBool = script.locked;

            if (lockBool)
            {
                ChangeState(gameCanvas, true);
                ChangeState(termin8InterfaceTitle, false);
                ChangeState(allT8Chats, false);
            }
            else
            {
                ChangeState(termin8InterfaceTitle, false);
                ChangeState(allT8Chats, false);
                ChangeState(t8BotNameStatus, true);
                ChangeState(t8Conversation, true);

                if (allT8ChatPeopleParent.Find(buttonName))
                {
                    dataMangerSO.chatIndex = int.Parse(buttonName);
                }
            }
        }
    }
    public void BackToT8Terminal()
    {
        ChangeState(termin8InterfaceTitle, true);
        ChangeState(allT8Chats, true);
        ChangeState(t8BotNameStatus, false);
        ChangeState(t8Conversation, false);
        ChangeState(gameCanvas, false);

        allT8Chats.transform.GetChild(0).gameObject.SetActive(false);
        allT8Chats.transform.GetChild(1).gameObject.SetActive(false);
        allT8Chats.transform.GetChild(2).gameObject.SetActive(true);
        //Delete all child of chatconversation content parent.
        foreach (Transform child in t8ConversationParent)
        {
            Destroy(child.gameObject);
        }
        if (dataMangerSO.gameFinished == true)
        {
            dataMangerSO.gameFinished = false;
            gameCanvas.transform.GetChild(3).GetChild(2).gameObject.SetActive (false);
            foreach (Transform child in store)
            {
                GameObject newChildObject = Instantiate(child.gameObject);
                newChildObject.transform.SetParent(optionsParent);
                newChildObject.name = child.name;
            }
        }
    }
    public void OnPhoneCalls()
    {
        if(chatConversationParent.childCount != 0)
        {
            BackToMessages();
        }
        if(t8ConversationParent.childCount != 0)
        {
            BackToT8Terminal();
        }
        BackToNewsInterface();
        OnPhoneButton();
    }
    public void OnNewsOpen(string buttonName)
    {
        ChangeState(newsInterfaceTitle, false);
        ChangeState(allNews, false);
        ChangeState(newsHeading, true);
        ChangeState(detailedNews, true);

        if (allNewsParent.Find(buttonName))
        {
            dataMangerSO.chatIndex = int.Parse(buttonName);
        }
    }
    public void BackToNewsInterface()
    {
        ChangeState(newsInterfaceTitle, true);
        ChangeState(allNews, true);
        ChangeState(newsHeading, false);
        ChangeState(detailedNews, false);
    }

    public void OnPictureOpen()
    {
        // Assign picture
        Sprite pic = convManagerScript.pictureList[convManagerScript.picListNum-1];
        pictureEnlarge.transform.GetChild(1).GetComponent<Image>().sprite = pic;
        pictureEnlarge.SetActive(true);
    }
    public void OnT8PictureOpen()
    {
        // Assign picture
        Sprite pic = t8ConvManagerScript.pictureList[t8ConvManagerScript.picListNum-1];
        pictureEnlarge.transform.GetChild(1).GetComponent<Image>().sprite = pic;
        pictureEnlarge.SetActive(true);
    }
    public void OnPictureClose()
    {
        pictureEnlarge.SetActive(false);
    }
}