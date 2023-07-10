import unittest
import constants
from rock_paper_scissors_lizard_spock import RockPaperScissorsLizardSpock
# python -m unittest unit_tests.py

class RockPaperScissorsLizardSpockTestCase(unittest.TestCase):
    def setUp(self):
        self.game = RockPaperScissorsLizardSpock()

    def test_determine_winner_same_choice_results_in_tie(self):
        result = self.game.determine_winner("rock", "rock")
        self.assertEqual(result, "It's a tie!")

    def test_determine_winner_player_wins_with_rock_vs_scissors(self):
        result = self.game.determine_winner("rock", "scissors")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_rock_vs_lizard(self):
        result = self.game.determine_winner("rock", "lizard")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_paper_vs_rock(self):
        result = self.game.determine_winner("paper", "rock")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_paper_vs_spock(self):
        result = self.game.determine_winner("paper", "spock")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_scissors_vs_paper(self):
        result = self.game.determine_winner("scissors", "paper")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")
    
    def test_determine_winner_player_wins_with_scissors_vs_lizard(self):
        result = self.game.determine_winner("scissors", "lizard")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_lizard_vs_paper(self):
        result = self.game.determine_winner("lizard", "paper")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")
    
    def test_determine_winner_player_wins_with_lizard_vs_spock(self):
        result = self.game.determine_winner("lizard", "spock")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_player_wins_with_spock_vs_rock(self):
        result = self.game.determine_winner("spock", "rock")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")
    
    def test_determine_winner_player_wins_with_spock_vs_scissors(self):
        result = self.game.determine_winner("spock", "scissors")
        self.assertEqual(result, f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}")

    def test_determine_winner_computer_wins_with_rock_vs_lizard(self):
        result = self.game.determine_winner("lizard", "rock")
        self.assertEqual(result, f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}")

    def test_determine_winner_computer_wins_with_paper_vs_spock(self):
        result = self.game.determine_winner("spock", "paper")
        self.assertEqual(result, f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}")

    def test_determine_winner_computer_wins_with_scissors_vs_paper(self):
        result = self.game.determine_winner("paper", "scissors")
        self.assertEqual(result, f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}")

    def test_determine_winner_computer_wins_with_lizard_vs_paper(self):
        result = self.game.determine_winner("paper", "lizard")
        self.assertEqual(result, f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}")

    def test_determine_winner_computer_wins_with_spock_vs_rock(self):
        result = self.game.determine_winner("rock", "spock")
        self.assertEqual(result, f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}")

if __name__ == '__main__':
    unittest.main()
