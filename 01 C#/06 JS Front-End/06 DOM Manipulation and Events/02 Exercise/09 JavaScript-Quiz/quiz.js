document.addEventListener('DOMContentLoaded', solve);

function solve() {
  const sections = Array.from(document.getElementsByClassName("question"));
  const resultsDiv = document.getElementById("results");
  const h1Results = document.createElement("h1");
  resultsDiv.appendChild(h1Results);

  const correctAnswers = [
    "onclick",
    "JSON.stringify()",
    "A programming API for HTML and XML documents",
  ];
  let rightAnswers = 0;
  let currentQuestionIndex = 0;

  sections.forEach((section, index) => {
    const answers = Array.from(section.querySelectorAll(".quiz-answer"));
    answers.forEach((answer) => {
      answer.addEventListener("click", () => handleAnswer(answer, index));
    });
  });

  function handleAnswer(answer, questionIndex) {
    const userAnswer = answer.textContent;

    if (userAnswer === correctAnswers[questionIndex]) {
      rightAnswers++;
    }

    sections[questionIndex].classList.add("hidden");
    currentQuestionIndex++;

    if (currentQuestionIndex < sections.length) {
      sections[currentQuestionIndex].classList.remove("hidden");
    } else {
      displayResults();
    }
  }

  function displayResults() {
    resultsDiv.style.display = "block";

    if (rightAnswers === correctAnswers.length) {
      h1Results.textContent = "You are recognized as top JavaScript fan!";
    } else {
      const plural = rightAnswers === 1 ? "answer" : "answers";
      h1Results.textContent = `You have ${rightAnswers} right ${plural}`;
    }
  }
}
