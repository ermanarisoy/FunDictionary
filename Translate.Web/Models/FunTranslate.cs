using System.ComponentModel.DataAnnotations;

namespace Translate.Web.Models
{
    public class FunTranslate
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public string Translated { get; set; }
        public string Translation { get; set; }
    }
}
