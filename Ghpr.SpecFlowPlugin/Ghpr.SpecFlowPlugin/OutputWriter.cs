using System.IO;

namespace Ghpr.SpecFlowPlugin
{
    public static class OutputWriter
    {
        private static StringWriter _sw;

        static OutputWriter()
        {
            _sw = new StringWriter();
        }

        public static void Write(string s)
        {
            _sw.Write(s);
        }
    }
}