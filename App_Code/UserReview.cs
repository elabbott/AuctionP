using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Each User class will have 0 or more reviews of that user.
/// Each review will belong to 1 user who submitted the review.
/// Each review will have a string containing the comments submitted by the reviewer,
///     the date the review was submitted, and an integer Rating (1-5?)
/// </summary>
public class UserReview
{
    #region Attributes
    private int id;
    private int reviewer_id;
    private int reviewee_id;
    private String review_text;
    private DateTime review_date;
    private int rating;

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public int Reviewer_id
    {
        get
        {
            return reviewer_id;
        }

        set
        {
            reviewer_id = value;
        }
    }

    public int Reviewee_id
    {
        get
        {
            return reviewee_id;
        }

        set
        {
            reviewee_id = value;
        }
    }

    public string Review_text
    {
        get
        {
            return review_text;
        }

        set
        {
            review_text = value;
        }
    }

    public DateTime Review_date
    {
        get
        {
            return review_date;
        }

        set
        {
            review_date = value;
        }
    }

    public int Rating
    {
        get
        {
            return rating;
        }

        set
        {
            rating = value;
        }
    }
    #endregion

    public UserReview(int id, int reviewer_id, int reviewee_id, String review_text, DateTime review_date, int rating)
    {
        this.id = id;
        this.reviewer_id = reviewer_id;
        this.reviewee_id = reviewee_id;
        this.review_text = review_text;
        this.review_date = review_date;
        this.rating = rating;
    }
}