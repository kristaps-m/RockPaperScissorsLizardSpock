let choices = ["rock", "paper", "scissors", "lizard", "spock"];
let gameOutcomes = {
  // rock beats (scissors and lizard)...
  rock: ["scissors", "lizard"],
  paper: ["rock", "spock"],
  scissors: ["paper", "lizard"],
  lizard: ["paper", "spock"],
  spock: ["rock", "scissors"],
};

let rT = document.getElementById("randomT");

function test() {
  console.clear();
  let playerInput = document.getElementById("playerInput").value.toLowerCase();
  let randomAImove = choices[Math.floor(Math.random() * choices.length)];
  console.log("YOU", playerInput, gameOutcomes[playerInput]);
  console.log("robot", randomAImove, gameOutcomes[randomAImove]);
  let gameResult = document.getElementById("gameResult");
  gameResult.textContent = getWinner(playerInput, randomAImove);
}

function getWinner(p1choice, p2choice) {
  let w = "";

  if (p1choice === p2choice) {
    w = "TIE";
  } else if (gameOutcomes[p1choice].includes(p2choice)) {
    w = "Player";
  } else if (gameOutcomes[p2choice].includes(p1choice)) {
    w = "robot";
  }

  return w;
}
