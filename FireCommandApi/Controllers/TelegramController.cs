using Microsoft.AspNetCore.Mvc;

namespace FireCommandApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private IConfiguration configuration;

        public TelegramController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> SendTelegramMessage(bool activar)
        {
            string botToken = this.configuration["TelegramBot:Token"];
            string chatId = this.configuration["TelegramBot:ChatId"];

            if (string.IsNullOrEmpty(botToken) || string.IsNullOrEmpty(chatId))
            {
                return BadRequest("Credenciales incorrectas");
            }

            string mensaje;

            if (activar)
            {
                mensaje = "🚨 *ALERTA DE PROTECCIÓN CIVIL* 🚨\n\n" +
                          "*NIVEL DE GRAVEDAD:* EXTREMO\n" +
                          "*EMISOR:* Centro de Coordinación Operativa (CECOP) - FireCommand\n\n" +
                          "Se ha declarado una emergencia de nivel crítico en su área. Se requiere acción preventiva inmediata por parte de la población civil.\n\n" +
                          "*INSTRUCCIONES DE SEGURIDAD:*\n" +
                          "• Busque refugio en un edificio cerrado inmediatamente.\n" +
                          "• Cierre puertas, ventanas y desconecte sistemas de ventilación.\n" +
                          "• Evite desplazamientos para garantizar el acceso a los vehículos de intervención.\n" +
                          "• No sature las líneas telefónicas. Use el 112 ÚNICAMENTE para emergencias vitales.\n\n" +
                          "Permanezca atento a futuras actualizaciones a través de este canal oficial.";
            }
            else
            {
                mensaje = "✅ *AVISO OFICIAL: DESACTIVACIÓN DE ALERTA* ✅\n\n" +
                          "*ESTADO:* EMERGENCIA CONTROLADA / FASE DE MITIGACIÓN\n" +
                          "*EMISOR:* Centro de Coordinación Operativa (CECOP) - FireCommand\n\n" +
                          "El incidente que motivó la alerta ha sido neutralizado y asegurado por los equipos de intervención rápida. Los parámetros de riesgo han vuelto a niveles seguros.\n\n" +
                          "*SITUACIÓN ACTUAL:*\n" +
                          "• Se levanta la orden de confinamiento preventivo.\n" +
                          "• Quedan restablecidas las vías de comunicación y el tránsito habitual.\n" +
                          "• Es posible que aún perciba presencia de equipos de remate en la zona.\n\n" +
                          "Agradecemos la estricta colaboración ciudadana durante el despliegue operativo. Fin de la transmisión.";
            }

            string url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={System.Uri.EscapeDataString(mensaje)}&parse_mode=Markdown";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    await client.GetAsync(url);
                }
                return Ok();
            }
            catch
            {
                return BadRequest("Error al enviar el mensaje");
            }

        }
    }
}