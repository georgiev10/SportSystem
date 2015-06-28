namespace SportSystem.Web.InputModels
{
    using SportSystem.Models;
    using Common.Mappings;

    public class VoteInputModel : IMapTo<Vote>
    {
        public string UserId { get; set; }

        public int TeamId { get; set; }
    }
}