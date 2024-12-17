using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePro.Data.Seeding.DataTranferObjects
{
    public class ImportServiceDto
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;
    }
}
