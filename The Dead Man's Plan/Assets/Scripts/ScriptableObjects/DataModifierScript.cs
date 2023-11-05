using UnityEngine;

public class DataModifierScript : MonoBehaviour
{
    [SerializeField] private DataMangerSO dataMangerSO;
    [SerializeField] private Sprite char1, char2, char3, char4, char5, char6, char7, char8, char9, char10;
    [SerializeField] private CharChatDataSO ncSO1, ncSO2, ncSO3, ncSO4, ncSO5, ncSO6, ncSO7, ncSO8, ncSO9, ncSO10;
    [SerializeField] private T8ChatDataSO t8SO1, t8SO2, t8SO3, t8SO4, t8SO5, t8SO6, t8SO7, t8SO8, t8SO9, t8SO10;

    private void Awake()
    {
        dataMangerSO.chatIndex = 0;
        dataMangerSO.currentActiveCharacterNum = 0;

        dataMangerSO.afterChapterStarts.Clear();
        dataMangerSO.allCharacters.Clear();
        dataMangerSO.allCharDp.Clear();

        dataMangerSO.chatsIntroduced.Clear();
        dataMangerSO.allNrmlChats.Clear();
        dataMangerSO.nrmlChatSOList.Clear();

        dataMangerSO.t8ChatIntroduced.Clear();
        dataMangerSO.allT8Chats.Clear();
        dataMangerSO.t8ChatSOList.Clear();

        dataMangerSO.allBotCalls.Clear();
        dataMangerSO.allCallsDuration.Clear();

        dataMangerSO.newsIntroduced.Clear();
        dataMangerSO.allNews.Clear();
        dataMangerSO.afterNewsEvent.Clear();
    }
    void Start()
    {
        //After Chapter starts next bot data in this list
        dataMangerSO.afterChapterStarts.Add(0);
        dataMangerSO.afterChapterStarts.Add(999);

        //All Characters in this list.
        dataMangerSO.allCharacters.Add("Ajay Shastri");         // botIndex = 0.
        dataMangerSO.allCharacters.Add("Amrish Chopra");        // botIndex = 1.
        dataMangerSO.allCharacters.Add("???");                  // botIndex = 2.
        dataMangerSO.allCharacters.Add("Dr. Palkar");           // botIndex = 3.
        dataMangerSO.allCharacters.Add("Veena");                 // botIndex = 4.

        //All Charcter's DP in this list.
        dataMangerSO.allCharDp.Add(char1);
        dataMangerSO.allCharDp.Add(char2);
        dataMangerSO.allCharDp.Add(char3);
        dataMangerSO.allCharDp.Add(char4);
        dataMangerSO.allCharDp.Add(char5);
        dataMangerSO.allCharDp.Add(char6);
        dataMangerSO.allCharDp.Add(char7);
        dataMangerSO.allCharDp.Add(char8);
        dataMangerSO.allCharDp.Add(char9);
        dataMangerSO.allCharDp.Add(char10);

        //All chats in this list.
        dataMangerSO.allNrmlChats.Add("Ajay Shastri");
        dataMangerSO.allNrmlChats.Add("Amrish Chopra");
        dataMangerSO.allNrmlChats.Add("???");

        //All Chats SO Files.
        dataMangerSO.nrmlChatSOList.Add(ncSO1);
        dataMangerSO.nrmlChatSOList.Add(ncSO2);
        dataMangerSO.nrmlChatSOList.Add(ncSO3);
        dataMangerSO.nrmlChatSOList.Add(ncSO4);
        dataMangerSO.nrmlChatSOList.Add(ncSO5);
        dataMangerSO.nrmlChatSOList.Add(ncSO6);
        dataMangerSO.nrmlChatSOList.Add(ncSO7);
        dataMangerSO.nrmlChatSOList.Add(ncSO8);
        dataMangerSO.nrmlChatSOList.Add(ncSO9);
        dataMangerSO.nrmlChatSOList.Add(ncSO10);


        //All T8 Chats in this list
        dataMangerSO.allT8Chats.Add("Amrish Chopra, Dr.Palkar");
        dataMangerSO.allT8Chats.Add("Veena Shastri, Amrish Chopra");

        //All T8 Chat SO Files.
        dataMangerSO.t8ChatSOList.Add(t8SO1);
        dataMangerSO.t8ChatSOList.Add(t8SO2);
        dataMangerSO.t8ChatSOList.Add(t8SO3);
        dataMangerSO.t8ChatSOList.Add(t8SO4);
        dataMangerSO.t8ChatSOList.Add(t8SO5);
        dataMangerSO.t8ChatSOList.Add(t8SO6);
        dataMangerSO.t8ChatSOList.Add(t8SO7);
        dataMangerSO.t8ChatSOList.Add(t8SO8);
        dataMangerSO.t8ChatSOList.Add(t8SO9);
        dataMangerSO.t8ChatSOList.Add(t8SO10);

        // All Bots That will make calls
        dataMangerSO.allBotCalls.Add("Amrish Chopra");

        // All Phone call's duration
        dataMangerSO.allCallsDuration.Add(19);

        // All News in this list
        dataMangerSO.allNews.Add("Alia Singh Commits Suicide!!");
        dataMangerSO.allNews.Add("Bhushan Gayakwad stabbed to death");

        // All Event number after News
        dataMangerSO.afterNewsEvent.Add(1);
        dataMangerSO.afterNewsEvent.Add(201);
    }
}
