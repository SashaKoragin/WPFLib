using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Abstractions;
using ReactiveUI.Validation.Contexts;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;

namespace React.Model
{
   public class Model : ReactiveObject, ISupportsValidation
    {
        private int _count;

        public int Count
        {
            get { return _count; }
            set { this.RaiseAndSetIfChanged(ref _count, value); }
        }



        private string _firstname;
        [Reactive]
        public string FirstName
        {
            get { return _firstname; }
            set { this.RaiseAndSetIfChanged(ref _firstname, value); }
        }

        private string _lastName;
        [Reactive]
        public string LastName
        {
            get { return _lastName; }
            set { this.RaiseAndSetIfChanged(ref _lastName, value); }
        }

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            private set { this.RaiseAndSetIfChanged(ref _fullName, value); }
        }

        private string _seath = null;

        public string Seath
        {
            get { return _seath; }
            private set { this.RaiseAndSetIfChanged(ref _seath, value); }
        }

        //private readonly ObservableAsPropertyHelper<List<string>> _list;
        //public List<string> List => _list.Value;

        public ObservableCollection<TestClass> List { get; set; } = new ObservableCollection<TestClass>();


        public ReactiveCommand<Unit, Unit> Save { get; }


        /// <summary>
        /// Это жесткий паттерн мало иформации по нему и примеров если есть то очень сложны
        /// </summary>
        public Model()
        {
            //Подпись на наблюдаемое событие Полного именини при изменении LastName и FirstName
            //Очень странно что в таком ключе не работает
            //this.WhenAnyValue(vm => vm.WhenAnyValue(v => v.FirstName, v => v.LastName).Subscribe(x => UpdateFullName())
            //                 ,vm => vm.WhenAnyValue(m => m.FullName).Subscribe(x => List.Add(new TestClass() {FullName = FullName})));

            //А по отдельности работае
            //WhenAnyValue наблюдатель при изменении FirstName и LastName обновляется FullName
          
            //Валидация не понятна это из справки она избыточна в разных источниках по разному
            this.ValidationRule(
                           viewModel => viewModel.LastName,
                           name => !string.IsNullOrWhiteSpace(name),
                           "Не ввелденно имя");
            this.ValidationRule(
                viewModel => viewModel.FirstName,
                name => !string.IsNullOrWhiteSpace(name),
                           "Не ввелденна фамилия");



            var nameAndAgeValid = this.WhenAnyValue(x => x.FirstName, x => x.LastName, (lastname, firstname) => new { LastName = lastname, FirstName = firstname })
                                   .Select(x => !string.IsNullOrEmpty(x.LastName) && !string.IsNullOrEmpty(x.FirstName));

            ComplexRule = this.ValidationRule(_ => nameAndAgeValid,(vm, state) => !state ? "Не прошли валидацию" : string.Empty);
            var canSave = this.IsValid();
            var Save = ReactiveCommand.CreateFromTask(async  ()=>
            {
                var item = new TestClass();
                item.FullName = LastName;
                List.Add(item);
            }, canSave);



            //Вот эта часть впринципе работает 
            this.WhenAnyValue(vm => vm.FirstName, vm => vm.LastName).Subscribe(x => FullName = $"{LastName}{FirstName}");

            this.WhenAnyValue(vm => vm.FullName).Subscribe(x =>
            {
                List.Add(new TestClass() { FullName = FullName });
            });
            //Поиск по точному совпадению
            this.WhenAnyValue(v => v.Seath).Subscribe(s =>
            {
             Count = List.ToObservableChangeSet().Filter(t => t.FullName == Seath).AsObservableList().Count;
            });
        }
        public ValidationHelper ComplexRule { get; }

        public ValidationContext ValidationContext { get; } = new ValidationContext();
    }

    public class TestClass
    {
        public string FullName { get; set; }
    }
}
