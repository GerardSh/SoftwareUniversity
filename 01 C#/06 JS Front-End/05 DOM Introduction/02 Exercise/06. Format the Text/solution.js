function solve() {
  const input = document.getElementById('input').value
    .split('.')
    .filter(x => x)
    .map(x => x.trim())
    .map(x => x + '.');
  const targetDiv = document.getElementById('output');

  let elements = [];
  let currentIndex = 0;
  let sentencesCounter = 0;

  for (const sentence of input) {
    if (sentencesCounter % 3 == 0 && elements.length != 0) {
      currentIndex++;
      sentencesCounter = 0;
    }

    if (elements[currentIndex] == undefined) {
      elements[currentIndex] = sentence;
    } else {
      elements[currentIndex] += ` ${sentence}`;
    }

    sentencesCounter++
  }

  targetDiv.innerHTML = elements.map(x => `<p>${x}</p>`).join('');
}




//2
function solve() {
  const textarea = document.getElementById('input');
  const divOutput = document.getElementById('output');

  let text = textarea.value;

  let sentences = text.split('.');
  sentences = sentences.map((s) => s.trim());
  sentences.pop();

  while (sentences.length > 0) {
    let currentSentences = sentences.splice(0, 3);

    let content = currentSentences.join('.') + '.';

    let paragraph = document.createElement('p');
    paragraph.textContent = content;

    divOutput.appendChild(paragraph);
  }
}
