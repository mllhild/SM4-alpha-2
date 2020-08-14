using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SM4Character : Race
{

	public int ID;
	public string path;

	public string regionCurrent;
	public string regionLast;
	public string areaCurrent;
	public string areaLast;
	public string locationCurrent;
	public string locationLast;

	
	
	
    public CharacterName nameChar;
    public CharacterPronouns characterPronouns;
    public GeneralCharacter general;
    public Gender gender; // 0 none, 1 male, 2 female, 3 futa, others look sdk
    public Vitals vitals;
    public TextInserts text;
    public Stats stats;
    public SexSkills sexSkills;
    public Skills skills;

    public Viginity virginity;
    public TrainingTypes training;
    public Owner owner;

    public Parentclass father;
    public Parentclass mother;

	// public Dress dressCurrent = new Dress();
	// public Dress dressLast = new Dress(); 
	// public List<Dress> dresses = new List<Dress>();
 //    public List<Item> equipped = new List<Item>();
 //    public List<Item> inventory = new List<Item>();
 //    public List<ItemUsed> usedItems = new List<ItemUsed>();

	public int[] varInt = new int[100];
	public string[] varString = new string[100];
	public bool[] varBool = new bool[200];
	public List<int> listOfInt = new List<int>();
	public List<string> listOfString = new List<string>();
	public List<bool> listOfBool = new List<bool>();

	public int CurrentAge(int dateCurrent, int daysInAYear)
	{
		int age = (dateCurrent - general.birthday) / daysInAYear;
		general.age = age;
		return age;
	}
	public bool IsBirthday(int dateCurrent, int daysInAYear)
	{
		if( ((dateCurrent - general.birthday) % daysInAYear) == 0)
		{ return true; }
		else 
		{ return false; }
	}

	public void UpdateLocation(string newLocation)
	{
		locationLast = locationCurrent;
		locationCurrent = newLocation;
	}

}

public struct CharacterName
{				// example Magical Girl Miss Illya von Einzbern, 
	public string first;					// Illya
	public string middle;					// von
	public string last;						// Einzbern
	public string prefix;					// Miss
	public string title;					// Magicl Girl
	public string nickname;					// Kuros mana supply
	public string slavename;				// none, she isnt enslaved
	public string nameBorn;					// Illya von Einzbern (aka, she hasnt married)
}

public struct CharacterPronouns
{
	// multiple instances are for localization to other languages with multiple pronouns 
	// I will add them to the calling code in SM4EventExecute once there is demand

	public string I;
	public string heSheIt;
	public string hisherits;
	public string himherit;
	public string gender;
	
	public string I01;
	public string I02;

	public string heSheIt01;
	public string heSheIt02;
	public string heSheIt03;

	public string his01;
	public string his02;
	public string his03;
	public string his04;
	
	public string her01;
	public string her02;
	public string her03;
	public string her04;

	public string their01;
	public string their02;
	public string their03;
	public string their04;

	public string him01;
	public string him02;
	public string him03;
	public string him04;

	public string gender01;
	public string gender02;
	

}

public struct Gender
{
	public int current;
	public int last;
	public int born;
}

public struct BasicSize
{
	public float current;
	public float last;

}

public struct MediumSize
{
	public float min;
	public float max;
	public float start;
	public float last;
	public float current;
}

public struct StatBase
{
	public float min;
	public float max;
	public float start;
	public float last;
	public float current;
	public float modifier;
}
public struct SkillBase
{
	public int min;
	public int max;
	public int start;
	public int last;
	public int current;
	public int modifier;
	public float untilNextLevel;
}

public struct Cock
{
	public bool hasCock;
    public MediumSize size; 	// cock size , max 60cm
    public MediumSize grid;		// cock grid
    public float type;			// 0 human, 1 knotted, ...for human, feline, canine, equine
    public MediumSize typeVar;	// referes to a special size of the cock
    							// like knotsize, barbsizes, or whatever peculiarity the cock should have
}

public struct Cum
{
	public MediumSize volume;
	public float fertility;		// fertility 0 = 0%, 1 = 100%
}

public struct GeneralCharacter
{			// variables that dont have a place
	
	public bool sexActsOK; 		// are sex acts permitted via contract
	public int birthday;
	public int age;

	public string description;  // her short description "angry girl' etc

	public int goldEarned;
	public int goldOwned;
	
	public int badGirl;			// 0 she has not been bad, +1 for each bad action
	public int behaving;		// x > 0, she is obedient
								// raised by spanking. decreases each day
	public int loyalty;			// ?????
	public int attitude;		// 0 = normal, 1 = sexy, 2 = angry, 3 = heroine, 4 = scared, 5 = slut
	public int loveAccepted;	// -1 will never confess, 0 not confessed, 1 accepted confession, 2 refused confession outright, 3 asked for time to think

	public bool isNaked;		// is character wearing clothes
	public bool loli;			// is it a loli or shouta
	public int noble;			// 0 commoner, 1 minor noble, 2 noble, 3 major noble, 4 lord
}

public struct Vitals
{  			// all units are in kg(mass), cm(size) and ml(volume)
    // body demensions --------------------------------------------------------------
    public float height;
    public float weight;

    public MediumSize bust; 	// max 300cm
    public float underBustSize; 	// look up how BH sizes work if you dont get what this is for
    						  	// tldr: bust-underBustSize determites how large the breast are
    public MediumSize aurola;	// aurola size in cm
    public string cupSize;		// european cup sizes

    public Cock cock;			// cock variables
    public MediumSize testicles;// testicle size
    public Cum cum;		// cumvolume
    
    public MediumSize clit; 	// clit size, max 3cm
    
    public bool hasPussy;
    public MediumSize pussy; 	// depth of pussy
    public MediumSize pussyGrid;// how wide can the pussy strech
    
    public MediumSize waist; 
    public MediumSize throat; 	// depth of throat
    
    public string bloodType; 	// blood type A, B, O, AB, but you can insert anything
}

public struct TextInserts
{ 		// things to get for text inserts
	public string itHeShe;
	public string itHimHer;
	public string itsHisHer;
}

public struct Stats
{
	// A
		public StatBase agility;
	// B
		public StatBase blowjob; 		// Oral skills
	// C
		public StatBase charisma;		//
		public StatBase corruption;		// influences your dark magic power
		public StatBase constitution;	// 0 means dead
		public StatBase cooking;
		public StatBase cleaning;
		public StatBase conversation;	// 0 means unable to speak
	// D
		public StatBase dominance;
		public StatBase dexterity;
	// E
	// F
		public StatBase fuck; 			// Anal and Vaginal Skills
	// G
	// H
	// I
		public StatBase intelligence;	// decides your mana and learining capacity
	// J
		public StatBase joy;			// damages Mind if low
										// gives bonus to learning if high
	// K
	// L
		public StatBase libido;
		public StatBase love;			// love towards SlaveMaker
	// M 
		public StatBase mind;			// integrety of ones mind
										//decreases with trauma and low Joy. Constatn sex orgy hell, extreme bondadge, constantly locked in
										// has a daily regeneration + factor by Joy
										// if it hits 0 then mind break and regen stops
		public StatBase morality;		
	// N
		public StatBase nymphomania;	// slaanesh grants you bonus arousal damage
	// O
		public StatBase obedience;
	// P
	// Q
	// R
		public StatBase refinement;
		public StatBase reputation;
	// S
		public StatBase sensibility;
		public StatBase strenght;
		public StatBase submission;
	// T
		public StatBase temperament;
		public StatBase tiredness;
	// U
	// V
	// W
	// X
	// Y
	// Z
}

public struct SexSkills
{

	// A
		public StatBase anal;
	// B
		public StatBase blowjob;
		public StatBase bondage;
	// C
		public StatBase cumBath;
	// D
		public StatBase dildo;
	// E
	// F
		public StatBase fuck;
	// G
		public StatBase gangBang;
		public StatBase group;
	// H
	// I
	// J
	// K
		public StatBase kiss;
	// L
		public StatBase lendHer;
		public StatBase lesbian;
		public StatBase lick;
	// M 
		public StatBase masturbate;
	// N
		public StatBase naked;
	// O
	// P
		public StatBase plug;
	// Q
	// R
	// S
		public StatBase spank;
		public StatBase stripTease;
	// T
		public StatBase threesome;
		public StatBase titsFuck;
		public StatBase touch;
	// U
	// V
	// W
	// X
	// Y
	// Z
	// Num
		public StatBase act69;
}

public struct Skills
{
	public SkillBase dancing;
	public SkillBase singing;
	public SkillBase swimming;
	public SkillBase slaveTrainer;
	public SkillBase likesFemaleTrainer;
	public SkillBase likesMaleTrainer;
	public SkillBase likesFutaTrainer;
	public SkillBase ponySlaveTrainer;
	public SkillBase catSlaveTrainer;
	public SkillBase dogSlaveTrainer;
	public SkillBase cowSlaveTrainer;
	public SkillBase succubusTrainer;
	public SkillBase slutTrainer;
	public SkillBase fairyTrainer;

	public SkillBase leadership;
	public SkillBase trader;
	public SkillBase alchemy;
	public SkillBase mage;
	public SkillBase refined;
	public SkillBase noble;

}

public struct Viginity
{
	public bool vaginal;
	public bool oral;
	public bool anal;
	public bool cock;
}

public struct Training
{
	public bool trainable;			// can she be trained for this
	public bool isBeingTrained;		// is she being trained?
	public int resistance;			// how easy is it to train her
									// SMTrainerLevel has to be higher than her resistance to train her in it
									// 0 will always train, 3 high resistance, 4 never(dont use pls)
	public StatBase completion;		// from 0 to 100, how much of the training is complete
}

public struct TrainingTypes
{
	public Training likesFemale;
	public Training likesMale;
	public Training likesFuta;
	public Training ponySlave;
	public Training catSlave;
	public Training dogSlave;
	public Training cowSlave;
	public Training succubus;
	public Training slut;			// 60+ she is a slut, Nymphomania always 50+
	public Training fairy;		
	public Training courtesan;	
}

public struct Owner
{
	public bool isOwned;			// is the character owned?
	public bool testing;			//true = her owner will visit every 7 days and test her.
	public bool testingUrgent;		// owner comes when SM is at home the next time (morning or evening)
	public int ownerIDcurrent;		// who is the owner, preferebly the owner is added as a npc to the game
									// -1 for free person, 0 for unknown
	public int ownerIDprevious;
	public string ownerName;		// Owner name, for generic owners
	public string ownerPath;		// file path to images for generic owners

}

public struct Rules
{
	public bool talk;
	public bool fuck;
	public bool goOut;
	public bool touchThemself;
	public bool writeLetters;
	public bool poketMoney;
	public bool pray;
}

public struct CombatStats
{
	public CombatProficiency proficiency;
	public int weaponID;
	public CombatProficiency damage;
	public CombatProficiency resistance;
	public int fightsNumber;
	public int fightsVictory;
	public int fightsLosses;
	public int kills;
	public int exp;

}

public struct CombatProficiency
{
	public SkillBase sword;
	public SkillBase axe;
	public SkillBase spear;
	public SkillBase bow;
	public SkillBase magicIce;
	public SkillBase magicFire;
	public SkillBase magicThunder;
	public SkillBase magicLight;
	public SkillBase magicDark;
	public SkillBase armor;
	public SkillBase whip;
	public SkillBase unarmed;
	public SkillBase arousal;
}

public struct Parentclass
{
	public int ID;
	public int raceID;
	public CharacterName nameOf;
}