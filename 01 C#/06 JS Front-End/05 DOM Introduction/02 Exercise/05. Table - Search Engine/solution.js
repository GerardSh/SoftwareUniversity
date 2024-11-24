function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const rowElements = Array.from(document.querySelectorAll('tbody tr'));
      const input = document.getElementById('searchField');

      rowElements.forEach(x => x.className = '');
      rowElements.filter(x => x.textContent.includes(input.value) && input.value != '')
         .forEach(x => x.className = 'select');

      input.value = '';
   }
}
