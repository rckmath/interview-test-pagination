using InterviewTestPagination.Search.Todo;
using System.Linq;

namespace InterviewTestPagination.Models.Todo
{
    public interface ITodoRepository : IModelRepository<Todo>
    {
        IQueryable<Todo> FindAll(bool isDesc, string orderBy);
        PagedResult<Todo> AllPaged(IQueryable<Todo> query, TodoSearch todoSearch);
    }
}