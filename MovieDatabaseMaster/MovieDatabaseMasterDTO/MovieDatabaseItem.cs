namespace MovieDatabaseMasterDTO
{
    public class MovieDatabaseItem
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; }
        public string? Genre { get; set; }
        public float Runtime { get; set; }
    }
}