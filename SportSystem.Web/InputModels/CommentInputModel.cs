namespace SportSystem.Web.InputModels
{
    using SportSystem.Models;
    using Common.Mappings;

    public class CommentInputModel : IMapTo<Comment>
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public int MatchId { get; set; }

    }
}