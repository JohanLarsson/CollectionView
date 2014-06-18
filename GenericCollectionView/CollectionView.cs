namespace GenericCollectionView
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Windows;
    using System.Windows.Data;

    public class CollectionView<T> : CollectionView, IEnumerable<T>, IWeakEventListener
    {
        public CollectionView(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public CollectionView(INotifyPropertyChanged source, Expression<Func<IEnumerable<T>>> prop)
            : base(prop.Compile().Invoke())
        {
            PropertyChangedEventManager.AddListener(source, this, ((MemberExpression)prop.Body).Member.Name);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.Cast<T>().GetEnumerator();
        }

        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            Refresh();
            return true;
        }
    }
}
