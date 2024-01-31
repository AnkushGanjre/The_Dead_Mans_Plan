using UnityEngine;

public class ToAmrishChopra : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;
    [SerializeField] private Sprite picture1, picture2, picture3;

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
        charDataSO.pictureList.Add(picture1);
        // #001
        //1
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Hello");
        charDataSO.optionsToPlayer.Add("Hi Inspector");
        charDataSO.optionsToPlayer.Add("I was Expecting you");
        //2
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("OK");
        charDataSO.optionsToPlayer.Add("EMOJI5");
        charDataSO.optionsToPlayer.Add("Tell me everything");
        //3
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Hmm interesting");
        charDataSO.optionsToPlayer.Add("It can be a cover");
        charDataSO.optionsToPlayer.Add("Did you see him yourself");
        //4
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("We will need more details");
        charDataSO.optionsToPlayer.Add("Err.. can't say");

        // #002
        //5
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Yes I'm");
        charDataSO.optionsToPlayer.Add("EMOJI4");
        charDataSO.optionsToPlayer.Add("For you anytime!");
        //6
        charDataSO.optionsToPlayer.Add("2");
        charDataSO.optionsToPlayer.Add("No it's definitely murder");
        charDataSO.optionsToPlayer.Add("Yeah it's possibly suicide");
        //7
        charDataSO.optionsToPlayer.Add("3");
        charDataSO.optionsToPlayer.Add("Yeah");
        charDataSO.optionsToPlayer.Add("EMOJI5");
        charDataSO.optionsToPlayer.Add("Definitely");
    }
}
