using ViewModelLib.ModelTestAutoit.PublicModel.SelectBranch;

namespace AutomatAis3Full.Form.AddResours.SelectBranch
{
   public class SelectBranch
    {
        /// <summary>
        /// Вспомогательный метод для добавления веток для выбора режима пользователя
        /// Что обрабатывать.
        /// </summary>
        /// <returns></returns>
        public Branch AddBranhc()
        {
            Branch branch = new Branch();
            branch.BranchSelect.Add(new Branch() {NameBranch = "Земля с Имуществом", NumBranch = 100});
            branch.BranchSelect.Add(new Branch() { NameBranch = "Транспорт", NumBranch = 101 });
            return branch;
        }
    }
}