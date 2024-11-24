function solve() {
  const textElementValueArray = document.getElementById('text').value.split(' ');
  const typeElementValue = document.getElementById('naming-convention').value;
  let result = textElementValueArray.map(x => x[0].toUpperCase() + x.slice(1).toLowerCase()).join('');

  if (typeElementValue == 'Camel Case') {
    result = result[0].toLowerCase() + result.slice(1);
  } else if (typeElementValue != 'Pascal Case') {
    result = 'Error!'
  }

  document.getElementById('result').textContent = result;
}
