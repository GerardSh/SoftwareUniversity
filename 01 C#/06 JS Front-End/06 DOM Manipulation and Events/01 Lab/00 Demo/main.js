// Demo 1 - create element and append
// Select movie list element
const movieListElement = document.querySelector('ul.movie-list');

// Create new li element
const newMovieELement = document.createElement('li');

// Add content
newMovieELement.textContent = 'Ink'

// Add to DOM
movieListElement.appendChild(newMovieELement);

// Demo 2 - clone element and append

const firstMovieElement = movieListElement.children[0];

// Clone as new element
const firstMovieElementClone = firstMovieElement.cloneNode(true);

// Change text content
firstMovieElementClone.textContent += ' Clone'

// Append cloned element
movieListElement.appendChild(firstMovieElementClone);

// Delete element
firstMovieElement.remove();
