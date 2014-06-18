namespace GenericCollectionView
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Data;
    using Annotations;

    public class Vm : INotifyPropertyChanged
    {
        private readonly List<Person> _persons;
        public Vm()
        {
            _persons = new List<Person>
            {
                new Person("Johan"),
                new Person("Sean")
            };
            PersonsGenericView = new CollectionView<Person>(this, () => Persons);

            //PropertyChangedEventManager.AddListener(this, PersonsGenericView, "Persons");
            PersonsView = new CollectionView(Persons);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IEnumerable<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons.Clear();
                _persons.AddRange(value);
                PersonsView.Refresh();
                OnPropertyChanged();
            }
        }

        public CollectionView<Person> PersonsGenericView { get; private set; }

        public CollectionView PersonsView { get; private set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
