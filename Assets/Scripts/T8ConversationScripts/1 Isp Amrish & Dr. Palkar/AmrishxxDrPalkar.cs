using UnityEngine;

public class AmrishxxDrPalkar : MonoBehaviour
{
    [SerializeField] private T8ChatDataSO t8ChatDataSO;
    [SerializeField] private Sprite picture1, picture2, picture3;

    private void Awake()
    {
        t8ChatDataSO.BOTONE = "Dr. Palkar";
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
        t8ChatDataSO.chatFromBot.Add("Hello Doctor");
        t8ChatDataSO.chatFromBot.Add("I'm Inspector Amrish Chopra");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Yes inspector");
        t8ChatDataSO.chatFromBot.Add("How can I help you");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("I need some information about one of your patient");
        t8ChatDataSO.chatFromBot.Add("AJAY SHASTRI");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Yes, what about him?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("I need to know what happened to him");
        t8ChatDataSO.chatFromBot.Add("& what is his current condition?");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("He tried to commit suicide, we have already told every thing to police");
        t8ChatDataSO.chatFromBot.Add("But I will tell you again if you want to know");
        t8ChatDataSO.chatFromBot.Add("When he came his condtion was critical but we managed to stabilize his condition");
        t8ChatDataSO.chatFromBot.Add("since then he never gained concious");
        t8ChatDataSO.chatFromBot.Add("As his doctor we are trying our best");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Are you 100% sure he never gained consious because I think he went out of hospital");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Sorry to disappoint you but it's not possible");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Or someone helped him sneak out like an old friend?");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("I think I told you everything regarding Ajay Shastri & I have to go, I have patient to see. ");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Wait a sec!!!");
        t8ChatDataSO.chatFromBot.Add("Maybe you forgot to tell me that Ajay Shatri is your friend");
        t8ChatDataSO.chatFromBot.Add("Isn't it correct Dr. Palkar");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Yes, Ajay Shastri is my friend & under his condition no one help him even if his friend is a doctor.");
        t8ChatDataSO.chatFromBot.Add("And what did he do? that you want to investigate?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("Your dear friend is our prime suspect in aila singh murder case!!!");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("what?");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("One more disturbing fact, Ajay Shastri killed Alia after he was admitted to your hospital");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("It's impossible!");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("I know, but what if Ajay Shastri is just acting of being unconsious and his doctor friend help him, then this whole thing become possible.");
        t8ChatDataSO.chatFromBot.Add("Isn't it Doctor?");

        t8ChatDataSO.chatFromBot.Add("BOTONE");
        t8ChatDataSO.chatFromBot.Add("Are you accusing me??");

        t8ChatDataSO.chatFromBot.Add("BOTTWO");
        t8ChatDataSO.chatFromBot.Add("No consider it as a warning, bring Ajay Shatri to consious");
        t8ChatDataSO.chatFromBot.Add("If he really is unconsious, only he can answer my questions");
        t8ChatDataSO.chatFromBot.Add("For now I think I got everything I need to know ");
        t8ChatDataSO.chatFromBot.Add("and I will see you soon, Doctor");


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
