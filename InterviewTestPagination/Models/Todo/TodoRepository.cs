using InterviewTestPagination.Search.Todo;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InterviewTestPagination.Models.Todo {

    /// <summary>
    /// No need to use an actual persistent datasource. 
    /// All operations can be mocked in-memory as long as they are consistent with the chosen datasource implementation 
    /// (e.g. dont create new model instances when executing a search 'query', etc).
    /// TL;DR: from this point on Database-like operations can be mocked.
    /// </summary>
    public class TodoRepository : ITodoRepository {

        /// <summary>
        /// Example in-memory model datasource 'indexed' by id.
        /// </summary>
        private static readonly IDictionary<long, Todo> DataSource = new ConcurrentDictionary<long, Todo>();

        static TodoRepository() {
            // initializing datasource
            var startDate = DateTime.Today;
            for (var i = 1; i <= 55; i++) {
                var createdDate = startDate.AddDays(i);
                DataSource[i] = new Todo(id: i, task: "Dont forget to do " + i, createdDate: createdDate);
            }
        }

        public IEnumerable<Todo> All()
        {
            return DataSource.Values.OrderByDescending(t => t.CreatedDate);
        }

        public IQueryable<Todo> FindAll(bool isDesc, string orderBy)
        {
            var query = DataSource.Values.AsQueryable().AsNoTracking();

            switch (orderBy)
            {
                case "ID":
                    query = isDesc
                        ? query.OrderByDescending(t => t.Id)
                        : query.OrderBy(t => t.Id);
                    break;
                case "TASK":
                    query = isDesc
                        ? query.OrderByDescending(t => t.Task)
                        : query.OrderBy(t => t.Task);
                    break;
                case "CREATEDDATE":
                    query = isDesc
                        ? query.OrderByDescending(t => t.CreatedDate)
                        : query.OrderBy(t => t.CreatedDate);
                    break;
                default:
                    query = query.OrderByDescending(t => t.CreatedDate);
                    break;
            }

            return query;
        }

        public PagedResult<Todo> AllPaged(IQueryable<Todo> query, TodoSearch todoSearch) {
            return PagedResult<Todo>.GetPagedList(query, todoSearch.CurrentPage, todoSearch.PageSize);
        }
    }
}
