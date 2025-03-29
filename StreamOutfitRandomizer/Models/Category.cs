using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOutfitRandomizer.Models
{
    public class Category : INotifyPropertyChanging, INotifyPropertyChanged
    {

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public required string Name {
            get => _name;
            set
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(Name)));
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private int _numberOfItems;
        public required int NumberOfItems 
        {           
            get => _numberOfItems;
            set
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(NumberOfItems)));
                _numberOfItems = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfItems)));
            } 
        }

        private int _randomChoice;
        public required int RandomChoice 
        {
            get => _randomChoice;
            set
            {
                PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(nameof(RandomChoice)));
                _randomChoice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RandomChoice)));
            }
        }
    }
}
