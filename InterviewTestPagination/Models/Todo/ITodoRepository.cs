using InterviewTestPagination.Search.Todo;
using System.Linq;

namespace InterviewTestPagination.Models.Todo
{
    public interface ITodoRepository : IModelRepository<Todo>
    {
        /// <summary>
        /// Method that lists with ordering all entries of model <see cref="Todo"/>
        /// </summary>
        /// <returns>
        /// Queryable list of model <see cref="Todo"/>
        /// </returns>
        IQueryable<Todo> FindAll(bool isDesc, string orderBy);

        /// <summary>
        /// Method that lists with pagination and the properly filtering entries of model <see cref="Todo"/>
        /// </summary>
        /// <returns>
        /// Paged list of model <see cref="Todo"/>, in the <see cref="PagedResult{T}"/> standards
        /// </returns>
        PagedResult<Todo> AllPaged(IQueryable<Todo> query, TodoSearch todoSearch);
    }
}