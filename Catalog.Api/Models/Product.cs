namespace Catalog.Api.Models
{
    public record Product
    (
        int Id,
        string Name,
        decimal Price,
        string Category,
        string Description
    );

    public record CreateProductDto(  
        string Name,
        decimal Price,
        string Category,
        string Description
    );
}
