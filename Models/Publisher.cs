using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farcas_Razvan_Lab2_incercareaNR2.Models
{
	public class Publisher
    {
		public int ID { get; set; }
		[Display(Name = "Publisher")]
		public string PublisherName { get; set; }
		public ICollection<Book>? Books { get; set; }
	}
}
