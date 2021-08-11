using InterviewTestPagination.Search.Todo;
using System.Collections.Generic;
using System.Linq;

namespace InterviewTestPagination.Models.Todo {
    /// <summary>
    /// TODO: Implement methods that enable pagination
    /// </summary>
    public class TodoService : ITodoService {

        private ITodoRepository _repository = new TodoRepository();

        public ITodoRepository Repository {
            get { return _repository; }
            set { _repository = value; }
        }

        /// <summary>
        /// Example implementation of List method: lists all entries of type <see cref="Todo"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Todo> List() {
            // invoke Datasource layer
            return Repository.All();
        }
        
        /// <summary>
        /// Example implementation of List method: lists all entries of type <see cref="Todo"/>
        /// </summary>
        /// <returns></returns>
        public PagedResult<Todo> ListPaged(TodoSearch todoSearch) {
            var isDescending = todoSearch.IsDesc();

            var query = Repository.FindAll(isDescending, todoSearch.OrderBy.ToUpper());

            if (todoSearch.PageSize == 0)
            {
                todoSearch.PageSize = query.Count();
            }
            // invoke Datasource layer
            return Repository.AllPaged(query, todoSearch);
        }
    }
}
