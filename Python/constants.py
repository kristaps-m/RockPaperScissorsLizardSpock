# declare 'constants'
PLAYER_NAME = "'YOU!!'"
MIN_ROUNDS_AND_OPPONENTS = 1
MAX_OPPONENTS = 9
MAX_ROUNDS = 5
PLAYER_SCORE = 0
COMPUTER_SCORE = 0
ROUND_AGAINST_COMPUTER = 1
GAME_PARTICIPANTS_NAMES = [PLAYER_NAME, "'Call of Blanked'", "'Vintage Vegan'", "'Lean fat'",
                           "'Average Taste'", "'Terminator'", "'Super man'",
                           "'Premium Princess'", "'Fat KitKat'", "'Bald Egg'"]

CHOICES = ["rock", "paper", "scissors", "lizard", "spock"]

GAME_OUTCOMES = {
    # rock beats (scissors and lizard)...
    "rock": ["scissors", "lizard"],
    "paper": ["rock", "spock"],
    "scissors": ["paper", "lizard"],
    "lizard": ["paper", "spock"],
    "spock": ["rock", "scissors"]
}

RED_COLOR = "\u001b[31;1m"
GREEN_COLOR = "\u001b[32;1m"
RESET_COLOR = "\u001b[0m"
