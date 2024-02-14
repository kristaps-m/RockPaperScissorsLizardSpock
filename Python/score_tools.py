import random
import constants
import scores
import print_tools


class ScoreTools:
    def __init__(self):
        self.players = constants.GAME_PARTICIPANTS_NAMES
        self.scores = []
        self.player_names_and_games_won = {}
        self.print_tools = print_tools.PrintTools()

    def create_scores_list(self, num_players):
        for i in range(num_players + 1):
            self.scores.append([])
            for j in range(num_players + 1):
                if i != j:
                    self.scores[i].append(scores.Scores(
                        self.players[i], 0, self.players[j], 0))
                else:
                    self.scores[i].append(None)

    def generate_player_names_and_games_won_dictionary(self, number_of_opponents):
        self.player_names_and_games_won = {
            k: 0 for k in self.players[:number_of_opponents + 1]}

    def count_games_won_for_each_player(self, number_of_opponents):
        self.generate_player_names_and_games_won_dictionary(
            number_of_opponents)
        for row in self.scores:
            for score in row:
                if score is not None and score.score1 > score.score2:
                    self.player_names_and_games_won[score.player1] += 1

    def sort_and_print_player_names_and_games_won(self):
        sorted_dict = dict(sorted(
            self.player_names_and_games_won.items(), key=lambda x: x[1], reverse=True))
        max_name_length = max(len(name) for name in sorted_dict.keys())

        self.print_tools.print_player_name_and_victories(
            sorted_dict, max_name_length)

    def have_you_won_the_game_with_most_wins(self):
        print(self.player_names_and_games_won)
        max_win_score = max(
            wins for wins in self.player_names_and_games_won.values())
        how_many_players_have_max_score = 0
        has_player_max_score = self.player_names_and_games_won[constants.PLAYER_NAME] == max_win_score

        for v in self.player_names_and_games_won.values():
            if max_win_score == v:
                how_many_players_have_max_score += 1

        return True if how_many_players_have_max_score == 1 and has_player_max_score else False

    def update_scores(self, player1, score1, player2, score2):
        index1 = self.players.index(player1)
        index2 = self.players.index(player2)
        self.scores[index1][index2] = scores.Scores(
            player1, score1, player2, score2)
        self.scores[index2][index1] = scores.Scores(
            player2, score2, player1, score1)

    def automatically_pick_winning_move_against_computer(self, computer_choice):
        not_pick_to_win = constants.GAME_OUTCOMES[computer_choice]
        not_pick_to_win.append(computer_choice)
        winning_choices = [
            c for c in constants.CHOICES if c not in not_pick_to_win]
        random_winning_choice = random.choice(winning_choices)

        return random_winning_choice
