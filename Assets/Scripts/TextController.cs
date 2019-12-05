using UnityEngine;
using UnityEngine.UI;  // allows Text
using System.Collections;

public class TextController : MonoBehaviour {

    public Text roomText;      // at 18 font size it can hold 813 characters or about 125 words 

    private enum States { faceInDirt, gunOutOfReach, laughter, bottleToFace, staggering, punchBlocked, kickMissed, armed, shotBySheriff, escape };
    private States myState;
    private bool firstTime;
    private int pushYourLuck;

    void Start()
    {
        myState = States.faceInDirt;
        firstTime = true;   // determines what is written on the first screen on the first time or every time after
        pushYourLuck = 0;   // to be implemented in the future - can die if you make too many bad decisions
    }

    // Update is called once per frame
    void Update() {
        //print(myState);
        if (myState == States.faceInDirt) { faceInDirt(); }
        else if (myState == States.gunOutOfReach) { gunOutOfReach(); }
        else if (myState == States.laughter) { laughter(); }
        else if (myState == States.bottleToFace) { bottleToFace(); }
        else if (myState == States.staggering) { staggering(); }
        else if (myState == States.punchBlocked) { punchBlocked(); }
        else if (myState == States.kickMissed) { kickMissed(); }
        else if (myState == States.armed) { armed(); }
        else if (myState == States.shotBySheriff) { shotBySheriff(); }
        else if (myState == States.escape) { escape(); }
    }

    void faceInDirt()
    {
        if (firstTime == true)
        {
            roomText.text = "You wake up with a mouth full of dust and a lingering taste of whiskey, wondering how the hell you fell asleep face first in the dirt.  " +
                            "The world spins as you attempt to wet your lips with a sandpaper tongue.  From behind you, you hear the crunch of boots on the red clay, walking at a slow gait until it comes to a standstill.\n\n" +
                            "\"Kid Curry?!  I been tracking you for thousands of miles.  A mighty fine position you in, aint it?  It ends here.\"\n\n" +
                            "The Sherrif and the Deputy, gotta be.  You reach for your holster, but the piece ain't there.  Shit!\n\n" +
                            "You see a blurry glint of metal to your right that might be your [[G]]un.  " +
                            "In your left hand is a [[W]]hiskey bottle, a pile of [[D]]irt is piled up under your face.";
        }
        else
        {
            roomText.text = "\n\nBack to where you started again, with a face full of dirt, a bad hangover, and a gun trained at your head...\n\n" +
                            "You see a blurry glint of metal to your right that might be your [[G]]un.  " +
                            "In your left hand is ad [[W]]hiskey bottle, a pile of [[D]]irt is piled up under your face.";
        }
        if (Input.GetKeyDown(KeyCode.W)) { myState = States.bottleToFace; }
        else if (Input.GetKeyDown(KeyCode.G)) { myState = States.gunOutOfReach; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.laughter; }
    }

    void gunOutOfReach()
    {
        roomText.text = "You grope for that blurry shine and hope to God that it's your gun.  Dust squeezes out from between your fingers as realize you've come up empty.  " +
                        "A pistol fires from behind you and a plume of dust ejects where your hand used to be.\n\n" +
                        "\"I wouldn't recommend you do that again, Kid.  Stand up so I can take you back to a nice little cement five by five I got laid out for you.\n\n" +
                        "The dust settles back down and you see he's missed your hand by a few inches.  You flex your fingers in relief.\n\n" +
                        "[[R]]eturn";
        firstTime = false;
        pushYourLuck += 1;
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.faceInDirt; }
    }

    void laughter()
    {
        roomText.text = "Rolling onto your back, you grab a handful of dirt and rocks and throw it in the asshole's direction, sidearm style.\n\n" +
                        "You leap to your feet and run forward to tackle him...but damn if the world ain't upside down right now...\n\n" +
                        "As you fall back to the ground, you hear hollow, mocking laughter from behind and wonder just how strong that damn whiskey was.\n\n" +
                        "[[R]]eturn";
        firstTime = false;
        pushYourLuck += 1;
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.faceInDirt; }
    }

    void bottleToFace()
    {
        roomText.text = "The thought of wasting good whiskey goes against everything you believe in.  But hell, maybe he's thirsty.\n\n" +
                        "\"All right I'll come with you.  But this laying in the dirt stuff is thirsty work.  Allow me a few swallows.\"\n\n" +
                        "\"That's fine Kid.  Just make it quick.\"\n\n" +
                        "You tilt the bottle back against your lips and take a long swallow.  Motioning for one more, you tilt it back again, then reach over your head " +
                        "and bring your arm down in full force, throwing it in the direction of the two men.  You hear a dull thunk and a low moan before a man crumples to the dirt.  " +
                        "Looks like he was thirsty.\n\n" +
                        "[[S]]tand up";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.staggering; }
    }

    void staggering()
    {
        roomText.text = "You're finally on your feet.  Staggering, really, but on your feet at least.\n\n" +
                        "The one that crumpled to the dirt looks to be the Sherrif, but that Deputy bastard has his eye on you and he's moving in with fists raised ready for a fight.\n\n" +
                        "\"Let's do this little man.\" you snarl as he advances.\n\n" +
                        "[[P]]unch, [[K]]ick, [[D]]ive for gun.";
        if (Input.GetKeyDown(KeyCode.P)) { myState = States.punchBlocked; }
        else if (Input.GetKeyDown(KeyCode.K)) { myState = States.kickMissed; }
        else if (Input.GetKeyDown(KeyCode.D)) { myState = States.armed; }
    }

    void punchBlocked()
    {
        roomText.text = "You throw a haymaker at that waif of a Deputy, one so ferocious it would make a grown man cringe just by looking at it.\n\n" +
                        "The deputy throws up his forearm and blocks it.\n\n" +
                        "You've gotta be shittin me?!  You seem to remember that fistfights aren't really your forte.\n\n" +
                        "[[R]]eturn.";
        pushYourLuck += 1;
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.staggering; }
    }

    void kickMissed()
    {
        roomText.text = "As the Deputy walks towards you, you sprint directly towards him, throwing up dirt and dust in your wake.\n\n" +
                        "Just before you reach him, you jump into the air and throw a nasty kick aimed right at his knee.  " +
                        "You sail past as the Deputy deftly side steps you.\n\n" +
                        "What is this guy, a God Damn ninja?!\n\n" +
                        "[[R]]eturn.";
        pushYourLuck += 1;
        if (Input.GetKeyDown(KeyCode.R)) { myState = States.staggering; }
    }

    void armed()
    {
        roomText.text = "You imagine yourself diving towards your gun, snatching it off the ground with one hand, then roll forward and pop to your feet " +
                        "with your gun aimed at the Deputy.  Ok, works just fine in theory, now for the attempt...\n\n" +
                        "And what do you know, it goes exactly as you planned.\n\n" +
                        "You now have a gun in your hands, and by most accounts, you are the fastest living gun in the West, hungover or not.  " +
                        "You hear a horse braying behind you and remember that your 'ol pal Dynamite Hooves is nearby.\n\n" +
                        "[[S]]hoot the deputy, or [[W]]histle for your horse.";
        if (Input.GetKeyDown(KeyCode.S)) { myState = States.shotBySheriff; }
        else if (Input.GetKeyDown(KeyCode.W)) { myState = States.escape; }
    }

    void shotBySheriff()
    {
        roomText.text = "With a flick of the wrist and a squeeze of the finger, you make quick work of the Deputy.  He didn't stand a chance.  " +
                        "You walk forward to make sure he's dead and gone.  Maybe put another one in him for good merit.\n\n" +
                        "Motion from the corner of your eye.  The Sherrif is sitting up, with an arm on his knee and a gun pointed in your direction.  " +
                        "A shot rings out and you feel a sharp pinch in your chest.  Bob Marley had it wrong.\n\n" +
                        "\"The reward is bigger for alive, but I'll just as soon take you back dead.  Good night, Kid.\"\n\n" +
                        "***GAME OVER.  YOU ARE DEAD!***\n\n[[R]]estart";
        if (Input.GetKeyDown(KeyCode.R)) { restart(); }
    }

    void escape()
    {
        roomText.text = "Pressing your tongue to your teeth you let out a piercing whistle.  A mustang gallops up " +
                        "from behind, just like you've trained her to do so many times.\n\n" +
                        "Stretching out your arm, you grab hold of the harness and swing up into the saddle.  " +
                        "As you ride off, you see the Sherrif has made it back to a sitting position and is aiming his gun at you.  You duck down as he fires.\n\n" +
                        "But the horse is too fast and the shot goes wide.  Free and clear, they have no chance at catching you now.  " + 
                        "You recall that Deadwood just opened up a new brothel.  This calls for a little celebration.\n\n" +
                        "***GAME OVER.  YOU WIN!***\n[[R]]estart\n[[Q]]uit";
        if (Input.GetKeyDown(KeyCode.R)) { restart(); }
        else if (Input.GetKeyDown(KeyCode.Q)) { Application.Quit(); }
    }

    void restart()
    {
        myState = States.faceInDirt;
        firstTime = true;
        pushYourLuck = 0;
    }


}
