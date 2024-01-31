using UnityEngine;

public class AmrishxxVeena : MonoBehaviour
{
    [SerializeField] private T8ChatDataSO t8ChatDataSO;
    [SerializeField] private Sprite picture1, picture2, picture3;

    private void Awake()
    {
        t8ChatDataSO.BOTONE = "Veena";
        t8ChatDataSO.BOTTWO = "Amrish Chopra";
    }
    void Start()
    {// BOTONE, BOTTWO, PARTSTARTS, PARTENDS.
        t8ChatDataSO.historyNum = 0;
        t8ChatDataSO.chatNum = 0;
        t8ChatDataSO.picListNum = 0;
        t8ChatDataSO.chatHistory.Clear();
        t8ChatDataSO.chatFromBot.Clear();
        t8ChatDataSO.pictureList.Clear();

        // Pictures
        t8ChatDataSO.pictureList.Add(picture1);
        t8ChatDataSO.pictureList.Add(picture2);
        t8ChatDataSO.pictureList.Add(picture3);

        // #001
        t8ChatDataSO.chatFromBot.Add("PARTSTARTS");
        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Are you Veena Shastri");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Yes");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("I'm Inspector Amrish Chopra");
        t8ChatDataSO.chatFromBot.Add("and I have few questions for you");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Ok");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Do you recognise this hand writting?");
        t8ChatDataSO.chatFromBot.Add("PICTURE");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Yes, this is my father's diary, he likes to write poem");
        t8ChatDataSO.chatFromBot.Add("where do you find it?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("From your home, we just came from there.");
        t8ChatDataSO.chatFromBot.Add("It might sound strange, but in our investigation we found that your father is the prime suspect of a murder case");
        t8ChatDataSO.chatFromBot.Add("I know he is fighting life and death but he is our only lead");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Just look at my dad lying there unconsious, do you think he can kill somebody?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("I know kid, someone might be trying to frame your dad in murder that he didn't commit.");
        t8ChatDataSO.chatFromBot.Add("but I will need your help to prove his innocence");
        t8ChatDataSO.chatFromBot.Add("And you need to tell me everything about him");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("My father is a simple man living a very simple life, mom died when i was young.");
        t8ChatDataSO.chatFromBot.Add("He don't talk much about his work but I know he is a computer expert in some company.");
        t8ChatDataSO.chatFromBot.Add("He don'y have lot's of friends and enemies is completely out of quuestion.");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Does he drink?");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("No, he stayed away from cigrate & alcohol. Only think he ever liked was writing poem and chess");
        t8ChatDataSO.chatFromBot.Add("Now how can such a person can kill somebody?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Ok kid, I have to go for now but I might interrogate you in future");
        t8ChatDataSO.chatFromBot.Add("such is the job of a policeman");
        t8ChatDataSO.chatFromBot.Add("Take care!");


        // PartEnds
        t8ChatDataSO.chatFromBot.Add("PARTENDS");
        t8ChatDataSO.chatFromBot.Add("2");

        // #002



        //t8ChatDataSO.chatFromBot.Add("BOTTWO");
        //t8ChatDataSO.chatFromBot.Add("");

        //t8ChatDataSO.chatFromBot.Add("BOTONE");
        //t8ChatDataSO.chatFromBot.Add("");

    }
}
