function solve() {
   const resultEl = document.querySelector('textarea');
   const buttonEl = document.querySelector('button.checkout')
   let boughtProductsSum = 0;
   const products = new Set();

   document.querySelectorAll('button.add-product')
      .forEach(el => el.addEventListener('click', (e) => {
         const productEl = e.target.parentElement.parentElement;
         const productName = productEl.querySelector('div.product-title').textContent;
         const productPrice = Number(productEl.querySelector('div.product-line-price').textContent);

         boughtProductsSum += productPrice;
         resultEl.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`
         products.add(productName);
      }));

   buttonEl.addEventListener('click', () => {
      resultEl.textContent += `You bought ${Array.from(products).join(', ')} for ${boughtProductsSum.toFixed(2)}.`

      document.querySelectorAll('button').forEach(el => el.setAttribute('disabled', 'true'));
   })
}
