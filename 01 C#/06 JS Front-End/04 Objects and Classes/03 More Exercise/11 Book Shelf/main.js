function solve(input) {
    const shelves = [];

    for (const line of input) {
        if (line.includes('->')) {
            const [iD, genre] = line.split(' -> ');

            const shelf = shelves.find(x => x.iD == iD);

            if (!shelf) {
                shelves.push({ iD, genre, books: [] });
            }

        } else {
            const [title, author, genre] = line.split(/: |, /);

            const shelf = shelves.find(x => x.genre == genre);

            if (shelf) {
                shelf.books.push({
                    title,
                    author,
                })
            }
        }
    }

    shelves.sort((a, b) => b.books.length - a.books.length);

    for (const shelf of shelves) {
        console.log(`${shelf.iD} ${shelf.genre}: ${shelf.books.length}`);

        for (const book of shelf.books) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}
