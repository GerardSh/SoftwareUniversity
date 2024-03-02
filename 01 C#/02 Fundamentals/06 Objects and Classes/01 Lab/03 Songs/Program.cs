class Song
{
    public string TypeList { get; set; }
    public string Name { get; set; }
    public string Time { get; set; }

    static void Main()
    {

        int n = int.Parse(Console.ReadLine());

        Song[] test = new Song[n];

        List<Song> Songs = new List<Song>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split("_", StringSplitOptions.RemoveEmptyEntries);

            string typeList = input[0];
            string name = input[1];
            string time = input[2];

            Song song = new Song();

            song.TypeList = typeList;
            song.Name = name;
            song.Time = time;

            Songs.Add(song);
        }

        string songsToPrint = Console.ReadLine();

        List<Song> filteredSongs = new List<Song>();

        foreach (Song song in Songs)
        {
            if (songsToPrint == "all")
            {
                Console.WriteLine(song.Name);
            }
            else
            {
                if (song.TypeList == songsToPrint)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }
    }
}