using Nebx.Labs.Core.Domain.Models;

namespace Nebx.Labs.AspNetCore.Responses;

/// <summary>
/// Represents metadata associated with API responses.
/// </summary>
public sealed class Meta
{
    /// <summary>
    /// Pagination-related metadata.
    /// </summary>
    public PaginationInfo? Pagination { get; private set; }

    /// <summary>
    /// Populates pagination metadata using the provided page parameters and total item count.
    /// </summary>
    public void AddPagination(int page, int pageSize, int totalCount)
    {
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var isPageInvalid = page > 1 && page > totalPages;

        Pagination = new PaginationInfo(
            Page: isPageInvalid ? 1 : page,
            PageSize: pageSize,
            TotalPages: totalPages == 0 ? 1 : totalPages,
            TotalCount: totalCount
        );
    }

    /// <summary>
    /// Populates pagination metadata using a <see cref="Pagination"/> object.
    /// </summary>
    public void AddPagination(Pagination pagination, int totalCount)
        => AddPagination(pagination.Page, pagination.PageSize, totalCount);
}