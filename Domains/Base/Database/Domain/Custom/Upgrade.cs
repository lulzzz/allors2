namespace Allors
{
    using System;
    using System.IO;

    public class Upgrade
    {
        private readonly ISession session;

        private DirectoryInfo DataPath;

        public Upgrade(ISession session, DirectoryInfo dataPath)
        {
            this.session = session;
            this.DataPath = dataPath;
        }

        public void Execute()
        {
        }
        
        private void Derive(Extent extent)
        {
            var derivation = new Domain.NonLogging.Derivation(this.session, extent.ToArray());
            var validation = derivation.Derive();
            if (validation.HasErrors)
            {
                foreach (var error in validation.Errors)
                {
                    Console.WriteLine(error.Message);
                }

                throw new Exception("Derivation Error");
            }
        }
    }
}