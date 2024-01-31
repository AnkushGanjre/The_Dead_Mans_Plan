using UnityEngine;

public class GroupChat : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.BOTONE = "Ajay Shastri";
        charDataSO.BOTTWO = "Amrish Chopra";
        charDataSO.BOTTHIRD = "Dr. Palkar";
        charDataSO.BOTFOUR = "Rana";
    }
    private void Start()
    {
        charDataSO.chatFromBot.Add("PARTSTARTS");
        charDataSO.chatFromBot.Add("BOTONE");
        charDataSO.chatFromBot.Add("Hello?");
        charDataSO.chatFromBot.Add("I'm Ajay Shastri");

        charDataSO.chatFromBot.Add("BOTTWO");
        charDataSO.chatFromBot.Add("Hello?");
        charDataSO.chatFromBot.Add("I'm Amrish Chopra");

        charDataSO.chatFromBot.Add("BOTTHIRD");
        charDataSO.chatFromBot.Add("Hello?");
        charDataSO.chatFromBot.Add("I'm Dr. Palkar");

        charDataSO.chatFromBot.Add("BOTFOUR");
        charDataSO.chatFromBot.Add("Hello?");
        charDataSO.chatFromBot.Add("I'm Rana");

        //1
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Uh");
        charDataSO.chatFromBot.Add("Hello");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("I'm not sure");
        charDataSO.chatFromBot.Add("Well");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Ah, good");
        charDataSO.chatFromBot.Add("Hello");

        charDataSO.chatFromBot.Add("Ready to receive Phone Call");
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("201");
    }

}
