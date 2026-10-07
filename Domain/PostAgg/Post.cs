using System;
using System.Collections.Generic;
using System.Text;
using Common.Domain;

namespace Domain.PostAgg;

public class Post : BaseEntity
{
    public string Title { get; private set; }
    public string Text { get; private set; }
    public long WrittenBy { get; set; }
    public int ViewCount { get; private set; }

    public Post(long id, string title, string text, long writtenBy)
    {
        Title = title;
        Text = text;
        WrittenBy = writtenBy;
    }

    public void Edit(string title, string text)
    {
        Title = title;
        Text = text;
    }
}