using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

       
        Video video1 = new Video("Tutorial how make a sandwich", "Juan Martinez", 200);
        video1.AddComment(new Comment("Roby", "very useful!"));
        video1.AddComment(new Comment("Charles", "thanks for the video."));
        video1.AddComment(new Comment("Albert", "It helped me ."));

        Video video2 = new Video("How use POO", "Carlos Perez", 500);
        video2.AddComment(new Comment("David", "excellent ."));
        video2.AddComment(new Comment("Rosario", "Clear."));
        video2.AddComment(new Comment("Franky", "I could understand."));

        Video video3 = new Video("Learning hmtl", "Jesus Poma", 700);
        video3.AddComment(new Comment("Gabriela", "Great."));
        video3.AddComment(new Comment("Braulio", "Keep it out !"));
        video3.AddComment(new Comment("Ivonne", "Very well explained."));


        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
      

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Duration: {video._duration} segundos");
            Console.WriteLine($"number of Comments : {video.GetCommentCount()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment._author}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}