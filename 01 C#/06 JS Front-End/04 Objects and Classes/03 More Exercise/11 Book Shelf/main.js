function solve(input) {
    const shelfs = [];

    for (const line of input) {
        if (line.includes('->')) {
            const [iD, genre] = line.split(' -> ');

            const shelf = shelfs.find(x => x.iD == iD);

            if (!shelf) {
                shelfs.push({ iD, genre, books: [] });
            }

        } else {
            const [title, author, genre] = line.split(/: |, /);

            const shelf = shelfs.find(x => x.genre == genre);

            if (shelf) {
                shelf.books.push({
                    title,
                    author,
                })
            }
        }
    }

    shelfs.sort((a, b) => b.books.length - a.books.length);

    for (const shelf of shelfs) {
        console.log(`${shelf.iD} ${shelf.genre}: ${shelf.books.length}`);

        for (const book of shelf.books) {
            console.log(`--> ${book.title}: ${book.author}`);
        }
    }
}
