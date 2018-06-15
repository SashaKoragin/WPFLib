using LibaryXMLAutoModelXmlSql.Model.FaceError;
using SyteIfns.PostResponse;

namespace SyteIfns.Models.PostRestAplication.ModelFaceError
{
    public class ReaderAnsvwer
    {
        public Face Face { get; private set; }
        public string AddFace { get; private set; }
        internal ReaderAnsvwer()
        {
            RefreshModel();
        }

        public void RefreshModel()
        {
            Response response = new Response();
            Face = response.FaceRestError();
        }


        public void AddFaces(int? nold, int? nnew)
        {
            var addface = new PostRestAdd();
            AddFace = addface.FaceSelect(nold,nnew);
            RefreshModel();
        }

        public void Deleteface(int? id)
        {
         //  Face.FaceError.Id Думаю ошибочно нужно параметр кидать на Rest Приложение там на сервере обновит и вернет нормальную модель. Вопрос что делать с моделями их както много!!!!
        }
    }
}