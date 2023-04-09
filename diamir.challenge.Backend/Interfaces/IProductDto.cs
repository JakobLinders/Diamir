namespace diamir.challenge.Backend
{
    public interface IProductDto
    {
        string Id { get; set; }

        string Name { get; set; }

        decimal Price { get; set; }
    }
}
