using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Prism.Commands;


namespace QueueApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Queue<string> _queue;

        public MainViewModel()
        {
            _queue = new Queue<string>();
            EnqueueCommand = new RelayCommand(Enqueue);
            DequeueCommand = new RelayCommand(Dequeue, CanDequeue);
            ClearCommand = new RelayCommand(Clear);
        }

        public string NewItem { get; set; }

        public IEnumerable<string> Items => (IEnumerable<string>)_queue;

        public string CurrentElement => _queue.CurrentElement;

        public int Count => _queue.Count;

        public bool IsEmpty => _queue.IsEmpty;

        public ICommand EnqueueCommand { get; }
        public ICommand DequeueCommand { get; }
        public ICommand ClearCommand { get; }

        private void Enqueue()
        {
            _queue.Enqueue(NewItem);
            NewItem = "";
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(CurrentElement));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        private void Dequeue()
        {
            _queue.Dequeue();
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(CurrentElement));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        private void Clear()
        {
            _queue.Clear();
            NewItem = "";
            OnPropertyChanged(nameof(Items));
            OnPropertyChanged(nameof(CurrentElement));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        private bool CanDequeue()
        {
            return !IsEmpty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
