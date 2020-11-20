
namespace AisPoco.Ifns51.ToAis
{
    public class SrvToLoad
    {
        public string Tree
        {
            get;set;
        }

        public int IdTemplate
        {
            get; set;
        }

        public string[] Memo
        {
            get; set;
        }

        public string[] INN
        {
            get; set;
        }

        public string TreeExport
        {
            get; set;
        }

        public string TreeUpdate
        {
            get; set;
        }

        public string TreeFilter
        {
            get; set;
        }

        public TreeGrid TreeGrid
        {
            get; set;
        }

        public TreeDataArea TreeDataArea
        {
            get; set;
        }
    }
    public class TreeGrid
    {

        public string FullPathGrid
        {
            get; set;
        }

        public string GridToIndexParameter
        {
            get; set;
        }
    }

    public partial class TreeDataArea
    {

        public DataAreaParameters[] DataAreaParameters
        {
            get; set;
        }

        public string FullPathDataArea
        {
            get; set;
        }
    }

    public partial class DataAreaParameters
    {

        public string NameParameters
        {
            get; set;
        }


        public string FindNameMemo
        {
            get; set;
        }


        public string IndexParameters
        {
            get; set;
        }

        public string ParametersGrid
        {
            get; set;
        }
    }
}
