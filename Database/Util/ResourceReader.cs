using System;
using System.IO;
using System.Reflection;

namespace DbMigrations.Database.Util
{
    public class ResourceReader
    {
        internal string ReadResource(string resourceName)
        {
            var assembly =Assembly.GetExecutingAssembly();

            string name=  assembly.GetName().Name+".Resources."+resourceName;

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if(stream == null)
                {
            
                    string[] resources =  assembly.GetManifestResourceNames();
                    throw new ArgumentException($"name {name} not found in "+string.Join("",resources));

                }
                using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }       
            }
        }
    }
}