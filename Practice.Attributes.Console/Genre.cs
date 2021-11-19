namespace Practice.Attributes.ConsoleApp
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        [EnumDescription("Sci-Fi")]
        [EnumDescription("SciFi")]
        SciFi,
        Thriller
    }
}
