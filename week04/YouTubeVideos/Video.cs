using System.Collections.Generic;

public class Video
{
    public string _title;
    public string _author;
    public int _duration;
    public List<Comment> _comments;

    public Video(string title, string author, int duration)
    {
        _title = title;
        _author = author;
        _duration = duration;
        _comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
}