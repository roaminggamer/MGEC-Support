//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Game start / end events sent from the server
//----------------------------------------------------------------------------

function clientCmdGameStart(%seq)
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /gpgt/client/scripts/game.cs ->" SPC "clientCmdGameStart()");
   PlayerListGui.zeroScores();
}

function clientCmdGameEnd(%seq)
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /gpgt/client/scripts/game.cs ->" SPC "clientCmdGameEnd()");
   // Stop local activity... the game will be destroyed on the server
   alxStopAll();

   // Copy the current scores from the player list into the
   // end game gui (bit of a hack for now).
   EndGameGuiList.clear();
   for (%i = 0; %i < PlayerListGuiList.rowCount(); %i++) {
      %text = PlayerListGuiList.getRowText(%i);
      %id = PlayerListGuiList.getRowId(%i);
      EndGameGuiList.addRow(%id,%text);
   }
   EndGameGuiList.sortNumerical(1,false);

   // Display the end-game screen
   Canvas.setContent(EndGameGui);
}