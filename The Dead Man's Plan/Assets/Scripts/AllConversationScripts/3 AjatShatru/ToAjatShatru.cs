using UnityEngine;

public class ToAjatShatru : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.botStatus = "Offline";
        charDataSO.historyNum = 0;
        charDataSO.botChatNum = 0;
        charDataSO.playerOptionsNum = 0;
        charDataSO.picListNum = 0;
        charDataSO.chatHistory.Clear();
        charDataSO.chatFromBot.Clear();
        charDataSO.optionsToPlayer.Clear();
        charDataSO.pictureList.Clear();
    }
    void Start()
    {
        //(Don't say anything)
        // #001
        // 1
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Who are you?");
        charDataSO.optionsToPlayer.Add("I don't know what you mean");
        charDataSO.optionsToPlayer.Add("What was that?");
        // 2
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("It was somehow exciting!");
        charDataSO.optionsToPlayer.Add("Are you a Hacker");
        charDataSO.optionsToPlayer.Add("That's illegal");
        // 3
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("That definitely illegal");
        charDataSO.optionsToPlayer.Add("Well... Thank you");
        // 4
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Phew");
        charDataSO.optionsToPlayer.Add("Or something horrible");
        charDataSO.optionsToPlayer.Add("Understood");
        // 5
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("Why don't you do it yourself");
        charDataSO.optionsToPlayer.Add("Nope");

        // #002
        // 6
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("What?");
        charDataSO.optionsToPlayer.Add("Do you ever speak clearly");
        charDataSO.optionsToPlayer.Add("Interesting?");
    }
}
