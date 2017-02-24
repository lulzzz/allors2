﻿namespace Allors
{
    using Allors.Development.Repository.Tasks;

    class Program
    {
        static int Main(string[] args)
        {
            switch (args.Length)
            {
                case 0:
                    return Default();
                case 2:
                    return Generate.Execute(args[0], args[1]).ErrorOccured ? 1 : 0;
                default:
                    return 1;
            }
        }

        private static int Default()
        {
            var config = new System.Collections.Generic.Dictionary<string, string>()
                             {
                                { "Database/Templates/domain.cs.stg", "Domain/Generated" },
                                { "Database/Templates/uml.cs.stg", "Domain/Domain.Diagrams" },
                                { "Workspace/Csharp/Templates/uml.cs.stg", "Workspace/CSharp/Diagrams" },
                                { "Workspace/Csharp/Templates/meta.cs.stg", "Workspace/CSharp/Meta/Generated" },
                                { "Workspace/Csharp/Templates/domain.cs.stg", "Workspace/CSharp/Domain/Generated" },
                                { "Workspace/Typescript/Templates/meta.ts.stg", "Workspace/Typescript/Meta/src/meta/Generated" },
                             };

            foreach (var entry in config)
            {
                var log = Generate.Execute(entry.Key, entry.Value);
                if (log.ErrorOccured)
                {
                    return 1;
                }
            }

            return 0;
        }
    }
}