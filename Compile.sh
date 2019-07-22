#!/bin/bash
cd '/home/martin/Documentos/Projectos/C#/VirtusPecto/'
csc 'Behaviors.cs' 'Buttons/PlayButton.cs' 'Buttons/SettingsButton.cs' 'GameMaker.cs' 'Buttons/WindowBox.cs' 'Buttons/AspectBox.cs' 'Card.cs' 'CardContent.cs' 'Creature.cs' 'CreatureDatabase.cs' 'Buttons/DifficultyBox.cs' 'Enemy.cs' 'FireBall.cs' 'Buttons/Fullscreen.cs' 'Game1.cs' 'GameMouse.cs' 'Level.cs' 'Lobby.cs' 'Mouse.cs' 'PauseMenu.cs' 'Player.cs' 'Program.cs' 'SettingsMenu.cs' 'ToolBar.cs' 'Buttons/WinBorder.cs' -r:'Game/MonoGame.Framework.dll' 
if [ -f 'Program.exe' ]
then
mv 'Program.exe' './Game'
cd './Game'
mono Program.exe
fi
