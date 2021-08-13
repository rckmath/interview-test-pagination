﻿using System.Collections.Generic;

namespace InterviewTestPagination.Models {
    /// <summary>
    /// Model Service layer's main entry-point. 
    /// Should translate high-level commands and data structures into something that can be used by the data source layer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelService<T> {

        /// <summary>
        /// Example signature of a method that lists entries of model T
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> List();
    }
}
