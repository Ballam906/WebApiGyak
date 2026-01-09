namespace Balla_Milán_backend.Models.Dtos
{
    public class bookHozzaadasDto
    {
        public string Title { get; set; } = null!;

        public DateTime PublishDate { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }

        public int CategoryId { get; set; }
    }
}
