using InterviewTestPagination.Search.Todo;

namespace InterviewTestPagination.Models.Todo {
    /// <summary>
    /// Model Service layer's main entry-point. 
    /// Should translate high-level commands and data structures into something that can be used by the data source layer.
    /// </summary>
    /// <typeparam name="Todo"></typeparam>
    public interface ITodoService : IModelService<Todo> {

        /// <summary>
        /// Example signature of a method that lists entries of model Todo
        /// </summary>
        /// <returns>
        /// Paged list of model <see cref="Todo"/>, in the <see cref="PagedResult{T}"/> standards
        /// </returns>
        PagedResult<Todo> ListPaged(TodoSearch todoSearch);
    }
}
