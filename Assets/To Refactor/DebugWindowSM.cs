using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebugWindowSM : MonoBehaviour
{ /*
    public GameObject imputfieldPrefab;
    public CharacterControlScrips cc;
    public int[] intArray;
    public List<GameObject> fields01 = new List<GameObject>();
    public GameObject smField01;
    public GameObject smField02;
    public GameObject smField03;
    public GameObject smField04;
    public GameObject smField05;
    public GameObject smField06;
    public GameObject smField07;
    public GameObject smField08;
    public GameObject smField09;
    public GameObject smField10;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        //text.text = cc.sm.ToString();
        //Debug.Log(cc.sm.ToString());
        SlaveMakerOnly();
        SlaveOnly();
        CharacterOnly();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void UpdateVariablesDisplayed()
    //{
    //    fields01 = new List<GameObject>();
    //    if(fields01.Count > 0)
    //    {
    //        int var01 = 0;
    //        foreach(GameObject field in fields01)
    //        {
    //            Destroy(fields01[var01].gameObject);
    //            var01++;
    //        }
    //        fields01.Clear();
    //    }


        //foreach(int i in intArray)
        //{
        //    GameObject inputfield = Instantiate(imputfieldPrefab) as GameObject;
        //    inputfield.SetActive(true);
        //    inputfield.GetComponent<DebugGridImputfield>().varName.text = "varName.text";
        //    inputfield.GetComponent<DebugGridImputfield>().input.text = "input.text";
        //    inputfield.transform.SetParent(smField01.transform.parent, false);
        //}
    //}
    public void AddNewField(string label, string input, GameObject fieldToAddTo)
    {
        GameObject inputfield = Instantiate(imputfieldPrefab) as GameObject;
        inputfield.SetActive(true);
        inputfield.GetComponent<DebugGridImputfield>().varName.text = label;
        inputfield.GetComponent<DebugGridImputfield>().input.text = input;
        inputfield.transform.SetParent(fieldToAddTo.transform.parent, false);
    }
    public void SlaveMakerOnly()
    {
        // Field 1
        AddNewField("Slaves trained", cc.sm.products.trained.ToString(), smField01);

        AddNewField("Slaves sold", cc.sm.products.sold.ToString(), smField01);
        AddNewField("Slaves kept", cc.sm.products.kept.ToString(), smField01);
        AddNewField("Slaves bought", cc.sm.products.bought.ToString(), smField01);
        AddNewField("Slaves lost", cc.sm.products.lost.ToString(), smField01);
        AddNewField("Slaves escaped", cc.sm.products.escaped.ToString(), smField01);
        AddNewField("Slaves kidnapped", cc.sm.products.kidnapped.ToString(), smField01);
        AddNewField("Slaves died", cc.sm.products.died.ToString(), smField01);

        // Field 2
        AddNewField("Supervise", cc.sm.generalSM.supervise.ToString(), smField01);
        AddNewField("MasterMistress", cc.sm.generalSM.masterMistress, smField01);

        // Field 03 SlaveMaker acts 1
        // Field 04 SlaveMaker acts 2
    }

    public void SlaveOnly()
    {
        AddNewField("trainingStartDate", cc.sm.trainingStartDate.ToString(), smField02);
        AddNewField("trainingTime", cc.sm.trainingTime.ToString(), smField02);
        AddNewField("slaveCategory", cc.sm.slaveCategory.ToString(), smField02);
        AddNewField("minReputation", cc.sm.minReputation.ToString(), smField02);
        AddNewField("showInSlaveMarket", cc.sm.showInSlaveMarket.ToString(), smField02);
        AddNewField("canBeBought", cc.sm.canBeBought.ToString(), smField02);
        AddNewField("slavePrice", cc.sm.slavePrice.ToString(), smField02);
        AddNewField("aviableForTraining", cc.sm.aviableForTraining.ToString(), smField02);
        AddNewField("contractOnly", cc.sm.contractOnly.ToString(), smField02);

        AddNewField("astrid.chanceToMeet", cc.sm.astrid.chanceToMeet.ToString(), smField02);
        AddNewField("astrid.futaAstrid", cc.sm.astrid.futaAstrid.ToString(), smField02);
        AddNewField("astrid.futaChance", cc.sm.astrid.futaChance.ToString(), smField02);

        AddNewField("prostituteParty", cc.sm.generalSlave.prostituteParty.ToString(), smField02);
        AddNewField("highclassParty", cc.sm.generalSlave.highclassParty.ToString(), smField02);
        AddNewField("callsYouMaster", cc.sm.generalSlave.callsYouMaster.ToString(), smField02);

        AddNewField("dating", cc.sm.dating.dating.ToString(), smField02);
        AddNewField("loverGender", cc.sm.dating.loverGender.ToString(), smField02);
        AddNewField("loverRelativeAge", cc.sm.dating.loverRelativeAge.ToString(), smField02);

        AddNewField("nobleID", cc.sm.noble.nobleID.ToString(), smField02);
        AddNewField("nobleLove", cc.sm.noble.nobleLove.ToString(), smField02);
        AddNewField("noble.state", cc.sm.noble.state.ToString(), smField02);

        // Field 06 Planning Acts 
        // Field 07 Visit lists 

    }
    public void CharacterOnly()
    {
        // ID
        AddNewField("ID", cc.sm.ID.ToString(), smField03);
        AddNewField("path", cc.sm.path, smField03);
        
        // Name
        AddNewField("nameChar.first", cc.sm.nameChar.first, smField03);
        AddNewField("nameChar.middle", cc.sm.nameChar.middle, smField03);
        AddNewField("nameChar.last", cc.sm.nameChar.last, smField03);
        AddNewField("nameChar.prefix", cc.sm.nameChar.prefix, smField03);
        AddNewField("nameChar.nameBorn", cc.sm.nameChar.nameBorn, smField03);
        AddNewField("nameChar.nickname", cc.sm.nameChar.nickname, smField03);
        AddNewField("sm.nameChar.slavename", cc.sm.nameChar.slavename, smField03);
        AddNewField("sm.nameChar.title", cc.sm.nameChar.title, smField03);

        // General
        AddNewField("general.age", cc.sm.general.age.ToString(), smField03);
        AddNewField("general.attitude", cc.sm.general.attitude.ToString(), smField03);
        AddNewField("general.badGirl", cc.sm.general.badGirl.ToString(), smField03);
        AddNewField("general.behaving", cc.sm.general.behaving.ToString(), smField03);
        AddNewField("general.birthday", cc.sm.general.birthday.ToString(), smField03);
        AddNewField("general.description", cc.sm.general.description, smField03);
        AddNewField("general.goldEarned", cc.sm.general.goldEarned.ToString(), smField03);
        AddNewField("general.goldOwned", cc.sm.general.goldOwned.ToString(), smField03);
        AddNewField("general.isNaked", cc.sm.general.isNaked.ToString(), smField03);
        AddNewField("general.loli", cc.sm.general.loli.ToString(), smField03);
        AddNewField("general.loveAccepted", cc.sm.general.loveAccepted.ToString(), smField03);
        AddNewField("general.loyalty", cc.sm.general.loyalty.ToString(), smField03);
        AddNewField("general.noble", cc.sm.general.noble.ToString(), smField03);
        AddNewField("general.sexActsOK", cc.sm.general.sexActsOK.ToString(), smField03);

        // Gender
        AddNewField("gender.born", cc.sm.gender.born.ToString(), smField03);
        AddNewField("gender.current", cc.sm.gender.current.ToString(), smField03);
        AddNewField("gender.last", cc.sm.gender.last.ToString(), smField03);

        // Vitals
        // insert here

        // Textinserts
        AddNewField("text.itHeShe", cc.sm.text.itHeShe, smField03);
        AddNewField("text.itHimHer", cc.sm.text.itHimHer, smField03);
        AddNewField("text.itsHisHer", cc.sm.text.itsHisHer, smField03);

        // Virginity
        AddNewField("virginity.anal", cc.sm.virginity.anal.ToString(), smField03);
        AddNewField("virginity.vaginal", cc.sm.virginity.vaginal.ToString(), smField03);
        AddNewField("virginity.oral", cc.sm.virginity.oral.ToString(), smField03);
        AddNewField("virginity.cock", cc.sm.virginity.cock.ToString(), smField03);

        // Owner
        AddNewField("owner.isOwned", cc.sm.owner.isOwned.ToString(), smField03);
        AddNewField("owner.ownerIDcurrent", cc.sm.owner.ownerIDcurrent.ToString(), smField03);
        AddNewField("owner.ownerIDprevious", cc.sm.owner.ownerIDprevious.ToString(), smField03);
        AddNewField("owner.ownerName", cc.sm.owner.ownerName, smField03);
        AddNewField("owner.ownerPath", cc.sm.owner.ownerPath, smField03);
        AddNewField("owner.testing", cc.sm.owner.testing.ToString(), smField03);
        AddNewField("owner.testingUrgent", cc.sm.owner.testingUrgent.ToString(), smField03);

        // Parents
        AddNewField("father.ID", cc.sm.father.ID.ToString(), smField03);
        AddNewField("father.raceID", cc.sm.father.raceID.ToString(), smField03);
        AddNewField("mother.ID", cc.sm.mother.ID.ToString(), smField03);
        AddNewField("mother.raceID", cc.sm.mother.raceID.ToString(), smField03);

        // Dress Current
        AddNewField("ID", cc.sm.dressCurrent.ID.ToString(), smField04);
        AddNewField("alive", cc.sm.dressCurrent.alive.ToString(), smField04);
        AddNewField("bdsm", cc.sm.dressCurrent.bdsm.ToString(), smField04);
        AddNewField("consumable", cc.sm.dressCurrent.consumable.ToString(), smField04);
        AddNewField("courtly", cc.sm.dressCurrent.courtly.ToString(), smField04);
        AddNewField("craftingIngredient", cc.sm.dressCurrent.craftingIngredient.ToString(), smField04);
        AddNewField("demonic", cc.sm.dressCurrent.demonic.ToString(), smField04);
        AddNewField("equippable", cc.sm.dressCurrent.equippable.ToString(), smField04);
        AddNewField("holy", cc.sm.dressCurrent.holy.ToString(), smField04);
        AddNewField("isBeingWorn", cc.sm.dressCurrent.isBeingWorn.ToString(), smField04);
        AddNewField("itemName", cc.sm.dressCurrent.itemName, smField04);
        AddNewField("lingery", cc.sm.dressCurrent.lingery.ToString(), smField04);
        AddNewField("loreLong", cc.sm.dressCurrent.loreLong, smField04);
        AddNewField("loreShort", cc.sm.dressCurrent.loreShort, smField04);
        AddNewField("maid", cc.sm.dressCurrent.maid.ToString(), smField04);
        AddNewField("numberOfUses", cc.sm.dressCurrent.numberOfUses.ToString(), smField04);
        AddNewField("path", cc.sm.dressCurrent.path, smField04);
        AddNewField("quantity", cc.sm.dressCurrent.quantity.ToString(), smField04);
        AddNewField("slutty", cc.sm.dressCurrent.slutty.ToString(), smField04);
        AddNewField("swimsuit", cc.sm.dressCurrent.swimsuit.ToString(), smField04);
        AddNewField("value", cc.sm.dressCurrent.value.ToString(), smField04);
        AddNewField("valueBase", cc.sm.dressCurrent.valueBase.ToString(), smField04);

        // Dress Last
        AddNewField("ID", cc.sm.dressLast.ID.ToString(), smField10);
        AddNewField("alive", cc.sm.dressLast.alive.ToString(), smField10);
        AddNewField("bdsm", cc.sm.dressLast.bdsm.ToString(), smField10);
        AddNewField("consumable", cc.sm.dressLast.consumable.ToString(), smField10);
        AddNewField("courtly", cc.sm.dressLast.courtly.ToString(), smField10);
        AddNewField("craftingIngredient", cc.sm.dressLast.craftingIngredient.ToString(), smField10);
        AddNewField("demonic", cc.sm.dressLast.demonic.ToString(), smField10);
        AddNewField("equippable", cc.sm.dressLast.equippable.ToString(), smField10);
        AddNewField("holy", cc.sm.dressLast.holy.ToString(), smField10);
        AddNewField("isBeingWorn", cc.sm.dressLast.isBeingWorn.ToString(), smField10);
        AddNewField("itemName", cc.sm.dressLast.itemName, smField10);
        AddNewField("lingery", cc.sm.dressLast.lingery.ToString(), smField10);
        AddNewField("loreLong", cc.sm.dressLast.loreLong, smField10);
        AddNewField("loreShort", cc.sm.dressLast.loreShort, smField10);
        AddNewField("maid", cc.sm.dressLast.maid.ToString(), smField10);
        AddNewField("numberOfUses", cc.sm.dressLast.numberOfUses.ToString(), smField10);
        AddNewField("path", cc.sm.dressLast.path, smField10);
        AddNewField("quantity", cc.sm.dressLast.quantity.ToString(), smField10);
        AddNewField("slutty", cc.sm.dressLast.slutty.ToString(), smField10);
        AddNewField("swimsuit", cc.sm.dressLast.swimsuit.ToString(), smField10);
        AddNewField("value", cc.sm.dressLast.value.ToString(), smField10);
        AddNewField("valueBase", cc.sm.dressLast.valueBase.ToString(), smField10);


        // Dresses
        // Equipped
        // inventory
        // usedItems
        // list of Int
        // list of String
        // list of Bool

    }

    public void RaceOnly()
    {

    }
    
    */

}
