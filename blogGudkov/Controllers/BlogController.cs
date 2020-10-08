using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogForStudents.Security.Extensions;
using blogGudkov.Domain.DB;
using blogGudkov.Domain.Model;
using blogGudkov.ViewModels.Blog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogGudkov.Controllers
{
    /// <summary>
    /// Контроллер страницы блога
    /// </summary>
    public class BlogController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext ?? throw new ArgumentNullException(nameof(blogDbContext));
        }

        /// <summary>
        /// Метод открывает страницу с добавлением поста
        /// </summary>
        /// <returns>Возвращает страницу для добавления поста</returns>
        [HttpGet]
        public IActionResult AddPost()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(NewPostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = this.GetAuthorizedUser();

            var post = new BlogPost
            {
                Created = DateTime.Now,
                Data = model.Data,
                Title = model.Title,
                Owner = user.Employee
            };

            _blogDbContext.BlogPosts.Add(post);

            _blogDbContext.SaveChanges();

            return View();
        }

        /// <summary>
        /// Возвращает Index страницу для Blog контроллера
        /// </summary>
        /// <returns>Страница Index</returns>
        public IActionResult Index()
        {
            var posts = _blogDbContext.BlogPosts
                .Select(x => new BlogPostItemViewModel
                {
                    Author = x.Owner.FullName,
                    Created = x.Created,
                    Data = x.Data,
                    Title = x.Title,
                }).OrderByDescending(x => x.Created);

            return View(posts);
        }

        /// <summary>
        /// Возвращает страницу с постами авторизованного пользователя
        /// </summary>
        /// <returns>Страница с постами авторизованного пользователя</returns>
        [HttpGet]
        [Authorize]
        public IActionResult UserPosts()
        {
            var user = this.GetAuthorizedUser();

            var posts = _blogDbContext.BlogPosts
                .Where(x => x.Owner.Id == user.Employee.Id)
                .Select(x => new BlogPostItemViewModel
                {
                    Author = x.Owner.FullName,
                    Created = x.Created,
                    Data = x.Data,
                    Title = x.Title,
                })
                .OrderByDescending(x => x.Created);

            return View(posts);
        }
    }
}
