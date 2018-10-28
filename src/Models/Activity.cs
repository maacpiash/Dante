using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dante.Models
{
    // An Activity can be anything an Author posts: a Story, a Reaction or a Comment.
    public class Activity
    {
        public int ID { get; set; }
        public Author Author { get; set; }
        public DateTime PostedOn { get; set; }
        public string ActivityDisplayText { get; set; }
        // Example of an ActivityDisplayText (will appear
        // on his profile and his followers' feed):
        // Shawon Ashraf has posted a story titled "আমার বিয়েতে
        // বটমলেস কাচ্চি খাওয়াবো" on Sunday at 2:04 pm.
    }

    // A Content can be either a Story or a Comment.
    public class Content : Activity
    {
        public string Body { get; set; }
        public List<Reaction> Reactions { get; set; }
    }

    // A story is a blog post.
    public class Story : Content
    {
        public string Title { get; set; }
        public DateTime LastEditedOn { get; set; }
        public List<Comment> Comments { get; set; }
    }

    // A Comment is posted on a Story. It cannot be edited and cannot be commented on, but can be reacted on.
    public class Comment : Content
    {
        public Story Parent { get; set; }
    }

    // A Reaction is an Author's primitive non-contextual opinion on a Story or a Comment.
    public class Reaction : Activity
    {
        //public Content Parent { get; set; }
        public int React;
    }

    public static class Reactions
    {
        public const int Like = 0;
        public const int Dislike = 1;
        public const int Love = 2;
        public const int Laugh = 3;
        public const int Cry = 4;
        public const int Angry = 5;
        public const int Hooray = 6;
        public const int Amazed = 7;
        public const int Confused = 8;
        public const int Meh = 9;
        public const int WTF = 10;
        public const int Geli = 11;
    }
}
