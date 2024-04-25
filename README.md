# D&D RPG Base Functions
## Classes 
### - **GameCharacter**: The abstract superclass of the Player and Monster classes. Holds the empty data and methods shared between them (e.g. Attacking, rolling dice, etc.)
### - **Player**: A GameCharacter subclass exclusively used for party memebers. Has added variables & functions for party-only actions like leveling up.
### - **Monster**: A GameCharacter subclass exclusively used for enemies. Has added variables for dropped exp, gold, and items.
### - **RPGFunctions**: The main class for us to run and test our code.
