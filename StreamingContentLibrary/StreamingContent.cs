using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamingContentLibrary
{
    public enum MaturityRating
    {
        G,
        PG,
        PG_13,
        R,
        NC17
    }
    public class StreamingContent
    {
        public StreamingContent() { }

        public StreamingContent(string title, string description, double starRating, MaturityRating maturityRating, /*bool isFamilyFriendly,*/ int runTimeInMinutes)
        {
            Title = title;
            Description = description;
            StarRating = starRating;
            MaturityRating = maturityRating;
            // IsFamilyFriendly = isFamilyFriendly;
            RunTimeInMinutes = runTimeInMinutes;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public double StarRating { get; set; }
        public MaturityRating MaturityRating { get; set; }

        //Adjust IsFamilyFriendly to return correct bool based on MaturityRating
        public bool IsFamilyFriendly
        {
            get
            {
                return MaturityRating < MaturityRating.R;
            }
        }
        public int RunTimeInMinutes { get; set; }
    }
}