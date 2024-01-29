using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MessageData { get; set; }

        public int RandomNumber { get; set; }

    }
}
