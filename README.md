AutoPoke
========

Automatic memory search &amp; poke

This tool allows you to scan the memory of a process, find the memory location of
some variable and change it as needed.

In effect, this can be use as a semi-automatical game trainer. For example, say
you want to have infinite ammo in a game:

* Load the process list and select the game process in the top dropdown
* Add a new search - let's call it "Ammo". Leave type on Int32 (most integers are that).
* Note the current ammo in the game and put it in the Search value box. Press search.
* Shoot once, and search again with the new value. Repeat until the number occurences above
  the progress bar either drops to 1, or stays the same for a few attempts.
* Press "->" to store the found memory location.
* Select the stored location and write the desired ammo count in the textbox below the
  list, and press set.

This tool is not intended for cheating in multiplayer games (unless all of the players agree).

Also, be careful, especially when poking .NET or Java applications. It's very easy to crash
a process by writing liberally over its memory :) 
