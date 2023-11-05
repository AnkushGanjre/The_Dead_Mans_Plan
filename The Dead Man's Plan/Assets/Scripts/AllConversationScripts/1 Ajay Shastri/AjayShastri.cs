using UnityEngine;

public class AjayShastri : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.BOTONE = "Ajay Shastri";
    }
    void Start()
    {
        // BOTONE, PLAYER, PLAYER2, PICTURE, ERASING, SKIPLINES, SKIPOPTIONS, PARTSTARTS, PARTENDS.
        // EMOJI1, EMOJI2, EMOJI3, EMOJI4, EMOJI5.

        //charDataSO.chatFromBot.Add("");

        //charDataSO.chatFromBot.Add("PLAYER");
        //charDataSO.chatFromBot.Add("BOTONE");     // option1 will read this line
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("SKIPLINE");
        //charDataSO.chatFromBot.Add("14");
        //charDataSO.chatFromBot.Add("BOTONE");     // option2 will read this line
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("SKIPLINE");
        //charDataSO.chatFromBot.Add("9");
        //charDataSO.chatFromBot.Add("BOTONE");     // option3 will read this line
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("SKIPLINE");
        //charDataSO.chatFromBot.Add("4");
        //charDataSO.chatFromBot.Add("BOTONE");     // option4 will read this line
        //charDataSO.chatFromBot.Add("---");
        //charDataSO.chatFromBot.Add("---");


        charDataSO.chatFromBot.Add("PARTSTARTS");
        charDataSO.chatFromBot.Add("BOTONE");
        charDataSO.chatFromBot.Add("Hello KHOJEE");
        charDataSO.chatFromBot.Add("If you are reading this message then it means I'm already dead");

        //charDataSO.chatFromBot.Add("PARTENDS");
        //charDataSO.chatFromBot.Add("301");

        //1 --3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Hello");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("Maybe, I'm not sure");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("I'll explain everything");

        charDataSO.chatFromBot.Add("I'm Ajay Shastri, you don't know me but you will soon");
        charDataSO.chatFromBot.Add("I have something important to tell you");
        charDataSO.chatFromBot.Add("This city is going to witness a series of murder, starting with my own");
        charDataSO.chatFromBot.Add("If you are one of the unlucky one, only time will tell");

        //2 --4 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("something even more scary is that");
        charDataSO.chatFromBot.Add("It's me who is going to kill all this people");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("14");
        charDataSO.chatFromBot.Add("SKIPLINE"); // option2 will read this line
        charDataSO.chatFromBot.Add("12");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Yes & it's me");
        charDataSO.chatFromBot.Add("Who is going to kill all this people");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("SKIPLINE"); // option4 will read this line
        charDataSO.chatFromBot.Add("2");
        charDataSO.chatFromBot.Add("---");

        charDataSO.chatFromBot.Add("I have created a CHAKRAVYUH where no one can escape");
        charDataSO.chatFromBot.Add("& the people I choose to kill will die, even after my death");
        charDataSO.chatFromBot.Add("And there is no way to stop this DEAD MAN'S PLAN");

        //3 --2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Not exactly");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("certainly, but");

        charDataSO.chatFromBot.Add("It take an extraordinary person to breach a CHAKRAVYUH");
        charDataSO.chatFromBot.Add("but the question is, are you the ARJUN of my CHAKRAVYUH?");
        charDataSO.chatFromBot.Add("can you complete against a dead man who have already played his move?");
        charDataSO.chatFromBot.Add("Are you ready to play a game where your life depends on it?");
        charDataSO.chatFromBot.Add("Can you solve the mystery before it's too late?");

        //4 --2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("The Game is on!!!");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("The Game is on!!!");
        //PartEnds
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("301");
    }
}
