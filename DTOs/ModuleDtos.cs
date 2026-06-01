using System.ComponentModel.DataAnnotations;

namespace anisa_lms.DTOs
{
    public class ModuleBaseDto
    {
        [MinLength(3, ErrorMessage = "Title must be atleast 3 chars long")]
        public string Title { get; set; } = "";
        [Required]
        public string Content { get; set; } = "";
        public int OrderIndex { get; set; }
    }

    public class CreateModuleDto : ModuleBaseDto
    {
        [Required]
        public Guid CourseId { get; set; }
    }

    public class UpdateModuleDto : ModuleBaseDto { }

    public class ModuleDto : ModuleBaseDto {
        public Guid Id { get; set; }
    }
}
