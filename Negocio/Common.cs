using System.Linq;
using System.Text.RegularExpressions;

namespace Utils {
    public class Common {
        public const int MIN_CHARS_TEXTO = 3;
        public const int MAX_CHARS_TEXTO = 50;
        public static string eliminarEspaciosDelTexto(string texto) {
            return Regex.Replace(texto.Trim(), @"\s+", " ");
        }
        public static bool esUnNroValido(string texto) {
            return int.TryParse(texto, out int nroValidar) && nroValidar >= 0;
        }
        public static bool esUnaFechaValida(string texto) {
            return System.DateTime.TryParse(texto, out _);
        }
        public static bool esUnNroValidoMayorACero(string texto) {
            return int.TryParse(texto, out int nroValidar) && nroValidar > 0; //texto.All(char.IsDigit)
        }
        public static bool esSoloLetras(string texto) {
            return texto.All(char.IsLetter);
        }
        public static bool esAlfanumerico(string texto) {
            return texto.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c));
        }
        public static bool estaElTextoDentroDelRango(string texto, int minChars = MIN_CHARS_TEXTO, int maxChars = MAX_CHARS_TEXTO) {
            if (string.IsNullOrEmpty(texto))
                return minChars == 0;

            int length = texto.Length;
            return length >= minChars && length <= maxChars;
        }

        public static string obtenerTextoPrimerLetraMayuscula(string texto) {
            if (string.IsNullOrEmpty(texto))
                return texto;

            return char.ToUpper(texto[0]) + texto.Substring(1).ToLower();
        }
        public static void mostrarMensajeEnAlerta(string mensaje, System.Web.UI.Page page) {
            string safeMessage = mensaje.Replace("'", "\\'").Replace("\n", "\\n");
            page.ClientScript.RegisterStartupScript(page.GetType(),
                "alert",
                $"alert('{safeMessage}');",
                true);
        }
    }
}