using UnityEngine;

public class AmrishChopra : MonoBehaviour
{
    [SerializeField] private CharChatDataSO charDataSO;

    private void Awake()
    {
        charDataSO.BOTONE = "Amrish Chopra";
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
        charDataSO.chatFromBot.Add("Hey there KHOJEE, remember me?");
        charDataSO.chatFromBot.Add("Inspector Amrish Chopra, I need your help!!");
        charDataSO.chatFromBot.Add("Again");

        //1 -3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Did you heard about Alia Singh Suicide case");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("11");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("Did you heard about Alia Singh Suicide case");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("6");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Huh!!");
        charDataSO.chatFromBot.Add("Expecting me? Anyway");

        charDataSO.chatFromBot.Add("Did you heard about Alia Singh Suicide case");
        charDataSO.chatFromBot.Add("I need your help in that case");

        //2 -3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("So Alia Singh commits Suicide &");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("10");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("So Alia Singh Commits Suicide &");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("5");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Sure");
        charDataSO.chatFromBot.Add("So Alia singh Commits Suicide &");

        charDataSO.chatFromBot.Add("There is this man Ajay Shastri");
        charDataSO.chatFromBot.Add("who is claiming that he killed her");
        charDataSO.chatFromBot.Add("And here comes the good part");
        charDataSO.chatFromBot.Add("At the time of Alia's death Ajay was in hospital, unconscious");
        charDataSO.chatFromBot.Add("He commited suicide 2 days ago");

        //3 - 3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Yeah it is!!");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("10");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("Yeah");
        charDataSO.chatFromBot.Add("it can be");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Not yet");
        charDataSO.chatFromBot.Add("I will be visiting the hospital later today");

        charDataSO.chatFromBot.Add("Actually, I should tell you from starting");
        charDataSO.chatFromBot.Add("Alia is the daughter of famous industrialist Nirmal Singh");
        charDataSO.chatFromBot.Add("Out of nowhere she commits suicide");
        charDataSO.chatFromBot.Add("Next day we receive a letter from Ajay Shastri");
        charDataSO.chatFromBot.Add("Actually you should see for yourself");
        charDataSO.chatFromBot.Add("Wait!!");

        charDataSO.chatFromBot.Add("PICTURE");

        charDataSO.chatFromBot.Add("What do you think??");

        //4 - 2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Yeah");
        charDataSO.chatFromBot.Add("you are right");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("Yeah");
        charDataSO.chatFromBot.Add("We lack evidences");

        charDataSO.chatFromBot.Add("I should visit hospital ASAP and talk with his doctor");
        charDataSO.chatFromBot.Add("I will come back with more details");
        charDataSO.chatFromBot.Add("Later KHOJEE");

        // PartEnds
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("101");



        // #002
        charDataSO.chatFromBot.Add("PARTSTARTS");
        charDataSO.chatFromBot.Add("BOTONE");
        charDataSO.chatFromBot.Add("Are you there");

        //5 - 3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Ok, I have update");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("9");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("Ok, I have update");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("4");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("BOTONE"); // option3 will read this line
        charDataSO.chatFromBot.Add("Ok, I have update");

        charDataSO.chatFromBot.Add("Ajay Shastri is not at all in a condition to move fromthe bed");
        charDataSO.chatFromBot.Add("and I don't think he did it");
        charDataSO.chatFromBot.Add("someone might be trying to frame him");
        charDataSO.chatFromBot.Add("Alia Singh wasn't murdered, she did commited suicide");
        charDataSO.chatFromBot.Add("And this was just a joke on police");

        //6 - 2 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("BOTONE"); // option1 will read this line
        charDataSO.chatFromBot.Add("Can't say for sure");
        charDataSO.chatFromBot.Add("We need more details");
        charDataSO.chatFromBot.Add("SKIPLINE");
        charDataSO.chatFromBot.Add("3");
        charDataSO.chatFromBot.Add("BOTONE"); // option2 will read this line
        charDataSO.chatFromBot.Add("We need more details");

        charDataSO.chatFromBot.Add("Well Ajay Shastri have a daughter Veena");
        charDataSO.chatFromBot.Add("I think I should talk to her, maybe I will get something useful");

        //7 - 3 options
        charDataSO.chatFromBot.Add("PLAYER");
        charDataSO.chatFromBot.Add("SKIPLINE"); // option1 will read this line
        charDataSO.chatFromBot.Add("11");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("SKIPLINE"); // option2 will read this line
        charDataSO.chatFromBot.Add("6");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("---");
        charDataSO.chatFromBot.Add("SKIPLINE"); // option3 will read this line
        charDataSO.chatFromBot.Add("1");

        // PartsEnds
        charDataSO.chatFromBot.Add("PARTENDS");
        charDataSO.chatFromBot.Add("102");
    }
}
