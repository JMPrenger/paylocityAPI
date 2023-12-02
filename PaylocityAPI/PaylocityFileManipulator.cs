using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace PaylocityAPI
{
    public static class PaylocityFileManipulator
    {
        public static async Task<List<PaylocityDto>> ReadFile()
        {
            TextReader? reader = null;
            List<PaylocityDto> objectList = null;
            try 
            {
                if (File.Exists("ObjectList.txt"))
                {
                    reader = new StreamReader("ObjectList.txt");
                    var fileContents = await reader.ReadToEndAsync();
                       
                    if (!string.IsNullOrEmpty(fileContents))
                    {
                        objectList = JsonSerializer.Deserialize<List<PaylocityDto>>(fileContents);
                    }
                    reader.Close();
                }

                objectList ??= [];

                return objectList;
            }
            catch
            {
                reader?.Close();
                throw;
            }
        }

        public static async Task WriteObjectToFile(List<PaylocityDto> dtoList)
        {
            TextWriter? writer = null;
            try
            {
                string dtoText = JsonSerializer.Serialize(dtoList);
                writer = new StreamWriter("ObjectList.txt", false);
                await writer.WriteAsync(dtoText);
                writer.Close();
            }
            catch
            {
                writer?.Close();
                throw;
            }
        }
    }
}
