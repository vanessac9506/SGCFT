namespace SGCFT.Utilitario
{
    public static class HelperURL
    {
        public static string ToURLCustomizada(this string conteudo)
        {
            if (string.IsNullOrEmpty(conteudo))
                return null;

            if (string.IsNullOrWhiteSpace(conteudo))
                return null;

            conteudo = conteudo.Replace("&", "-");
            conteudo = conteudo.Trim();
            conteudo = conteudo.Trim('-');
            conteudo = conteudo.ToLower();
            char[] chars = @"$%@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            conteudo = conteudo.Replace(".", "-");
            //Replace Characters especiais
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (conteudo.Contains(strChar))
                {
                    conteudo = conteudo.Replace(strChar, string.Empty);
                }
            }

            conteudo = conteudo.Replace("#", "sharp");

            conteudo = conteudo.Replace(" ", "-");
            conteudo = conteudo.Replace("--", "-");
            conteudo = conteudo.Replace("---", "-");
            conteudo = conteudo.Replace("----", "-");
            conteudo = conteudo.Replace("-----", "-");
            conteudo = conteudo.Replace("----", "-");
            conteudo = conteudo.Replace("---", "-");
            conteudo = conteudo.Replace("--", "-");
            conteudo = conteudo.Trim();
            conteudo = conteudo.Trim('-');
            // acento agudo
            conteudo = conteudo.Replace("á", "a");
            conteudo = conteudo.Replace("é", "e");
            conteudo = conteudo.Replace("í", "i");
            conteudo = conteudo.Replace("ó", "o");
            conteudo = conteudo.Replace("ú", "u");
            conteudo = conteudo.Replace("Á", "A");
            conteudo = conteudo.Replace("É", "E");
            conteudo = conteudo.Replace("Í", "I");
            conteudo = conteudo.Replace("Ó", "O");
            conteudo = conteudo.Replace("Ú", "U");
            // acento ci
            conteudo = conteudo.Replace("â", "a");
            conteudo = conteudo.Replace("ê", "e");
            conteudo = conteudo.Replace("î", "i");
            conteudo = conteudo.Replace("ô", "o");
            conteudo = conteudo.Replace("û", "u");
            conteudo = conteudo.Replace("Â", "A");
            conteudo = conteudo.Replace("Ê", "E");
            conteudo = conteudo.Replace("Î", "I");
            conteudo = conteudo.Replace("Ô", "O");
            conteudo = conteudo.Replace("Û", "U");
            // til
            conteudo = conteudo.Replace("ã", "a");
            conteudo = conteudo.Replace("õ", "o");
            conteudo = conteudo.Replace("Ã", "A");
            conteudo = conteudo.Replace("Õ", "O");
            // ce-cedilha
            conteudo = conteudo.Replace("ç", "c");
            conteudo = conteudo.Replace("Ç", "C");
            // trema
            conteudo = conteudo.Replace("ü", "u");
            conteudo = conteudo.Replace("Ü", "U");
            // crase
            conteudo = conteudo.Replace("à", "a");
            conteudo = conteudo.Replace("è", "e");
            conteudo = conteudo.Replace("ì", "i");
            conteudo = conteudo.Replace("ò", "o");
            conteudo = conteudo.Replace("ù", "u");
            conteudo = conteudo.Replace("À", "A");
            conteudo = conteudo.Replace("È", "E");
            conteudo = conteudo.Replace("Ì", "I");
            conteudo = conteudo.Replace("Ò", "O");
            conteudo = conteudo.Replace("Ù", "U");
            conteudo = conteudo.Replace(" ", "-");
            conteudo = conteudo.Replace(",", "-");
            conteudo = conteudo.Replace("'", "-");
            conteudo = conteudo.Replace("/", "");
            conteudo = conteudo.Replace("--", "");
            conteudo = conteudo.Replace("---", "");
            
            return conteudo;
        }

    }
}
