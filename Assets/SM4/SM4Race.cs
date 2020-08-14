using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Race 
{
	// essential for pregnancy code
	public float fertility;
	public string raceName;		// if your race doesnt have and ID, then put the name here and raceID = 0
	public int raceID;          // index of the race of your character
								// 0 none, use this in case your race is not on the list
								// 1 Human, if you are reacding this, you probably are one. If not, pls contact me at mllhild@gmail.com.
								// 2 Elf, the JR Tolkien sexy type
								// 3 Fairy, think Tinker Bell, only that in this world they can use magic to change their size and a re huge sluts, so yeah, Tinker Bell
								// 4 Fae, general nature spiritis like Driad, Nymph, Mermaids and the like
								// 5 Dwarf, Bulky Alcoholic Midgits, google Diggy Diggy Hole
								// 6 Orc, hulking brute with pidgeon brain, also the elfs best friend
								// 7 Goblin, Feeble Midgits, more cunning than an orc, but still stupid. When crops are poor, farmers like to make soup out of them
								// 8 Golems, any far enought advanced tecnology is indistinguisheble from magic, so Robots, Droids and Holograms go here
								// 9 Catpeople, starting from the catgirls of Nekopara and up to any amount of fur you want
								// 10 Dogpeople, for all your floppy ear needs and eternal loyalty in exchange for headpads 
								// 11 Woldpeople, the edgy dogpeople, will fall just as quickly to a good belly rub
								// 12 Foxpeople, here because of the fox goddess, since there will be some
								// 14 Cowpeople, think Draph race from granblue fantasy
								// 15 Centaurs, because the one from Corruption of Champions was fun
								// 16 Undead, vampires, skeletons, the usual
								// 17 Monsters, all monster girls go in here, as well as any monsters
								// 18 Demonic, demons and fiends
								// 19 Divine, angels and gods
								// 20 Tentacles, the ultimate beings


	// not essential for the code to work
	public int averageBodySize;     // 0 Tiny, 1 Small, 2 Medium, 3 Large, 4 Huge
	public EyeType eyes;
	public EarType ears;
	public AppendageType legs;
	public AppendageType arms;
	public AppendageType wings;
	public int raceType;			//0 none, default 
									//1 Humanoid, //Including Elves, Orks, etc
								    //2 Bestial, //Including Tentacles, MLP, etc
								    //3 Undead, //Vampires, ghosts, etc
								    //4 Synthetic, //Including Androids, holograms, etc
								    //5 Alien //Non-terrestrial

}

public struct EarType
{
	public int shape;			// 0 round, 1 pointy
	public int size;			// 0 none, 1 small, 2 medium, 3 large
	public int lenght;			// 0 none, 1 short, 2 medium, 3 long
	public int texture;			// 0 fleshy, 1 furry, 2 scaley, 3 insect, 4 feathery
}

public struct AppendageType
{
	public int number;			// number of parts
	public int lenght;			// 0 short, 1 average, 2 long, 3 tentacles
	public int thickness;		// 0 slender, 1 average, 2 thick
	public int texture;			// 0 fleshy, 1 furry, 2 scaley, 3 insect, 4 feathery
}

public struct EyeType
{
	public int number;			// how many. 
	public int type;			// 0 humanlike, 1 insect
	public int pupilForm;		// -1 heartshape, 0 round, 1 vertical (cat), 2 horizontal (frog), 3 somthing else
	public int nightVision;		// 0 no, 1 low light vision, 2 always perfect vision
}