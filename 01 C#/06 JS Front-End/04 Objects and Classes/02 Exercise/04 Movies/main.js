function solve(input) {
    let movies = {};

    for (let element of input) {
        let lineArray = element.split(' ');

        let movieName = '';

        if (lineArray[0] == 'addMovie') {
            lineArray.shift();
            movieName = lineArray.join(' ');

            movies[movieName] = { name: movieName };
        } else {
            if (element.includes('directedBy')) {
                let [movieName, director] = element.split(' directedBy ');

                if (movies.hasOwnProperty(movieName)) {
                    movies[movieName].director = director;
                }
            } else {
                let [movieName, date] = element.split(' onDate ');

                if (movies.hasOwnProperty(movieName)) {
                    movies[movieName].date = date;
                }
            }
        }
    }

    for (movie in movies) {
        const currentMovie = movies[movie];

        if (currentMovie.director && currentMovie.date) {
            console.log(JSON.stringify(currentMovie));
        }
    }
}
