using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        List<Video> videos = new List<Video>();
        videos.Add(new Video("History of the Dynasties in China, part 1", "Master Lee", 120));
        videos.Add(new Video("How to build a giant sand castel", "The Sandman", 180));
        videos.Add(new Video("Holidays in Taiwan", "Cute Dumpling", 150));

        // Adding comments to videos
        videos[0].AddComment(new Comment("YuYu", "Great video!"));
        videos[0].AddComment(new Comment("K-Roll", "Interesting topic."));
        videos[0].AddComment(new Comment("NiaoNiao", "I learned a lot from this."));

        videos[1].AddComment(new Comment("SillyKitty", "Nice work!"));
        videos[1].AddComment(new Comment("downunder333", "Keep it up!"));
        videos[1].AddComment(new Comment("Uknowwho", "Good job!."));

        videos[2].AddComment(new Comment("LingYu", "Awesome content!"));
        videos[2].AddComment(new Comment("littlefannumber1", "I'm definitly going to suscribe to your chanel!"));
        videos[2].AddComment(new Comment("hungrypotato", "Thanks for sharing."));

        // Displaying information about videos
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }
            Console.WriteLine();
        }

    }
}