namespace Inventario.Core.Dtos;

public record ProdutoDto(
    int Id,
    string Nome,
    string? Descriçao,
    int Quantidade,
    decimal Preco);
