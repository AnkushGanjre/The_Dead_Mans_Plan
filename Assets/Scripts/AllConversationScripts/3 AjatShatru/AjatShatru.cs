using UnityEngine;

public class AjatShatru : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.BOTONE = "???";
    }

    void Start()
    {
        // BOTONE, PLAYER, PLAYER2, PICTURE, ERASING, SKIPLINES, SKIPOPTIONS, PARTSTARTS, PARTENDS.
        // EMOJI1, EMOJI2, EMOJI3, EMOJI4, EMOJI5.

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

        // #001
        charDataSO.chatFromBot.Add("PARTSTARTS");
        charDataSO.chatFromBot.Add("BOTONE");
        charDataSO.chatFromBot.Add("Did you like it?");

        //1 --3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("A friend you can say");
        charDataSO.chatFromBot.Add("Did you like it");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("8");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("The conversation between Doctor & Inspector");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("5");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("A private conversation");

        charDataSO.chatFromBot.Add("The conversation between Doctor & Inspector");
        charDataSO.chatFromBot.Add("I made that possible for you. Thanks to me you could read along");

        //2 --3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Yeah it is");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("You are free to call me anything");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Maybe");

        charDataSO.chatFromBot.Add("Now that you have become a part of this case");
        charDataSO.chatFromBot.Add("It is important taht you know things the other's don't");
        charDataSO.chatFromBot.Add("I will grant you access to everybody's messages");
        charDataSO.chatFromBot.Add("and you should be able to access their data");

        //3 --2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Only if you don't tell the police");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("You're welcome");

        charDataSO.chatFromBot.Add("And be careful");
        charDataSO.chatFromBot.Add("I don't know what you're going to come across. Be prepared for the worst.");
        charDataSO.chatFromBot.Add("But chances are you'll find Something useful");

        //4 --3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Is there anything you want to ask?");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("you never know");
        charDataSO.chatFromBot.Add("Is there anything you want to ask?");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("3");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Is there anything you want to ask?");

        //5 --2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("I can't do everything at once. But If you think I sit around and twiddle my thumbs I can calm you down. I follow other tracks.");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("ok Good");

        charDataSO.chatFromBot.Add("We are running out of time");
        charDataSO.chatFromBot.Add("and only for safety's sake");
        charDataSO.chatFromBot.Add("all this is between you & me");
        charDataSO.chatFromBot.Add("don't tell anyone");
        charDataSO.chatFromBot.Add("I'm serious");

        //PartEnds
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("1");



        // #002
        charDataSO.chatFromBot.Add("PARTSTARTS");
        charDataSO.chatFromBot.Add("BOTONE");
        charDataSO.chatFromBot.Add("Hmmm");
        charDataSO.chatFromBot.Add("Interesting");

        //6 --3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Don't you saw what happened");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("you never know");
        charDataSO.chatFromBot.Add("Don't you saw what happened");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("3");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Don't you saw what happened");

        charDataSO.chatFromBot.Add("Either Veena is brilliant actor or she is truly innocent");
        charDataSO.chatFromBot.Add("But either way this case is really simple");
        charDataSO.chatFromBot.Add("Or hard to break CHAKRAYUH, only time will tell");
        
        //PartEnds
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("302");


        // #003
        //charDataSO.chatFromBot.Add("");
    }
}
