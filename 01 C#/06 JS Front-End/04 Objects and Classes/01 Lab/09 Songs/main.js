function solve(input = []) {
    class Song {
        constructor(typeList, name, time) {
            this.typeList = typeList;
            this.name = name;
            this.time = time;
        }
    }

    const [n, ...songs] = input;
    const typeListToPrint = songs.pop();

    let songCollection = [];

    for (const song of songs) {
        const [typeList, name, time] = song.split('_');
        songCollection.push(new Song(typeList, name, time));
    }

    for (const song of songCollection) {
        if (song.typeList == typeListToPrint || typeListToPrint == 'all') {
            console.log(song.name);
        }
    }
}
