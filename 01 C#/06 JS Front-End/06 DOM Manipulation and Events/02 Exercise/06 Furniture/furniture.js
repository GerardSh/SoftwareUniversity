document.addEventListener('DOMContentLoaded', solve);

function solve() {
  const generateInputEl = document.querySelector('form#input input');
  const inputBuyEl = document.querySelector('form#shop input[type="submit"]');

  generateInputEl.addEventListener('click', (e) => {
    e.preventDefault();

    const inputEl = document.querySelector('form#input textarea');
    const productObjects = JSON.parse(inputEl.value);
    inputEl.value = '';

    const rowToCloneEl = document.querySelector('tbody tr');

    for (const product of productObjects) {
      const rowEl = rowToCloneEl.cloneNode(true);
      rowEl.innerHTML = rowEl.innerHTML.trim().replace(/\n\s*/g, '');

      rowEl.querySelector('img').src = product.img;
      rowEl.querySelector('td:nth-child(2) p').textContent = product.name;
      rowEl.querySelector('td:nth-child(3) p').textContent = product.price;
      rowEl.querySelector('td:nth-child(4) p').textContent = product.decFactor;
      rowEl.querySelector('td:nth-child(5) input').disabled = false;

      document.querySelector('tbody').append(rowEl);
    }
  })

  inputBuyEl.addEventListener('click', (e) => {
    e.preventDefault();

    const textAreaEl = document.querySelector('form#shop textarea');

    const rowEls = Array.from(document.querySelectorAll('tbody tr'))
      .filter(x => x.querySelector('td:nth-child(5) input').checked);

    const products = [];

    for (const rowEl of rowEls) {
      const name = rowEl.querySelector('td:nth-child(2) p').textContent;
      const price = Number(rowEl.querySelector('td:nth-child(3) p').textContent);
      const factor = Number(rowEl.querySelector('td:nth-child(4) p').textContent);

      products.push({
        name,
        price,
        factor
      })
    }

    textAreaEl.value = `Bought furniture: ${products.map(x => x.name).join(', ')}`
    textAreaEl.value += `\nTotal price: ${products.reduce((aggr, currentEl) => aggr + currentEl.price, 0)}`
    textAreaEl.value += `\nAverage decoration factor: ${((products.reduce((aggr, currentEl) => aggr + currentEl.factor, 0)) / products.length)}`;
  })
}
