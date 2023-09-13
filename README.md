# Baccarat Game with SQL Server

This is a simple Baccarat card game developed in C# using the .NET framework and WPF (Windows Presentation Foundation). The game allows players to place bets on either the player or the banker's hand and then deals cards to determine the winner. It also tracks the player's and banker's wins, ties, and total games played, and stores this data in a SQL Server database.

## Table of Contents

- [How to Play](#how-to-play)
- [Features](#features)
- [Screenshots](#screenshots)
- [Development](#development)
- 
## How to Play

1. Launch the application.
2. Enter your name when prompted.
3. Place a bet on either the player's or the banker's hand.
4. Click the "Play" button to start the game.
5. Cards will be dealt automatically to both the player and banker.
6. The winner (Player, Banker, or Tie) will be displayed.
7. Your bankroll and game statistics are updated accordingly.

## Features

- Betting: Players can place bets on the player or banker's hand.
- Card Dealing: The game automatically deals cards to both sides.
- Scoring: The game calculates the scores for both the player and banker.
- Winner Display: The winner is displayed after each game.
- Bankroll Tracking: Your bankroll is updated based on wins and losses.
- Game Statistics: Track the number of games played and the number of wins for each side.
- Betting Limits: Prevents players from betting more than their available bankroll.
- Data Persistence: Player scores are stored in a SQL Server database and displayed in a DataGrid.

## Screenshots

![image](https://github.com/vladislavv27/Baccarat-wpf.net/assets/77066719/670fd8e4-e354-4fa2-9ea5-f0579467650c)
![image](https://github.com/vladislavv27/Baccarat-wpf.net/assets/77066719/00f1d586-6859-4211-9616-d6c197280aa5)


## Development

This project is developed in C# using the .NET framework and WPF for the graphical user interface. It uses Entity Framework Core to interact with a SQL Server database for data storage and retrieval. The database schema includes tables for player scores and game statistics.


