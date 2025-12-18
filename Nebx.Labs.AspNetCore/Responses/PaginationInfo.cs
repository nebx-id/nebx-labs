namespace Nebx.Labs.AspNetCore.Responses;

/// <summary>
/// Represents pagination-specific metadata.
/// </summary>
public sealed record PaginationInfo(
    int? Page,
    int? PageSize,
    int? TotalPages,
    int? TotalCount
)
{
    /// <summary>
    /// Indicates whether there is a subsequent page of results available.
    /// </summary>
    public bool? HasNextPage =>
        Page.HasValue && PageSize.HasValue && TotalCount.HasValue
            ? Page * PageSize < TotalCount
            : null;

    /// <summary>
    /// Indicates whether there is a preceding page of results available.
    /// </summary>
    public bool? HasPreviousPage =>
        Page.HasValue
            ? Page > 1
            : null;
}