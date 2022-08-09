using System;

namespace Homework01
{
    internal class Response
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }

        public override string ToString()
        {
            string nl = Environment.NewLine;
            return $"{userId}{nl}{id}{nl}{title}{nl}{body}";
        }
    }
}
