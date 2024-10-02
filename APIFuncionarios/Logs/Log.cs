namespace APIFuncionarios.Logs
{
    public static class Log
    {
        public static void LogToFile(string title, string LogMessage)
        {
            string fileName = DateTime.Now.ToString("ddMMyyyy") + ".txt";

            StreamWriter swLog;

            if (File.Exists(fileName))
            {
                swLog = File.AppendText(fileName);
            }
            else
            {
                swLog = new StreamWriter(fileName);
            }

            swLog.WriteLine("Log:");
            swLog.WriteLine(DateTime.Now);

            swLog.WriteLine("Título da Mensagem: {0}", title);
            swLog.WriteLine("Mensagem: {0}", LogMessage);

            swLog.WriteLine("--------------------------");
            swLog.WriteLine("");
            swLog.Close();

        }
    }
}
