namespace Git.ViewModels.Repositories
{
    public class RepositoryListingView
    {
        public string Id { get; init; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string CreatedOn { get; set; }
        public int Commits { get; set; }
    }
}
