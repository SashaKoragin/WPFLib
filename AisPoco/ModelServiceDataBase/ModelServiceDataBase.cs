
namespace AisPoco.ModelServiceDataBase
{
   public class ModelServiceDataBase
    {
        public int IdService { get; set; } // IdService (Primary key)
        public string ApiService { get; set; } // ApiService (length: 1024)
        public string ModelNameFileXml { get; set; } // ModelNameFileXml (length: 1024)
        public string TypeFileNameSpaceClass { get; set; } // TypeFileNameSpaceClass (length: 1024)
        public string FileNameDll { get; set; } // FileNameDll (length: 1024)
        public string FileInfoFile { get; set; } // FileInfoFile (length: 1024)
        public System.DateTime? DateCreate { get; set; } // DateCreate
    }
}
