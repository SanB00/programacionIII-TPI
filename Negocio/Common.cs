using System.Linq;
using System.Text.RegularExpressions;

namespace Utils {
    public class Common {
        public const int MIN_CHARS_TEXTO = 3;
        public const int MAX_CHARS_TEXTO = 50;
        
        public static bool esUnNroValido(string texto) {
            return int.TryParse(texto, out int nroValidar) && nroValidar >= 0;
        }
                 
        public static bool estaElTextoDentroDelRango(string texto, int minChars = MIN_CHARS_TEXTO, int maxChars = MAX_CHARS_TEXTO) {
            if (string.IsNullOrEmpty(texto))
                return minChars == 0;

            int length = texto.Length;
            return length >= minChars && length <= maxChars;
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