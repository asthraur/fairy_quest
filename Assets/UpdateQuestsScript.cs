using UnityEngine;
using TMPro;
using Yarn.Unity;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Rendering;

public class UpdateQuestsScript : MonoBehaviour
{
    private TMP_Text textComponent;
    private InMemoryVariableStorage variableStorage;
    private DialogueRunner dialogueRunner;

    private bool stableboyQuestAccepted;
    private bool princeQuestAccepted;
    private bool fishingFairyQuestAccepted;
    private bool rockFairyQuestAccepted;
    private bool stableboyBonusQuestAccepted;

    private bool stableboyQuestCompleted;
    private bool princeQuestCompleted;
    private bool fishingFairyQuestCompleted;
    private bool rockFairyQuestCompleted;
    private bool stableboyBonusQuestCompleted;

    private bool stableboyAcceptedOnce = false;
    private bool princeAcceptedOnce = false;
    private bool fishingFairyAcceptedOnce = false;
    private bool rockFairyAcceptedOnce = false;
    private bool stableboyBonusAcceptedOnce = false;

    void Start()
    {
        dialogueRunner = UnityEngine.Object.FindFirstObjectByType<DialogueRunner>();
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

        textComponent = gameObject.GetComponent<TMP_Text>();
        textComponent.text = "Slay the dragon \n";

        dialogueRunner.onDialogueComplete.AddListener(UpdateQuestText);
        
    }

    // Update is called once per frame
    void UpdateQuestText()
    {
        variableStorage.TryGetValue("$safa_quest_accepted", out stableboyQuestAccepted);
        variableStorage.TryGetValue("$ghanim_quest_accepted", out princeQuestAccepted);
        variableStorage.TryGetValue("$perch_quest_accepted", out fishingFairyQuestAccepted);
        variableStorage.TryGetValue("$bimb_quest_accepted", out rockFairyQuestAccepted);
        variableStorage.TryGetValue("$safa_bonus_accepted", out stableboyBonusQuestAccepted);

        variableStorage.TryGetValue("$safa_quest_completed", out stableboyQuestCompleted);
        variableStorage.TryGetValue("$ghanim_quest_completed", out princeQuestCompleted);
        variableStorage.TryGetValue("$perch_quest_completed", out fishingFairyQuestCompleted);
        variableStorage.TryGetValue("$bimb_quest_completed", out rockFairyQuestCompleted);
        variableStorage.TryGetValue("$safa_bonus_completed", out stableboyBonusQuestCompleted);

        if (stableboyQuestCompleted)
        {
            textComponent.text = textComponent.text.Replace("Return the cargo to Safa \n", "<s>Return the cargo to Safa</s> \n");
        }
        else if (princeQuestCompleted)
        {
            textComponent.text = textComponent.text.Replace("Break the spell on Aldieb, the talking horse \n", "<s>Break the spell on Aldieb, the talking horse</s>\n");
        }
        else if (fishingFairyQuestCompleted)
        {
            textComponent.text = textComponent.text.Replace("Find a bait for Perch \n", "<s>Find a bait for Perch</s> \n");
        }
        else if (rockFairyQuestCompleted)
        {
            textComponent.text = textComponent.text.Replace("Find Bimbs' rocks and bring them home \n", "<s>Find Bimbs' rocks and bring them home</s> \n");
        }


        else if (stableboyQuestAccepted &&!stableboyAcceptedOnce)
        {
            textComponent.text += "Return the cargo to Safa \n";
            stableboyAcceptedOnce = true;
        }
        else if (princeQuestAccepted && !princeAcceptedOnce)
        {
            textComponent.text += "Break the spell on Aldieb, the talking horse \n";
            princeAcceptedOnce = true;
        }
        else if (fishingFairyQuestAccepted && !fishingFairyAcceptedOnce)
        {
            textComponent.text += "Find a bait for Perch \n";
            fishingFairyAcceptedOnce = true;
        }
        else if (rockFairyQuestAccepted && !rockFairyAcceptedOnce)
        {
            textComponent.text += "Find Bimbs' rocks and bring them home \n";
            rockFairyAcceptedOnce = true;
        }
        


        if (stableboyBonusQuestCompleted)
        {
            textComponent.text = textComponent.text.Replace("Get Adones back on the road \n", "<s>Get Adones back on the road</s> \n");
        }
        else if (stableboyBonusQuestAccepted && !stableboyBonusAcceptedOnce)
        {
            textComponent.text += "Get Adones back on the road \n";
            stableboyBonusAcceptedOnce = true;
        }
    }
}
