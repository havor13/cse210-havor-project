class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Intro to C#", "Locas Kanyir", 600);
        video1.AddComment("Alpha", "Great tutorial!");
        video1.AddComment("Rapheal", "Very informative.");
        video1.AddComment("Charlie", "I learned a lot!");

        Video video2 = new Video("Advanced OOP Concepts", "Sampson Havor", 1200);
        video2.AddComment("Klinsmann", "Thanks for the explanation.");
        video2.AddComment("Locadia", "Super helpful!");
        video2.AddComment("Frank", "This is gold!");

        Video video3 = new Video("How to write Encapsulation program", "Bright Biney", 1800);
        video3.AddComment("Mavis", "This is exactly what I am looking for.");
        video3.AddComment("Abraham", "Keep bring more tutorials, I really love it!");
        video3.AddComment("Clement", "Best vidoe ever.");

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.Display();
        }
    }
}
