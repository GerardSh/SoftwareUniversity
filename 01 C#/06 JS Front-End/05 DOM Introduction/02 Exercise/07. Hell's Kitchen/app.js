function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let input = document.getElementsByTagName('textarea')[0].value;


      input = input.replaceAll('["', '');
      input = input.replaceAll('"]', '');

      const arrayInput = input.split('","')
      console.log(arrayInput);
   }
}
