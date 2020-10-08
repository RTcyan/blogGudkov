using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogGudkov.ViewModels.Blog
{
    /// <summary>
    /// Модель поста
    /// </summary>
    public class BlogPostItemViewModel
    {
        /// <summary>
        /// Пользователь, который создал сущность
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Дата и время создания поста
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Заголовок поста
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        public string Data { get; set; }
    }
}
