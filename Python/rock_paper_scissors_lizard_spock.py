import random
import constants
import score_tools
import print_tools
# For printing with colors
import os
os.system('cls')


class RockPaperScissorsLizardSpock:
    def __init__(self):
        self.choices = constants.CHOICES
        self.rounds = 0
        self.computer_names = constants.GAME_PARTICIPANTS_NAMES
        self.print_tools = print_tools.PrintTools()
        self.score_tools = score_tools.ScoreTools()
        self.round_against_computer = constants.ROUND_AGAINST_COMPUTER

    def get_player_choice_from_input(self, round_number):
        valid_choice = False
        while not valid_choice:
            player_choice = input(
                f"It's round {round_number}. Enter your ({'/'.join(self.choices)}) choice : ").lower()
            if player_choice in self.choices:
                valid_choice = True
            else:
                print(
                    f"{constants.RED_COLOR}Invalid choice. Please try again.{constants.RESET_COLOR}")

        return player_choice

    def get_valid_player_input(self, text_player_can_see, min_number, max_number):
        valid_input = False
        while not valid_input:
            player_input = input(text_player_can_see +
                                 f" ({min_number}-{max_number})\n  :")
            if player_input.isnumeric() and min_number <= int(player_input) <= max_number:
                valid_input = True
            else:
                print(f"{constants.RED_COLOR}Invalid input. Please enter number from {min_number} to {max_number}."
                      f"{constants.RESET_COLOR}")

        return int(player_input)

    def get_computer_choice(self):
        return random.choice(self.choices)

    def determine_winner(self, player_choice, computer_choice):
        if player_choice == computer_choice:
            return "It's a tie!"
        elif computer_choice in constants.GAME_OUTCOMES[player_choice]:
            constants.PLAYER_SCORE += 1
            return f"{constants.GREEN_COLOR}You win this round!{constants.RESET_COLOR}"
        else:
            constants.COMPUTER_SCORE += 1
            return f"{constants.RED_COLOR}Computer wins this round!{constants.RESET_COLOR}"

    def is_rounds_equal_to_zero(self, is_human_playing, result, number_of_rounds_with_each_opponent, player_name,
                                computer_name):
        if "It's a tie!" not in result:
            self.rounds -= 1
            if is_human_playing:
                self.round_against_computer += 1
        if self.rounds == 0:
            one_round_results = self.print_tools.show_one_round_results(constants.PLAYER_SCORE, constants.COMPUTER_SCORE,
                                                                        number_of_rounds_with_each_opponent)
            self.score_tools.update_scores(player_name, constants.PLAYER_SCORE, computer_name,
                                           constants.COMPUTER_SCORE)
            if is_human_playing:
                print(one_round_results)
                self.round_against_computer = constants.ROUND_AGAINST_COMPUTER
            constants.PLAYER_SCORE = 0
            constants.COMPUTER_SCORE = 0
            self.rounds = number_of_rounds_with_each_opponent

            return True
        return False

    def play_game(self):
        self.print_tools.print_beginning_of_game(
            self.choices, self.computer_names)
        player_name = constants.PLAYER_NAME
        number_of_opponents = self.get_valid_player_input(f"Enter number of computer players!",
                                                          constants.MIN_ROUNDS_AND_OPPONENTS, constants.MAX_OPPONENTS)
        number_of_rounds_with_each_opponent = self.get_valid_player_input(
            f"Enter number of rounds with each opponent!", constants.MIN_ROUNDS_AND_OPPONENTS, constants.MAX_ROUNDS)
        self.rounds = number_of_rounds_with_each_opponent
        self.score_tools.create_scores_list(number_of_opponents)

        for game_nr in range(1, number_of_opponents + 1):
            print("\n\n")
            print(
                f"This is game {game_nr} against {self.computer_names[game_nr]}")
            while True:
                computer_choice = self.get_computer_choice()
                # print("----->>>>> " + computer_choice)  # print computer choice for testing
                player_choice = self.get_player_choice_from_input(
                    self.round_against_computer)
                # player_choice = self.score_tools.automatically_pick_winning_move_against_computer(
                #     computer_choice)
                print(f"You chose: {player_choice}")
                print(
                    f"Computer {self.computer_names[game_nr]} chose: {computer_choice}")
                result = self.determine_winner(player_choice, computer_choice)
                print(result)

                if self.is_rounds_equal_to_zero(True, result, number_of_rounds_with_each_opponent,
                                                player_name, self.computer_names[game_nr]):
                    break

        # remaining computers play against each other
        for computer_game_index in range(1, number_of_opponents + 1):
            computer_main_player_name = self.computer_names[computer_game_index]
            for computer_opponent_index in range(1 + computer_game_index, number_of_opponents + 1):
                cpu_played_against_name = self.computer_names[computer_opponent_index]
                while True:
                    computer_main_player_choice = self.get_computer_choice()
                    cpu_played_against_choice = self.get_computer_choice()
                    result = self.determine_winner(
                        computer_main_player_choice, cpu_played_against_choice)

                    if self.is_rounds_equal_to_zero(False, result, number_of_rounds_with_each_opponent,
                                                    computer_main_player_name, cpu_played_against_name):
                        break

        self.print_tools.print_scores(self.score_tools.scores)
        self.score_tools.count_games_won_for_each_player(number_of_opponents)
        print("-------")
        self.score_tools.sort_and_print_player_names_and_games_won()

        if self.score_tools.have_you_won_the_game_with_most_wins():
            print(
                f"\nYou won all {number_of_opponents} computer opponents!\nCongratulations!")
        else:
            print("\nYou lost against computer!")
