using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogGudkov.ViewModels.Blog
{
    /// <summary>
    /// Создание нового поста
    /// </summary>
    public class NewPostViewModel
    {
        /// <summary>
        /// Заколовок поста
        /// </summary>
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        /// <summary>
        /// Данные поста
        /// </summary>
        [Required]
        [Display(Name = "Данные поста")]
        public string Data { get; set; }

    }
}
