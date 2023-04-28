# **Doggie Daycare Dating (DDD)**

## Summary of Additions and Changes

## Additions

- Improved and finalized dating system with owner reactions based on player response, positive/negative values for player response, and good and bad endings per date.
- Added more date-able characters with full dating progression and endings.
- Added more functioning dogs.
- Added more decorations to the daycare scene.
- Implemented owner selection system at the end of each daycare day.
- Included black screen fade transitions.
- Included new credits screen at the end of game.
- Added 2 good ending scenes, and a bad ending scene.
- Music and sound effects are included.
- Added visuals for dog tasks including apparel shown on dog, and animations for bathing and walking dog.
- Implemented "exit game" feature within the game with corresponding UI.
- Implemented an owner entrance event before the date.
- More decorations in the daycare scene.
- Added dog/owner description panel, activated by clicking the computer desk.
- Owner now has animated sprites in the daycare scene.
- Added dog's favorite item feature that gives happiness boost.

## Changes

- Changed dating flow from 2 dates and ending to 3 dates and ending.
- Changed dating scripts to make dating each owner more consistent.
- Updated placeholder assets with final art.
- Rearranged dog positioning within the game scene to encourage players to move around the scene.
- Redesigned "Start" screen so be more consistent in style to the rest of the game.
- Moved dog task buttons on dogs instead of on player.
- Shorten the day length from 10 hrs to 8 hrs.
- Fixed player walking animation.
- Changed dating scene's fonts and scales.


## Introduction

## Description

Doggie Daycare Dating is a Task Management/Dating Simulator where the player takes the role of new hire at a dog daycare business. She's single and ready to mingle, so if she does an impressive job she'll have the opportunity to go on dates with the dog owners in hopes of getting married to one of them, or else remain single forever.

The art style consists of 2d top down pixel art. The color palette is cute and filled with vibrant pastels. Every dog and owner is built with love and resembles each other. Dating scenes that will make your heart swoon. We aim to create a chill experience with free lo fi music. The game will be built with Unity game engine and using the 2D environment and framework.

## Technical Design

_This section should cover any technical systems/mechanics/features included_ _in the project._

## Description of Technologies Used

**Unity 2021.3.16**

Majority of DDD was built using a Unity 2D environment

- Integrated sprite assets with Unity UI & GameObjects
- Integrated C# scripts with Unity UI & GameObjects

**Visual Studio/IDE**

- Used for script editing

**Aseprite**

- Used to create all sprite assets for game
  - Including: player, dog, inventory items, UI elements & tile set.

**Adobe Photoshop 23.1.1**

- Used to edit sprites, if needed

**Git (using Github as remote storage)**

- Used for version controlling, syncing progress and asset storage

## Technical Limitations

_Have you found any issues with the game between computers/operating systems? Does it perform poorly under certain circumstances? During parts of the game? Has it crashed at all?_

There have been no issues with running the game on different computers or operating systems. The game's performance does not change under any particular circumstances. Although during development the daycare part of the game has proven to be the most prone to bugs, currently there aren't any known bugs or issues in any part of the game aside from certain UI layering issues with the dog tasks buttons in the daycare section.

## Game Features

## Story

The owner of Doggie Daycare is going out of town for the week, and they've hired you to take care of the dogs in the meantime. On day 1, the owner shows you all the tasks you'll need to complete to take care of the dogs. You'll be introduced to the dog owners and their dogs when they drop them off in the morning.

When you take care of a dog really well, they like you more. Owners notice their dogs happiness and begin to like you too. The owner will then ask you on a date. Based on your dialogue responses the date can go well or poorly. If it goes well, the next day the owner will take you on a second date. If the second date goes well, this repeats for a third date. If all goes well, you'll get married! If not, they'll break up with you.

### Dialogue/Documents

#### Tutorial

The Doggie Daycare owner greets you and introduces herself. She explains that she needs your help to run the daycare and begins to introduce the basic controls. She explains how the dogs have 3 stats that need to be kept satisfied by performing tasks or using items. _[Appendix II]_

#### Dog Owner Introduction

The three dog owners will introduce themselves in a way that expresses a snippet of their personality in a brief piece of dialogue. _[Appendix III]_

#### Date 1 w/ Logan, Elaine, or Jeff

Logan or Jeff take Olivia on a date at a sports bar. Elaine takes Olivia to a late night coffee bar instead. They will ask the player what they'd like to drink and orders. They ask about Olivia's motivations to work at the doggie daycare, what she thinks of the sports bar, her hometown, and her family. _[Appendix IV]_

#### Date 2 w/ Logan, Elaine, or Jeff

The dog owners will ask how Olivia has been and go on to inquire about what attracted the player to them. They ask about how the player has been treating their dog and have a conversation about what Olivia's dream vacation would be, and the idea of the owner coming along.

#### Date 3 w/ Logan, Elaine, or Jeff

The last date with the owners is clearly a special one, and the player has a choice about what to wear to the occasion. On this date, the owner decides to share something special to them with Olivia. Logan talks about surfing, Elaine explains it's her brothers' birthday as they perform, and Jeff has a vulnerable moment sharing about his father's death. The conversation continues on until they each eventually propose to Olivia.

### Audio

Audio on all the time (Scene-Specific)

- Menu - Chill Lofi Music
  - [https://freesound.org/people/Seth\_Makes\_Sounds/sounds/587897/](https://freesound.org/people/Seth_Makes_Sounds/sounds/587897/)
- Credits - Music
  - [https://freesound.org/people/deleted\_user\_11009121/sounds/506595/](https://freesound.org/people/deleted_user_11009121/sounds/506595/)
- Intro/Tutorial - Music
- Inside doggie daycare - Chill Lofi Music
  - [https://freesound.org/people/Seth\_Makes\_Sounds/sounds/587897/](https://freesound.org/people/Seth_Makes_Sounds/sounds/587897/)
- Inside doggie daycare - Joyful Music (Alternate)
  - [https://www.youtube.com/watch?v=zT50dvlYUBQ](https://www.youtube.com/watch?v=zT50dvlYUBQ)
- Date - Music (Based on character, mostly upbeat, romantic, & chill)
  - [https://www.youtube.com/watch?v=w4oLP7fa9Vk](https://www.youtube.com/watch?v=w4oLP7fa9Vk)
  - [https://freesound.org/people/SergeQuadrado/sounds/555798/](https://freesound.org/people/SergeQuadrado/sounds/555798/)
- Ending #1 (No Dates) - Relaxing Music
  - [https://www.youtube.com/watch?v=O1tu3bntP\_I](https://www.youtube.com/watch?v=O1tu3bntP_I)
- Ending #2 (Happily Ever After) - Joyful Music (Wedding bells, happy ending music, etc; Based on character)
  - [https://freesound.org/people/acclivity/sounds/23090/](https://freesound.org/people/acclivity/sounds/23090/)
  - [https://www.youtube.com/watch?v=LXJcwn\_rfqM](https://www.youtube.com/watch?v=LXJcwn_rfqM)

Audio specific to an object

- Dogs - Idle sounds (Barking, sleeping)
  - [https://freesound.org/people/crazymonke9/sounds/418106/](https://freesound.org/people/crazymonke9/sounds/418106/)
- NPCs - Talking (Rambling/hums)
- Alert sound for passive change in dog stats
  - Will play when a dog is getting low on hunger/energy/etc
  - [https://freesound.org/people/Andromadax24/sounds/186719/](https://freesound.org/people/Andromadax24/sounds/186719/)
- Door sounds (opening/closing)

Audio specific to interactivity

- UI/menu sounds (Hovering buttons, clicking buttons, checking dog stats)
  - [https://freesound.org/people/Ranner/sounds/487533/](https://freesound.org/people/Ranner/sounds/487533/)
  - [https://freesound.org/people/Kagateni/sounds/571501/](https://freesound.org/people/Kagateni/sounds/571501/)
- Performing an action(Feeding, walking, bathing, cleaning/maintaining)
  - Will go along with short/simple animations playing on the screen
  - [https://freesound.org/people/plasterbrain/sounds/396196/](https://freesound.org/people/plasterbrain/sounds/396196/)
  - [https://freesound.org/people/Davidsraba/sounds/367608/](https://freesound.org/people/Davidsraba/sounds/367608/)
- Inventory sounds (Moving items, using items, spending money)
  - [https://freesound.org/people/GabFitzgerald/sounds/625174/](https://freesound.org/people/GabFitzgerald/sounds/625174/)
- Start of day/End of day chime
  - [https://freesound.org/people/nezuai/sounds/582606/](https://freesound.org/people/nezuai/sounds/582606/)

## Gameplay Mechanics

### Player Movement (Daycare Section Only)

**Controls** : WASD or arrow keys movement in four directions.

**Speed** : A constant 10 pixels per second

### World Generation

The world is a premade scene of the inside of the Doggie Daycare business.

#### Environment Details

The playable environment is the interior of the Doggie Daycare business. In the room there is fixed furniture and cushions for placing dogs on. Environment objects act as colliders and cannot be interacted with by the player. Dogs stay in place on the cushion placed on and are animated to move like a gif.

### Daycare Activities

**Walk** : Clicking "_Walk"_ will perform the walk action and a small pop-up animation will be displayed showing the task being completed on the selected dog.

**Bathe** : Clicking "_Bathe"_ will perform the walk action and a small pop-up animation will be displayed showing the task being completed on the selected dog.

**Give Item** : Clicking _"Give Item"_ will open the Inventory UI pop-up where the player can choose a _Food_, _Toy_ item, or _Accessory_ item. If a _Food_ item is selected and fed to the dog. If a _Toy_ item is selected then the dog's happiness is increased. If an _Accessory_ is selected then the dog will appear wearing the apparel in the scene.

#### Dogs

Dogs will hold 3 main stats: Hunger, Hygiene, Happiness (hidden). They will each add up with an apparel bonus to calculate the overall well being value displayed on the screen as "Happiness" (not the hidden stats). Players can spend time and use items without limit in number until a dog's associated value reaches 100%, except for apparels, which can only be equipped once and its bonus is not added until the final well being calculation. A dog's hygiene, hunger and happiness condition will be displayed with sprite animations. Its equipped toy and apparel will also show up in animation. Feeding special food to corresponding dogs or using apparels may bring an advantage of triggering the dating event with owners.

#### Clock

- Keeps track of in-game time and weekday during the daycare section.
- Buttons to pause, resume, and speed up time.
- 2 seconds = 1 in-game minute.
- Speeding up time increases the game speed by 50 times.
- Daycare days go from 9 AM to 5 PM.
- Available owner and happiness checking occurs at 4 PM and the owner will show up at 4:30 PM.
- The player can then walk up to the owner to trigger the dialogue scene or wait until the end of day.

### Dating

The player is taken to a dialogue scene between Olivia and a dog owner. The player will have to choose between 2 responses at given moments during the date. These responses will affect the player's relationship with the dog owner and depending on how well they do, the dog owner may break up with Olivia at the end or the player will be able to progress to the next date and afterwards the happy ending.

