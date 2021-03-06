﻿using System;
using System.Linq;
using FubuMVC.Core.Continuations;
using FubuMVC.Diagnostics.Visualization;
using fubu_todo.Endpoints.Home;
using FubuMVC.TwitterBootstrap;

namespace fubu_todo
{
    public class HomeEndpoint
    {
        private readonly ITodoListDBInteractor _dbInteractor;

        public HomeEndpoint(ITodoListDBInteractor dbInteractor)
        {
            _dbInteractor = dbInteractor;
        }

        public TodoListViewModel Index()
        {
            var todoItems = new TodoListViewModel
            {
                todoList = _dbInteractor.GetAll().ToList()
                
            };
            return todoItems;
        }
        public TodoListViewModel get_all_items()
        {
            TodoListViewModel allItems = new TodoListViewModel
            {
                todoList = _dbInteractor.GetAll().ToList()
            };
            return allItems;
        }

        public Response post_update(Request request)
        {
            return new Response();
        }
    }
    public class Request { }
    public class Response { }
}