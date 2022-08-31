using System.ComponentModel.DataAnnotations;

namespace Blog.Web.Models
{
    public class PostCreateViewModel
    {
      

        [StringLength(100, ErrorMessage = "İsim alanı en fazla 20 karakter olabilir")]
        [Required(ErrorMessage = "İsim alanı boş olamaz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Özet alanı boş olamaz")]
        [StringLength(450, ErrorMessage = "İsim alanı en fazla 20 karakter olabilir")]
        public string Summary { get; set; }


        public string PostBanner { get; set; }

        [Required(ErrorMessage = "İçerik alanı boş olamaz")]
        public string PostContents { get; set; }

        public bool IsPublish { get; set; } = true;

        [Required(ErrorMessage = "Lütfen kategori seçiniz")]
        public int CategoryId { get; set; }
        public string UserId { get; set; } = "";
    }
}
