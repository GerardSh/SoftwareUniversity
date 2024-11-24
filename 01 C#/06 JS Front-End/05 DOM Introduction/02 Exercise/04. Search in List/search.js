function search() {
   const townElements = document.getElementById('towns').children;
   const textSearchElement = document.getElementById('searchText');
   const resultElement = document.getElementById('result');
   let matchesCount = 0;

   for (const town of townElements) {
      town.style.fontWeight = '200';
      town.style.textDecoration = 'auto';
   }

   for (const town of townElements) {
      if (town.textContent.includes(textSearchElement.value)) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         matchesCount++;
      }
   }

   resultElement.textContent = `${matchesCount} matches found`;
}
