using Azure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Training_Luna_Project.Data.Models
{
    [Keyless]
    public class FormField
    {
        public int FormModelsId { get; set; }
        public FormModel FormModel { get; set; } = null!;
        public int FieldsId { get; set; }
        public Field Field { get; set; } = null!;
    }
}
