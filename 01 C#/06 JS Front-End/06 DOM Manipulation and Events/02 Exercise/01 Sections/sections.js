document.addEventListener('DOMContentLoaded', solve);

function solve() {
   const words = document.querySelector('input[type ="text"]').value.split(', ');
   debugger;
   const divContainerEl = document.getElementById('content');

   for (const word of words) {
      const divEl = document.createElement('div');
      const pEl = document.createElement('p');

      pEl.textContent = word;
      pEl.style.display = 'none';
      divEl.appendChild(pEl);
      divContainerEl.appendChild(divEl);

      divEl.addEventListener('click', (e) => {
         e.currentTarget.children[0].style.display = 'block';
      })
   }
}
