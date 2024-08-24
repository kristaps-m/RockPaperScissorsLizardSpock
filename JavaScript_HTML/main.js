let choices = ["rock", "paper", "scissors", "lizard", "spock"];
let gameOutcomes = {
  // rock beats (scissors and lizard)...
  rock: ["scissors", "lizard"],
  paper: ["rock", "spock"],
  scissors: ["paper", "lizard"],
  lizard: ["paper", "spock"],
  spock: ["rock", "scissors"],
};
let autoPlayOnClick = true;
let roundNumber = 1;
let playerScore = 0;
let robotScore = 0;

let rT = document.getElementById("randomT");

function test() {
  console.clear();
  let playerInput = document.getElementById("playerInput").value.toLowerCase();
  let randomAImove = choices[Math.floor(Math.random() * choices.length)];
  console.log("YOU", playerInput, gameOutcomes[playerInput]);
  console.log("robot", randomAImove, gameOutcomes[randomAImove]);
  let gameResult = document.getElementById("gameResult");
  const theW = getWinner(playerInput, randomAImove);
  gameResult.textContent = theW;

  let setRoundNumber = document.getElementById("roundNumber");
  if (theW !== "TIE") {
    roundNumber++;
  }
  if (theW === "Player") {
    playerScore++;
  } else if (theW === "robot") {
    robotScore++;
  }
  console.log(`[p=${playerScore} : r= ${robotScore}]`);
  let threeRoundResult = document.getElementById("threeRoundResult");
  if (roundNumber === 4) {
    threeRoundResult.textContent = threeRoundResultAsFunction(
      playerScore,
      robotScore
    );
  }

  if (roundNumber !== 4) {
    setRoundNumber.textContent = roundNumber;
  }
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

function threeRoundResultAsFunction(pS, rS) {
  if (pS > rS) {
    return "Player Won!";
  } else {
    return "Robot Won ;(";
  }
}
