# Unleash-Havoc
Game for CS-583 where you Unleash Havoc!

This game project is a 2D action platformer. It's quick, sporadic, and loud! 

# Controls:

Approach an object on the ground and press **E** with your mouse pointed in its general vicinity to pick it up.

To drop an object being held, press **E** again.

To throw an object, press **left click** on the mouse/trackpad.

To move, the character can go left or right with **A or D**, respectively.

To jump, press **space**.

A powerup is included that allows the player to grab enemies and throw them, but it's only active for a few seconds.

# Differences from One-Pager:

# Controls
All the controls I wanted within the one-pager were implemented.

# Art Assets
I unfortunately wasn't able to get the throwing frames I wanted showing my character throwing the object explicitly.

For the objects thrown, I wasn't able to create the tennis or car. I decided to change the brown box into a metallic one to better fit the theme.
Instead of a bowling ball, I went with a bouncy dodgeball look instead.

The facility was not as grandiose as I had hoped. It appears more like a space station with an alien escaping its containment, but if I were to have more time, I would want to edit this to appear more science-like. It mostly consists of prefabs for time.

The powerup does increase the player's strength as desired, but it doesn't look like a jug of milk, but a buff icon. Instead, it allows the player to pick up 
basic enemies and throw them.

I wasn't able to get a HUD showing the strength of the player nor an image of the object they were holding. Only the player's current health above their head is shown.

I included a Menu Start Screen with a Win Screen as well, which wasn't originally mentioned in the one-pager.

During development, I was planning to use the AStarSearch plugin, but decided against it due to it being overengineered for the purpose.

For most of my art assets, it came from an asset pack by Kenny.nl to match the lab/space look I was intending. Other images such as the backgrounds were taken from
Google.

# Audio Assets
I was able to get the footsteps, powerup, throwing, enemy death, hit sounds, and more.

I even added jumping sounds, multiple throwing and walking sounds that would shift randomly, ball bouncing, glass breaking, and edited version of my basic enemy death sound for the large enemy.

For background audio, I ultimately decided against it because I believe an alarm that kept ringing constantly would've been annoying to listen to.

For enemy footsteps, I decided against it because I believe multiple enemies would drown out the other audio in the scene. I wasn't able to get the enemies to scream and immediately jump at the player so that audio
wasn't included.

Instead of a victory song playing at the end of every level, I instead placed it in the very last level for when the player beats the game. 

# Game Flow
The beginning storyline wasn't really translated well with my game, but I did include the beginning glass break encounter as desired.

For the middle, the general jumping and taking out enemies is there, but some aspects were changed. The enemy that has protection isn't one that wears armor, but instead is impenetrable to normal attacks.
The big enemy I introduced could only be neutralized with an object being dropped on its head. Otherwise, the object bounces right off. I had switches with gateways that would open when an object was thrown at them.
I didn't include the large gap idea but instead provided a section that required stacking multiple objects to hop over. I added the ball to add rolling puzzles that involved throwing the ball in tight vents that would have a switch inside to open gates. Finally, the power up did make the player stronger, but not with picking up heavier objects, but instead picking up the enemies! 

For the end, I wasn't able to have a door swing open. Instead, a golden archway is provided, and if a player touches it, they are transported to the next level.

# Potential Challenges
Animation was indeed a challenge for the throwing as it was never complete. I couldn't create the throwing motion like I wanted.
I was able to get basic movement for the player, that being a jump, run, idle, and hurt animations. Unfortunately, I couldn't provide animations to the enemies like I intended.

Physics were not too bad when it came to collisions for an object hitting an enemy and killing it. I unfortunately was unable to have different objects affect different parts of the enemy's body. Weights were attached to the gigantic objects that kill the big enemies, but not for any others. This was not the original one-pager intention.

Breakables were attempted, specifically with the glass, which I think looks alright. Figuring that out on my own was a bit of a challenge. I also remembered to remove collisions for the glass shards and the player using the 2D collision matrix.

I was able to allow the user to drop the objects they didn't want. But I made the key for its E instead of right click because I thought it felt more comfortable.

Game Feel wasn't as great as I wanted it to be. In my one-pager, I wanted the enemy to rotate and puff into smoke after death. Instead, I opted to launch the enemy quite far after the object hit them with a loud hit sound and a scream coming from them. 

# AI Disclosure

Claude AI assisted me in these portions.

Cosine/Sin conversions for aiming functionality to convert the angle into a throw vector.
Suggestions for how to solve a bug that involved a basic-enemy simply walking into a static object and dying by suggesting to add a velocity check.
Helping with fixing the player's animation not flipping properly when hitting A or D.
Fixing the aiming rotation to update under localRotation rather than transform.position to make sure that it wouldn't be affecting the world but instead the parent object with its children.
Helping with an X offset approach that was used for mirroring aiming from one side of the player to another via flipping.

Whenever Claude would give me advice or provide code in some scenarios, I made sure to write comments explaining how they functioned, and made sure to have it explain why it chose an approach. I would write down its explanation in my notebook and append comments to make sure I understood the concept. 


**Link to GitHub:** https://github.com/MatHern2004/Unleash-Havoc
# End
