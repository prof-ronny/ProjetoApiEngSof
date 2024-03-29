using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoApiEngSof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoUploadController : ControllerBase
    {
        private readonly string _uploadsDirectory;

        public FotoUploadController()
        {
            // Diretório onde as fotos serão armazenadas
            _uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            // Crie o diretório se não existir
            Directory.CreateDirectory(_uploadsDirectory);
        }

        [HttpPost("photo")]
        public async Task<IActionResult> UploadPhoto([FromForm] UploadPhotoRequest request)
        {
            if (request.Photo == null || request.Photo.Length == 0)
                return BadRequest("A foto não foi enviada.");

            try
            {
                // Gere um nome de arquivo único
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(request.Photo.FileName);
                var filePath = Path.Combine(_uploadsDirectory, fileName);

                // Salve o arquivo
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.Photo.CopyToAsync(stream);
                }

                // Retorne o JSON com nome, caminho e ID
                var response = new
                {
                    Id = Guid.NewGuid(),
                    Nome = fileName,
                    Caminho = "/Uploads/" + fileName
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao fazer upload da foto: {ex.Message}");
            }
        }
    }

    public class UploadPhotoRequest
    {
        public IFormFile Photo { get; set; }
    }
}
