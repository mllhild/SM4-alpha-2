using System.Collections.Generic;

public class SM4Slave : SM4Character
{
    private float _slaveXMLFileStructuretype;
    public int slaveID;
    public string slaveName;
    
	public int trainingStartDate;		// date she started training
	public int trainingTime;			// days to train her
	public npcAstrid astrid;
	public GeneralSlave generalSlave;
	public Dating dating;

	// this should be read from an xml later on
	public List<PlanningAct> jobs = new List<PlanningAct>();
	public List<PlanningAct> chores = new List<PlanningAct>();
	public List<PlanningAct> schools = new List<PlanningAct>();
	public List<PlanningAct> misc = new List<PlanningAct>();
	public List<PlanningAct> sexNormal = new List<PlanningAct>();
	public List<PlanningAct> sexExtreme = new List<PlanningAct>();

	public NobleLoveEvent noble;

	public List<Visit> visits = new List<Visit>();

	// to check if slave is aviable for training
	public int slaveCategory;			// for purpuse of which to show, no idea yet
	public int minReputation;			// min reputation for the owner to let you train the slave
	public bool showInSlaveMarket;		// can seen in the slaveMarket
	public bool canBeBought;			// slave can be bought
	public float slavePrice;			// flat market price of slave
	public bool aviableForTraining;		// can be trained
	public bool contractOnly;			// slave has a specific contract


}
public struct GeneralSlave
{
	public int prostituteParty; 		// number of this party visited
	public int highclassParty;
	public bool callsYouMaster;			// does slave call you master? 
}

public struct npcAstrid
{
	public float chanceToMeet;			// % chance to meet Astrid in the woods
	public int futaAstrid;				// -1 will never be a futa, 0 female, 1 permanent futa, 2 permanent futa and refused to be cured
	public float futaChance;				// chance slave will grow a random cock
}


public class PlanningAct
{  // to be read from an xmlfile
	public int countStart;
	public int countCurrent;
	public string actName;
	public int actEventnumber;		// event that triggers when pressing button
									// buttons wont have the event number internally
									// as its now during development
	public bool actActive;			// show buttom
	public int timeOpen;			// from when 
	public int timeClose;			// to when is it possible to do the act
	public int duration;			// how long does the act take 1 to 4 hours
}

public struct Dating
{
	public int dating; 				// 0 not dating, 1 dating(fucking), -1 will not date
	public int loverGender;			// 
	public int loverRelativeAge;	// -1 younger, 0 same age, +1 older
}
public struct NobleLoveEvent
{
	public int nobleID;				// noble who can fall in love with her
	public float nobleLove;			// love of the noble for the slave
	public int state;				// -2 sold to noble, -1 refused to sell, 0 visiting 
}

public class Visit
{
	public int visitID;
	public int visitName;
	public int eventNumber;
	public bool showButton;
	public bool canVisit;
	public int visitAttemps;
	public int visitsSuccess;
}