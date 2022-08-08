using System.ComponentModel.DataAnnotations;

namespace CreatingAMovieLab.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }

        public string Rating { get; set; }
        public int RottenTomatoScore { get; set; }  
    }

    public class ApiResponse<T>
    {
        public bool succeeded { get; set; }
        public int errorCode { get; set; }
        public string errorMessage { get; set; }
        public T data { get; set; }
    }
}
