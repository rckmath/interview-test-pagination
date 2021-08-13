using InterviewTestPagination.Search.Todo;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTestPagination.Models.Todo {
    /// <summary>
    /// Todo Service Service layer extending from ITodoService interface that implements the base IModelService. 
    /// </summary>
    public class TodoService : ITodoService {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository) {
            _todoRepository = todoRepository;
        }

        /// <summary>
        /// Example implementation of List method: lists all entries of type <see cref="Todo"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Todo> List()
        {
            // invoke Datasource layer
            return _todoRepository.All();
        }

        /// <summary>
        /// Lsists with pagination all entries of type <see cref="Todo"/>
        /// </summary>
        /// <returns>
        /// Paged list of model <see cref="Todo"/>, in the <see cref="PagedResult{T}"/> standards
        /// </returns>
        public PagedResult<Todo> ListPaged(TodoSearch todoSearch)
        {
            var isDescending = todoSearch.IsDesc();

            var query = _todoRepository.FindAll(isDescending, todoSearch.OrderBy.ToUpper());

            if (todoSearch.PageSize == 0)
            {
                todoSearch.PageSize = query.Count();
            }

            // invoke Datasource layer
            return _todoRepository.AllPaged(query, todoSearch);
        }
    }
}
