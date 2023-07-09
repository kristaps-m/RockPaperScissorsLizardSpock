import constants


class PrintTools:
    def print_scores(self, scores):
        for row in scores:
            print("----------------------------------------------------------------")
            for score in row:
                if score is not None:
                    print(f"{score.player1} vs {score.player2}: {score.score1}-{score.score2}")
                else:
                    print("N/A")

    def show_one_round_results(self, player_score, computer_score, number_of_rounds):
        result_start = f"After {number_of_rounds} rounds "
        result_end = f"\nResult [You - {player_score} : CPU - {computer_score}]"

        if player_score == computer_score:
            return result_start + "it's a tie!" + result_end
        elif player_score > computer_score:
            return result_start + "Player wins!" + result_end
        else:
            return result_start + "Computer wins!" + result_end

    def print_beginning_of_game(self, choices, computer_names):
        print(f"Welcome to {', '.join(i.capitalize() for i in choices)}")
        print("You can play the game against computer players. And they will play against each other.")
        print(f"Their names are {', '.join(computer_names[1:])}!")
        print("You can pick how many opponents to play and how many rounds against them!")

    def print_player_name_and_victories(self, sorted_dict, max_name_length):
        for name, wins in sorted_dict.items():
            padded_name = name.ljust(max_name_length, '.')
            if constants.PLAYER_NAME in padded_name:
                print(f"Player: {constants.GREEN_COLOR}{padded_name}{constants.RESET_COLOR} Wins: {wins}")
            else:
                print(f"Player: {padded_name} Wins: {wins}")
